using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        Student student = new Student();

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (this.rBNo.Checked == true)
            {
                if (this.rBAll.Checked == true)
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
                else if (this.rBFemale.Checked == true)
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM AddStudent Where gender = 'Female'");
                    this.dataGridView1.ReadOnly = true;
                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    this.dataGridView1.RowTemplate.Height = 80;
                    this.dataGridView1.DataSource = student.getStudent(cmd);
                    picCol = (DataGridViewImageColumn)this.dataGridView1.Columns[7];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    this.dataGridView1.AllowUserToAddRows = false;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM AddStudent Where gender = 'Male'");
                    this.dataGridView1.ReadOnly = true;
                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    this.dataGridView1.RowTemplate.Height = 80;
                    this.dataGridView1.DataSource = student.getStudent(cmd);
                    picCol = (DataGridViewImageColumn)this.dataGridView1.Columns[7];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    this.dataGridView1.AllowUserToAddRows = false;
                }
            }
            else
            {
                if (this.rBAll.Checked == true)
                {
                    DateTime date1 = this.dT1.Value; string datee1 = date1.ToString("yyyy-MM-dd");
                    DateTime date2 = this.dT2.Value; string datee2 = date2.ToString("yyyy-MM-dd");
                    SqlCommand cmd = new SqlCommand("SELECT * FROM AddStudent where bdate >= '" + datee1 + "' and bdate <= '" + datee2 + "'");
                    this.dataGridView1.ReadOnly = true;
                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    this.dataGridView1.RowTemplate.Height = 80;
                    this.dataGridView1.DataSource = student.getStudent(cmd);
                    picCol = (DataGridViewImageColumn)this.dataGridView1.Columns[7];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    this.dataGridView1.AllowUserToAddRows = false;
                }
                else if (this.rBMale.Checked == true)
                {
                    DateTime date1 = this.dT1.Value; string datee1 = date1.ToString("yyyy-MM-dd");
                    DateTime date2 = this.dT2.Value; string datee2 = date2.ToString("yyyy-MM-dd");
                    SqlCommand cmd = new SqlCommand("SELECT * FROM AddStudent where gender = 'Male' and bdate >= '" + datee1 + "' and bdate <= '" + datee2 + "'");
                    this.dataGridView1.ReadOnly = true;
                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    this.dataGridView1.RowTemplate.Height = 80;
                    this.dataGridView1.DataSource = student.getStudent(cmd);
                    picCol = (DataGridViewImageColumn)this.dataGridView1.Columns[7];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    this.dataGridView1.AllowUserToAddRows = false;
                }
                else
                {
                    DateTime date1 = this.dT1.Value; string datee1 = date1.ToString("yyyy-MM-dd");
                    DateTime date2 = this.dT2.Value; string datee2 = date2.ToString("yyyy-MM-dd");
                    SqlCommand cmd = new SqlCommand("SELECT * FROM AddStudent where gender = 'Female' and bdate >= '" + datee1 + "' and bdate <= '" + datee2 + "'");
                    this.dataGridView1.ReadOnly = true;
                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    this.dataGridView1.RowTemplate.Height = 80;
                    this.dataGridView1.DataSource = student.getStudent(cmd);
                    picCol = (DataGridViewImageColumn)this.dataGridView1.Columns[7];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                    this.dataGridView1.AllowUserToAddRows = false;
                }
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename;
                filename = saveFileDialog1.FileName;
                try
                {
                    string sLine = "";
                    StreamWriter sw = File.CreateText(filename);
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            sLine += dataGridView1.Rows[i].Cells[j].Value;
                            sLine = sLine + ",";
                        }
                        sw.WriteLine(sLine);
                        sLine = "";
                    }
                    sw.Close();
                    MessageBox.Show("Export Complete.", "Save to file", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Export Error", "Save to file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            PrintDialog pDlg = new PrintDialog();
            PrintDocument pDoc = new PrintDocument();
            pDoc.DocumentName = "Print Document";
            pDlg.Document = pDoc;
            pDlg.AllowSelection = true;
            pDlg.AllowSomePages = true;
            pDoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            if (pDlg.ShowDialog() == DialogResult.OK)
            {
                printPreviewDialog1.Document = pDoc;
                printPreviewDialog1.ShowDialog();
                pDoc.Print();
            }
            else
            {
                MessageBox.Show("Đã hủy in");
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            string str = "";
            int row = dataGridView1.Rows.Count;
            int cell = dataGridView1.Rows[1].Cells.Count;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < cell; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value == null)
                    {
                        dataGridView1.Rows[i].Cells[j].Value = "null";
                    }
                    str += dataGridView1.Rows[i].Cells[j].Value.ToString().Trim() + " , ";
                }
                str += "\n";
            }
            e.Graphics.DrawString(str, new Font("Times New Roman", 15), Brushes.Black, new Point(10, 10));
        }
    }
}
