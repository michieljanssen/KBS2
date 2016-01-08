namespace KBS2.UI
{
    partial class InlogSchermStudent
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
            this.lbl_studentnr = new System.Windows.Forms.Label();
            this.lbl_wachtwoord = new System.Windows.Forms.Label();
            this.btn_inloggen = new System.Windows.Forms.Button();
            this.txtbx_email = new System.Windows.Forms.TextBox();
            this.txtbx_wachtwoord = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_studentnr
            // 
            this.lbl_studentnr.AutoSize = true;
            this.lbl_studentnr.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_studentnr.Location = new System.Drawing.Point(32, 160);
            this.lbl_studentnr.Name = "lbl_studentnr";
            this.lbl_studentnr.Size = new System.Drawing.Size(112, 26);
            this.lbl_studentnr.TabIndex = 0;
            this.lbl_studentnr.Text = "Studentnr:";
            this.lbl_studentnr.Click += new System.EventHandler(this.lbl_email_Click);
            // 
            // lbl_wachtwoord
            // 
            this.lbl_wachtwoord.AutoSize = true;
            this.lbl_wachtwoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_wachtwoord.Location = new System.Drawing.Point(32, 206);
            this.lbl_wachtwoord.Name = "lbl_wachtwoord";
            this.lbl_wachtwoord.Size = new System.Drawing.Size(139, 26);
            this.lbl_wachtwoord.TabIndex = 1;
            this.lbl_wachtwoord.Text = "Wachtwoord:";
            this.lbl_wachtwoord.Click += new System.EventHandler(this.lbl_wachtwoord_Click);
            // 
            // btn_inloggen
            // 
            this.btn_inloggen.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_inloggen.Location = new System.Drawing.Point(258, 269);
            this.btn_inloggen.Name = "btn_inloggen";
            this.btn_inloggen.Size = new System.Drawing.Size(108, 36);
            this.btn_inloggen.TabIndex = 2;
            this.btn_inloggen.Text = "Inloggen";
            this.btn_inloggen.UseVisualStyleBackColor = true;
            this.btn_inloggen.Click += new System.EventHandler(this.btn_inloggen_Click);
            // 
            // txtbx_email
            // 
            this.txtbx_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtbx_email.Location = new System.Drawing.Point(179, 157);
            this.txtbx_email.Name = "txtbx_email";
            this.txtbx_email.Size = new System.Drawing.Size(408, 32);
            this.txtbx_email.TabIndex = 3;
            this.txtbx_email.TextChanged += new System.EventHandler(this.txtbx_email_TextChanged);
            // 
            // txtbx_wachtwoord
            // 
            this.txtbx_wachtwoord.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtbx_wachtwoord.Location = new System.Drawing.Point(179, 206);
            this.txtbx_wachtwoord.Name = "txtbx_wachtwoord";
            this.txtbx_wachtwoord.PasswordChar = '*';
            this.txtbx_wachtwoord.Size = new System.Drawing.Size(408, 32);
            this.txtbx_wachtwoord.TabIndex = 4;
            this.txtbx_wachtwoord.TextChanged += new System.EventHandler(this.txtbx_wachtwoord_TextChanged);
            // 
            // InlogSchermStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.txtbx_wachtwoord);
            this.Controls.Add(this.txtbx_email);
            this.Controls.Add(this.btn_inloggen);
            this.Controls.Add(this.lbl_wachtwoord);
            this.Controls.Add(this.lbl_studentnr);
            this.Name = "InlogSchermStudent";
            this.Text = "Inloggen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_studentnr;
        private System.Windows.Forms.Label lbl_wachtwoord;
        private System.Windows.Forms.Button btn_inloggen;
        private System.Windows.Forms.TextBox txtbx_email;
        private System.Windows.Forms.TextBox txtbx_wachtwoord;
    }
}