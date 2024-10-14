using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f_g_hotel
{
    internal class ReservMethode
    {

        public string RId { get; set; }
        public string RNom { get; set; }
        public string RChambre { get; set; }
        public string Agent { get; set; }
        public string RDate { get; set; }

        public string DateArr { get; set; }
        public string DateSortie { get; set; }
        public string Montant { get; set; }



        string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True";


        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                String req = "Select * From reservation";
                SqlCommand cmd = new SqlCommand(req, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        public bool insert(ReservMethode ch)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                string req = "INSERT INTO reservation (RDate, RChambre, Agent, DateArr, DateSortie, Montant) VALUES (@RDate, @RChambre, @Agent, @DateArr, @DateSortie, @Montant)";
                SqlCommand cmd = new SqlCommand(req, conn);
                cmd.Parameters.AddWithValue("@RDate", ch.RDate);
                cmd.Parameters.AddWithValue("@RChambre", ch.RChambre);
                cmd.Parameters.AddWithValue("@Agent", ch.Agent);
                cmd.Parameters.AddWithValue("@DateArr", ch.DateArr);
                cmd.Parameters.AddWithValue("@DateSortie", ch.DateSortie);
                cmd.Parameters.AddWithValue("@Montant", ch.Montant);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                success = rows > 0;
            }
            catch (Exception ex)
            {
                // Gérer l'exception ici, par exemple, afficher un message d'erreur
                MessageBox.Show("Erreur lors de l'insertion : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
      
    }
}
