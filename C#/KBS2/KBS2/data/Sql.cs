using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

using KBS2.cijfer;
using KBS2.views;

namespace KBS2.data
{
    class Sql
    {
        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader reader;
        
        public Sql()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand("Select * from Student;",con);
            reader = cmd.ExecuteReader();

            List<int> ids = new List<int>();

            while (reader.Read()) {
                ids.Add((int)reader.GetValue(0));
            }
            reader.Close();

            for (int i = 0; i < ids.Count; i++) {
                int studentID = ids[i];
                SqlCommand vakken = new SqlCommand(
                       "Select v.Id " +
                       "from Vak v inner join Klas k on v.oplid = k.oplid"+
                       " inner join Student s on k.id = s.klasid "+
                       "where s.Id = "  +studentID, con);

                SqlDataReader sqlr = vakken.ExecuteReader();

                Console.WriteLine(studentID);
                while (sqlr.Read())
                {
                    Console.WriteLine(sqlr.GetValue(0));
                }
                sqlr.Close();

            }
            //cmd.Execute
        }

        public Student getStudent(String naam)
        {

            return null;
        }

        public Toets getToets(String naam)
        {
            return null;
        }
    }
}
