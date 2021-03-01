using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    class MY_DB
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-DE070V4\D2T;Initial Catalog=LOG_IN_Winform;Integrated Security=True");

        public SqlConnection GetConnection
        {
            get { return con; }
        }

        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
