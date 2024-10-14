using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace f_g_hotel
{
    public partial class reservation : Form
    {
        Fonctions con;
        ReservMethode ch = new ReservMethode();
        
        public reservation()
        {
            InitializeComponent();
            con = new Fonctions();

            listerchambre();
            listerreservation();

        }
        private void listerchambre()
        {
            string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                try
                {
                    con.Open();
                    string stat = "libre";
                    string req = "SELECT ChId AS code, ChNom AS Nom, ChCat AS cat, ChPrix AS prix, Chstatut AS statut FROM chambre WHERE Chstatut = @statut";

                    using (SqlCommand cmd = new SqlCommand(req, con))
                    {
                        cmd.Parameters.AddWithValue("@statut", stat);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            listech.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du rafraîchissement des chambres : " + ex.Message);
                }
            }
        }
        private void reservation_Load(object sender, EventArgs e)
        {

        }

        private void chambrebtn_Click(object sender, EventArgs e)
        {
            chambres obj = new chambres();
            obj.Show();
            this.Hide();
        }

        private void catbtn_Click(object sender, EventArgs e)
        {
            categories cat = new categories();
            cat.Show();
            this.Hide();
        }

        private void agentbtn_Click(object sender, EventArgs e)
        {
            agent a = new agent();
            a.Show();
            this.Hide();
        }

        private void deconbtn_Click(object sender, EventArgs e)
        {

            connexion c = new connexion();
            c.Show();
            this.Hide();
        }

        int key = 0, prix, prixtotal;
        private void listech_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void prixbtn_Click(object sender, EventArgs e)
        {
            TimeSpan ts = dateout.Value.Date - datein.Value.Date;
            int jours = ts.Days;
            prixtotal = prix * jours;
            montch.Text = "$" + prixtotal;

        }

        private void listech_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;

            nomch.Text = listech.Rows[rowIndex].Cells[1].Value.ToString();
            prix = Convert.ToInt32(listech.Rows[rowIndex].Cells[3].Value.ToString());
            if (nomch.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(listech.Rows[0].Cells[0].Value.ToString());

            }
        }


      
        private void listerreservation()
        {

            String req = "Select * From reservation ";

            listeres.DataSource = con.RecupererDonnees(req);

        }
        int Agent = connexion.Agent;

        public object RId { get; private set; }

        private void reserver_Click(object sender, EventArgs e)
        {
           
            string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True";
            SqlConnection con = new SqlConnection(constring);
            try
            {
                con.Open();
                if (string.IsNullOrEmpty(nomch.Text) || string.IsNullOrEmpty(montch.Text))
                {
                    MessageBox.Show("Information incomplète");
                }
                else
                {
                    string chnom = nomch.Text;
                    DateTime dateIn = datein.Value;
                    DateTime dateOut = dateout.Value;
                    string req = "INSERT INTO reservation (RDate, RChambre, Agent, DateArr, DateSortie, Montant) " +
                                 "VALUES (@RDate, @RChambre, @Agent, @DateArr, @DateSortie, @Montant)";

                    // Insertion de la réservation dans la base de données
                    SqlCommand cmd = new SqlCommand(req, con);
                    cmd.Parameters.AddWithValue("@RDate", DateTime.Today);
                    cmd.Parameters.AddWithValue("@RChambre", key);
                    cmd.Parameters.AddWithValue("@Agent", Agent);
                    cmd.Parameters.AddWithValue("@DateArr", dateIn);
                    cmd.Parameters.AddWithValue("@DateSortie", dateOut);
                    cmd.Parameters.AddWithValue("@Montant", prixtotal);
                    cmd.ExecuteNonQuery();

                    // Mise à jour du statut de la chambre réservée
                    string updateReq = "UPDATE chambre SET ChStatut = 'occupée' WHERE ChId = @ChambreId";
                    SqlCommand updateCmd = new SqlCommand(updateReq, con);
                    updateCmd.Parameters.AddWithValue("@ChambreId", key);
                    updateCmd.ExecuteNonQuery();
                   

                    // Rafraîchissement de la liste des chambres disponibles
                    listerchambre();

                    MessageBox.Show("Chambre réservée avec succès");
                    DataTable dt = ch.Select();
                    listeres.DataSource = dt;
                    montch.Text = "";
                    nomch.Text = "";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        private void listeres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void annuler_Click(object sender, EventArgs e)
        {
            if (listeres.SelectedRows.Count > 0)
            {
                // Récupérer l'identifiant de la réservation sélectionnée à partir de la première colonne (ou la colonne appropriée)
                int RId = Convert.ToInt32(listeres.SelectedRows[0].Cells["RId"].Value);

                string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True";
                SqlConnection con = new SqlConnection(constring);

                try
                {
                    con.Open();

                    // Suppression de la réservation de la base de données
                    string deleteReq = "DELETE FROM reservation WHERE RId = @RId";
                    SqlCommand cmd = new SqlCommand(deleteReq, con);
                    cmd.Parameters.AddWithValue("@RId", RId);
                    cmd.ExecuteNonQuery();

                    
                    string getChambreIdReq = "SELECT RChambre FROM reservation WHERE RId = @RId";
                    SqlCommand getChambreIdCmd = new SqlCommand(getChambreIdReq, con);
                    getChambreIdCmd.Parameters.AddWithValue("@RId", RId);
                    int chambreId = Convert.ToInt32(getChambreIdCmd.ExecuteScalar());

                    string updateReq = "UPDATE chambre SET ChStatut = 'libre' WHERE ChId = @ChambreId";
                    SqlCommand updateCmd = new SqlCommand(updateReq, con);
                    updateCmd.Parameters.AddWithValue("@ChambreId", key);
                    updateCmd.ExecuteNonQuery();

                    // Rafraîchissement de la liste des chambres disponibles

                    listerchambre();

                    
                    MessageBox.Show("Réservation annulée avec succès");
                    DataTable dt = ch.Select();
                    listeres.DataSource = dt;
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de l'annulation de la réservation : " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une réservation à annuler.");
            }

        }
    }
}

