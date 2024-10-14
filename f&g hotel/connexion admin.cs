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
    public partial class connexion_admin : Form
    {
        public connexion_admin()
        {
            InitializeComponent();
        }

        private void agbtn_Click(object sender, EventArgs e)
        {

            connexion c = new connexion();
            c.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (mdp.Text == "")
            {
                MessageBox.Show("Entrez votre mot de passe");
            }
            else if (mdp.Text == "admin2024")
            {
                reservation res = new reservation();
                res.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Mot de passe incorrect.");
            }
        }

        private void connexion_admin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}