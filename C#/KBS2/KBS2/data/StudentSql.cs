using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using KBS2.model;
using KBS2.model.cijfer;

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
                con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
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
        public static Student getStudent(int id)
        {
            //verkrijgt  student naam uit sql
            String query = "select *  from student where id = " + id;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            String naam = (String)reader.GetValue(1);
            reader.Close();
           
            //verkrijgt toets informatie uit sql
            List<VakCijfer> cijfers = new List<VakCijfer>();
            query = "SELECT  Cijfer.toetsid, Cijfer.cijfer,Cijfer.datum, Toets.vakid, Vak.ec " +
            "FROM Student " +
            "INNER JOIN Cijfer ON Student.Id = Cijfer.studentid " +
            "INNER JOIN Toets ON Toets.Id = Cijfer.toetsid " +
            "INNER JOIN Vak ON Vak.Id = Toets.vakid " +
            "WHERE Student.Id = " + id + ";";
            com = new SqlCommand(query, con);
            reader = com.ExecuteReader();

            //voegt de data toe aan de lijst
            while (reader.Read())
            {
                bool found = false;
                for (int i = 0; i < cijfers.Count; i++)
                {
                    if (cijfers[i].VakNaam == (String)reader.GetValue(3))
                    {
                        found = !found;
                        ToetsCijfer cijfer = new ToetsCijfer(id + "", naam, (String)reader.GetValue(0), Convert.ToDouble(reader.GetValue(1)), reader.GetDateTime(2).ToString());
                        cijfers[i].Cijfers.Add(cijfer);
                        break;
                    }
                }
                if (!found)
                {
                    VakCijfer vakcijfer = new VakCijfer((string)reader.GetValue(3), (int)reader.GetValue(4), new List<ToetsCijfer>());
                    ToetsCijfer cijfer = new ToetsCijfer(id + "", naam, (String)reader.GetValue(0), Convert.ToDouble(reader.GetValue(1)), reader.GetDateTime(2).ToString());
                    vakcijfer.Cijfers.Add(cijfer);
                    cijfers.Add(vakcijfer);
                }
            }
            reader.Close();
            //maakt student aan en geeft deze terug
            Student student = new Student(naam, id + "", cijfers);
            return student;
        }

        public static Boolean studentExists(String naam)
        {
            //vraagt informatie op over de student in kwestie
            String query = "select * from Student where naam = '" + naam + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            //checked of er informatie is
            Boolean check = reader.HasRows;
            reader.Close();
            //geeft antwoord terug
            return check;
        }
        public static Boolean studentExists(int id)
        {
            //vraagt informatie op over de student in kwestie
            String query = "select * from Student where id = " + id;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            //checked of er informatie is
            Boolean check = reader.HasRows;
            reader.Close();
            //geeft antwoord terug
            return check;
        }

        public static Boolean passwordCompare(int id, string hash)
        {
            //vraagt hash op uit sql
            String query = "select hash from Email where studentid = " + id;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            string storedHash = reader.GetString(0);
            reader.Close();
            //vergelijkt de hashes
            bool check = storedHash.Equals(hash);      
            //geeft antwoord terug     
            return check;
        }

        public static String getEmail(int id)
        {
            //vraagt informatie op
            String query = "select email from Email where studentid = " + id;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            //verkrijgt informatie
            string email = reader.GetString(0);
            reader.Close();
            //geeft informatie terug
            return email;
        }

        public static String getStudentNaam(int id)
        {
            //vraagt informatie op
            String query = "select naam from Student where id = " + id;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            //verkrijgt informatie
            string naam = reader.GetString(0);
            reader.Close();
            //geeft naam terug
            return naam;
        }
        public static String getSalt(int id)
        {
            //vraagt salt op
            String query = "select salt from Email where studentid = " + id;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            //verkrijgt salt
            string salt = reader.GetString(0);
            reader.Close();
            //geeft salt terug
            return salt;
        }
    }
}
