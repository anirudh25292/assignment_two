using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZooAnalyasis
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                MainMenuForm mmf = new MainMenuForm();
                mmf.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("UserName/Password Mismatch.....");
            }
        }
    }
}
