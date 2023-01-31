using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageStu
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_mngStu_Click(object sender, EventArgs e)
        {
            this.Hide();
            StuForm stuFrom = new StuForm();
            stuFrom.ShowDialog();
            this.Close();
        }

        private void button_mngExam_Click(object sender, EventArgs e)
        {
            this.Hide();
            ExamForm examFrom = new ExamForm();
            examFrom.ShowDialog();
            this.Close();
        }

        private void button_mngCourse_Click(object sender, EventArgs e)
        {
            this.Hide();
            CourseForm examFrom = new CourseForm();
            examFrom.ShowDialog();
            this.Close();
        }
    }
}
