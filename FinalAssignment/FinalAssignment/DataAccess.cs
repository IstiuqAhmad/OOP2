using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FinalAssignment
{
    public static class DataAccess
    {
        public static bool ExecuteQuery(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-S4A9PK9\ISTIUQEXPRESS;Initial catalog=IntroGUI;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                con.Close();
                return true;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        public static DataTable GetData(string query)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-S4A9PK9\ISTIUQEXPRESS;Initial catalog=IntroGUI;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = query;

                DataSet ds = new DataSet();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];

                con.Close();

                return dt;
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return null;
            }
        }
    }
}
