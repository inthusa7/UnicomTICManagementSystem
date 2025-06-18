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
    public partial class StaffForm : Form
    {
        private readonly StaffController controller = new StaffController();
        private int selectedStaffId = -1;
        public StaffForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {

        }
        private async void LoadData()
        {
            dgvStaff.DataSource = await controller.GetAllAsync();
        }

        

        

        private async void btnAdd_Click_1(object sender, EventArgs e)
        {
            var staff = new Staff
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                JobTitle = txtJobTitle.Text
            };
            await controller.AddAsync(staff);
            LoadData();
        }

        private async void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (selectedStaffId != -1)
            {
                var staff = new Staff
                {
                    StaffID = selectedStaffId,
                    Name = txtName.Text,
                    Address = txtAddress.Text,
                    JobTitle = txtJobTitle.Text
                };
                await controller.UpdateAsync(staff);
                LoadData();
            }

        }

        private async void btnDelete_Click_1(object sender, EventArgs e)
        {

            if (selectedStaffId != -1)
            {
                await controller.DeleteAsync(selectedStaffId);
                LoadData();
            }

        }

        private void dgvStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStaff.Rows[e.RowIndex];
                selectedStaffId = Convert.ToInt32(row.Cells["StaffID"].Value);
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtJobTitle.Text = row.Cells["JobTitle"].Value.ToString();
            }
        }
    }
}
