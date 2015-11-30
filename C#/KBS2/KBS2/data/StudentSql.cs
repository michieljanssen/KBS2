using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using KBS2.model;

namespace KBS2.data
{
    static class StudentSql
    {
        //connectie variable
        private static SqlConnection con;
        
        //connectie maken
        public static Boolean connect()
        {
            try
            {
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
                con.Open();
                return true;
            }
            //mogelijke error afvangen
            catch (SqlException e)
            {
                return false;
            }
        }
        //connectie afsluiten
        public static void close()
        {

            con.Close();
        }
        //student ophalen uit database
        public static Student getStudent(String naam)
        {

            return null;
        }

        public static Boolean studentExists(String naam)
        {
            String query = "select * from Student where naam = '" + naam + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            Boolean check = reader.HasRows;
            reader.Close();
            return check;
        }

        public static Boolean studentExists(int id)
        {
            String query = "select * from Student where id = "+id;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            Boolean check = reader.HasRows;
            reader.Close();
            return check;
        }
    }
}
