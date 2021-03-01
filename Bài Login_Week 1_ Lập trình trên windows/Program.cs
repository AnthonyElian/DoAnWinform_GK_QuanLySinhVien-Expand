using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Form1 flogin = new Form1();
            //if (flogin.ShowDialog() == DialogResult.OK)
            //{
            //    Application.Run(new MainForm());
            //}
            //else
            //{
            //    Application.Exit();
            //}
        }
    }
}
