using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomTICManagementSystem.Controllers;
using UnicomTICManagementSystem.Data;
using UnicomTICManagementSystem.Forms;
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
       

        public LoginForm()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {


            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string selectedRole = cmbRole.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var userController = new UserController();

            if (selectedRole == "Student")
            {
                var user = await userController.ValidateStudentAsync(username, password);
                if (user != null)
                {
                    MessageBox.Show("Login successful as Student", "Success");
                    this.Hide();
                    new StudentDashbordForm(user.UserId).Show();
                }
                else
                {
                    MessageBox.Show("Invalid Student name or ID", "Login Failed");
                }
            }
            else if (selectedRole == "Lecturer")
            {
                var user = await userController.ValidateLecturerAsync(username, password);
                if (user != null)
                {
                    MessageBox.Show("Lecturer login successful");
                    this.Hide();
                    new LecturerDashbordForm(user.UserId).Show();
                }
                else
                {
                    MessageBox.Show("Invalid lecturer login");

                }

            }
            else if (selectedRole == "Staff")
            {
                var user = await userController.ValidateStaffAsync(username, password);
                if (user != null)
                {
                    MessageBox.Show("Login successful as Staff", "Success");
                    this.Hide();
                    new StaffDashbordForm(user.UserId).Show();
                }
                else
                {
                    MessageBox.Show("Invalid Staff name or ID", "Login Failed");
                }
            }
            else if (selectedRole == "Admin" && username == "inthusa" && password == "1234")
            {
                MessageBox.Show("Admin login successful");
                this.Hide();
                new AdminDashbordForm().ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Login Failed");
            }

        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            cmbRole.Items.Add("Admin");
            cmbRole.Items.Add("Staff");
            cmbRole.Items.Add("Lecturer");
            cmbRole.Items.Add("Student");
            cmbRole.SelectedIndex = 0;

        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

           
            