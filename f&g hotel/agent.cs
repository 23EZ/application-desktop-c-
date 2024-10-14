using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace f_g_hotel
{
    public partial class agent : Form
    {

        Agentmethode a = new Agentmethode();
        public agent()
        {
            InitializeComponent();

        }

        private void nomag_TextChanged(object sender, EventArgs e)
        {

        }

        private void enregistrer_Click(object sender, EventArgs e)
        {

            a.AgNom = nomag.Text;
            a.AgTel = tel.Text;
            a.AgGenre = genre.Text;
            a.AgAdd = add.Text;
            a.AgMotPasse = mdp.Text;
            bool succes = a.insert(a);
            if (succes == true)
            {
                MessageBox.Show("agent ajouté avec succes");
                clear();
            }
            else
            {
                MessageBox.Show("erreur");
            }
            DataTable dt = a.Select();
            listeAgent.DataSource = dt;





        }

        private void agent_Load(object sender, EventArgs e)
        {

            DataTable dt = a.Select();
            listeAgent.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void clear()
        {
            
            nomag.Text = "";
            add.Text = "";
            genre.Text = "";
            tel.Text = "";
            mdp.Text = "";
            Id.Text = "";
        }

        private void modifier_Click(object sender, EventArgs e)
        {

           
            a.AgNom = nomag.Text;
            a.AgTel = tel.Text;
            a.AgGenre = genre.Text;
            a.AgAdd = add.Text;
            a.AgMotPasse = mdp.Text;
            a.AgId = Id.Text;

           
            bool succes = a.update(a);
            if (succes == true)
            {
                MessageBox.Show("agent modifié avec succes");
                DataTable dt = a.Select();
                listeAgent.DataSource = dt;
            }
            else
            {
                MessageBox.Show("erreur");
            }


            clear();



        }

        private void listeAgent_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            Id.Text = listeAgent.Rows[rowIndex].Cells[0].Value.ToString();
            nomag.Text = listeAgent.Rows[rowIndex].Cells[1].Value.ToString();
            tel.Text = listeAgent.Rows[rowIndex].Cells[2].Value.ToString();
            genre.Text = listeAgent.Rows[rowIndex].Cells[3].Value.ToString();
            add.Text = listeAgent.Rows[rowIndex].Cells[4].Value.ToString();
            mdp.Text = listeAgent.Rows[rowIndex].Cells[5].Value.ToString();
        }


        private void listeAgent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listeAgent_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void supprimer_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel;Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE agent WHERE AgId=@AgId", con);
            cmd.Parameters.AddWithValue("@AgId", int.Parse(Id.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("agent supprimé");
            DataTable dt = a.Select();
            listeAgent.DataSource = dt;
            clear();




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

        private void reservbtn_Click(object sender, EventArgs e)
        {
            reservation res = new reservation();
            res.Show();
            this.Hide();

        }

        private void decnbtn_Click(object sender, EventArgs e)
        {

            connexion c = new connexion();
            c.Show();
            this.Hide();
        }
    }
}
