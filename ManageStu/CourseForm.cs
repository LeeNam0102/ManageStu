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
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                bindingSource1.DataSource = db.Courses.ToList();
                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;

            }

        }
        private void CourseForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void button_Del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure??", "EF CRUD OPERATION", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (StuManagementEntities1 db = new StuManagementEntities1())
                {
                    var entry = db.Entry(model);
                    if (entry.State == EntityState.Detached)
                    {
                        db.Courses.Attach(model);
                    }
                    db.Courses.Remove(model);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Delete sucessfully !");
                }
            }
        }

       
        public void Reset()
        {
            TxtCourseName.Text = "";
            TxtCourseSemester.Text = "";
            LoadData();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Reset();

        }
        //private void PopulateDataGriview()
        //{
        //    dataGridView1.AutoGenerateColumns = false;
        //    using (StuManagementEntities1 db = new StuManagementEntities1())
        //    {
        //        dataGridView1.DataSource = db.Courses.ToList<Course>();
        //    }
        //}

        private void save_Click(object sender, EventArgs e)
        {
            model.couName = TxtCourseName.Text;
            model.couSemester = Convert.ToInt32(TxtCourseSemester.Text);
            
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                if (model.couId == 0)
                {
                    db.Courses.Add(model);
                }
                else db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Submitted Succesfully !");
            LoadData();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                model.couId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["couId"].Value);
                using (StuManagementEntities1 db = new StuManagementEntities1())
                {
                    model = db.Courses.Where(x => x.couId == model.couId).FirstOrDefault();
                    TxtId.Text = model.couId.ToString();
                    TxtCourseName.Text = model.couName.ToString();
                    TxtCourseSemester.Text = model.couSemester.ToString();
                }
                btn_save.Text = "Update";
                button_Del.Enabled = true;
                LoadData();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                string kw = textBoxSearch.Text.Trim();
                dataGridView1.DataSource = db.Courses
                    .Where(x => x.couName.Contains(kw)).ToList();
            }
        }
    }
}
