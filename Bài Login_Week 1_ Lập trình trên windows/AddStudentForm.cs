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
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            int ID = Convert.ToInt32(this.txtStuID.Text);
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
            if (((curr_year - born_year) < 18 ) || ((curr_year - born_year)>100))
            {
                MessageBox.Show("The Student Age Must Be Between 18 and 100 years old", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (verify())
            {
                this.picBox.Image.Save(pic, this.picBox.Image.RawFormat);
                if (student.insertStudent(ID, fname, lname, bdate, gender, phone, adrs, pic))
                {
                    MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnUpImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if ((opf.ShowDialog() == DialogResult.OK))
            {
                this.picBox.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
