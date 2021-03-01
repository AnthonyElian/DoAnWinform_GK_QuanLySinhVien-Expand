using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();

            SqlDataAdapter adapter = new SqlDataAdapter();

            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Login WHERE Username = @username AND Pass = @password", db.GetConnection);

            command.Parameters.Add("@username", SqlDbType.NVarChar).Value = this.txtUser.Text;
            command.Parameters.Add("@password", SqlDbType.NVarChar).Value = this.txtPass.Text;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                //MessageBox.Show("OK, next time will be go to Main Menu of App");
                Form mainForm = new MainForm();
                this.Hide();
                mainForm.ShowDialog();
                this.Show();
                //this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DE070V4\D2T;Initial Catalog=LOG_IN_Winform;Integrated Security=True");
            //try
            //{
            //    con.Open();
            //    string taiKhoan = this.txtUser.Text;
            //    string matKhau = this.txtUser.Text;
            //    string sql = "SELECT * FROM Login WHERE Username = '" + taiKhoan + "' AND Pass = '" + matKhau + "'";
            //    SqlCommand command = new SqlCommand(sql, con);
            //    SqlDataReader data = command.ExecuteReader();
            //    if (data.Read())
            //    {
            //        MessageBox.Show("OK, next time will be go to Main Menu of App");
            //    }
            //    else
            //    {
            //        MessageBox.Show("Invalid Username or Password", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure ?!?", "Warning", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLog_Click(sender, e);
            }   
        }

        //Control Keyboard
        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnCancel_Click(sender, e);
            }    
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPass.Focus();
            }   
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnLog.Focus();
            }   
        }
    }
}
