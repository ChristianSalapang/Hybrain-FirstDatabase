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
    public partial class GuardianWindow : Window
    {
        Students_Controller ctrl_student = new Students_Controller();
        Guardians_Controller ctrl_guardian = new Guardians_Controller();

        public GuardianWindow(Students_Controller ctrl_student)
        {
            InitializeComponent();

            this.ctrl_student=ctrl_student;
            dgDetails.ItemsSource = ctrl_guardian.Reload_DataG(ctrl_student).DefaultView;

            btnUpdate.IsEnabled = false;

        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            
                if (txtFirstname.Text == "" || txtLastname.Text == "" || txtRelationship.Text == "")
                {
                    MessageBox.Show("Please fill the information box.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    ctrl_guardian.Firstname = txtFirstname.Text;
                    ctrl_guardian.Middlename = txtMiddlename.Text;
                    ctrl_guardian.Lastname = txtLastname.Text;
                    ctrl_guardian.Relationship = txtRelationship.Text;

                    if (ctrl_guardian.InsertG(ctrl_guardian, ctrl_student) == true)
                    {
                        MessageBox.Show("Successfully Added!");
                         dgDetails.ItemsSource = ctrl_guardian.Reload_DataG(ctrl_student).DefaultView;
                }
                    else
                        MessageBox.Show("Unable to save!");
                }
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = dgDetails.SelectedItem as DataRowView;

            if (sender == btnUpdate)
            {
                do
                {
                    if (txtFirstname.Text == "" || txtLastname.Text == "" || txtRelationship.Text == "")
                    {
                        MessageBox.Show("Please fill the information box.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("The data will be change. Will you proceed?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            ctrl_guardian.GuardianID = Convert.ToInt32(drv.Row["GuardianID"].ToString());

                            try
                            {
                                ctrl_guardian.Firstname = txtFirstname.Text;
                                ctrl_guardian.Middlename = txtMiddlename.Text;
                                ctrl_guardian.Lastname = txtLastname.Text;
                                ctrl_guardian.Relationship = txtRelationship.Text;

                                ctrl_guardian.UpdateG(ctrl_guardian);

                                dgDetails.ItemsSource = ctrl_guardian.Reload_DataG(ctrl_student).DefaultView;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Failed to update the data. Please contact the administrator.", "Message", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                } while (txtFirstname.Text == null || txtMiddlename.Text == null || txtLastname.Text == null);
            }
            else
            {
                btnSave.IsEnabled = false;
                btnUpdate.IsEnabled = true;
                txtFirstname.Text = drv.Row[1].ToString();
                txtMiddlename.Text = drv.Row[2].ToString();
                txtLastname.Text = drv.Row[3].ToString();
                txtRelationship.Text = drv.Row[4].ToString();
            }
        }

        private void btnDelete_ClickG(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("The data will be remove. Will you proceed?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                DataRowView drv = dgDetails.SelectedItem as DataRowView;
                ctrl_guardian.GuardianID = Convert.ToInt32(drv.Row["GuardianID"].ToString());
                ctrl_guardian.DeleteG(ctrl_guardian);

                MessageBox.Show("Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                dgDetails.ItemsSource = ctrl_guardian.Reload_DataG(ctrl_student).DefaultView;
            }
        }


    }
}
