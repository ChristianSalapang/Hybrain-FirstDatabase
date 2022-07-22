using UIActivity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace UIActivity.Controller
{
    public class Guardians_Controller : Guardians_Model
    {
        bool result = false;
        SqlCommand cmd = new SqlCommand();

        //Save
        public bool InsertG(Guardians_Controller ctrl_G, Students_Controller ctrl_S)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO Guardians (StudentID, Firstname, MiddleIntial, Lastname, Relationship) VALUES (@StudentID, @Firstname, @Middlename, @Lastname, @Relationship)");
                //cmd = new SqlCommand("usp_TestInsert");

                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StudentID", ctrl_S.StudentID);
                cmd.Parameters.AddWithValue("@Firstname", ctrl_G.Firstname);
                cmd.Parameters.AddWithValue("@Middlename", ctrl_G.Middlename);
                cmd.Parameters.AddWithValue("@Lastname", ctrl_G.Lastname);
                cmd.Parameters.AddWithValue("@Relationship", ctrl_G.Relationship);
                result = Queries_Controller.ExecNonQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return result;
        }

        public DataTable Reload_DataG(Students_Controller ctrl_S)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("SELECT GuardianID, Firstname, MiddleIntial, Lastname, Relationship FROM Guardians WHERE StudentID = @StudentID");
                cmd.Parameters.AddWithValue("@StudentID", ctrl_S.StudentID);
                dt = Queries_Controller.LoadData(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return dt;

        }

        public bool DeleteG(Guardians_Controller ctrl_G)
        {

            try
            {
                cmd = new SqlCommand("DELETE FROM Guardians WHERE GuardianID = @GuardianID");
                cmd.Parameters.AddWithValue("@GuardianID", ctrl_G.GuardianID);

                result = Queries_Controller.ExecNonQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return result;

        }


        public bool UpdateG(Guardians_Controller ctrl_G)
        {
            try
            {
                cmd = new SqlCommand("UPDATE Guardians SET Firstname = @Firstname, MiddleIntial = @Middlename, Lastname = @Lastname, Relationship = @Relationship WHERE GuardianID = @GuardianID");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@GuardianID", ctrl_G.GuardianID);
                cmd.Parameters.AddWithValue("@Firstname", ctrl_G.Firstname);
                cmd.Parameters.AddWithValue("@Middlename", ctrl_G.Middlename);
                cmd.Parameters.AddWithValue("@Lastname", ctrl_G.Lastname);
                cmd.Parameters.AddWithValue("@Relationship", ctrl_G.Relationship);
                result = Queries_Controller.ExecNonQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return result;
        }

    }
}
