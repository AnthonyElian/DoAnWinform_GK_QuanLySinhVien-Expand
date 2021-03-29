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
    public partial class studentListForm : Form
    {
        public studentListForm()
        {
            InitializeComponent();
        }

        Student student = new Student();

        public void studentListForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM AddStudent");
            this.dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            this.dataGridView1.RowTemplate.Height = 80;
            this.dataGridView1.DataSource = student.getStudent(cmd);
            picCol = (DataGridViewImageColumn)this.dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm updateDeleteStdF = new UpdateDeleteStudentForm();
            updateDeleteStdF.txtStuID.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            updateDeleteStdF.txtfName.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            updateDeleteStdF.txtlName.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            
            if ((this.dataGridView1.CurrentRow.Cells[4].Value.ToString() == "Female"))
            {
                updateDeleteStdF.rbFemale.Checked = true;
            }

            updateDeleteStdF.dBirDate.Value = (DateTime)this.dataGridView1.CurrentRow.Cells[3].Value;
            updateDeleteStdF.txtPhone.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
            updateDeleteStdF.txtAdrs.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();

            byte[] pic;
            pic = (byte[])this.dataGridView1.CurrentRow.Cells[7].Value;
            MemoryStream picture = new MemoryStream(pic);
            updateDeleteStdF.picBox.Image = Image.FromStream(picture);

            updateDeleteStdF.Show();
        }
        //
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from AddStudent");
            this.dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            this.dataGridView1.RowTemplate.Height = 80;
            this.dataGridView1.DataSource = student.getStudent(cmd);
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[7];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            this.dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
