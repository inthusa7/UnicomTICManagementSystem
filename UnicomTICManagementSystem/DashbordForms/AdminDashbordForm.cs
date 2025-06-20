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
    public partial class AdminDashbordForm : Form
    {
        public AdminDashbordForm()
        {
            InitializeComponent();
            LoadForm(new WelcomePanel());
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

        private void button3_Click(object sender, EventArgs e)
        {
            LoadForm(new SubjectForm());

        }

        private void btnCourse_Click(object sender, EventArgs e)
        {
            LoadForm(new CourseForm());

        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            LoadForm(new StudentForm());

        }

        private void btnExam_Click(object sender, EventArgs e)
        {
            LoadForm(new ExamForm());
        }

        private void AdminDashbordForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            LoadForm(new RoomForm());

        }

        private void btnTimetable_Click(object sender, EventArgs e)
        {
            LoadForm(new TimetableForm());

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

        private void btnLecturer_Click(object sender, EventArgs e)
        {
            LoadForm(new LecturerForm());
        }

        private void btnCourses_Click(object sender, EventArgs e)
        {
            LoadForm(new CourseForm());
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            LoadForm(new StaffForm());
        }
        //private Panel panelMain;
        // private Button btnCourse

    }

    public class WelcomePanel : Form 
    {
        public WelcomePanel() 
        { 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(new Label
            {
                Text = "Welcome to Admin ",
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold),
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            });

        }
    }
    
}

