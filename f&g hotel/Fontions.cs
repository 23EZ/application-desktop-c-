using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Collections;

namespace f_g_hotel
{
    public class Fonctions
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string constring;



        public Fonctions()
        {
            constring = "Data Source= (localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True";

            con = new SqlConnection(constring);
            cmd = new SqlCommand();
            cmd.Connection = con;


        }

        public DataTable RecupererDonnees(string requete)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(requete, constring);
          sda.Fill(dt);
            return dt;


        }
        public int EnvoyerDonnee(string requete)
        {
            int cnt = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = requete;
            cnt = cmd.ExecuteNonQuery();
            return cnt;
        }

    }
}
