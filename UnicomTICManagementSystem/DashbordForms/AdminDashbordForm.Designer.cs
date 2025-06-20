namespace UnicomTICManagementSystem.Forms
{
    partial class AdminDashbordForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCourse = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnSubject = new System.Windows.Forms.Button();
            this.btnExam = new System.Windows.Forms.Button();
            this.btnMarks = new System.Windows.Forms.Button();
            this.btnRoom = new System.Windows.Forms.Button();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStaff = new System.Windows.Forms.Button();
            this.btnCourses = new System.Windows.Forms.Button();
            this.btnLecturer = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCourse
            // 
            this.btnCourse.Location = new System.Drawing.Point(21, 18);
            this.btnCourse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCourse.Name = "btnCourse";
            this.btnCourse.Size = new System.Drawing.Size(56, 19);
            this.btnCourse.TabIndex = 0;
            this.btnCourse.Text = "Course";
            this.btnCourse.UseVisualStyleBackColor = true;
            this.btnCourse.Click += new System.EventHandler(this.btnCourse_Click);
            // 
            // btnStudent
            // 
            this.btnStudent.Location = new System.Drawing.Point(41, 51);
            this.btnStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(68, 19);
            this.btnStudent.TabIndex = 1;
            this.btnStudent.Text = "Students";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnSubject
            // 
            this.btnSubject.Location = new System.Drawing.Point(41, 193);
            this.btnSubject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubject.Name = "btnSubject";
            this.btnSubject.Size = new System.Drawing.Size(68, 19);
            this.btnSubject.TabIndex = 2;
            this.btnSubject.Text = "Subjects";
            this.btnSubject.UseVisualStyleBackColor = true;
            this.btnSubject.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnExam
            // 
            this.btnExam.Location = new System.Drawing.Point(41, 227);
            this.btnExam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExam.Name = "btnExam";
            this.btnExam.Size = new System.Drawing.Size(68, 19);
            this.btnExam.TabIndex = 3;
            this.btnExam.Text = "Exam";
            this.btnExam.UseVisualStyleBackColor = true;
            this.btnExam.Click += new System.EventHandler(this.btnExam_Click);
            // 
            // btnMarks
            // 
            this.btnMarks.Location = new System.Drawing.Point(41, 260);
            this.btnMarks.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMarks.Name = "btnMarks";
            this.btnMarks.Size = new System.Drawing.Size(68, 19);
            this.btnMarks.TabIndex = 4;
            this.btnMarks.Text = "Marks";
            this.btnMarks.UseVisualStyleBackColor = true;
            this.btnMarks.Click += new System.EventHandler(this.btnMarks_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.Location = new System.Drawing.Point(41, 295);
            this.btnRoom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Size = new System.Drawing.Size(68, 19);
            this.btnRoom.TabIndex = 5;
            this.btnRoom.Text = "Room";
            this.btnRoom.UseVisualStyleBackColor = true;
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // btnTimetable
            // 
            this.btnTimetable.Location = new System.Drawing.Point(41, 332);
            this.btnTimetable.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Size = new System.Drawing.Size(68, 19);
            this.btnTimetable.TabIndex = 6;
            this.btnTimetable.Text = "TimeTable";
            this.btnTimetable.UseVisualStyleBackColor = true;
            this.btnTimetable.Click += new System.EventHandler(this.btnTimetable_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(41, 373);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(68, 19);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.btnStaff);
            this.panel1.Controls.Add(this.btnCourses);
            this.panel1.Controls.Add(this.btnLecturer);
            this.panel1.Controls.Add(this.btnStudent);
            this.panel1.Controls.Add(this.btnSubject);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnExam);
            this.panel1.Controls.Add(this.btnTimetable);
            this.panel1.Controls.Add(this.btnMarks);
            this.panel1.Controls.Add(this.btnRoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(163, 443);
            this.panel1.TabIndex = 8;
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(41, 122);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(68, 19);
            this.btnStaff.TabIndex = 13;
            this.btnStaff.Text = "Staff";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // btnCourses
            // 
            this.btnCourses.Location = new System.Drawing.Point(41, 157);
            this.btnCourses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(68, 19);
            this.btnCourses.TabIndex = 12;
            this.btnCourses.Text = "Courses";
            this.btnCourses.UseVisualStyleBackColor = true;
            this.btnCourses.Click += new System.EventHandler(this.btnCourses_Click);
            // 
            // btnLecturer
            // 
            this.btnLecturer.Location = new System.Drawing.Point(41, 87);
            this.btnLecturer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLecturer.Name = "btnLecturer";
            this.btnLecturer.Size = new System.Drawing.Size(68, 19);
            this.btnLecturer.TabIndex = 11;
            this.btnLecturer.Text = "Lecturer";
            this.btnLecturer.UseVisualStyleBackColor = true;
            this.btnLecturer.Click += new System.EventHandler(this.btnLecturer_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(163, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(697, 37);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(163, 37);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(697, 406);
            this.panelMain.TabIndex = 10;
            // 
            // AdminDashbordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 443);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCourse);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdminDashbordForm";
            this.Text = "AdminDashbordForm";
            this.Load += new System.EventHandler(this.AdminDashbordForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCourse;
        private System.Windows.Forms.Button btnStudent;
        private System.Windows.Forms.Button btnSubject;
        private System.Windows.Forms.Button btnExam;
        private System.Windows.Forms.Button btnMarks;
        private System.Windows.Forms.Button btnRoom;
        private System.Windows.Forms.Button btnTimetable;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnLecturer;
        private System.Windows.Forms.Button btnCourses;
        private System.Windows.Forms.Button btnStaff;
    }
}