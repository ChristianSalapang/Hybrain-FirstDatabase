using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace UIActivity.Controller
{
    public static class Queries_Controller
    {
        public static DataTable LoadData(SqlCommand sqlcmd)
        {
            SqlCommand cmd = sqlcmd;
            using (SqlConnection connect = new SqlConnection(DB_Controller.connectString1))
            {
                connect.Open();
                cmd.Connection = connect;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                connect.Close();
                return dt;
            }
        }
        public static bool ExecNonQuery(SqlCommand sqlcmd)
        {
            try
            {
                SqlCommand cmd = sqlcmd;
                using (SqlConnection connect = new SqlConnection(DB_Controller.connectString1))
                {
                    cmd.Connection = connect;
                    connect.Open();
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static bool Connect()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(DB_Controller.connectString1))
                {
                    connect.Open();
                    connect.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

