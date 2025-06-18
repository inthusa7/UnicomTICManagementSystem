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
    public partial class TimetableForm : Form
    {
        private TimetableController timetableController = new TimetableController();
        private SubjectController subjectController = new SubjectController();
        private RoomController roomController = new RoomController();
        private int selectedTimetableId = -1;

        public TimetableForm()
        {
            InitializeComponent();
            this.Load += TimetableForm_Load;
        }

        private async void TimetableForm_Load(object sender, EventArgs e)
        {
            await LoadSubjects();
            await LoadRooms();
            await LoadTimetables();

        }
        private async Task LoadSubjects()
        {
            var subjects = await subjectController.GetAllAsync();
            cmbSubjects.DataSource = subjects;
            cmbSubjects.DisplayMember = "SubjectName";
            cmbSubjects.ValueMember = "SubjectID";
        }

        private async Task LoadRooms()
        {
            var rooms = await roomController.GetAllAsync();
            cmbRooms.DataSource = rooms;
            cmbRooms.DisplayMember = "RoomName";
            cmbRooms.ValueMember = "RoomID";
        }

        private async Task LoadTimetables()
        {
            dgvTimetables.DataSource = await timetableController.GetAllAsync();
        }


        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var t = new Timetable
            {
                SubjectID = Convert.ToInt32(cmbSubjects.SelectedValue),
                RoomID = Convert.ToInt32(cmbRooms.SelectedValue),
                TimeSlot = txtTimeSlot.Text.Trim()
            };

            await timetableController.AddAsync(t);
            txtTimeSlot.Clear();
            await LoadTimetables();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId != -1)
            {
                await timetableController.UpdateAsync(new Timetable
                {
                    TimetableID = selectedTimetableId,
                    SubjectID = Convert.ToInt32(cmbSubjects.SelectedValue),
                    RoomID = Convert.ToInt32(cmbRooms.SelectedValue),
                    TimeSlot = txtTimeSlot.Text.Trim()
                });

                txtTimeSlot.Clear();
                selectedTimetableId = -1;
                await LoadTimetables();
            }



        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTimetableId != -1)
            {
                await timetableController.DeleteAsync(selectedTimetableId);
                txtTimeSlot.Clear();
                selectedTimetableId = -1;
                await LoadTimetables();
            }

        }

        private void dgvTimetable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvTimetables.Rows[e.RowIndex];
            selectedTimetableId = Convert.ToInt32(row.Cells["TimetableID"].Value);
            cmbSubjects.SelectedValue = row.Cells["SubjectID"].Value;
            cmbRooms.SelectedValue = row.Cells["RoomID"].Value;
            txtTimeSlot.Text = row.Cells["TimeSlot"].Value.ToString();

        }
    }
}
