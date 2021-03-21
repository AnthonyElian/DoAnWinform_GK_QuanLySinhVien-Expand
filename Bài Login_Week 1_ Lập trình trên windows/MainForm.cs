using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.Show(this);
        }

        private void studentsListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            studentListForm stdList = new studentListForm();
            stdList.Show();
        }

        private void searchingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Searching find = new Searching();
            this.Hide();
            find.ShowDialog();
            this.Show();
        }
    }
}
