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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UnicomTICManagementSystem.Forms
{
    public partial class StudentMarksForm : Form
    {
        
        private readonly int studentId;
        private readonly MarksController marksController = new MarksController();



        public StudentMarksForm(int id)
        {
            InitializeComponent();
            studentId = id;
            this.Load += StudentMarksForm_Load_1;

            
        }

        
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }
        
        private async void StudentMarksForm_Load_1(object sender, EventArgs e)
        {
            DataTable marksTable = await marksController.GetStudentMarksDetailedAsync(studentId);
            dgvStudentMarks.DataSource = marksTable;

            dgvStudentMarks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudentMarks.ReadOnly = true;
            dgvStudentMarks.AllowUserToAddRows = false;
            dgvStudentMarks.AllowUserToDeleteRows = false;




        }
    }
}
