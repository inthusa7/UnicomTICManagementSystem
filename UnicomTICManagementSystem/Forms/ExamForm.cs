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
    public partial class ExamForm : Form
    {
        private ExamController examController = new ExamController();
        private SubjectController subjectController = new SubjectController();
        private int selectedExamId = -1;

        public ExamForm()
        {
            InitializeComponent();
            this.Load += ExamForm_Load;

        }

        private async void ExamForm_Load(object sender, EventArgs e)
        {
            await LoadSubjects();
            await LoadExams();

        }
        private async Task LoadSubjects()
        {
            var subjects = await subjectController.GetAllAsync();
            cmbSubjects.DataSource = subjects;
            cmbSubjects.DisplayMember = "SubjectName";
            cmbSubjects.ValueMember = "SubjectID";
        }
        private async Task LoadExams()
        {
            dgvExams.DataSource = await examController.GetAllAsync();
        }





        private void txtExamName_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string examName = txtExamName.Text.Trim();
            int subjectId = Convert.ToInt32(cmbSubjects.SelectedValue);

            if (!string.IsNullOrWhiteSpace(examName))
            {
                await examController.AddAsync(new Exam { ExamName = examName, SubjectID = subjectId });
                txtExamName.Clear();
                await LoadExams();
            }
            else
            {
                MessageBox.Show("Please enter exam name.");
            }

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedExamId != -1)
            {
                await examController.UpdateAsync(new Exam
                {
                    ExamId = selectedExamId,
                    ExamName = txtExamName.Text.Trim(),
                    SubjectID = Convert.ToInt32(cmbSubjects.SelectedValue)
                });

                txtExamName.Clear();
                selectedExamId = -1;
                await LoadExams();
            }

        }

        private void dgvExams_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                var row = dgvExams.Rows[e.RowIndex];
                selectedExamId = Convert.ToInt32(row.Cells["ExamID"].Value);
                txtExamName.Text = row.Cells["ExamName"].Value.ToString();
                cmbSubjects.SelectedValue = row.Cells["SubjectID"].Value;
            }

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedExamId != -1)
            {
                await examController.DeleteAsync(selectedExamId);
                txtExamName.Clear();
                selectedExamId = -1;
                await LoadExams();
            }
        }
    }
}
