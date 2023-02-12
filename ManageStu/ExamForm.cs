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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ManageStu
{
    public partial class ExamForm : Form
    {
        public ExamForm()
        {
            InitializeComponent();
            LoadData();
        }
        Exam model = new Exam();


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
                bindingSource1.DataSource = db.Exams.ToList();
                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;

            }
        }

        private void ExamForm_Load(object sender, EventArgs e)
        {
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                foreach (var item in db.Students)
                {
                    comboBoxStuId.Items.Add(item.stuId);

                }
                foreach (var item in db.Courses)
                {
                    comboBoxCouId.Items.Add(item.couId);

                }
            }
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
                        db.Exams.Attach(model);
                    }
                    db.Exams.Remove(model);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Delete sucessfully");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double max = 0;
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                foreach (var item in db.Exams)
                {
                    if (item.examMark > max)
                    {
                        max = item.examMark.Value;
                        List<Exam> listMax = new List<Exam>();
                        foreach (var a in db.Exams)
                        {
                            if (a.examMark == max)
                            {
                                listMax.Add(a);
                            }
                        }
                        dataGridView1.DataSource = listMax;

                    }
                }
            }
        }

        public void Reset()
        {
            TxtId.Clear();

            TxtName.Text = "";
            TxtMark.Text = "";

            btn_Save.Text = "Save";
            button_Del.Enabled = false;
            LoadData();


        }
        //button Reset


        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            model.examName = TxtName.Text;
            model.examMark = Convert.ToInt64(TxtMark.Text);
            model.examDate = Convert.ToDateTime(dateTimePicker1.Value);
            model.stuId = Convert.ToInt32(comboBoxStuId.SelectedItem.ToString());

            model.couId = Convert.ToInt32(comboBoxCouId.SelectedItem.ToString());
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                if (model.examId == 0)
                {
                    db.Exams.Add(model);
                }
                else db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Submitted Succesfully !!!");
            LoadData();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                model.examId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["examId"].Value);
                using (StuManagementEntities1 db = new StuManagementEntities1())
                {
                    model = db.Exams.Where(x => x.examId == model.examId).FirstOrDefault();
                    TxtId.Text = model.examId.ToString();
                    TxtName.Text = model.examName.ToString();
                    TxtMark.Text = model.examMark.ToString();
                    dateTimePicker1.Text = model.examDate.ToString();
                    comboBoxStuId.Text = model.stuId.ToString();
                    comboBoxCouId.Text = model.couId.ToString();
                }
                btn_Save.Text = "Update";
                button_Del.Enabled = true;
                LoadData();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                string kw = textBoxSearch.Text.Trim();
                dataGridView1.DataSource = db.Exams
                    .Where(x => x.examName.Contains(kw)).ToList();
            }
        }
    }
}