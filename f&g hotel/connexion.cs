using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace f_g_hotel
{
    public partial class connexion : Form
    {
        Fonctions con;

        // public int Agent;

        public connexion()
        {
            InitializeComponent();
            con = new Fonctions();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void adminbtn_Click(object sender, EventArgs e)
        {

            connexion_admin c = new connexion_admin();
            c.Show();
            this.Hide();
        }
        public static int Agent;
        private void login_Click(object sender, EventArgs e)
        {
           
            try
            {
                string req = "SELECT AgId, AgNom, AgMotpasse FROM agent where AgNom= '{0}'";
                req = string.Format(req, username.Text, mdp.Text);
                DataTable dt = con.RecupererDonnees(req);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("mot de passe incorrecte");
                }
                else
                {
                    Agent = Convert.ToInt32(dt.Rows[0][0].ToString());
                    reservation obj = new reservation();

                    obj.Show();
                    this.Hide();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void connexion_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mdp_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }
    }
}
