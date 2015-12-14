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
            String query = "select *  from student where id = " + id;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            List<VakCijfer> cijfers = new List<VakCijfer>();
            String naam = (String)reader.GetValue(1);
            reader.Close();
            ////////////////
            //query = "select distinct vak.id, vak.ec from student " +
            //    "INNER JOIN Jaar on Student.Id = Jaar.studentId " +
            //    "INNER JOIN Klas on Klas.Id = Jaar.klasId " +
            //    "INNER JOIN Opleiding on Klas.oplid = Opleiding.id " +
            //    "INNER JOIN Vak on Vak.oplid = Opleiding.ID " +
            //    "WHERE Student.Id = " + id + ";";
            //com = new SqlCommand(query, con);
            //reader = com.ExecuteReader();

            //while (reader.Read())
            //{
            //    VakCijfer vakcijfer = new VakCijfer((string)reader.GetValue(0), (int)reader.GetValue(1), new List<ToetsCijfer>());
            //    cijfers.Add(vakcijfer);
            //}
            //reader.Close();

            //query = "select distinct Toets.id, vak.id from Toets " +
            //    "INNER join Vak on Vak.id = Toets.vakid " +
            //    "INNER JOIN opleiding on Opleiding.id = vak.oplid " + 
            //    "INNER JOIN Klas on klas.oplid = Opleiding.id " +
            //    "INNER JOIN Jaar on jaar.klasid = Klas.ID " +
            //    "INNER JOIN";




            ///////////
            query = "SELECT  Cijfer.toetsid, Cijfer.cijfer,Cijfer.datum, Toets.vakid, Vak.ec " +
            "FROM Student " +
            "INNER JOIN Cijfer ON Student.Id = Cijfer.studentid " +
            "INNER JOIN Toets ON Toets.Id = Cijfer.toetsid " +
            "INNER JOIN Vak ON Vak.Id = Toets.vakid " +
            "WHERE Student.Id = " + id + ";";
            com = new SqlCommand(query, con);
            reader = com.ExecuteReader();
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
            Console.WriteLine(cijfers.Count);
            Student student = new Student(naam, id + "", cijfers);
            return student;
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
            String query = "select * from Student where id = " + id;
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            Boolean check = reader.HasRows;
            reader.Close();
            return check;
        }
    }
}
