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
    public partial class MainMenuForm : Form
    {
        global g = new global();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            AddDataForm mnfrm = new AddDataForm();
            mnfrm.ShowInTaskbar = false;
            mnfrm.FormBorderStyle = FormBorderStyle.None;
            mnfrm.ControlBox = false;
            mnfrm.TopLevel = false;
            mnfrm.Text = "";
            mnfrm.Visible = true;
            this.splitContainer1.Panel2.Controls.Add(mnfrm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2.Controls.Clear();
            AccessDataForm mnfrm1 = new AccessDataForm();
            mnfrm1.ShowInTaskbar = false;
            mnfrm1.FormBorderStyle = FormBorderStyle.None;
            mnfrm1.ControlBox = false;
            mnfrm1.TopLevel = false;
            mnfrm1.Text = "";
            mnfrm1.Visible = true;
            this.splitContainer1.Panel2.Controls.Add(mnfrm1);
        }

  
    }
}
