using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomTICManagementSystem.Forms
{
    public partial class StaffDashbordForm : Form
    {
        private int staffId;
        public StaffDashbordForm(int id)
        {
            InitializeComponent();
            staffId = id;
        }
        public void LoadForm(object formObj)
        {
            if (this.panelMain.Controls.Count > 0)
            {
                this.panelMain.Controls.RemoveAt(0);
            }
            Form form = formObj as Form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(form);
            this.panelMain.Tag = form;
            form.Show();



        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            LoadForm(new ReadOnlyTimetableForm("Staff", 0)); 
        
        }

        private void btnMarks_Click(object sender, EventArgs e)
        {
            LoadForm(new MarksForm());
        }

       

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoadForm(new LoginForm());

        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            LoadForm(new ExamForm());
        }
    }
}
