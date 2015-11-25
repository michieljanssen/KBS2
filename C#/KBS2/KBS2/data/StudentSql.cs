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

        private static SqlConnection con;

        public static Boolean connect()
        {
            try
            {
                con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
                con.Open();
                return true;
            }
            catch (SqlException e)
            {

                return false;
            }
        }

        public static void close()
        {

            con.Close();
        }

        public static Student getStudent(String naam)
        {

            return null;
        }
    }
}
