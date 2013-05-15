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
    public partial class AccessDataForm : Form
    {
        global g = new global();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt11 = new DataTable();
        DataTable dt111 = new DataTable();
        DataTable dt2111 = new DataTable();
        DataTable dtv = new DataTable();
        DataTable dtv1 = new DataTable();
        DataTable dtt = new DataTable();
        

        public AccessDataForm()
        {
            InitializeComponent();
            string strempid = "select AnimalId from AnimalDetails";
            dt = g.ExecuteReaderForTable(strempid, null);
            //DataRow row = dt.NewRow();
            //row["EmployeeID"] = "<-Please select EmployeeID->";
            //dt.Rows.InsertAt(row, 0);
            string str = Convert.ToString(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "AnimalId";
            comboBox1.ValueMember = "AnimalId";

            string strempid2 = "select AnimalId from AnimalDetails";
            dt2111 = g.ExecuteReaderForTable(strempid2, null);
            //DataRow row = dt.NewRow();
            //row["EmployeeID"] = "<-Please select EmployeeID->";
            //dt.Rows.InsertAt(row, 0);
            string str1 = Convert.ToString(dt2111);
            comboBox12.DataSource = dt2111;
            comboBox12.DisplayMember = "AnimalId";
            comboBox12.ValueMember = "AnimalId";


            string strempid1 = "select CageId from CageDetails";
            dt1 = g.ExecuteReaderForTable(strempid1, null);
            string str21 = Convert.ToString(dt1);
            comboBox4.DataSource = dt1;
            comboBox4.DisplayMember = "CageId";
            comboBox4.ValueMember = "CageId";

            string strempid111 = "select CageId from CageDetails";
            dt111 = g.ExecuteReaderForTable(strempid111, null);
            string str111 = Convert.ToString(dt111);
            comboBox15.DataSource = dt111;
            comboBox15.DisplayMember = "CageId";
            comboBox15.ValueMember = "CageId";


            string strempids = "select CageId from CageDetails";
            dtt = g.ExecuteReaderForTable(strempids, null);
            string strs = Convert.ToString(dtt);
            comboBox23.DataSource = dtt;
            comboBox23.DisplayMember = "CageId";
            comboBox23.ValueMember = "CageId";

            string strempidss = "select CageId from CageDetails";
            dtv = g.ExecuteReaderForTable(strempidss, null);
            string strss = Convert.ToString(dtv);
            comboBox30.DataSource = dtv;
            comboBox30.DisplayMember = "CageId";
            comboBox30.ValueMember = "CageId";

            string strempid11 = "select  MemberId from MemberTable";
            dt11 = g.ExecuteReaderForTable(strempid11, null);
            string strr = Convert.ToString(dt11);
            comboBox19.DataSource = dt11;
            comboBox19.DisplayMember = "MemberId";
            comboBox19.ValueMember = "MemberId";
        }

        private void button31_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                string addcage = "insert into AnimalAssign(AnimalId,AnimalType,AnimalName,CageId,CageLocation,CageType,CageSize,Animalsincage,CareBy)values('" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + comboBox5.Text + "','" + comboBox6.Text + "','" + comboBox7.Text + "','" + textBox17.Text + "','" + textBox16.Text + "')";
                int count = g.ExecuteNonQuery(addcage, null);
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                textBox16.Text = "";
                textBox17.Text = "";
                if (count != 0)
                    MessageBox.Show("AnimalAssign Details Saved Successfully..!");
                else
                    MessageBox.Show("AnimalAssign Details Not Saved....!!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Insert");
            }

            string Str = "select *  from AnimalAssign";
            dt = g.ExecuteReaderForTable(Str, null);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
        }
        
        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "" && comboBox7.Text != "" && textBox16.Text != "" && textBox17.Text != "")
                {

                    string strupd = "update AnimalAssign set AnimalType='" + comboBox2.Text + "' ,AnimalName='" + comboBox3.Text + "',CageId='" + comboBox4.Text + "',CageLocation='" + comboBox5.Text + "',CageType='" + comboBox6.Text + "',CageSize='" + comboBox6.Text + "',Animalsincage='" + textBox17.Text + "',CareBy='" + textBox16.Text + "' where AnimalId='" + comboBox1.Text + "'";
                    g.ExecuteNonQuery(strupd, null);
                    comboBox1.Text = "" ; 
                    comboBox2.Text = "" ; 
                    comboBox3.Text = "" ; 
                    comboBox4.Text = "" ; 
                    comboBox5.Text = "" ;
                    comboBox6.Text = "" ; 
                    comboBox7.Text = "" ; 
                    textBox16.Text = "" ; 
                    textBox17.Text = "";
                    MessageBox.Show("AnimalAssign Details Updated Succesfully");
                }
                else
                {
                    MessageBox.Show(" Input all the Details");
                }
                string Str = "select *  from AnimalAssign";
                dt = g.ExecuteReaderForTable(Str, null);
                dataGridView1.DataSource = dt;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToOrderColumns = false;
            }
            catch (Exception ex) { }
        }

       

       

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                string str = "Delete from AnimalAssign where AnimalId='" + comboBox1.Text + "'";
                g.ExecuteNonQuery(str, null);
                MessageBox.Show("Deleted successfully");

            }
            else
            {
                MessageBox.Show("Select the Animal ID");
            }
            string Str = "select *  from AnimalAssign";
            dt = g.ExecuteReaderForTable(Str, null);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox5.Text = "";
            comboBox6.Text = "";
            comboBox7.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from AnimalDetails where AnimalId='" + comboBox1.Text + "'";
            dt = g.ExecuteReaderForTable(Str, null);
            if (dt.Rows.Count > 0)
            {
                comboBox3.Text = dt.Rows[0][1].ToString();
                comboBox2.Text = dt.Rows[0][2].ToString();  
            }
            else
            {
                // MessageBox.Show("Tables are empty");
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from CageDetails where CageId='" + comboBox4.Text + "'";
            dt1 = g.ExecuteReaderForTable(Str, null);
            if (dt1.Rows.Count > 0)
            {
                comboBox5.Text = dt1.Rows[0][1].ToString();
                comboBox6.Text = dt1.Rows[0][2].ToString();
                comboBox7.Text = dt1.Rows[0][3].ToString();
                

            }
        }
        private void button27_Click(object sender, EventArgs e)
        {
            try
            {
                string addcage = "insert into MemberAssign(MemberId,MemberName,CageId,CageLocation,CageType,CazeSize,AnimalId,AnimalType,AnimalName)values('" + comboBox19.Text + "','" + textBox18.Text + "','" + comboBox15.Text + "','" + comboBox16.Text + "','" + comboBox17.Text + "','" + comboBox18.Text + "','" + comboBox12.Text + "','" + comboBox13.Text + "','" + comboBox14.Text + "')";
                int count = g.ExecuteNonQuery(addcage, null);
                comboBox19.Text = "";
                comboBox12.Text = "";
                comboBox13.Text = "";
                comboBox14.Text = "";
                comboBox15.Text = "";
                comboBox16.Text = "";
                comboBox17.Text = "";
                comboBox18.Text = "";
                textBox18.Text = "";
                
                if (count != 0)
                    MessageBox.Show("MemberAssign Details Saved Successfully..!");
                else
                    MessageBox.Show("MemberAssign Details Not Saved....!!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Insert");
            }

            string Str = "select *  from MemberAssign";
            dt = g.ExecuteReaderForTable(Str, null);
            dataGridView2.DataSource = dt;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToOrderColumns = false;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox19.Text != "" && textBox18.Text != "" && comboBox15.Text != "" && comboBox16.Text != "" && comboBox17.Text != "" && comboBox18.Text != "" && comboBox12.Text != "" && comboBox13.Text != "" && comboBox14.Text != "")
                {

                    string strupd = "update MemberAssign set MemberName='" + textBox18.Text + "' ,CageId='" + comboBox15.Text + "',CageLocation='" + comboBox16.Text + "',CageType='" + comboBox17.Text + "',CazeSize='" + comboBox18.Text + "',AnimalId='" + comboBox12.Text + "',AnimalType='" + comboBox13.Text + "',AnimalName='" + comboBox14.Text + "' where MemberId='" + comboBox19.Text + "'";
                    g.ExecuteNonQuery(strupd, null);
                    comboBox19.Text = ""; textBox18.Text = ""; comboBox15.Text = ""; comboBox16.Text = ""; comboBox17.Text = ""; comboBox18.Text = ""; comboBox12.Text = ""; comboBox13.Text = ""; comboBox14.Text = "";
                    MessageBox.Show("MemberAssign Details Updated Succesfully");
                }
                else
                {
                    MessageBox.Show(" Input all the Details");
                }
                string Str = "select *  from MemberAssign";
                dt = g.ExecuteReaderForTable(Str, null);
                dataGridView2.DataSource = dt;
                dataGridView2.AllowUserToAddRows = false;
                dataGridView2.AllowUserToOrderColumns = false;
            }
            catch (Exception ex) { }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (comboBox19.Text != "")
            {
                string str = "Delete from MemberAssign where MemberId='" + comboBox19.Text + "'";
                g.ExecuteNonQuery(str, null);
                MessageBox.Show("Deleted successfully");

            }
            else
            {
                MessageBox.Show("Select the MemberId ID");
            }
            string Str = "select *  from MemberAssign";
            dt = g.ExecuteReaderForTable(Str, null);
            dataGridView2.DataSource = dt;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToOrderColumns = false;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            comboBox19.Text = ""; textBox18.Text = ""; comboBox15.Text = ""; comboBox16.Text = ""; comboBox17.Text = ""; comboBox18.Text = ""; comboBox12.Text = ""; comboBox13.Text = ""; comboBox14.Text = "";
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from MemberAssign where MemberId='" + comboBox19.Text + "'";
            dt11 = g.ExecuteReaderForTable(Str, null);
            if (dt11.Rows.Count > 0)
            {
                textBox18.Text = dt11.Rows[0][1].ToString();
            }
        }

       

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from CageDetails where CageId='" + comboBox15.Text + "'";
            dt1 = g.ExecuteReaderForTable(Str, null);
            if (dt1.Rows.Count > 0)
            {
                comboBox16.Text = dt1.Rows[0][1].ToString();
                comboBox17.Text = dt1.Rows[0][2].ToString();
                comboBox18.Text = dt1.Rows[0][3].ToString();
                
            }
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from AnimalDetails where AnimalId='" + comboBox12.Text + "'";
            dt111 = g.ExecuteReaderForTable(Str, null);
            if (dt111.Rows.Count > 0)
            {
                comboBox13.Text = dt111.Rows[0][2].ToString();
                comboBox14.Text = dt111.Rows[0][1].ToString();
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            try
            {
                string addcage = "insert into ZooGraphic(CageId,CageLocation,CageType,DoorStatus,CageAlarm,MemberName,ContactNo)values('" + comboBox23.Text + "','" + comboBox24.Text + "','" + comboBox25.Text + "','" + comboBox22.Text + "','" + comboBox21.Text + "','" + comboBox20.Text + "','" + textBox19.Text +  "')";
                int count = g.ExecuteNonQuery(addcage, null);
                comboBox23.Text = "";
                comboBox24.Text = "";
                comboBox25.Text = "";
                comboBox20.Text = "";
                comboBox21.Text = "";
                comboBox22.Text = "";
                
                textBox19.Text = "";

                if (count != 0)
                    MessageBox.Show("ZooGraphic Details Saved Successfully..!");
                else
                    MessageBox.Show("ZooGraphic Details Not Saved....!!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Insert");
            }
            string Str = "select *  from ZooGraphic";
            dt = g.ExecuteReaderForTable(Str, null);
            dataGridView3.DataSource = dt;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToOrderColumns = false;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            comboBox23.Text = "";
            comboBox24.Text = "";
            comboBox25.Text = "";
            comboBox20.Text = "";
            comboBox21.Text = "";
            comboBox22.Text = "";
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboBox23_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from CageDetails where CageId='" + comboBox23.Text + "'";
            dt1 = g.ExecuteReaderForTable(Str, null);
            if (dt1.Rows.Count > 0)
            {
                comboBox24.Text = dt1.Rows[0][1].ToString();
                comboBox25.Text = dt1.Rows[0][2].ToString();
                

            }
        }

        private void comboBox31_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button33_Click(object sender, EventArgs e)
        {
            try
            {
                string addcage = "insert into ZooMonitoring(CageId,CageLoaction,CageType,Door,DoorStatus,CageLight,Timings)values('" + comboBox30.Text + "','" + comboBox31.Text + "','" + comboBox32.Text + "','" + comboBox29.Text + "','" + comboBox28.Text + "','" + comboBox27.Text + "','" + comboBox26.Text + "')";
                int count = g.ExecuteNonQuery(addcage, null);
              
                

                if (count != 0)
                    MessageBox.Show("ZooMonitoring Details Saved Successfully..!");
                else
                    MessageBox.Show("ZooMonitoring Details Not Saved....!!!");
                comboBox26.Text = "";
                comboBox27.Text = "";
                comboBox28.Text = "";
                comboBox29.Text = "";
                comboBox30.Text = "";
                comboBox31.Text = "";
                comboBox32.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Insert");
            }
            string Str = "select *  from ZooMonitoring";
            dt = g.ExecuteReaderForTable(Str, null);
            dataGridView4.DataSource = dt;
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToOrderColumns = false;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            comboBox26.Text = "";
            comboBox27.Text = "";
            comboBox28.Text = "";
            comboBox29.Text = "";
            comboBox30.Text = "";
            comboBox31.Text = "";
            comboBox32.Text = "";
        }

        private void comboBox30_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from CageDetails where CageId='" + comboBox30.Text + "'";
            dtv1 = g.ExecuteReaderForTable(Str, null);
            if (dtv1.Rows.Count > 0)
            {
                comboBox31.Text = dtv1.Rows[0][1].ToString();
                comboBox32.Text = dtv1.Rows[0][2].ToString();


            }
        }
    }
}
