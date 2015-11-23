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
