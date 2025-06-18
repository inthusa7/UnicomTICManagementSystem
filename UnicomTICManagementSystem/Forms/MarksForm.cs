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
    public partial class MarksForm : Form
    {
        private MarksController marksController = new MarksController();
        private StudentController studentController = new StudentController();
        private ExamController examController = new ExamController();
        private int selectedMarkId = -1;

        public MarksForm()
        {
            InitializeComponent();
            this.Load += MarksForm_Load;
        }

        private async void MarksForm_Load(object sender, EventArgs e)
        {
            await LoadStudents();
            await LoadExams();
            await LoadMarks();

        }
        private async Task LoadStudents()
        {
            var students = await studentController.GetAllAsync();
            cmbStudents.DataSource = students;
            cmbStudents.DisplayMember = "StudentName";
            cmbStudents.ValueMember = "StudentID";
        }

        private async Task LoadExams()
        {
            var exams = await examController.GetAllAsync();
            cmbExams.DataSource = exams;
            cmbExams.DisplayMember = "ExamName";
            cmbExams.ValueMember = "ExamID";
        }

        private async Task LoadMarks()
        {
            dgvMarks.DataSource = await marksController.GetAllAsync();
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(cmbStudents.SelectedValue);
            int examId = Convert.ToInt32(cmbExams.SelectedValue);
            int score = Convert.ToInt32(txtScore.Text);

            await marksController.AddAsync(new Mark
            {
                StudentID = studentId,
                ExamID = examId,
                Score = score
            });

            txtScore.Clear();
            await LoadMarks();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedMarkId != -1)
            {
                await marksController.UpdateAsync(new Mark
                {
                    MarkID = selectedMarkId,
                    StudentID = Convert.ToInt32(cmbStudents.SelectedValue),
                    ExamID = Convert.ToInt32(cmbExams.SelectedValue),
                    Score = Convert.ToInt32(txtScore.Text)
                });

                txtScore.Clear();
                selectedMarkId = -1;
                await LoadMarks();
            }

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMarkId != -1)
            {
                await marksController.DeleteAsync(selectedMarkId);
                txtScore.Clear();
                selectedMarkId = -1;
                await LoadMarks();
            }

        }

        private void dgvMarks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMarks.Rows[e.RowIndex];
                selectedMarkId = Convert.ToInt32(row.Cells["MarkID"].Value);
                cmbStudents.SelectedValue = row.Cells["StudentID"].Value;
                cmbExams.SelectedValue = row.Cells["ExamID"].Value;
                txtScore.Text = row.Cells["Score"].Value.ToString();
            }

        }
    }
}
