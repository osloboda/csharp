using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab2
{
    public partial class Form1 : Form
    {
        Mutex objMutex = new Mutex();
        int range = 40;
        int sp = 2;
        Int64 none_count = 0;
        bool none = true;
        int num = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            this.timer1.Start();
            timer1.Tick += timer1_Tick;
            this.button1.MouseEnter += Button1_MouseEnter;
            this.MouseMove += Form_MouseMove;

            this.button1.Click += button2_Click;
        }

        private void Button2_OnlyFocus(object sender, EventArgs e)
        {
            button2.Focus();
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            Random rand = new Random();
            int rndX = button1.Location.X * (1 / rand.Next(2, 5));
            int rndY = button1.Location.Y * (1 / rand.Next(2, 5));


            button1.Location = new Point(rndX, rndY);
        }

        string text = "Press 'OK' button";
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (none)
            {
                this.Text = "";
            }
            else
            {
                this.Text = text;
            }

            none = !none;
            num++;

            if (num == 8)
            {
                this.timer1.Tick -= timer1_Tick;
                this.timer1.Stop();
            }

        }

        private void End_Tick(object sender, EventArgs e)
        {
            if (none)
            {
                this.Text = "";
            }
            else
            {
                this.Text = "Button 'OK' cannot be pressed anymore";
            }

            none = !none;
            num++;

            if (num == 8)
            {
                this.timer1.Tick -= End_Tick;
                this.timer1.Stop();
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {

            int pos1X = this.button1.Location.X;
            int pos1Y = this.button1.Location.Y;
            int but1W = this.button1.Width;
            int but1H = this.button1.Height;

            int pos2X = this.button2.Location.X;
            int pos2Y = this.button2.Location.Y;

            int pXbW = pos1X + but1W;
            int pYbH = pos1Y + but1H;


            if (e.X >= pos1X - range && e.X < pos1X && e.Y >= pos1Y - range && e.Y < pos1Y)
            {
                this.button1.Location = new Point(pos1X + sp, pos1Y + sp);
                none_count++;
                if (none_count % 35 == 0)
                    SizeChange(-3, -1);

            }
            else if (e.X > pos1X && e.X < pXbW && e.Y >= pos1Y - range && e.Y < pos1Y)
            {
                this.button1.Location = new Point(pos1X, pos1Y + sp);
                none_count++;
                if (none_count % 35 == 0)
                    SizeChange(0, -1);
            }
            else if (e.X > pXbW && e.X < pXbW + range && e.Y >= pos1Y - range && e.Y < pos1Y)
            {
                this.button1.Location = new Point(pos1X - sp, pos1Y + sp);
                none_count++;
                if (none_count % 35 == 0)
                    SizeChange(-3, -1);
            }
            else if (e.X > pXbW && e.X < pXbW + range && e.Y >= pos1Y && e.Y < pYbH)
            {
                this.button1.Location = new Point(pos1X - sp, pos1Y);
                none_count++;
                if (none_count % 35 == 0)
                    SizeChange(-3);
            }
            else if (e.X > pXbW && e.X < pXbW + range && e.Y >= pYbH && e.Y < pYbH + range)
            {
                this.button1.Location = new Point(pos1X - sp, pos1Y - sp);
                none_count++;
                if (none_count % 35 == 0)
                    SizeChange(-3, -1);
            }
            else if (e.X > pos1X && e.X < pXbW && e.Y >= pYbH && e.Y < pYbH + range)
            {
                this.button1.Location = new Point(pos1X, pos1Y - sp);
                none_count++;
                if (none_count % 35 == 0)
                    SizeChange(0, -1);
            }
            else if (e.X > pos1X - range && e.X < pos1X && e.Y >= pYbH && e.Y < pYbH + range)
            {
                this.button1.Location = new Point(pos1X + sp, pos1Y - sp);
                none_count++;
                if (none_count % 35 == 0)
                    SizeChange(-3, -1);
            }
            else if (e.X > pos1X - range && e.X < pos1X && e.Y >= pos1Y && e.Y < pYbH)
            {
                this.button1.Location = new Point(pos1X + sp, pos1Y);
                none_count++;
                if (none_count % 35 == 0)
                    SizeChange(-3);
            }
            else if (pos1X >= pos2X && pos1Y >= pos2Y && pos1X <= pos2X + but1W && pos1Y <= pos2Y + but1H)
            {
                this.button1.Location = new Point(pos1X / 2, pos1Y / 2);
            }

            if (button1.Width <= 0 || button1.Height <= 0)
            {
                button1.Dispose();
                num = 0;
                this.timer1.Tick += End_Tick;
                this.timer1.Start();


                none = true;
                num = 0;
                this.MouseMove -= Form_MouseMove;
            }

            if (pos1X <= 0)
            {
                this.button1.Location = new Point(pos1X + e.X + range, pos1Y);
            }
            else if (pos1Y <= 0)
            {
                this.button1.Location = new Point(pos1X, pos1Y + e.Y + range);
            }
            else if (pXbW >= this.ClientRectangle.Width)
            {
                this.button1.Location = new Point(pos1X - but1H - range - range, pos1Y);
            }
            else if (pYbH >= this.ClientRectangle.Height)
            {
                this.button1.Location = new Point(pos1X, pos1Y - but1H - range - range);
            }

            void SizeChange(int w = 0, int h = 0)
            {
                this.button1.Width += w;
                this.button1.Height += h;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
