using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using KBS2.model.cijfer;
using KBS2.views;
using KBS2.model;

namespace KBS2.data
{
    static class ToetsSql
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

        //connectie sluiten
        public static void close()
        {
            con.Close();
        }

        //toets ophalen uit database
        public static Toets getToets(String toetsnaam, String jaar)
        {

            String query = "select id,type from Toets where Id = '" + toetsnaam + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            String naam = (String)reader.GetValue(0);
            String toetstype = (String)reader.GetValue(1);
            reader.Close();
            List<ToetsCijfer> cijfers = new List<ToetsCijfer>();
            query = "select Student.Id, Student.Naam, Cijfer.cijfer, Cijfer.Datum"
                + " from Student "
                + " inner join Cijfer on Student.Id = Cijfer.studentid "
                + " inner join Jaar on Student.id = Jaar.studentID "
                + " where Cijfer.toetsid = '" + toetsnaam
                + "' and Jaar.jaar = '" + jaar + "'";
            com = new SqlCommand(query, con);
            reader = com.ExecuteReader();


            while (reader.Read())
            {
                ToetsCijfer cijfer = new ToetsCijfer(reader.GetValue(0) + "", (String)reader.GetValue(1), naam, Convert.ToDouble(reader.GetValue(2)), reader.GetValue(3) + "");
                cijfers.Add(cijfer);
            }
            reader.Close();

            for (int i = cijfers.Count - 1; i >= 0; i--)
            {
                for (int c = cijfers.Count - 1; c >= 0; c--)
                {
                    if (i != c && cijfers[i].ID.Equals(cijfers[c].ID))
                    {
                        if (cijfers[i].Cijfer <= cijfers[c].Cijfer)
                        {
                            cijfers.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            Toets toets = new Toets(naam, toetstype, cijfers);
            return toets;
        }

        public static Toets getToets(String toetsnaam, String datum, String jaar)
        {
            CultureInfo us = new CultureInfo("nl-NL");
            DateTime time = DateTime.Parse(datum, us);
            datum = time.ToString();
            //Console.WriteLine(time.ToString());

            String query = "select id,type from Toets where Id = '" + toetsnaam + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            String naam = (String)reader.GetValue(0);
            String toetstype = (String)reader.GetValue(1);
            reader.Close();
            List<ToetsCijfer> cijfers = new List<ToetsCijfer>();
            query = "select Student.Id, Student.Naam, Cijfer.cijfer, Cijfer.Datum from Cijfer  "
                + "inner join Student on Student.Id = Cijfer.studentid "
                + "inner join Jaar on Student.id = Jaar.studentID "
                + "where Cijfer.toetsid = '" + toetsnaam + "'"
                + " and Cijfer.datum = '" + datum + "' and Jaar.jaar = '" + jaar + "'";
            com = new SqlCommand(query, con);
            reader = com.ExecuteReader();

            while (reader.Read())
            {
                ToetsCijfer cijfer = new ToetsCijfer(reader.GetValue(0) + "", (String)reader.GetValue(1), naam, Convert.ToDouble(reader.GetValue(2)), reader.GetValue(3) + "");
                cijfers.Add(cijfer);
            }
            reader.Close();
            for (int i = cijfers.Count - 1; i >= 0; i--)
            {
                for (int c = cijfers.Count - 1; c >= 0; c--)
                {
                    if (i != c && cijfers[i].ID.Equals(cijfers[c].ID))
                    {
                        if (cijfers[i].Cijfer <= cijfers[c].Cijfer)
                        {
                            cijfers.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
            Toets toets = new Toets(naam, toetstype, cijfers);
            return toets;
        }

        public static List<String> toetsData(String toetsnaam, String jaar)
        {
            List<String> data = new List<string>();
            data.Add("beste resultaten");
            String query = "select Distinct datum from Cijfer"
                + " inner join Student on Cijfer.studentid = Student.id"
                + " inner join Jaar on Student.id = Jaar.studentID"
                + " where toetsid = '" + toetsnaam + "' and Jaar.jaar = '" + jaar + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();

            CultureInfo ci = new CultureInfo("nl-NL");
            while (reader.Read())
            {
                DateTime date = (DateTime)reader.GetValue(0);
                data.Add((String)date.ToString("dd/MM/yyyy HH:mm:ss tt"));
          
            }
            reader.Close();
            return data;
        }

        public static List<String> getToetsJaren(String toetsnaam)
        {
            List<String> data = new List<string>();
            String query = "select Distinct jaar from Jaar"
                + " inner join Student on Jaar.studentId = Student.id "
                + " inner join Cijfer on Cijfer.studentid = Student.id"
                + " where Cijfer.toetsid = '" + toetsnaam + "'"
                + " order by Jaar.jaar Desc";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {

                data.Add((String)reader.GetValue(0));
            }
            reader.Close();
            return data;

        }

        //kijken of toets bestaat in database
        public static Boolean ToetsExists(String toetsnaam)
        {
            String query = "select * from Toets where Id = '" + toetsnaam + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            Boolean check = reader.HasRows;
            reader.Close();
            return check;
        }
    }
}
