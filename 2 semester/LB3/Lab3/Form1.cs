using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LB3
{
    public partial class Form1 : Form
    {

        Button[] buttons = new Button[16];
        Random rand = new Random();
        List<int> numbers = new List<int>();
        Button ranbutton;
        int num = 0;
        int column = 0;
        int joJo = 1;

        public Form1()
        {
            InitializeComponent();
            num = 1;
            foreach (Button button in this.buttons)
            {
                numbers.Add(num++);
            }

            for (int i = 1; i < buttons.Length + 1; i++)
            {
                num = rand.Next(numbers.Count - 1);

                this.ranbutton = new Button();
                this.ranbutton.Size = new Size(60, 30);
                this.ranbutton.Location = new Point(column * ranbutton.Size.Width + 60, (i - 1) % 4 * ranbutton.Size.Height + 10);
                this.ranbutton.Name = "Num_Button";
                this.ranbutton.Text = numbers[num].ToString();

                this.buttons[i - 1] = this.ranbutton;
                this.tabPage2.Controls.Add(buttons[i - 1]);

                numbers.RemoveAt(num);
                if (i % 4 == 0)
                {
                    column++;
                }
            }


        }

        private void Next_Buttons()
        {

            num = 1;

            foreach (Button button in buttons)
            {
                numbers.Add(num++);
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].Visible == false)
                {
                    numbers.Remove(Convert.ToInt32(buttons[i].Text));
                }
            }

            for (int i = 1; i < buttons.Length + 1; i++)
            {
                if (numbers.Count > 0)
                {
                    num = rand.Next(numbers.Count - 1);
                }


                if (this.buttons[i - 1].Visible)
                {
                    this.buttons[i - 1].Text = numbers[num].ToString();
                    numbers.RemoveAt(num);
                }

            }
        }

        private void New_Buttons()
        {

            num = 1;

            foreach (Button button in buttons)
            {
                numbers.Add(num++);
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Visible = true;
            }

            for (int i = 1; i < buttons.Length + 1; i++)
            {

                num = rand.Next(numbers.Count - 1);

                this.buttons[i - 1].Text = numbers[num].ToString();
                numbers.RemoveAt(num);

            }

            joJo = 1;
        }

        private void button1_Add(object sender, EventArgs e)
        {
            if (this.textBox1.Text != "")
            {
                this.comboBox1.Items.Add(this.textBox1.Text);
                this.textBox1.Text = "";
            }
        }

        private void button2_Delete(object sender, EventArgs e)
        {


            if (this.textBox1.Text != "")
            {
                this.comboBox1.Items.Remove(this.textBox1.Text);
                this.textBox1.Text = "";
            }
            else
            {
                if (this.comboBox1.Items.Count != 0)
                {
                    this.comboBox1.Items.RemoveAt(this.comboBox1.Items.Count - 1);
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

