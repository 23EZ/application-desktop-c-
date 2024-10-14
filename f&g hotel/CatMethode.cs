using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace f_g_hotel
{
     class CatMethode
    {

        public string CatId { get; set; }
        public string CatNom { get; set; }
        public string CatDetails { get; set; }



        string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True";


        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                String req = "Select * From category";
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
        public bool insert(CatMethode c)
        {
           
            {
                bool succes = false;
                SqlConnection conn = new SqlConnection(constring);
                try
                {
                    String req = "INSERT INTO category(CatNom, CatDetails) VALUES (@CatNom, @CatDetails)";
                    SqlCommand cmd = new SqlCommand(req, conn);
                    cmd.Parameters.AddWithValue("@CatNom", c.CatNom);
                    cmd.Parameters.AddWithValue("@CatDetails", c.CatDetails);

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
                    // Gérer les exceptions ici
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                return succes;
            }

        }
        public bool update(CatMethode c)
        {
            bool succes = false;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                string req = "UPDATE category SET CatNom = @CatNom, CatDetails = @CatDetails";
                SqlCommand cmd = new SqlCommand(req, conn);
                cmd.Parameters.AddWithValue("@CatId", c.CatId);
                cmd.Parameters.AddWithValue("@CatNom", c.CatNom);
                cmd.Parameters.AddWithValue("@CatNom", c.CatDetails);

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



            public bool Delete(CatMethode c)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                string req = "DELETE FROM category WHERE CatId = @CatId";
                using (SqlCommand cmd = new SqlCommand(req, conn))
                {
                    cmd.Parameters.AddWithValue("@CatId", c.CatId);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    success = rows > 0;
                }
            }
            catch (Exception ex)
            {
                // Gérer l'exception ici, par exemple, afficher un message d'erreur
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }


    }
}
