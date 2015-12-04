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
            String naam = (String)reader.GetValue(2);
            reader.Close();
            query = "SELECT  HeeftCijfer.toetsid, HeeftCijfer.cijfer, HeeftCijfer.datum, Toets.vakid, Vak.ec " +
            "FROM Student " +
            "INNER JOIN HeeftCijfer ON Student.Id = HeeftCijfer.studentid " +
            "INNER JOIN Toets ON Toets.Id = HeeftCijfer.toetsid " +
            "INNER JOIN Vak ON Vak.Id = Toets.vakid " +
            "WHERE Student.Id = " + id + ";";
            com = new SqlCommand(query, con);
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                if (cijfers.Count > 0)
                {
                    bool found = false;
                    for (int i = 0; i < cijfers.Count; i++)
                    {
                        if (cijfers[i].VakNaam == (String)reader.GetValue(3))
                        {
                            found = !found;
                            ToetsCijfer cijfer = new ToetsCijfer(id + "", naam, Convert.ToDouble(reader.GetValue(1)), (String)reader.GetValue(2));
                            cijfers[i].Cijfers.Add(cijfer);
                            break;
                        }
                    }
                    if (!found)
                    {
                        VakCijfer vakcijfer = new VakCijfer((string)reader.GetValue(3), (int)reader.GetValue(4), new List<ToetsCijfer>());
                        ToetsCijfer cijfer = new ToetsCijfer(id + "", naam, Convert.ToDouble(reader.GetValue(1)), (String)reader.GetValue(2));
                        vakcijfer.Cijfers.Add(cijfer);
                        cijfers.Add(vakcijfer);
                    }
                }
            }
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
