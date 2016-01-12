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
            //verkrijg de naam en toetstype uit sql
            String query = "select id,type from Toets where Id = '" + toetsnaam + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            String naam = (String)reader.GetValue(0);
            String toetstype = (String)reader.GetValue(1);
            reader.Close();

            //verkrijg alle studenten met cijers en datum uit sql
            List<ToetsCijfer> cijfers = new List<ToetsCijfer>();
            query = "select Student.Id, Student.Naam, Cijfer.cijfer, Cijfer.Datum"
                + " from Student "
                + " inner join Cijfer on Student.Id = Cijfer.studentid "
                + " inner join Jaar on Student.id = Jaar.studentID "
                + " where Cijfer.toetsid = '" + toetsnaam
                + "' and Jaar.jaar = '" + jaar + "'";
            com = new SqlCommand(query, con);
            reader = com.ExecuteReader();

            //voeg deze data toe aan de lijst
            while (reader.Read())
            {
                ToetsCijfer cijfer = new ToetsCijfer(reader.GetValue(0) + "", (String)reader.GetValue(1), naam, Convert.ToDouble(reader.GetValue(2)), reader.GetValue(3) + "");
                cijfers.Add(cijfer);
            }
            reader.Close();
            //haal alle onnodige lage cijfers weg
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
            //maak toets aan en geef deze terug
            Toets toets = new Toets(naam, toetstype, cijfers);
            return toets;
        }

        public static Toets getToets(String toetsnaam, String datum, String jaar)
        {
            //vertaling tijd van nederlands naar americaans notatie
            CultureInfo nl = new CultureInfo("nl-NL");
            CultureInfo us = new CultureInfo("en-US");
            DateTime time = DateTime.Parse(datum, nl);
            datum = time.ToString(us);
            //Console.WriteLine(time.ToString());

            //verkrijgt toetsnaam en type uit sql
            String query = "select id,type from Toets where Id = '" + toetsnaam + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            String naam = (String)reader.GetValue(0);
            String toetstype = (String)reader.GetValue(1);
            reader.Close();

            //verkrijg student informatie, cijfers en datum uit sql
            List<ToetsCijfer> cijfers = new List<ToetsCijfer>();
            query = "select Student.Id, Student.Naam, Cijfer.cijfer, Cijfer.Datum from Cijfer  "
                + "inner join Student on Student.Id = Cijfer.studentid "
                + "inner join Jaar on Student.id = Jaar.studentID "
                + "where Cijfer.toetsid = '" + toetsnaam + "'"
                + " and Cijfer.datum = '" + datum + "' and Jaar.jaar = '" + jaar + "'";
            com = new SqlCommand(query, con);
            reader = com.ExecuteReader();

            //voeg de data toe aan de lijst
            while (reader.Read())
            {
                ToetsCijfer cijfer = new ToetsCijfer(reader.GetValue(0) + "", (String)reader.GetValue(1), naam, Convert.ToDouble(reader.GetValue(2)), reader.GetValue(3) + "");
                cijfers.Add(cijfer);
            }
            reader.Close();

            //haal onnodige lage cijfers weg
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
            //geef toets terug
            Toets toets = new Toets(naam, toetstype, cijfers);
            return toets;
        }

        public static List<String> toetsData(String toetsnaam, String jaar)
        {
            //verkijg de toets datas uit sql
            List<String> data = new List<string>();
            data.Add("beste resultaten");
            String query = "select Distinct datum from Cijfer"
                + " inner join Student on Cijfer.studentid = Student.id"
                + " inner join Jaar on Student.id = Jaar.studentID"
                + " where toetsid = '" + toetsnaam + "' and Jaar.jaar = '" + jaar + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();

            CultureInfo ci = new CultureInfo("nl-NL");
            //voeg deze data toe aan de lijst in de nederlandse notatie
            while (reader.Read())
            {
                DateTime date = (DateTime)reader.GetValue(0);
                data.Add((String)date.ToString("g", ci));
          
            }
            reader.Close();
            return data;
        }

        public static List<String> getToetsJaren(String toetsnaam)
        {
            //verkrijg de toets jaren uit sql
            List<String> data = new List<string>();
            String query = "select Distinct jaar from Jaar"
                + " inner join Student on Jaar.studentId = Student.id "
                + " inner join Cijfer on Cijfer.studentid = Student.id"
                + " where Cijfer.toetsid = '" + toetsnaam + "'"
                + " order by Jaar.jaar Desc";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            //voeg deze data toe aan een lijst
            while (reader.Read())
            {
                data.Add((String)reader.GetValue(0));
            }
            reader.Close();
            //geef de lijst terug
            return data;
        }

        //kijken of toets bestaat in database
        public static Boolean ToetsExists(String toetsnaam)
        {

            //verkrijgt de toets informatie uit sql
            String query = "select * from Toets where Id = '" + toetsnaam + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            //checked of er informatie is
            Boolean check = reader.HasRows;
            reader.Close();
            //geeft antwoord terug
            return check;
        }
    }
}
