using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f_g_hotel
{
   class ChMethodes
    {
        public string ChId { get; set; }
        public string ChNom { get; set; }
        public string ChDetails { get; set; }
        public string ChCat { get; set; }

        public string ChLocalisation { get; set; }
        public string ChPrix { get; set; }
        public string Chstatut { get; set; }



        string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True";


        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                String req = "Select * From chambre";
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
        public bool insert(ChMethodes  ch)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                string req = "INSERT INTO chambre (ChNom, ChCat, ChLocalisation, ChPrix, ChDetails, Chstatut) VALUES (@ChNom, @ChCat, @ChLocalisation, @ChPrix, @ChDetails, @Chstatut)";
                SqlCommand cmd = new SqlCommand(req, conn);
                cmd.Parameters.AddWithValue("@ChNom", ch.ChNom);
                cmd.Parameters.AddWithValue("@ChCat", ch.ChCat);
                cmd.Parameters.AddWithValue("@ChLocalisation", ch.ChLocalisation);
                cmd.Parameters.AddWithValue("@ChPrix", ch.ChPrix);
                cmd.Parameters.AddWithValue("@ChDetails", ch.ChDetails); // Utilisez le bon nom de paramètre
                cmd.Parameters.AddWithValue("@Chstatut", ch.Chstatut);

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
        public bool update(ChMethodes ch)
        {

            bool succes = false;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                string req = "UPDATE chambre SET  ChNom = @ChNom, ChCat = @ChCat, ChLocalisation = @ChLocalisation, ChPrix=@ChPrix, ChDetails = @ChDetails, Chstatut=@Chstatut  WHERE ChId = @ChId ";
                SqlCommand cmd = new SqlCommand(req, conn);
                cmd.Parameters.AddWithValue("@ChId", ch.ChId);

                cmd.Parameters.AddWithValue("@ChNom", ch.ChNom);
                cmd.Parameters.AddWithValue("@ChCat", ch.ChCat);
                cmd.Parameters.AddWithValue("@ChLocalisation", ch.ChLocalisation);
                cmd.Parameters.AddWithValue("@ChPrix", ch.ChPrix);
                cmd.Parameters.AddWithValue("@ChDetails", ch.ChDetails); 
                cmd.Parameters.AddWithValue("@Chstatut", ch.Chstatut);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    succes = true;
                }
                else
                {
                    succes = false;
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }




            return succes;
        }



    }

    }

