using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f_g_hotel
{
    public partial class categories : Form
    {
        CatMethode c = new CatMethode();
        Fonctions con;
        public categories()
        {
            InitializeComponent();
            con= new Fonctions();

        }
        private void Listercategorie()
        {

        }

        private void categories_Load(object sender, EventArgs e)
        {
            DataTable dt = c.Select();
            lcat.DataSource = dt;
        }

        private void enregistrerch_Click(object sender, EventArgs e)
        {
            if (detcat.Text == "" || nomc.Text == "")
            {
                MessageBox.Show("informations incomplete");
            }
            else
            {

                c.CatId = Idcat.Text;
                c.CatNom = nomc.Text;
                c.CatDetails = detcat.Text;
            }


            bool succes = c.insert(c);
            if (succes == true)
            {
                MessageBox.Show("agent ajouté avec succes");
                clear();
            }
            else
            {
                MessageBox.Show("erreur");
            }
            DataTable dt = c.Select();
            lcat.DataSource = dt;

        }


        private void lcat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void modifierch_Click(object sender, EventArgs e)
        {
           
            try
            {
                if(nomc.Text=="" || detcat.Text=="")
                {
                    MessageBox.Show("information incomplete");
                }
                else
                {
                    string catnom = nomc.Text;
                    string det = detcat.Text;
                    string req = "update category set CatNom='{0}', CatDetails='{1}' where CatId={2}";
                    req = string.Format(req, catnom, det,cle);
                    con.EnvoyerDonnee(req);
                    Listercategorie();
                    MessageBox.Show("categorie modifiée");
                    clear();
                }
                DataTable dt = c.Select();
                lcat.DataSource = dt;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }




        int cle = 0;
        private void lcat_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
      
            nomc.Text = lcat.Rows[rowIndex].Cells[1].Value.ToString();
            detcat.Text = lcat.SelectedRows[0].Cells[2].Value.ToString();
            if (nomc.Text == "")
            {
                cle = 0;
            }
            else
            {
                cle = Convert.ToInt32(lcat.Rows[rowIndex].Cells[0].Value.ToString());

            } 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void clear()
        {
            nomc.Text = "";
            detcat.Text = "";
            Idcat.Text = "";

        }

        private void supprimerch_Click(object sender, EventArgs e)
        {

            

            if (lcat.SelectedRows.Count > 0)
            {
                // Obtenez l'ID de la catégorie sélectionnée à partir de la ligne sélectionnée
                int catId = Convert.ToInt32(lcat.SelectedRows[0].Cells["CatId"].Value);

                SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=true");
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM category WHERE CatId=@CatId", con); // Ajout de "FROM" dans la requête DELETE
                cmd.Parameters.AddWithValue("@CatId", catId);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Catégorie supprimée");

                // Rafraîchissez  DataGridView après la suppression
                DataTable dt = c.Select();
                lcat.DataSource = dt;
                clear();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une catégorie à supprimer.");
            }

        }

        private void chambrebtn_Click(object sender, EventArgs e)
        {
            chambres obj = new chambres();
            obj.Show();
            this.Hide();
        }

        private void agentbtn_Click(object sender, EventArgs e)
        {
            agent a = new agent();
            a.Show();
            this.Hide();
        }

        private void resbtn_Click(object sender, EventArgs e)
        {
            reservation res = new reservation();
            res.Show();
            this.Hide();
        }

        private void deconbtn_Click(object sender, EventArgs e)
        {
            connexion c = new connexion();
            c.Show();
            this.Hide();
        }
    }
}

