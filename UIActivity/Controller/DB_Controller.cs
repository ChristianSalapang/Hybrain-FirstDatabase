using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIActivity.Controller
{
    public static class DB_Controller
    {
        //public static string connectString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public static string connectString1 = "Data Source=DESKTOP-FII56OI; Initial Catalog=DataUI; Integrated Security= True";
        public static SqlConnection GetGlobalConnection()
        {
            return new SqlConnection(connectString1);
        }
    }
}
