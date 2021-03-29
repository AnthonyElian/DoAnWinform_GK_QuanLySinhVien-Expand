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

        private void staticToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticsForm static_form = new StaticsForm();
            this.Hide();
            static_form.ShowDialog();
            this.Show();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Print printform = new Print();
            this.Hide();
            printform.ShowDialog();
            this.Show();
        }

        private void manageStudentFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudentForm mgF = new ManageStudentForm();
            this.Hide();
            mgF.ShowDialog();
            this.Show();
        }

        private void editRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDeleteStudentForm form = new UpdateDeleteStudentForm();
            this.Hide();
            form.ShowDialog();
            this.Show();
        }
    }
}
