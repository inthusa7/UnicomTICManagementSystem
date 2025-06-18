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
    public partial class CourseForm : Form
    {
        private CourseController courseController = new CourseController(); 
        private int selectedCourseId = -1;

        public CourseForm()
        {
            InitializeComponent();
            this.Load += CourseForm_Load;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private  void CourseForm_Load(object sender, EventArgs e)
        {
             LoadCourses();

        }
        private async void LoadCourses()
        {
            dgvCourses.DataSource = await courseController.GetAllCoursesAsync();
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtCourseName.Text.Trim();

            if (!string.IsNullOrWhiteSpace(name))
            {
                await courseController.AddCourseAsync(new Course { CourseName = name });
                txtCourseName.Clear();
                LoadCourses();
            }


            else
            {
                MessageBox.Show("Please enter course name.");
            }

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCourseId != -1)
            {
                await courseController.UpdateCourseAsync(new Course
                {
                    CourseID = selectedCourseId,
                    CourseName = txtCourseName.Text.Trim()
                });
                txtCourseName.Clear();
                selectedCourseId = -1;
                LoadCourses();

            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCourseId != -1)
            {
                await courseController.DeleteCourseAsync(selectedCourseId);
                txtCourseName.Clear();
                selectedCourseId = -1;
                LoadCourses();
            }

        }

       
       
        private void dgvCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCourses.Rows[e.RowIndex];
                selectedCourseId = Convert.ToInt32(row.Cells["CourseID"].Value);
                txtCourseName.Text = row.Cells["CourseName"].Value.ToString();
            }

        }
    }
}
