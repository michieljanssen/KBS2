﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
        
        //connectie sluiten
        public  static void close() {
            con.Close();
        }
        
        //toets ophalen uit database
        public static Toets getToets(String toetsnaam)
        {
            String query = "select type from Toets where Id = '" + toetsnaam + "'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            String toetstype = (String)reader.GetValue(0);
            reader.Close();
            List<ToetsCijfer> cijfers = new List<ToetsCijfer>();
            query = "select Student.Id, Student.Naam, HeeftCijfer.cijfer, HeeftCijfer.Datum"
                + " from HeeftCijfer  "
                + "inner join Student  "
                + "on Student.Id = HeeftCijfer.studentid "
                + "where HeeftCijfer.toetsid = '" + toetsnaam + "'";
            com  = new SqlCommand(query, con);
            reader = com.ExecuteReader();
            reader.Read();
            while (reader.Read()) {
                ToetsCijfer cijfer = new ToetsCijfer(reader.GetValue(0)  +"", (String)reader.GetValue(1), Convert.ToDouble(reader.GetValue(2)),reader.GetValue(3) + "");
                cijfers.Add(cijfer);
            }
            reader.Close();
            Toets toets = new Toets(toetsnaam, toetstype, cijfers);
            return toets;
        }
        
        //kijken of toets bestaat in database
        public static Boolean ToetsExists(String toetsnaam)
        {
            String query = "select * from Toets where Id = '" + toetsnaam+"'";
            SqlCommand com = new SqlCommand(query, con);
            SqlDataReader reader = com.ExecuteReader();
            Boolean check =reader.HasRows;
            reader.Close();
            return check;
        }
    }
}
