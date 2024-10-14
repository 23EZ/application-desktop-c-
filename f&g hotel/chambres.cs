using System.Data;
using System.Data.SqlClient;
using System.Resources;

namespace f_g_hotel
{
    public partial class chambres : Form
    {
        ChMethodes ch = new ChMethodes();
       
        Fonctions con;
        public chambres()
        {

            InitializeComponent();
            con = new Fonctions();
            listerchambre();
            remplircat();

        }

        private void listerchambre()
        {
            string req = "SELECT * FROM chambre";
            listech.DataSource = con.RecupererDonnees(req);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void remplircat()
        {
            string req = "SELECT * FROM category";
            cat.Text = con.RecupererDonnees(req).Columns["CatNom"].ToString();
            cat.ValueMember = con.RecupererDonnees(req).Columns["CatId"].ToString();
            cat.DataSource = con.RecupererDonnees(req);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            ch.ChNom = nomch.Text;
            ch.ChCat = cat.SelectedValue.ToString();
            ch.ChLocalisation = locch.Text;
            ch.ChPrix = prixch.Text;
            ch.ChDetails = detch.Text;
            ch.Chstatut = statch.Text;

            bool succes = ch.insert(ch);
            if (succes == true)
            {
                MessageBox.Show("chambre ajouté avec succes");
                clear();
            }
            else
            {
                MessageBox.Show("erreur");
            }
            DataTable dt = ch.Select();
            listech.DataSource = dt;




        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = ch.Select();
            listech.DataSource = dt;

        }
        public void clear()
        {
            idch.Text = "";
            nomch.Text = "";
            cat.Text = "";
            locch.Text = "";
            prixch.Text = "";
            detch.Text = "";
            statch.Text = "";

        }

        private void modifier_Click(object sender, EventArgs e)
        { // Créer un nouvel objet ChMethodes et le remplir avec les données de la ligne sélectionnée
            ChMethodes chambreToUpdate = new ChMethodes();
            chambreToUpdate.ChId = idch.Text; // Assurez-vous de convertir l'ID de la chambre en entier
            chambreToUpdate.ChNom = nomch.Text;
            chambreToUpdate.ChCat = cat.Text;
            chambreToUpdate.ChLocalisation = locch.Text;
            chambreToUpdate.ChPrix = prixch.Text; // Assurez-vous de convertir le prix en double si nécessaire
            chambreToUpdate.ChDetails = detch.Text;
            chambreToUpdate.Chstatut = statch.Text;

            // Appeler la méthode de mise à jour pour mettre à jour les données dans la base de données
            bool success = chambreToUpdate.update(chambreToUpdate);

            if (success)
            {
                MessageBox.Show("Chambre modifiée avec succès");
                DataTable dt = chambreToUpdate.Select();
                listech.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification de la chambre");
            }

            clear();
        }



        private void listech_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            idch.Text = listech.Rows[rowIndex].Cells[0].Value.ToString();
            nomch.Text = listech.Rows[rowIndex].Cells[1].Value.ToString();
            cat.Text = listech.Rows[rowIndex].Cells[2].Value.ToString();
            locch.Text = listech.Rows[rowIndex].Cells[3].Value.ToString();
            prixch.Text = listech.Rows[rowIndex].Cells[4].Value.ToString();
            detch.Text = listech.Rows[rowIndex].Cells[5].Value.ToString();
            statch.Text = listech.Rows[rowIndex].Cells[6].Value.ToString();
        }


        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void supprimer_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE chambre WHERE ChId=@CHId ", con);
            cmd.Parameters.AddWithValue("@ChId", int.Parse(idch.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("chambre supprimée");
            DataTable dt = ch.Select();
            listech.DataSource = dt;
            clear();
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

        private void reserbtn_Click(object sender, EventArgs e)
        {
            reservation res = new reservation();
            res.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deconbtn_Click(object sender, EventArgs e)
        {

            connexion c = new connexion();
            c.Show();
            this.Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

            // Récupérer le texte de la zone de recherche et le nettoyer
            string chrecherche = textBox1.Text.Trim();

            // Vérifier si la zone de recherche n'est pas vide
            if (chrecherche != "")
            {
                // Chaîne de connexion à la base de données
                string constring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=True";

                // Requête SQL pour rechercher les chambres par nom
                string req = "SELECT ChId as code, ChNom as Nom, ChCat as cat, ChPrix as prix, Chstatut as statut FROM chambre WHERE ChNom LIKE @searchTerm";

                // Création de la connexion SQL et de la commande avec les paramètres
                using (SqlConnection con = new SqlConnection(constring))
                {
                    SqlCommand cmd = new SqlCommand(req, con);
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + chrecherche + "%");

                    try
                    {
                        // Ouverture de la connexion et exécution de la commande
                        con.Open();
                        DataTable dt = new DataTable();
                        dt.Load(cmd.ExecuteReader());

                        // Mettre à jour la source de données de la grille avec les résultats de la recherche
                        listech.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        // Gérer les erreurs éventuelles lors de la recherche
                        MessageBox.Show("Erreur lors de la recherche : " + ex.Message);
                    }
                }
            }
            else
            {
                // Si la zone de recherche est vide, afficher toutes les chambres disponibles
                listerchambre();
            }
        }

        private void listech_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

