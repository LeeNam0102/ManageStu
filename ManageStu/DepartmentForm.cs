using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageStu
{

    public partial class DepartmentForm : Form
    {
        Department model = new Department();
        public DepartmentForm()
        {
            InitializeComponent();
        }

        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            AllowDrop = true;
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                LoadData();

            }
        }
        private void LoadData()
        {
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                bindingSource1.DataSource = db.Departments.ToList();
                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            model.depName = txtDepName.Text.Trim();

            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                if (model.depId == 0)
                {
                    db.Departments.Add(model);
                }
                else db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Submitted Succesfully !");
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
                        db.Departments.Attach(model);
                    }
                    db.Departments.Remove(model);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Delete sucessfully !");
                }
            }
        }
        public void Reset()
        {
           txtDepId.Text=txtDepName.Text = "";
           
            LoadData();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
            this.Close();
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow.Index != -1)
            {
                model.depId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["stuId"].Value);
                using (StuManagementEntities1 db = new StuManagementEntities1())
                {
                    model = db.Departments.Where(x => x.depId == model.depId).FirstOrDefault();
                    txtDepId.Text = model.depId.ToString();
                    txtDepName.Text = model.depName.ToString();
                }
                btn_Save.Text = "Update";
                button_Del.Enabled = true;
                LoadData();
            }
        }
    }

}
