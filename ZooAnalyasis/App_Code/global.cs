using System;
using System.Data;
using System.Configuration;
using System.Web;
//using System.Web.UI;
using System.Data.SqlClient;
using System.Collections;

using System.IO;
using System.Drawing;
using System.Diagnostics;

namespace WindowsApplication1.App_Code
{
    class global
    {
    }
}
public class global
{
    private string ConString;
    private SqlConnection SqlCon;
    private SqlCommand SqlComd;
    private string ptablename;
    /* public global(string tablename)
     {
         ptablename = tablename;
         //
         // TODO: Add constructor logic here
         // 
     }*/
    public global()
    {

    }

    private bool Connect()
    {
        // ConString = "Data Source=SANJAY-92779BC1\\SQLEXPRESS;Initial Catalog=ReachFitness;Integrated Security=True";
        //ConString = "Data Source=REACHFITNESS-PC\\SQLEXPRESS;Initial Catalog=SECURTIME;Integrated Security=True;";
        //ConString = " Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\user\\Desktop\\Projects\\ReachFitness\\ReachFitness\\App_Data\\GymDataBase.mdf;Integrated Security=True;User Instance=True";
        //ConString = "Data Source=182.18.165.199;Initial Catalog=iieducom_1;User ID=sanju; Password=1234";
        ConString = "Data Source=USER-PC\\SQLEXPRESS;Initial Catalog=ZooDataBase; Integrated Security=True;";
        // ConString = "Data Source=173.231.40.204;Initial Catalog=snooker;Persist Security Info=True;User ID=snooker;Password=9845098450";
        //ConString = "Data Source=.;Initial Catalog=test;User ID=sa; Password=spyinfo;";
        SqlCon = new SqlConnection(ConString);

        SqlComd = new SqlCommand();
        SqlComd.CommandType = CommandType.StoredProcedure;

        SqlCon.Open();

        if (SqlCon.State == ConnectionState.Open)
            return true;
        else
            return false;
    }

    private void Disconnect()
    {
        if (SqlCon.State == ConnectionState.Open)
        {
            SqlCon.Close();
            //SqlCon.Dispose();
        }
    }

    public int ExecuteNonQuery(string Query, ArrayList Parameters, bool OutPut)
    {

        try
        {
            if (this.Connect())
            {
                SqlComd.Connection = SqlCon;
                SqlComd.CommandText = Query;
                Query = Query.ToLower();

                //if (Query.StartsWith("select") || Query.StartsWith("insert") || Query.StartsWith("delete") || Query.StartsWith("update"))
                //    SqlComd.CommandType = CommandType.Text;

                if (Parameters != null)
                {
                    foreach (string param in Parameters)
                    {
                        string[] key_Value = param.Split('=');
                        SqlComd.Parameters.AddWithValue("@" + key_Value[0], key_Value[1]);
                    }
                }

                SqlComd.Parameters.Add(new SqlParameter("@ReturnID", SqlDbType.Int));
                SqlComd.Parameters["@ReturnID"].Direction = ParameterDirection.Output;
                int RowsEffected = SqlComd.ExecuteNonQuery();
                int op = (int)SqlComd.Parameters["@ReturnID"].Value;
                this.Disconnect();
                return op;

            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            this.Disconnect();
        }

        return 0;

    }


    public int ExecuteNonQuery(string Query, ArrayList Parameters)
    {
        //Parameters array must be of type
        //Parameters[] = "name=Chandrakiran";
        //Parameters[] = "email=chandrakiran@gmail.com";                

        try
        {
            if (this.Connect())
            {
                SqlComd.Connection = SqlCon;
                this.ConstructCommand(Query, Parameters);
                int RowsEffected = SqlComd.ExecuteNonQuery();
                this.Disconnect();
                return RowsEffected;
            }
        }
        catch (Exception err)
        {
        }
        finally
        {
            this.Disconnect();
        }

        return 0;
    }

    public Object ExecuteScalar(string Query, ArrayList Parameters)
    {
        //Parameters array must be of type
        //Parameters[] = "name=Chandrakiran";
        //Parameters[] = "email=chandrakiran@gmail.com";

        try
        {
            if (this.Connect())
            {
                SqlComd.Connection = SqlCon;
                this.ConstructCommand(Query, Parameters);
                Object Scalar = SqlComd.ExecuteScalar();
                this.Disconnect();
                return Scalar;
            }
        }
        catch (Exception err)
        {
        }
        finally
        {
            this.Disconnect();
        }

        return null;
    }

    public DataSet ExecuteReader(string Query, ArrayList Parameters)
    {
        //Parameters array must be of type
        //Parameters[] = "name=Chandrakiran";
        //Parameters[] = "email=chandrakiran@gmail.com";

        DataSet DS = new DataSet();
        try
        {
            if (this.Connect())
            {
                SqlComd.Connection = SqlCon;
                this.ConstructCommand(Query, Parameters);
                SqlComd.ExecuteReader();

                SqlDataAdapter DA = new SqlDataAdapter(SqlComd);
                this.Disconnect();
                DA.Fill(DS);

                return DS;
            }
        }
        catch (Exception err)
        {
        }
        finally
        {
            this.Disconnect();
        }

        return DS;
    }
    public DataTable ExecuteReaderForTable(string Query, ArrayList Parameters)
    {
        //Parameters array must be of type
        //Parameters[] = "name=Chandrakiran";
        //Parameters[] = "email=chandrakiran@gmail.com";

        DataSet DS = new DataSet();
        try
        {
            if (this.Connect())
            {
                SqlComd.Connection = SqlCon;
                this.ConstructCommand(Query, Parameters);
                SqlComd.ExecuteReader();

                SqlDataAdapter DA = new SqlDataAdapter(SqlComd);
                this.Disconnect();
                DA.Fill(DS);

                return DS.Tables[0];
            }
        }
        catch (Exception err)
        {
        }
        finally
        {
            this.Disconnect();
        }

        return DS.Tables[0];
    }


    private void ConstructCommand(string Query, ArrayList Parameters)
    {
        SqlComd.CommandText = Query;
        Query = Query.ToLower();

        if (Query.StartsWith("select") || Query.StartsWith("insert") || Query.StartsWith("alter") || Query.StartsWith("delete") || Query.StartsWith("update"))
            SqlComd.CommandType = CommandType.Text;

        if (Parameters != null)
        {
            foreach (string param in Parameters)
            {
                string[] key_Value = param.Split('=');
                SqlComd.Parameters.AddWithValue("@" + key_Value[0], key_Value[1]);
            }
        }
    }




    public DataSet ExecuteReader(string p)
    {
        throw new Exception("The method or operation is not implemented.");


    }
    //public SqlDataReader ExecuteReader(string p)
    //{
    //    throw new Exception("The method or operation is not implemented.");


    //}
    //public bool fillAreas(ComboBox cmb)
    //{
    //    try
    //    {
    //        DataSet ds = new DataSet();
    //        ds = ExecuteReader("select id,city from tblCity order by city", null);
    //        cmb.ValueMember = "id";
    //        cmb.DisplayMember = "city";
    //        cmb.DataSource = ds.Tables[0];
    //        return true;
    //    }
    //    catch (Exception excep)
    //    {
    //        MessageBox.Show(excep.Message);
    //        return false;
    //    }
    //}
    //public bool fillCities(ComboBox cmb)
    //{
    //    try
    //    {
    //        DataSet ds = new DataSet();
    //        ds = ExecuteReader("select id,city from tblCity order by city", null);
    //        cmb.ValueMember = "id";
    //        cmb.DisplayMember = "city";
    //        cmb.DataSource = ds.Tables[0];
    //        return true;
    //    }
    //    catch (Exception excep)
    //    {
    //        MessageBox.Show(excep.Message);
    //        return false;
    //    }
    //}
    //public bool fillStates(ComboBox cmb)
    //{
    //    try
    //    {
    //        DataSet ds = new DataSet();
    //        ds = ExecuteReader("select id,state from tblState order by state", null);
    //        cmb.ValueMember = "id";
    //        cmb.DisplayMember = "state";
    //        cmb.DataSource = ds.Tables[0];
    //        return true;
    //    }
    //    catch (Exception excep)
    //    {
    //        MessageBox.Show(excep.Message);
    //        return false;
    //    }
    //}
    //public bool fillCountries(ComboBox cmb)
    //{
    //    try
    //    {
    //        DataSet ds = new DataSet();
    //        ds = ExecuteReader("select id,country from tblCountry order by country", null);
    //        cmb.ValueMember = "id";
    //        cmb.DisplayMember = "country";
    //        cmb.DataSource = ds.Tables[0];
    //        return true;
    //    }
    //    catch (Exception excep)
    //    {
    //        MessageBox.Show(excep.Message);
    //        return false;
    //    }
    //}


    public bool customerExists(string customer)
    {
        try
        {
            int count = Convert.ToInt32(ExecuteScalar("select count (*) from tblCRM where customerName='" + customer + "'", null));
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {

            return true;
        }
    }
    public int getCustomerId(string customerName)
    {
        return Convert.ToInt32(ExecuteScalar("select id from tblCRM where customerName='" + customerName.Trim() + "'", null));
    }
    public void killThisApp()
    {
        Process[] pArray = Process.GetProcesses();
        foreach (Process p in pArray)
        {
            if (p.ProcessName == "SatyaWindows.vshost")
            {
                p.Kill();
            }
        }
    }
}
