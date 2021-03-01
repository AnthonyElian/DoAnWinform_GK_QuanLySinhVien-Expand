using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bài_Login_Week_1__Lập_trình_trên_windows
{
    public class Student
    {
        MY_DB mydb = new MY_DB();
        public bool insertStudent(int ID, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO AddStudent (id, fname, lname, bdate, gender, phone, address, picture)" +
                 "VALUES (@id, @fn, @ln, @bdt, @gdr, @phn, @adrs, @pic)", mydb.GetConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            cmd.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            cmd.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();
            //SqlDataAdapter adapter = new SqlDataAdapter();

            //DataTable table = new DataTable();
            //adapter.SelectCommand = cmd;
            //adapter.Fill(table);
            //int temp = Convert.ToInt32(cmd.ExecuteScalar());
            //SqlDataReader reader = cmd.ExecuteReader();
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
