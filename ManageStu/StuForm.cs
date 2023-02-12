using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ManageStu
{
    public partial class StuForm : Form
    {
        Student model = new Student();
        public StuForm()
        {
            InitializeComponent();
            LoadData();
        }


        private void Form_LoadData(object sender, EventArgs e)
        {
            AllowDrop= true;
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                LoadData();

            }
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
                bindingSource1.DataSource = db.Students.ToList();
                dataGridView1.DataSource = bindingSource1;
                bindingNavigator1.BindingSource = bindingSource1;
            }
        }


        public void Reset()
        {
            TxtId.Text = TxtName.Text = TxtAddress.Text = TxtDepId.Text = TxtPhone.Text = TxtEmail.Text = "";
            chkPass.Checked = true;
            chkPass.Text = "Pass or Fail";
            btn_Save.Text = "Save";
            button_Del.Enabled = false;
            model.stuId = 0;
            LoadData();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
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
                        db.Students.Attach(model);
                    }
                    db.Students.Remove(model);
                    db.SaveChanges();
                    LoadData();
                    MessageBox.Show("Delete sucessfully !");
                }
            }
        }
        //private void PopulateDataGriview()
        //{

        //    dataGridView1.AutoGenerateColumns = false;
        //    using (StuManagementEntities1 db = new StuManagementEntities1())
        //    {
        //        dataGridView1.DataSource = db.Students.ToList<Student>();

        //    }
        //}

        private void btn_Save_Click(object sender, EventArgs e)
        {

            model.stuPass = Convert.ToBoolean(chkPass.Checked);
            model.stuName = TxtName.Text.Trim();
            model.stuPhone = TxtPhone.Text.Trim();
            model.stuAddress = TxtAddress.Text.Trim();
            model.stuEmail = TxtEmail.Text.Trim();
            model.depId = TxtDepId.Text.Trim();
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                if (model.stuId == 0)
                {
                    db.Students.Add(model);
                }
                else db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            MessageBox.Show("Submitted Succesfully !");
            LoadData();
        }

        private void dataGridView1_DoubleClick_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                model.stuId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["stuId"].Value);
                using (StuManagementEntities1 db = new StuManagementEntities1())
                {
                    model = db.Students.Where(x => x.stuId == model.stuId).FirstOrDefault();
                    TxtId.Text = model.stuId.ToString();
                    chkPass.Checked = model.stuPass.Value;
                    chkPass.Text = "Pass or Fail";
                    TxtName.Text = model.stuName;
                    TxtPhone.Text = model.stuPhone.ToString();
                    TxtEmail.Text = model.stuEmail;
                    TxtAddress.Text = model.stuAddress;
                    TxtDepId.Text = model.depId;
                }
                btn_Save.Text = "Update";
                button_Del.Enabled = true;
                LoadData();
            }
        }


        private void button_Search_Click(object sender, EventArgs e)
        {
            using (StuManagementEntities1 db = new StuManagementEntities1())
            {
                string kw = textBoxSearch.Text.Trim();
                dataGridView1.DataSource = db.Students
                    .Where(x => x.stuName.Contains(kw)).ToList();
            }
        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            // If you are not at the end of the list, move to the next item
            // in the BindingSource.
            if (bindingSource1.Position + 1 < bindingSource1.Count)
                bindingSource1.MoveNext();

            // Otherwise, move back to the first item.
            else
                bindingSource1.MoveFirst();

            // Force the form to repaint.
            this.Invalidate();
        }
    }
}
