namespace ManageStu
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_mngCourse = new System.Windows.Forms.Button();
            this.button_mngExam = new System.Windows.Forms.Button();
            this.button_mngStu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(551, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Management ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::ManageStu.Properties.Resources.department_80px;
            this.button1.Location = new System.Drawing.Point(1049, 146);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(300, 136);
            this.button1.TabIndex = 4;
            this.button1.Text = "Department";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_mngCourse
            // 
            this.button_mngCourse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_mngCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mngCourse.Image = ((System.Drawing.Image)(resources.GetObject("button_mngCourse.Image")));
            this.button_mngCourse.Location = new System.Drawing.Point(719, 146);
            this.button_mngCourse.Margin = new System.Windows.Forms.Padding(4);
            this.button_mngCourse.Name = "button_mngCourse";
            this.button_mngCourse.Size = new System.Drawing.Size(300, 136);
            this.button_mngCourse.TabIndex = 3;
            this.button_mngCourse.Text = "Manage Course";
            this.button_mngCourse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_mngCourse.UseVisualStyleBackColor = false;
            this.button_mngCourse.Click += new System.EventHandler(this.button_mngCourse_Click);
            // 
            // button_mngExam
            // 
            this.button_mngExam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_mngExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mngExam.Image = ((System.Drawing.Image)(resources.GetObject("button_mngExam.Image")));
            this.button_mngExam.Location = new System.Drawing.Point(382, 146);
            this.button_mngExam.Margin = new System.Windows.Forms.Padding(4);
            this.button_mngExam.Name = "button_mngExam";
            this.button_mngExam.Size = new System.Drawing.Size(300, 136);
            this.button_mngExam.TabIndex = 2;
            this.button_mngExam.Text = "Manage Exam";
            this.button_mngExam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_mngExam.UseVisualStyleBackColor = false;
            this.button_mngExam.Click += new System.EventHandler(this.button_mngExam_Click);
            // 
            // button_mngStu
            // 
            this.button_mngStu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button_mngStu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_mngStu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_mngStu.Image = ((System.Drawing.Image)(resources.GetObject("button_mngStu.Image")));
            this.button_mngStu.Location = new System.Drawing.Point(44, 146);
            this.button_mngStu.Margin = new System.Windows.Forms.Padding(4);
            this.button_mngStu.Name = "button_mngStu";
            this.button_mngStu.Size = new System.Drawing.Size(300, 136);
            this.button_mngStu.TabIndex = 1;
            this.button_mngStu.Text = "Manage Student";
            this.button_mngStu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button_mngStu.UseVisualStyleBackColor = false;
            this.button_mngStu.Click += new System.EventHandler(this.button_mngStu_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1371, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_mngCourse);
            this.Controls.Add(this.button_mngExam);
            this.Controls.Add(this.button_mngStu);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_mngStu;
        private System.Windows.Forms.Button button_mngExam;
        private System.Windows.Forms.Button button_mngCourse;
        private System.Windows.Forms.Button button1;
    }
}