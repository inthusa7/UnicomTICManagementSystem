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
    public partial class RoomForm : Form
    {
        private RoomController roomController = new RoomController();
        private int selectedRoomId = -1;

        public RoomForm()
        {
            InitializeComponent();
            this.Load += RoomForm_Load;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string roomName = txtRoomName.Text.Trim();
            string roomType = cmbRoomType.SelectedItem?.ToString();

            if (!string.IsNullOrWhiteSpace(roomName) && !string.IsNullOrWhiteSpace(roomType))
            {
                await roomController.AddAsync(new Room { RoomName = roomName, RoomType = roomType });
                txtRoomName.Clear();
                await LoadRooms();
            }
            else
            {
                MessageBox.Show("Please enter room name and select type.");
            }

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedRoomId != -1)
            {
                await roomController.UpdateAsync(new Room
                {
                    RoomId = selectedRoomId,
                    RoomName = txtRoomName.Text.Trim(),
                    RoomType = cmbRoomType.SelectedItem?.ToString()
                });

                txtRoomName.Clear();
                selectedRoomId = -1;
                await LoadRooms();
            }


        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRoomId != -1)
            {
                await roomController.DeleteAsync(selectedRoomId);
                txtRoomName.Clear();
                selectedRoomId = -1;
                await LoadRooms();
            }


        }

        private void dgvRooms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvRooms.Rows[e.RowIndex];
                selectedRoomId = Convert.ToInt32(row.Cells["RoomID"].Value);
                txtRoomName.Text = row.Cells["RoomName"].Value.ToString();
                cmbRoomType.SelectedItem = row.Cells["RoomType"].Value.ToString();
            }

        }

        private async void RoomForm_Load(object sender, EventArgs e)
        {
            cmbRoomType.Items.AddRange(new[] { "Lab 01","Lab 02", "Hall A","Hall B" });
            cmbRoomType.SelectedIndex = 0;
            await LoadRooms();

        }
        private async Task LoadRooms()
        {
            dgvRooms.DataSource = await roomController.GetAllAsync();
        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
