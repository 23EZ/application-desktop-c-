namespace f_g_hotel
{
    partial class connexion_admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(connexion_admin));
            panel1 = new Panel();
            label1 = new Label();
            mdp = new TextBox();
            label2 = new Label();
            agbtn = new Label();
            login = new Button();
            pictureBox11 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Crimson;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(805, 83);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.GradientActiveCaption;
            label1.Location = new Point(295, 22);
            label1.Name = "label1";
            label1.Size = new Size(256, 36);
            label1.TabIndex = 3;
            label1.Text = "connexion admin";
            // 
            // mdp
            // 
            mdp.BackColor = SystemColors.ScrollBar;
            mdp.Location = new Point(417, 131);
            mdp.Name = "mdp";
            mdp.Size = new Size(179, 27);
            mdp.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(189, 133);
            label2.Name = "label2";
            label2.Size = new Size(141, 25);
            label2.TabIndex = 6;
            label2.Text = "mot de passe";
            // 
            // agbtn
            // 
            agbtn.AutoSize = true;
            agbtn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic | FontStyle.Underline, GraphicsUnit.Point, 0);
            agbtn.ForeColor = Color.FromArgb(192, 0, 0);
            agbtn.Location = new Point(451, 183);
            agbtn.Name = "agbtn";
            agbtn.Size = new Size(75, 25);
            agbtn.TabIndex = 9;
            agbtn.Text = "Agent?";
            agbtn.Click += agbtn_Click;
            // 
            // login
            // 
            login.BackColor = Color.DeepPink;
            login.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login.Location = new Point(401, 221);
            login.Name = "login";
            login.Size = new Size(179, 40);
            login.TabIndex = 8;
            login.Text = "se connecter";
            login.UseVisualStyleBackColor = false;
            login.Click += button1_Click;
            // 
            // pictureBox11
            // 
            pictureBox11.Image = (Image)resources.GetObject("pictureBox11.Image");
            pictureBox11.Location = new Point(731, 234);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(74, 84);
            pictureBox11.TabIndex = 27;
            pictureBox11.TabStop = false;
            pictureBox11.Click += pictureBox11_Click;
            // 
            // connexion_admin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 316);
            Controls.Add(pictureBox11);
            Controls.Add(agbtn);
            Controls.Add(login);
            Controls.Add(mdp);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "connexion_admin";
            Text = "connexion_admin";
            Load += connexion_admin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox mdp;
        private Label label2;
        private Label label3;
        private Button login;
        private Label label1;
        private Label agbtn;
        private PictureBox pictureBox11;
    }
}