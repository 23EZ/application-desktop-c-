namespace f_g_hotel
{
    partial class connexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(connexion));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            label4 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            username = new TextBox();
            label2 = new Label();
            mdp = new TextBox();
            login = new Button();
            adminbtn = new Label();
            pictureBox4 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Crimson;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox2);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 509);
            panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(-3, 398);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(143, 108);
            pictureBox3.TabIndex = 23;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.GradientActiveCaption;
            label4.Location = new Point(-3, 236);
            label4.Name = "label4";
            label4.Size = new Size(250, 36);
            label4.TabIndex = 4;
            label4.Text = "connexion agent";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(28, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(148, 156);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(525, 43);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(64, 94);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(287, 181);
            label1.Name = "label1";
            label1.Size = new Size(176, 25);
            label1.TabIndex = 2;
            label1.Text = "nom d'utulisateur";
            // 
            // username
            // 
            username.BackColor = SystemColors.ScrollBar;
            username.Location = new Point(487, 181);
            username.Name = "username";
            username.Size = new Size(179, 23);
            username.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(287, 258);
            label2.Name = "label2";
            label2.Size = new Size(141, 25);
            label2.TabIndex = 4;
            label2.Text = "mot de passe";
            // 
            // mdp
            // 
            mdp.BackColor = SystemColors.ScrollBar;
            mdp.Location = new Point(487, 258);
            mdp.Name = "mdp";
            mdp.PasswordChar = '*';
            mdp.Size = new Size(179, 23);
            mdp.TabIndex = 5;
            mdp.UseSystemPasswordChar = true;
            mdp.TextChanged += mdp_TextChanged;
            // 
            // login
            // 
            login.BackColor = Color.HotPink;
            login.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login.Location = new Point(487, 321);
            login.Name = "login";
            login.Size = new Size(179, 40);
            login.TabIndex = 6;
            login.Text = "se connecter";
            login.UseVisualStyleBackColor = false;
            login.Click += login_Click;
            // 
            // adminbtn
            // 
            adminbtn.AutoSize = true;
            adminbtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            adminbtn.ForeColor = Color.FromArgb(192, 0, 0);
            adminbtn.Location = new Point(499, 398);
            adminbtn.Name = "adminbtn";
            adminbtn.Size = new Size(148, 25);
            adminbtn.TabIndex = 7;
            adminbtn.Text = "Administrateur?";
            adminbtn.Click += adminbtn_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(730, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(74, 84);
            pictureBox4.TabIndex = 22;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // connexion
            // 
            AutoScaleDimensions = new SizeF(8F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 508);
            Controls.Add(pictureBox4);
            Controls.Add(adminbtn);
            Controls.Add(login);
            Controls.Add(mdp);
            Controls.Add(label2);
            Controls.Add(username);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 8.25F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "connexion";
            Text = "connexion";
            Load += connexion_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label1;
        private TextBox username;
        private Label label2;
        private TextBox mdp;
        private Button login;
        private Label label3;
        private PictureBox pictureBox4;
        private Label label4;
        private Label adminbtn;
        private PictureBox pictureBox3;
    }
}