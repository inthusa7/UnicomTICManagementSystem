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

namespace UnicomTICManagementSystem.Forms
{
    public partial class ReadOnlyTimetableForm : Form
    {
        private readonly string role;
        private readonly int userId;
        private readonly TimetableController controller = new TimetableController();




        public ReadOnlyTimetableForm(string role, int userId)
        
        {
            InitializeComponent();
            this.role = role;
            this.userId = userId;
            this.Load += ReadOnlyTimetableForm_Load;


        }

        private async void ReadOnlyTimetableForm_Load(object sender, EventArgs e)
        {
            DataTable timetable = null;

            if (role == "Student")
            {
                timetable = await controller.GetTimetableForStudentAsync(userId);
            }
            else if (role == "Lecturer")
            {
                timetable = await controller.GetTimetableByLecturerIdAsync(userId);
            }
            else if (role == "Staff" || role == "Admin")
            {
                timetable = await controller.GetAllTimetablesAsync(); 
            }

            if (timetable != null)
            {
                dgvTimetable.DataSource = timetable;
                dgvTimetable.ReadOnly = true;
                dgvTimetable.AllowUserToAddRows = false;
                dgvTimetable.AllowUserToDeleteRows = false;
                dgvTimetable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("No timetable data available.");
            }


        }
    }
}
