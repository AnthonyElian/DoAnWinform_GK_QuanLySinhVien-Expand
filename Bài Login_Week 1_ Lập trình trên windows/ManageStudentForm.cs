using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    public partial class ManageStudentForm : Form
    {
        Student student = new Student();
        public ManageStudentForm()
        {
            InitializeComponent();
        }

        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            this.FillGrid(new SqlCommand("Select * from AddStudent"));
        }

        private void FillGrid(SqlCommand cmd)
        {
            this.dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            this.dataGridView1.RowTemplate.Height = 80;
            this.dataGridView1.DataSource = student.getStudent(cmd);
            picCol = (DataGridViewImageColumn)this.dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            this.dataGridView1.AllowUserToAddRows = false;
            this.lbTotal.Text = ("Total  Student: " + dataGridView1.Rows.Count);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();
            SqlConnection con = db.GetConnection;
            if (this.cBSearch.SelectedIndex == 1)
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM AddStudent WHERE fname = @fname", con);
                cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = this.txtSearch.Text;
                this.FillGrid(cmd);
                //da.SelectCommand = cmd;
                //da.Fill(dt);
                //this.dataGridView1.DataSource = dt;
                //db.closeConnection();
            }
            else
            {
                if (this.cBSearch.SelectedIndex == 0)
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM AddStudent WHERE phone = @phone", con);
                    cmd.Parameters.Add("@phone", SqlDbType.NChar).Value = this.txtSearch.Text;
                    this.FillGrid(cmd);
                    //da.SelectCommand = cmd;
                    //da.Fill(dt);
                    //this.dataGridView1.DataSource = dt;
                    //db.closeConnection();
                }
                else if (this.cBSearch.SelectedIndex == 2)
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM AddStudent WHERE fname LIKE N'%" + this.txtSearch.Text + "%'", con);
                    this.FillGrid(cmd);
                    //da.Fill(dt);
                    //this.dataGridView1.DataSource = dt;
                    //db.closeConnection();
                }
                else if (this.cBSearch.SelectedIndex == 3)
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM AddStudent WHERE lname = @lname", con);
                    cmd.Parameters.Add("@lname", SqlDbType.NVarChar).Value = this.txtSearch.Text;
                    this.FillGrid(cmd);
                }
                else if (this.cBSearch.SelectedIndex == 4)
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM AddStudent WHERE lname LIKE N'%" + this.txtSearch.Text + "%'", con);
                    this.FillGrid(cmd);
                }
                else if (this.cBSearch.SelectedIndex == 5)
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM AddStudent WHERE Address = @adrs", con);
                    cmd.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = this.txtSearch.Text;
                    this.FillGrid(cmd);
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM AddStudent WHERE ID = @id", con);
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = this.txtSearch.Text;
                    this.FillGrid(cmd);
                }
            }
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
            if (((curr_year - born_year) < 18) || ((curr_year - born_year) > 100))
            {
                MessageBox.Show("The Student Age Must Be Between 18 and 100 years old", "Invalid Birth Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (verify())
            {
                this.picBox.Image.Save(pic, this.picBox.Image.RawFormat);
                if (student.insertStudent(ID, fname, lname, bdate, gender, phone, adrs, pic))
                {
                    MessageBox.Show("New Student Added", "Add Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.FillGrid(new SqlCommand("select * from AddStudent"));
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
                        this.FillGrid(new SqlCommand("select * from AddStudent"));
                    }
                    else
                    {
                        MessageBox.Show("Error", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Empty Fields", "Edit Student", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        this.FillGrid(new SqlCommand("select * from AddStudent"));
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtStuID.Text = "";
            this.txtAdrs.Text = "";
            this.txtfName.Text = "";
            this.txtlName.Text = "";
            this.txtPhone.Text = "";
            this.txtSearch.Text = "";
            this.picBox.Image = null;
            this.rbMale.Checked = true;
            this.dBirDate.Value = DateTime.Now;
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            this.txtStuID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            this.txtfName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.txtlName.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.dBirDate.Value = (DateTime)this.dataGridView1.CurrentRow.Cells[3].Value;

            if (this.dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female")
            {
                this.rbFemale.Checked = true;
            }
            else
                this.rbMale.Checked = true;

            this.txtPhone.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            this.txtAdrs.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();

            byte[] pic;
            pic = (byte[])this.dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            this.picBox.Image = Image.FromStream(picture);
        }

        private void btnDowl_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();
            svf.FileName = ("student_" + this.txtStuID.Text);
            if (this.picBox.Image == null)
            {
                MessageBox.Show("No image in the picbox");
            }
            else if (svf.ShowDialog() == DialogResult.OK)
            {
                this.picBox.Image.Save((svf.FileName + ("." + ImageFormat.Jpeg.ToString())));
            }
        }
    }
}
