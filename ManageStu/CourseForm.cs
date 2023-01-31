using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ManageStu
{
    public partial class CourseForm : Form
    {
        Course model = new Course();

        public CourseForm()
        {
            InitializeComponent();
        }

        private void Form_LoadData(object sender, EventArgs e)
        {
            LoadData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            this.Close();
        }
        private void LoadData()
        {
            using (StuManagementEntities db = new StuManagementEntities())
            {
               
                dataGridView1.DataSource = db.Courses.ToList();

            }

        }
        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button_Update_Click_1(object sender, EventArgs e)
        {

           
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure??", "EF CRUD OPERATION", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (StuManagementEntities db = new StuManagementEntities())
                {
                    var entry = db.Entry(model);
                    if (entry.State == EntityState.Detached)
                    {
                        db.Courses.Attach(model);
                    }
                    db.Courses.Remove(model);
                    db.SaveChanges();
                    PopulateDataGriview();
                    MessageBox.Show("Delete sucessfully !");
                }
            }
        }

       
        public void Reset()
        {
            TxtCourseName.Text = "";
            TxtCourseSemester.Text = "";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Reset();

        }
        private void PopulateDataGriview()
        {
            dataGridView1.AutoGenerateColumns = false;
            using (StuManagementEntities db = new StuManagementEntities())
            {
                dataGridView1.DataSource = db.Courses.ToList<Course>();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            model.couName = TxtCourseName.Text;
            model.couSemester = Convert.ToInt32(TxtCourseSemester.Text);
            
            using (StuManagementEntities db = new StuManagementEntities())
            {
                if (model.couId == 0)
                {
                    db.Courses.Add(model);
                }
                else db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Submitted Succesfully !");
            PopulateDataGriview();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                model.couId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["couId"].Value);
                using (StuManagementEntities db = new StuManagementEntities())
                {
                    model = db.Courses.Where(x => x.couId == model.couId).FirstOrDefault();
                    TxtId.Text = model.couId.ToString();
                    TxtCourseName.Text = model.couName.ToString();
                    TxtCourseSemester.Text = model.couSemester.ToString();
                }
                btn_save.Text = "Update";
                button_Del.Enabled = true;
                PopulateDataGriview();
            }
        }
    }
}
