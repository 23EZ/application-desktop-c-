using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace f_g_hotel
{
    class Agentmethode
    {
        public string AgId { get; set; }
        public string AgNom { get; set; }
        public string AgTel { get; set; }
        public string AgAdd { get; set; }

        public object AgMotPasse { get; set; }
        public object AgGenre { get; set; }
        string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True";


        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(constring);
            DataTable dt = new DataTable();
            try
            {
                String req = "Select * From agent";
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
        public bool insert(Agentmethode a)
        {
            bool succes = false;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                String req = "INSERT into agent(AgNom,AgTel,AgGenre,AgAdd,AgMotPasse) Values(@AgNom,@AgTel,@AgGenre,@AgAdd,@AgMotPasse)";
                SqlCommand cmd = new SqlCommand(req, conn);
                // cmd.Parameters.AddWithValue("@AgId",a.AgId);
                cmd.Parameters.AddWithValue("@AgNom", a.AgNom);
                cmd.Parameters.AddWithValue("@AgTel", a.AgTel);
                cmd.Parameters.AddWithValue("AgGenre", a.AgGenre);
                cmd.Parameters.AddWithValue("@AgAdd", a.AgAdd);
                cmd.Parameters.AddWithValue("@AgMotPasse", a.AgMotPasse);
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
        public bool update(Agentmethode a)
        {
            bool succes = false;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                string req = "UPDATE agent SET AgNom = @AgNom, AgTel = @AgTel, AgGenre = @AgGenre, AgAdd = @AgAdd, AgMotPasse = @AgMotPasse WHERE AgId = @AgId ";
                SqlCommand cmd = new SqlCommand(req, conn);
                cmd.Parameters.AddWithValue("@AgId", a.AgId);
                cmd.Parameters.AddWithValue("@AgNom", a.AgNom);
                cmd.Parameters.AddWithValue("@AgTel", a.AgTel);
                cmd.Parameters.AddWithValue("AgGenre", a.AgGenre);
                cmd.Parameters.AddWithValue("@AgAdd", a.AgAdd);
                cmd.Parameters.AddWithValue("@AgMotPasse", a.AgMotPasse);
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

        public bool Delete(Agentmethode a)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(constring);
            try
            {
                string req = "DELETE FROM agent WHERE AgId = @AgId";
                using (SqlCommand cmd = new SqlCommand(req, conn))
                {
                    cmd.Parameters.AddWithValue("@AgId", a.AgId);
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

