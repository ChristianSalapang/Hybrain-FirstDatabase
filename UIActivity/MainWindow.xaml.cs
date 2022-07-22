using UIActivity.Controller;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UIActivity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Students_Controller ctrl_student = new Students_Controller();
        string connetionString = "Data Source=DESKTOP-FII56OI; Initial Catalog=DataUI; Integrated Security= True";
        public MainWindow()
        {
            InitializeComponent();

            btnRefresh.IsEnabled = false;
            btnSave.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            txtFirstname.IsEnabled = false;
            txtMiddlename.IsEnabled = false;
            txtLastname.IsEnabled = false;
            dtpBirthday.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // CONNECT 
            if (sender == btnConnect)
            {
                SqlConnection connection;
                connection = new SqlConnection(connetionString);
                try
                {
                    connection.Open();
                    MessageBox.Show("Connected Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    connection.Close();
                    btnConnect.IsEnabled = false;
                    dgDetails.ItemsSource = ctrl_student.Reload_Data().DefaultView;
                    //CountGuardian();
                    btnRefresh.IsEnabled = true;
                    btnSave.IsEnabled = true;
                    txtFirstname.IsEnabled = true;
                    txtMiddlename.IsEnabled = true;
                    txtLastname.IsEnabled = true;
                    dtpBirthday.IsEnabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        

            //SAVE
            if (sender == btnSave)
            {
                ctrl_student.Firstname = txtFirstname.Text;
                ctrl_student.Middlename = txtMiddlename.Text;
                ctrl_student.Lastname = txtLastname.Text;
                ctrl_student.Birthdate = Convert.ToDateTime(dtpBirthday.Text);

                if (ctrl_student.Insert(ctrl_student) == true)
                {
                    MessageBox.Show("Successfully Added!");
  
                    dgDetails.ItemsSource = ctrl_student.Reload_Data().DefaultView;
                }

                else
                    MessageBox.Show("Unable to save!");
            }



            // REFRESH 
            else if (sender == btnRefresh)
            {
                dgDetails.ItemsSource = ctrl_student.Reload_Data().DefaultView;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = dgDetails.SelectedItem as DataRowView;
            // UPDATE 
            if (sender == btnUpdate)
            {
               
                    if (txtFirstname.Text == "" || txtLastname.Text == "" || dtpBirthday.Text == "")
                    {
                        MessageBox.Show("Please fill the information box.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("The data will be change. Will you proceed?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                             
                                ctrl_student.StudentID = Convert.ToInt32(drv.Row["StudentID"].ToString());
                        try
                            {
                                ctrl_student.Firstname = txtFirstname.Text;
                                ctrl_student.Middlename = txtMiddlename.Text;
                                ctrl_student.Lastname = txtLastname.Text;
                                ctrl_student.Birthdate = Convert.ToDateTime(dtpBirthday.Text);

                                ctrl_student.Update(ctrl_student);

                                dgDetails.ItemsSource = ctrl_student.Reload_Data().DefaultView;
                                
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Failed to update the data. Please contact the administrator.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                
            }
            else
            {
                btnSave.IsEnabled = false;
                btnUpdate.IsEnabled = true;
                txtFirstname.Text = drv.Row[1].ToString();
                txtMiddlename.Text = drv.Row[2].ToString();
                txtLastname.Text = drv.Row[3].ToString();
                dtpBirthday.Text = drv.Row[4].ToString();
            }
        }

        // DELETE
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("The data will be remove. Will you proceed?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DataRowView drv = dgDetails.SelectedItem as DataRowView;
                ctrl_student.StudentID = Convert.ToInt32(drv.Row["StudentID"].ToString());
                ctrl_student.Delete(ctrl_student);

                MessageBox.Show("Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                dgDetails.ItemsSource = ctrl_student.Reload_Data().DefaultView;
            }
        }


        private void btnAddGuardian_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = dgDetails.SelectedItem as DataRowView;

            ctrl_student.StudentID = Convert.ToInt32(drv.Row["StudentID"].ToString());

            Window form = new GuardianWindow(ctrl_student);
            form.ShowDialog();
        }

        private void btnViewDetails_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = dgDetails.SelectedItem as DataRowView;

            ctrl_student.StudentID = Convert.ToInt32(drv.Row["StudentID"].ToString());
            ctrl_student.Firstname = drv.Row["Firstname"].ToString();
            ctrl_student.Middlename = drv.Row["MiddleIntial"].ToString();
            ctrl_student.Lastname = drv.Row["Lastname"].ToString();
            ctrl_student.Birthdate = Convert.ToDateTime(drv.Row["Birthdate"].ToString());


            Window form = new ViewDetails(ctrl_student);
            form.ShowDialog();
        }

       
    }
}
