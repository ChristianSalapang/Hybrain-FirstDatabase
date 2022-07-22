using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UIActivity;
using UIActivity.Controller;

namespace UIActivity
{
    /// <summary>
    /// Interaction logic for GuardianWindow.xaml
    /// </summary>
    public partial class ViewDetails : Window
    {
        Students_Controller ctrl_student = new Students_Controller();
        Guardians_Controller ctrl_guardian = new Guardians_Controller();

        public ViewDetails(Students_Controller ctrl_student)
        {
            InitializeComponent(); 

            this.ctrl_student = ctrl_student;
            dgDetails.ItemsSource = ctrl_guardian.Reload_DataG(ctrl_student).DefaultView;

            ShowInfo(ctrl_student.Firstname, ctrl_student.Middlename, ctrl_student.Lastname, ctrl_student.Birthdate);
        }

        private void ShowInfo(string Firstname, string MiddleInitial, string Lastname, DateTime Birthdate)
        {
            Birthdate.ToLongDateString();
            ShowFirstname.Text = "";
            ShowMiddlename.Text = "";
            ShowLastname.Text = "";
            ShowBirthday.Text = "";
            this.ShowFirstname.Inlines.Add(new Run(Firstname));
            this.ShowMiddlename.Inlines.Add(new Run(MiddleInitial));
            this.ShowLastname.Inlines.Add(new Run(Lastname));
            this.ShowBirthday.Inlines.Add(new Run(Birthdate.ToString()));

        }
    }
}
