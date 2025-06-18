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
using UnicomTICManagementSystem.Models;

namespace UnicomTICManagementSystem.Forms
{
    public partial class LecturerForm : Form
    {
        private readonly LecturerController controller = new LecturerController();
        private readonly CourseController courseController = new CourseController(); 
        private readonly SubjectController subjectController = new SubjectController();
        private int selectedId = -1;
        public LecturerForm()
        {
            InitializeComponent();
            Load += LecturerForm_Load;
        }
        

        private async void LecturerForm_Load(object sender, EventArgs e)
        {
            await LoadCourses();
            await LoadSubjects();
            await LoadLecturers();

        }
        private async Task LoadCourses()
        {
            cmbCourse.DataSource = await courseController.GetAllCoursesAsync();
            cmbCourse.DisplayMember = "CourseName";
            cmbCourse.ValueMember = "CourseID";
        }

        private async Task LoadSubjects()
        {
            cmbSubject.DataSource = await subjectController.GetAllAsync();
            cmbSubject.DisplayMember = "SubjectName";
            cmbSubject.ValueMember = "SubjectID";
        }

        private async Task LoadLecturers()
        {
            dgvLecturers.DataSource = await controller.GetAllAsync();
            dgvLecturers.ReadOnly = true;
            dgvLecturers.AllowUserToAddRows = false;
        }

        
        private void ClearFields()
        {
            txtName.Clear();
            txtAddress.Clear();
            selectedId = -1;
        }

        private async void btnAdd_Click_1(object sender, EventArgs e)
        {
            var lec = new Lecturer
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                CourseID = Convert.ToInt32(cmbCourse.SelectedValue),
                SubjectID = Convert.ToInt32(cmbSubject.SelectedValue)
            };
            await controller.AddAsync(lec);
            await LoadLecturers();
            ClearFields();


        }

        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (selectedId != -1)
            {
                var lec = new Lecturer
                {
                    LecturerID = selectedId,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    CourseID = Convert.ToInt32(cmbCourse.SelectedValue),
                    SubjectID = Convert.ToInt32(cmbSubject.SelectedValue)
                };
                await controller.UpdateAsync(lec);
                await LoadLecturers();
                ClearFields();
            }

        }

        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (selectedId != -1)
            {
                await controller.DeleteAsync(selectedId);
                await LoadLecturers();
                ClearFields();
            }

        }

        private void dgvLecturers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvLecturers.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["LecturerID"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                cmbCourse.SelectedValue = row.Cells["CourseID"].Value;
                cmbSubject.SelectedValue = row.Cells["SubjectID"].Value;
            }

        }
    }

}


