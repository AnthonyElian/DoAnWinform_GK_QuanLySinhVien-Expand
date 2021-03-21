using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    public partial class UpdateDeleteStudentForm : Form
    {
        Student student = new Student();
        public UpdateDeleteStudentForm()
        {
            InitializeComponent();
        }

        private void btnSE_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtStuID.Text);
            SqlCommand cmd = new SqlCommand("SELECT ID, fname, lname, bdate, gender, phone, address, picture FROM AddStudent WHERE ID = " + id);

            DataTable table = student.getStudent(cmd);

            if (table.Rows.Count > 0)
            {
                this.txtfName.Text = table.Rows[0]["fname"].ToString();
                this.txtlName.Text = table.Rows[0]["lname"].ToString();
                this.dBirDate.Value = (DateTime)table.Rows[0]["bdate"];

                if (table.Rows[0]["gender"].ToString() == "Female")
                {
                    this.rbFemale.Checked = true;
                }
                else
                {
                    this.rbMale.Checked = true;
                }

                this.txtPhone.Text = table.Rows[0]["phone"].ToString();
                this.txtAdrs.Text = table.Rows[0]["address"].ToString();

                byte[] pic;
                pic = (byte[])table.Rows[0]["picture"];
                MemoryStream picture = new MemoryStream(pic);
                this.picBox.Image = Image.FromStream(picture);
            }
            else
            {
                MessageBox.Show("Not Found", "Find Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSE_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int stuID = Convert.ToInt32(this.txtStuID.Text);
                if (MessageBox.Show("Are You Sure ?!?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (student.deleteStu(stuID))
                    {
                        MessageBox.Show("Student Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtStuID.Text = "";
                        this.txtfName.Text = "";
                        this.txtlName.Text = "";
                        this.txtAdrs.Text = "";
                        this.txtPhone.Text = "";
                        this.dBirDate.Value = DateTime.Now;
                        this.picBox.Image = null;
                    }
                    else
                        MessageBox.Show("Student Not Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Please Enter A Valid ID", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg; *.png; *gif)|*.jpg; *.png; *.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                this.picBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private bool checkGender()
        {
            if (this.rbFemale.Checked == true || this.rbMale.Checked == true)
                return true;
            else
                return false;
        }

        private bool verify()
        {
            if ((this.txtfName.Text.Trim() == "") || this.txtlName.Text.Trim() == ""
                || this.txtStuID.Text.Trim() == "" || this.txtAdrs.Text.Trim() == ""
                || this.checkGender() == false)
            {
                return false;
            }
            else
                return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id;
            string fname = this.txtfName.Text;
            string lname = this.txtlName.Text;
            DateTime bdate = this.dBirDate.Value;
            string phone = this.txtPhone.Text;
            string adrs = this.txtAdrs.Text;
            string gender = "Male";

            if (this.rbFemale.Checked)
            {
                gender = "Female";
            }

            MemoryStream pic = new MemoryStream();
            int born_year = this.dBirDate.Value.Year;
            int curr_year = DateTime.Now.Year;
            if (((curr_year - born_year) < 18) || ((curr_year - born_year) > 100))
            {
                MessageBox.Show("The Student Age Must Be Between 18 and 100 years old", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (verify())
            {
                try
                {
                    id = Convert.ToInt32(this.txtStuID.Text);
                    this.picBox.Image.Save(pic, this.picBox.Image.RawFormat);
                    if (student.updateStu(id, fname, lname, bdate, gender, phone, adrs, pic))
                    {
                        MessageBox.Show("Student Information Updated", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }   
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
