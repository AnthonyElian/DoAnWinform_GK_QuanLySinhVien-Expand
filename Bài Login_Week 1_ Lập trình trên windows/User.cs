using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    public class User
    {
        MY_DB mydb = new MY_DB();

        public DataTable getUser(SqlCommand cmd)
        {
            cmd.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertUser(string Username, string Password)
        {
            MY_DB mydb = new MY_DB();
            SqlCommand cmd = new SqlCommand("INSERT INTO Login (username, pass)" +
         "VALUES (@username, @pass)", mydb.GetConnection);
            cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = Username;
            cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = Password;

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
    }
}
