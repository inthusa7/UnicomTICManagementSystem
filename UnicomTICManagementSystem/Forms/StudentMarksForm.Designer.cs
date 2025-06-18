namespace UnicomTICManagementSystem.Forms
{
    partial class StudentMarksForm
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
            this.dgvStudentMarks = new System.Windows.Forms.DataGridView();
            this.lblHeading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentMarks)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStudentMarks
            // 
            this.dgvStudentMarks.AllowUserToAddRows = false;
            this.dgvStudentMarks.AllowUserToDeleteRows = false;
            this.dgvStudentMarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentMarks.Location = new System.Drawing.Point(104, 125);
            this.dgvStudentMarks.Name = "dgvStudentMarks";
            this.dgvStudentMarks.ReadOnly = true;
            this.dgvStudentMarks.RowHeadersWidth = 51;
            this.dgvStudentMarks.RowTemplate.Height = 24;
            this.dgvStudentMarks.Size = new System.Drawing.Size(521, 282);
            this.dgvStudentMarks.TabIndex = 0;
            this.dgvStudentMarks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.Location = new System.Drawing.Point(101, 36);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(119, 16);
            this.lblHeading.TabIndex = 1;
            this.lblHeading.Text = "Welcome,Student !";
            // 
            // StudentMarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 521);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.dgvStudentMarks);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StudentMarksForm";
            this.Text = "StudentMarksForm";
            this.Load += new System.EventHandler(this.StudentMarksForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentMarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudentMarks;
        private System.Windows.Forms.Label lblHeading;
    }
}