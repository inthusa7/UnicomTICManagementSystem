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
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Forms
{
    public partial class StudentForm : Form
    {
        private StudentController studentController = new StudentController();
        private CourseController courseController = new CourseController();
        private int selectedStudentId = -1;
        public StudentForm()
        {
            InitializeComponent();
            this.Load += StudentForm_Load;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtStudentName.Text;
            int courseId = Convert.ToInt32(cmbCourses.SelectedValue);

            
            if (!string.IsNullOrWhiteSpace(name))
            {
                await studentController.AddAsync(new Student { StudentName = name, CourseID = courseId });
                txtStudentName.Clear();
                await LoadStudents();
                
            }
            else
            {
                MessageBox.Show("Enter student name.");
            }

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedStudentId != -1)
            {
                await studentController.UpdateAsync(new Student
                {
                    StudentId = selectedStudentId,
                    StudentName = txtStudentName.Text,
                    CourseID = Convert.ToInt32(cmbCourses.SelectedValue)
                });
                txtStudentName.Clear();
                selectedStudentId = -1;
                await LoadStudents();
            }

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedStudentId != -1)
            {
                await studentController.DeleteAsync(selectedStudentId);
                txtStudentName.Clear();
                selectedStudentId = -1;
                await LoadStudents();
            }

        }

        private void cmbCourses_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            string name = txtStudentName.Text;
            //MessageBox.Show("You typed:" + name);
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStudents.Rows[e.RowIndex];
                selectedStudentId = Convert.ToInt32(row.Cells["StudentID"].Value);
                txtStudentName.Text = row.Cells["StudentName"].Value.ToString();
                cmbCourses.SelectedValue = row.Cells["CourseID"].Value;
            }

        }

        private async void StudentForm_Load(object sender, EventArgs e)
        
            {
                await LoadCourses();
                await LoadStudents();

            }
        private async Task LoadCourses()
        {
            var courses = await courseController.GetAllCoursesAsync();
            cmbCourses.DataSource = courses;
            cmbCourses.DisplayMember = "CourseName";
            cmbCourses.ValueMember = "CourseID";
        }

        private async Task LoadStudents()
        {
            dgvStudents.DataSource = await studentController.GetAllAsync();




        }
    } 
}
