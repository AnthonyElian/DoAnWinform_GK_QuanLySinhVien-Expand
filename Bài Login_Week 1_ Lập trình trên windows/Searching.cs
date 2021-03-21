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
    public partial class Searching : Form
    {
        private object dataGridViewSearching;

        public Searching()
        {
            InitializeComponent();
        }

        Student student = new Student();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MY_DB db = new MY_DB();
            SqlConnection con = db.GetConnection;
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            if (this.cBSearch.SelectedIndex == 1)
            {
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM AddStudent WHERE fname = @fname", con);
                cmd.Parameters.Add("@fname", SqlDbType.NVarChar).Value = this.txtSearch.Text;
                da.SelectCommand = cmd;
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;
                db.closeConnection();
            }
            else
            {
                if (this.cBSearch.SelectedIndex == 0)
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT * FROM AddStudent WHERE phone = @phone", con);
                    cmd.Parameters.Add("@phone", SqlDbType.NChar).Value = this.txtSearch.Text;
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                    db.closeConnection();
                }    
                else
                {
                    SqlCommand cmd = new SqlCommand(@"SELECT* FROM AddStudent WHERE fname LIKE N'%" + this.txtSearch.Text + "%'", con);
                    //cmd.Parameters.Add("@phone", SqlDbType.NChar).Value = this.txtSearch.Text;
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    this.dataGridView1.DataSource = dt;
                    db.closeConnection();
                }    
            }
        }
    }
}
