using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ZooAnalyasis
{
    
        
    
    public partial class AddDataForm : Form
    {
        global g = new global();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt12 = new DataTable();
        DataTable dt123 = new DataTable();
        DataTable dt1231 = new DataTable();
        public AddDataForm()
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

            string strempid1 = "select CageId from CageDetails";
            dt1 = g.ExecuteReaderForTable(strempid1, null);
            string str1 = Convert.ToString(dt1);
            comboBox2.DataSource = dt1;
            comboBox2.DisplayMember = "CageId";
            comboBox2.ValueMember = "CageId";

            string strempid112 = "select CageId from CageDetails";
            dt1231 = g.ExecuteReaderForTable(strempid112, null);
            string str11 = Convert.ToString(dt1231);
            comboBox9.DataSource = dt1231;
            comboBox9.DisplayMember = "CageId";
            comboBox9.ValueMember = "CageId";


            string strempid12 = "select MemberId from MemberTable";
            dt12 = g.ExecuteReaderForTable(strempid12, null);
            string str12 = Convert.ToString(dt12);
            comboBox3.DataSource = dt12;
            comboBox3.DisplayMember = "MemberId";
            comboBox3.ValueMember = "MemberId";

            string strempid123 = "select SensorId from CageSensor";
            dt123 = g.ExecuteReaderForTable(strempid123, null);
            string str123 = Convert.ToString(dt123);
            comboBox8.DataSource = dt123;
            comboBox8.DisplayMember = "SensorId";
            comboBox8.ValueMember = "SensorId";

        }

        private void button7_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    string addcage = "insert into AnimalDetails(AnimalId,AnimalName,AnimalType,CageType,Comments)values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                    int count = g.ExecuteNonQuery(addcage, null);
                    comboBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";
                    if (count != 0)
                        MessageBox.Show("Member Details Saved Successfully..!");
                    else
                        MessageBox.Show("Member Details Already Exist....!!!");
                }
                else
                {
                    MessageBox.Show("Fill all the datas ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Insert" + ex);
            }
        }

        private void buttonAdUpd_Click(object sender, EventArgs e)
        {
            
            
            try
            {
                if (comboBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
                    string strupd = "update AnimalDetails set AnimalName='" + textBox2.Text + "' ,AnimalType='" + textBox3.Text + "',CageType='" + textBox4.Text + "',Comments='" + textBox5.Text + "' where AnimalId='" + comboBox1.Text + "'";
                    g.ExecuteNonQuery(strupd, null);
                    
                    MessageBox.Show("Animal Details Updated Succesfully");
                }
                else
                {
                    MessageBox.Show(" Input all the Details");
                }
            }
            catch (Exception ex) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                string str = "Delete from AnimalDetails where AnimalId='" + comboBox1.Text + "'";
                g.ExecuteNonQuery(str, null);
                MessageBox.Show("Deleted successfully");
            }
            else
            {
                MessageBox.Show("Select the Animal ID");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = ""; textBox2.Text = ""; textBox3.Text = ""; textBox4.Text = ""; textBox5.Text = "";
               
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                string addcage = "insert into CageDetails(CageId,CageLocation,CazeType,CazeSize,AnimalType)values('" + comboBox2.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')";
                int count = g.ExecuteNonQuery(addcage, null);
                comboBox2.Text = ""; textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = ""; textBox10.Text = "";
                if (count != 0)
                    MessageBox.Show("Cage Details Saved Successfully..!");
                else
                    MessageBox.Show("Cage Details Already Exist....!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Insert");
            }
        }


        private void button22_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox8.Text != "" && comboBox9.Text != "" && comboBox10.Text != "" && comboBox11.Text != "" && dateTimePicker1.Text != "")
                {
                    string strupd = "update CageSensor set CageId='" + comboBox9.Text + "' ,CageLocation='" + comboBox10.Text + "',SensorStatus='" + comboBox11.Text + "',SensorDate='" + dateTimePicker1.Text + "' where SensorId  ='" + comboBox8.Text + "'";
                    g.ExecuteNonQuery(strupd, null);

                    MessageBox.Show("Cage sensor Details Updated Succesfully");
                }
                else
                {
                    MessageBox.Show(" Input all the Details");
                }
            }
            catch (Exception ex) { }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                string addcage = "insert into CageSensor(SensorId,CageId,CageLocation,SensorStatus,SensorDate)values('" + comboBox8.Text + "','" + comboBox9.Text + "','" + comboBox10.Text + "','" + comboBox11.Text + "','"+dateTimePicker1.Text+"')";
                int count = g.ExecuteNonQuery(addcage, null);
                comboBox8.Text = "";
                comboBox9.Text = "";
                comboBox10.Text = "";
                comboBox11.Text = "";
                dateTimePicker1.Text = "";
                if (count != 0)
                    MessageBox.Show("CageSensor Details Saved Successfully..!");
                else
                    MessageBox.Show("CageSensor Details Not Saved....!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Insert");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {

            try
            {

                string addcage = "insert into MemberTable(MemberId,MemberName,ContactNo,Comments,Designation)values('" + comboBox3.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "')";
                int count = g.ExecuteNonQuery(addcage, null);
                comboBox3.Text = ""; textBox12.Text = ""; textBox13.Text = ""; textBox14.Text = ""; textBox15.Text = "";
                if (count != 0)
                    MessageBox.Show("Member Details Saved Successfully..!");
                else
                    MessageBox.Show("Member Details Already Exist....!!!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to Insert");
            }
        }


        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox3.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "")
                {
                    
                    string strupd = "update MemberTable set MemberName='" + textBox12.Text + "' ,ContactNo='" + textBox13.Text + "',Designation='" + textBox14.Text + "',Comments='" + textBox15.Text + "' where MemberId='" + comboBox3.Text + "'";
                    g.ExecuteNonQuery(strupd, null);
                    comboBox3.Text = ""; textBox12.Text = ""; textBox13.Text = ""; textBox14.Text = ""; textBox15.Text = "";
                    MessageBox.Show("Member Details Updated Succesfully");
                }
                else
                {
                    MessageBox.Show(" Input all the Details");
                }
            }
            catch (Exception ex) { }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from MemberTable where MemberId='" + comboBox3.Text + "'";
            dt12 = g.ExecuteReaderForTable(Str, null);
            if (dt12.Rows.Count > 0)
            {
                textBox12.Text = dt12.Rows[0][1].ToString();
                textBox13.Text = dt12.Rows[0][2].ToString();
                textBox14.Text = dt12.Rows[0][3].ToString();
                textBox15.Text = dt12.Rows[0][4].ToString();

            }
        }





        private void AddDataForm_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from AnimalDetails where AnimalId='" + comboBox1.Text + "'";
            dt = g.ExecuteReaderForTable(Str, null);
            if (dt.Rows.Count > 0)
            {
                textBox2.Text = dt.Rows[0][1].ToString();
                textBox3.Text = dt.Rows[0][2].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
                textBox5.Text = dt.Rows[0][4].ToString();
            }
            else
            {
               // MessageBox.Show("Tables are empty");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from CageDetails where CageId='" + comboBox2.Text + "'";
            dt1 = g.ExecuteReaderForTable(Str, null);
            if (dt1.Rows.Count > 0)
            {
                textBox7.Text = dt1.Rows[0][1].ToString();
                textBox8.Text = dt1.Rows[0][2].ToString();
                textBox9.Text = dt1.Rows[0][3].ToString();
                textBox10.Text = dt1.Rows[0][4].ToString();

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "")
                {
                    
                    string strupd = "update CageDetails set CageLocation='" + textBox7.Text + "' ,CazeType='" + textBox8.Text + "',CazeSize='" + textBox9.Text + "',AnimalType='" + textBox10.Text + "' where CageId='" + comboBox2.Text + "'";
                    g.ExecuteNonQuery(strupd, null);
                    comboBox2.Text = ""; textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = ""; textBox10.Text = "";
                    MessageBox.Show("Cage Details Updated Succesfully");
                }
                else
                {
                    MessageBox.Show(" Input all the Details");
                }
            }
            catch (Exception ex) { }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                string str = "Delete from CageDetails where CageId='" + comboBox2.Text + "'";
                g.ExecuteNonQuery(str, null);
                MessageBox.Show("Deleted successfully");
            }
            else
            {
                MessageBox.Show("Select the Animal ID");
            }
        }

       

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            comboBox3.Text = ""; textBox7.Text = ""; textBox8.Text = ""; textBox9.Text = ""; textBox10.Text = "";
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Str = "select *  from CageSensor where SensorId='" + comboBox8.Text + "'";
            dt123 = g.ExecuteReaderForTable(Str, null);
            if (dt123.Rows.Count > 0 )
            {
                //comboBox9.Text = dt1231.Rows[0][1].ToString();
                comboBox10.Text = dt123.Rows[0][2].ToString();
                comboBox11.Text = dt123.Rows[0][3].ToString();
                dateTimePicker1.Text = dt123.Rows[0][4].ToString();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (comboBox8.Text != "")
            {
                string str = "Delete from CageSensor where SensorId='" + comboBox8.Text + "'";
                g.ExecuteNonQuery(str, null);
                MessageBox.Show("Deleted successfully");
            }
            else
            {
                MessageBox.Show("Select the Animal ID");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            comboBox8.Text = "";
            comboBox9.Text = "";
            comboBox10.Text = "";
            comboBox11.Text = "";
            dateTimePicker1.Text = "";
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        }

   
}
