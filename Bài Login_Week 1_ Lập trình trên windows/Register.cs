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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnSig_Click(object sender, EventArgs e)
        {
            if (this.Captcha.Checked == false)
            {
                MessageBox.Show("Robot ", "Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.txtUser.Text = "";
                this.txtPass.Text = "";
                this.txtConfPass.Text = "";
                this.txtUser.Focus();
            }    
            else if (this.verify() == true)
            {
                User user = new User();
                string username = this.txtUser.Text;
                string pass = this.txtPass.Text;
                user.insertUser(username, pass);
                MessageBox.Show("Successfully!!");
                this.Close();
            }
            else
            {
                this.txtUser.Text = "";
                this.txtPass.Text = "";
                this.txtConfPass.Text = "";
                this.txtUser.Focus();
            }    
        }

        private bool verify()
        {
            if (this.txtPass.Text == "" || this.txtUser.Text == "")
            {
                MessageBox.Show("Empty Fields", "Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                if (this.txtConfPass.Text != this.txtPass.Text)
                {
                    MessageBox.Show("Pass different with Confirm Pass", "Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                } 
                else
                {
                    if (!checkPass(this.txtPass.Text))
                    {
                        MessageBox.Show("Worng format of Password", "Register", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    else
                        return true;
                }    
            }
        }

        private bool checkPass(string pass)
        {
            if (pass.Length >= 7)
            {
                int flagChu = 0;
                int flagSo = 0;
                for (int i = 0; i < pass.Length; i++)
                {
                    if (flagChu == 1 && flagSo == 1)
                    {
                        return true;
                    }

                    if ((pass[i] >= 'A' && pass[i] <= 'Z') || (pass[i] >= 'a' && pass[i] <= 'z'))
                    {
                        flagChu = 1;
                    }

                    if (pass[i] >= '0' && pass[i] <= '9')
                    {
                        flagSo = 1;
                    }
                }
                return false;
            }
            else
                return false;
        }
    }
}
