namespace UnicomTICManagementSystem.Forms
{
    partial class StaffDashbordForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnMarks = new System.Windows.Forms.Button();
            this.btnTimetable = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnExam = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.btnExam);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btnMarks);
            this.panel1.Controls.Add(this.btnTimetable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 543);
            this.panel1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(71, 412);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 28);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnMarks
            // 
            this.btnMarks.Location = new System.Drawing.Point(71, 290);
            this.btnMarks.Margin = new System.Windows.Forms.Padding(4);
            this.btnMarks.Name = "btnMarks";
            this.btnMarks.Size = new System.Drawing.Size(100, 28);
            this.btnMarks.TabIndex = 2;
            this.btnMarks.Text = "Marks";
            this.btnMarks.UseVisualStyleBackColor = true;
            this.btnMarks.Click += new System.EventHandler(this.btnMarks_Click);
            // 
            // btnTimetable
            // 
            this.btnTimetable.Location = new System.Drawing.Point(71, 65);
            this.btnTimetable.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimetable.Name = "btnTimetable";
            this.btnTimetable.Size = new System.Drawing.Size(100, 28);
            this.btnTimetable.TabIndex = 3;
            this.btnTimetable.Text = "Timetable";
            this.btnTimetable.UseVisualStyleBackColor = true;
            this.btnTimetable.Click += new System.EventHandler(this.btnTimetable_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(267, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(881, 65);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(267, 65);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(881, 478);
            this.panelMain.TabIndex = 0;
            // 
            // btnExam
            // 
            this.btnExam.Location = new System.Drawing.Point(71, 180);
            this.btnExam.Name = "btnExam";
            this.btnExam.Size = new System.Drawing.Size(100, 23);
            this.btnExam.TabIndex = 6;
            this.btnExam.Text = "Exams";
            this.btnExam.UseVisualStyleBackColor = true;
            this.btnExam.Click += new System.EventHandler(this.btnExam_Click);
            // 
            // StaffDashbordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 543);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StaffDashbordForm";
            this.Text = "StaffDashbordForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnMarks;
        private System.Windows.Forms.Button btnTimetable;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnExam;
    }
}