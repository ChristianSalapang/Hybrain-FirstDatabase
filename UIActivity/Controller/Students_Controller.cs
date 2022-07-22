using UIActivity.Model;
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
    public class Students_Controller : Students_Model
    {
        bool result = false;
        SqlCommand cmd = new SqlCommand();

        //Save
        public bool Insert(Students_Controller ctrl)
        {
            try
            {
                cmd = new SqlCommand("INSERT INTO Students (Firstname, MiddleIntial, Lastname, Birthdate) VALUES (@Firstname,@Middlename,@Lastname,@dtpBirthday)");
                //cmd = new SqlCommand("usp_TestInsert");

                //cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Firstname", ctrl.Firstname);
                cmd.Parameters.AddWithValue("@Middlename", ctrl.Middlename);
                cmd.Parameters.AddWithValue("@Lastname", ctrl.Lastname);
                cmd.Parameters.AddWithValue("@dtpBirthday", ctrl.Birthdate);
                result = Queries_Controller.ExecNonQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return result;
        }

        public DataTable Reload_Data()
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("SELECT Students.StudentID, Students.Firstname, Students.MiddleIntial, Students.Lastname, Students.Birthdate, COUNT(Guardians.GuardianID) AS 'Number of Guardians' FROM Students LEFT JOIN Guardians ON Students.StudentID = Guardians.StudentID GROUP BY Students.StudentID, Students.Firstname, Students.MiddleIntial, Students.Lastname, Students.Birthdate");
                dt = Queries_Controller.LoadData(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return dt;

        }

        public bool Delete(Students_Controller ctrl)
        {
           
            try
            {
                cmd = new SqlCommand("DELETE FROM Guardians WHERE StudentID = @StudentID; DELETE FROM Students WHERE StudentID = @StudentID");
                cmd.Parameters.AddWithValue("@StudentID", ctrl.StudentID);

                result = Queries_Controller.ExecNonQuery(cmd);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return result;

        }


        public bool Update(Students_Controller ctrl)
        {
            try
            {
                cmd = new SqlCommand("Update Students set Firstname = @Firstname, MiddleIntial = @Middlename,Lastname = @Lastname, Birthdate = @dtpBirthday where StudentID = @StudentID");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@StudentID", ctrl.StudentID);
                cmd.Parameters.AddWithValue("@Firstname", ctrl.Firstname);
                cmd.Parameters.AddWithValue("@Middlename", ctrl.Middlename);
                cmd.Parameters.AddWithValue("@Lastname", ctrl.Lastname);
                cmd.Parameters.AddWithValue("@dtpBirthday", ctrl.Birthdate);
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
