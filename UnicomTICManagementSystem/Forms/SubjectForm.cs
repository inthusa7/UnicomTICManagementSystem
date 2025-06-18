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
    public partial class SubjectForm : Form
    {
        private SubjectController subjectController = new SubjectController(); 
        private CourseController courseController = new CourseController(); 
        private int selectedSubjectId = -1;


        public SubjectForm()
        {
            InitializeComponent();
            this.Load +=SubjectForm_Load;
        }

        private async void SubjectForm_Load(object sender, EventArgs e)
        {
            await LoadCourses();
            await LoadSubjects();

        }
        private async Task LoadCourses()
        {
            var courses = await courseController.GetAllCoursesAsync();
            cmbCourses.DataSource = courses;
            cmbCourses.DisplayMember = "CourseName";
            cmbCourses.ValueMember = "CourseID";
        }

        private async Task LoadSubjects()
        {
            dgvSubjects.DataSource = await subjectController.GetAllAsync();
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtSubjectName.Text;
            int courseId = Convert.ToInt32(cmbCourses.SelectedValue);

            if (!string.IsNullOrWhiteSpace(name))
            {
                await subjectController.AddAsync(new Subject { SubjectName = name, CourseID = courseId });
                txtSubjectName.Clear();
                await LoadSubjects();
            }
            else
            {
                MessageBox.Show("Please enter subject name.");
            }

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId != -1)
            {
                await subjectController.UpdateAsync(new Subject
                {
                    SubjectID = selectedSubjectId,
                    SubjectName = txtSubjectName.Text,
                    CourseID = Convert.ToInt32(cmbCourses.SelectedValue)
                });
                txtSubjectName.Clear();
                selectedSubjectId = -1;
                await LoadSubjects();
            }


        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedSubjectId != -1)
            {
                await subjectController.DeleteAsync(selectedSubjectId);
                txtSubjectName.Clear();
                selectedSubjectId = -1;
                await LoadSubjects();
            }



        }

        private void dgvSubjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSubjects.Rows[e.RowIndex];
                selectedSubjectId = Convert.ToInt32(row.Cells["SubjectID"].Value);
                txtSubjectName.Text = row.Cells["SubjectName"].Value.ToString();
                cmbCourses.SelectedValue = row.Cells["CourseID"].Value;
            }

        }
    }
}
