using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LB2
{
	public class formapp : Form
	{
		private IContainer components = null;
		private TextBox txtBox;
		private CheckBox CheakBox1;
		private CheckBox CheakBox2;

		public string Company
		{
			get;
			set;
		} = "Osloboda Corp.";


		public string AppName
		{
			get;
			set;
		} = "LB2";


		public formapp()
		{
			InitializeComponent();
		}

		private void formapp_Load(object sender, EventArgs e)
		{
			LoadFromReg();
		}

		private void formapp_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveReg();
		}

		private void SaveXml()
		{
			Save o = new Save(base.Location, base.Size, txtBox.Text, new bool[2]
			{
				CheakBox1.Checked,
				CheakBox2.Checked
			});
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Save));
			if (!File.Exists("data.xml"))
			{
				File.Create("data.xml");
			}
			using (Stream stream = File.Open("data.xml", FileMode.Truncate, FileAccess.Write, FileShare.None))
			{
				xmlSerializer.Serialize(stream, o);
			}
		}

		private void LoadFromXml()
		{
			using (Stream stream = File.Open("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(Save));
				Save save = (Save)xmlSerializer.Deserialize(stream);
				base.Location = save.Position;
				base.Size = save.Size;
				txtBox.Text = save.TextBox;
				CheakBox1.Checked = save.CheckBox[0];
				CheakBox2.Checked = save.CheckBox[1];
			}
		}

		private void SaveReg()
		{
			RegistryKey registryKey = null;
			try
			{
				registryKey = Registry.CurrentUser.OpenSubKey($"Software\\{Company}\\{AppName}\\", writable: true);
				if (registryKey == null)
				{
					throw new NullReferenceException();
				}
			}
			catch (NullReferenceException)
			{
				registryKey = Registry.CurrentUser.CreateSubKey($"Software\\{Company}\\{AppName}\\");
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message, ex2.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			try
			{
				registryKey.SetValue("Pos_x", base.Location.X, RegistryValueKind.DWord);
				registryKey.SetValue("Pos_y", base.Location.Y, RegistryValueKind.DWord);
				registryKey.SetValue("Width", base.Width, RegistryValueKind.DWord);
				registryKey.SetValue("Height", base.Height, RegistryValueKind.DWord);
				registryKey.SetValue("Text", txtBox.Text, RegistryValueKind.String);
				registryKey.SetValue("Check 1", CheakBox1.Checked.ToString(), RegistryValueKind.String);
				registryKey.SetValue("Check 2", CheakBox2.Checked.ToString(), RegistryValueKind.String);
			}
			catch (Exception ex3)
			{
				MessageBox.Show(ex3.Message, ex3.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void LoadFromReg()
		{
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey($"Software\\{Company}\\{AppName}\\");
				base.Location = new Point((int)registryKey.GetValue("Pos_x"), (int)registryKey.GetValue("Pos_y"));
				base.Size = new Size((int)registryKey.GetValue("Width"), (int)registryKey.GetValue("Height"));
				txtBox.Text = (string)registryKey.GetValue("Text");
				CheakBox1.Checked = bool.Parse((string)registryKey.GetValue("Check 1"));
				CheakBox2.Checked = bool.Parse((string)registryKey.GetValue("Check 2"));
			}
			catch (NullReferenceException ex)
			{
				MessageBox.Show("There is no saved data", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message, ex2.Source, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.txtBox = new System.Windows.Forms.TextBox();
            this.CheakBox1 = new System.Windows.Forms.CheckBox();
            this.CheakBox2 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();

            this.txtBox.Location = new System.Drawing.Point(9, 10);
            this.txtBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtBox.Name = "TextBox";
            this.txtBox.Size = new System.Drawing.Size(152, 20);
            this.txtBox.TabIndex = 0;

            this.CheakBox1.AutoSize = true;
            this.CheakBox1.Location = new System.Drawing.Point(9, 32);
            this.CheakBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheakBox1.Name = "CheakBox1";
            this.CheakBox1.Size = new System.Drawing.Size(80, 17);
            this.CheakBox1.TabIndex = 1;
            this.CheakBox1.Text = "Check 1";
            this.CheakBox1.UseVisualStyleBackColor = true;
            this.CheakBox1.CheckedChanged += new System.EventHandler(this.CheakBox1_CheckedChanged);

            this.CheakBox2.AutoSize = true;
            this.CheakBox2.Location = new System.Drawing.Point(87, 32);
            this.CheakBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CheakBox2.Name = "CheakBox2";
            this.CheakBox2.Size = new System.Drawing.Size(80, 17);
            this.CheakBox2.TabIndex = 2;
            this.CheakBox2.Text = "Check 2";
            this.CheakBox2.UseVisualStyleBackColor = true;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 72);
            this.Controls.Add(this.CheakBox2);
            this.Controls.Add(this.CheakBox1);
            this.Controls.Add(this.txtBox);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Formapp";
            this.Text = "Слободянюк";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formapp_FormClosing);
            this.Load += new System.EventHandler(this.formapp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private void CheakBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
