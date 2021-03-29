using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
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

        public int totalMaleStudent()
        {
            SqlCommand cmd = new SqlCommand("select count(*) as TotalMale from AddStudent where gender = 'Male'");
            cmd.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return (int)table.Rows[0]["TotalMale"];
        }

        public int totalFemaleStudent()
        {
            SqlCommand cmd = new SqlCommand("select count(*) as TotalFemale from AddStudent where gender = 'Female'");
            cmd.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return (int)table.Rows[0]["TotalFemale"];
        }

        public int totalStudent()
        {
            string total = "";
            SqlCommand cmd = new SqlCommand("select count(*) as Total from AddStudent");
            cmd.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return (int)table.Rows[0]["Total"];
        }

        public bool updateStu(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("UPDATE AddStudent SET fname = @fn, lname = @ln, bdate = @bdt, gender = @gdr, phone = @phn, address = @adrs, picture = @pic WHERE ID = @ID", mydb.GetConnection);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            cmd.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            cmd.Parameters.Add("@gdr", SqlDbType.NChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            cmd.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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

        public bool deleteStu(int ID)
        {
            SqlCommand cmd = new SqlCommand("Delete from AddStudent where id = @id", mydb.GetConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
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

        public DataTable getStudent(SqlCommand cmd)
        {
            cmd.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool insertStudent(int ID, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO AddStudent (id, fname, lname, bdate, gender, phone, address, picture)" +
                 "VALUES (@id, @fn, @ln, @bdt, @gdr, @phn, @adrs, @pic)", mydb.GetConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
            cmd.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            cmd.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            cmd.Parameters.Add("@gdr", SqlDbType.NChar).Value = gender;
            cmd.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            cmd.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = address;
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
