namespace KBS2.UI
{
    partial class VergaderVerzoek
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lbl_vergaderVerzoekSturen = new System.Windows.Forms.Label();
            this.lbl_emailOntvanger = new System.Windows.Forms.Label();
            this.lbl_onderwerp = new System.Windows.Forms.Label();
            this.lbl_bericht = new System.Windows.Forms.Label();
            this.btn_verstuurBericht = new System.Windows.Forms.Button();
            this.txtbx_emailOntvanger = new System.Windows.Forms.TextBox();
            this.txtbx_onderwerp = new System.Windows.Forms.TextBox();
            this.txtbx_bericht = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_vergaderVerzoekSturen
            // 
            this.lbl_vergaderVerzoekSturen.AutoSize = true;
            this.lbl_vergaderVerzoekSturen.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbl_vergaderVerzoekSturen.Location = new System.Drawing.Point(477, 21);
            this.lbl_vergaderVerzoekSturen.Name = "lbl_vergaderVerzoekSturen";
            this.lbl_vergaderVerzoekSturen.Size = new System.Drawing.Size(408, 37);
            this.lbl_vergaderVerzoekSturen.TabIndex = 0;
            this.lbl_vergaderVerzoekSturen.Text = "Stuur een vergaderverzoek:";
            // 
            // lbl_emailOntvanger
            // 
            this.lbl_emailOntvanger.AutoSize = true;
            this.lbl_emailOntvanger.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbl_emailOntvanger.Location = new System.Drawing.Point(211, 86);
            this.lbl_emailOntvanger.Name = "lbl_emailOntvanger";
            this.lbl_emailOntvanger.Size = new System.Drawing.Size(267, 37);
            this.lbl_emailOntvanger.TabIndex = 1;
            this.lbl_emailOntvanger.Text = "E-mail ontvanger:";
            // 
            // lbl_onderwerp
            // 
            this.lbl_onderwerp.AutoSize = true;
            this.lbl_onderwerp.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbl_onderwerp.Location = new System.Drawing.Point(294, 141);
            this.lbl_onderwerp.Name = "lbl_onderwerp";
            this.lbl_onderwerp.Size = new System.Drawing.Size(184, 37);
            this.lbl_onderwerp.TabIndex = 2;
            this.lbl_onderwerp.Text = "Onderwerp:";
            // 
            // lbl_bericht
            // 
            this.lbl_bericht.AutoSize = true;
            this.lbl_bericht.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.lbl_bericht.Location = new System.Drawing.Point(353, 202);
            this.lbl_bericht.Name = "lbl_bericht";
            this.lbl_bericht.Size = new System.Drawing.Size(125, 37);
            this.lbl_bericht.TabIndex = 3;
            this.lbl_bericht.Text = "Bericht:";
            // 
            // btn_verstuurBericht
            // 
            this.btn_verstuurBericht.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_verstuurBericht.Location = new System.Drawing.Point(484, 679);
            this.btn_verstuurBericht.Name = "btn_verstuurBericht";
            this.btn_verstuurBericht.Size = new System.Drawing.Size(216, 42);
            this.btn_verstuurBericht.TabIndex = 4;
            this.btn_verstuurBericht.Text = "Verstuur bericht";
            this.btn_verstuurBericht.UseVisualStyleBackColor = true;
            this.btn_verstuurBericht.Click += new System.EventHandler(this.btn_verstuurBericht_Click);
            // 
            // txtbx_emailOntvanger
            // 
            this.txtbx_emailOntvanger.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtbx_emailOntvanger.Location = new System.Drawing.Point(484, 92);
            this.txtbx_emailOntvanger.Name = "txtbx_emailOntvanger";
            this.txtbx_emailOntvanger.Size = new System.Drawing.Size(581, 32);
            this.txtbx_emailOntvanger.TabIndex = 5;
            // 
            // txtbx_onderwerp
            // 
            this.txtbx_onderwerp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtbx_onderwerp.Location = new System.Drawing.Point(484, 141);
            this.txtbx_onderwerp.Name = "txtbx_onderwerp";
            this.txtbx_onderwerp.Size = new System.Drawing.Size(581, 32);
            this.txtbx_onderwerp.TabIndex = 6;
            // 
            // txtbx_bericht
            // 
            this.txtbx_bericht.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txtbx_bericht.Location = new System.Drawing.Point(484, 202);
            this.txtbx_bericht.Multiline = true;
            this.txtbx_bericht.Name = "txtbx_bericht";
            this.txtbx_bericht.Size = new System.Drawing.Size(581, 471);
            this.txtbx_bericht.TabIndex = 7;
            // 
            // VergaderVerzoek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.txtbx_bericht);
            this.Controls.Add(this.txtbx_onderwerp);
            this.Controls.Add(this.txtbx_emailOntvanger);
            this.Controls.Add(this.btn_verstuurBericht);
            this.Controls.Add(this.lbl_bericht);
            this.Controls.Add(this.lbl_onderwerp);
            this.Controls.Add(this.lbl_emailOntvanger);
            this.Controls.Add(this.lbl_vergaderVerzoekSturen);
            this.Name = "VergaderVerzoek";
            this.Text = "Vergaderverzoek sturen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VergaderVerzoek_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lbl_vergaderVerzoekSturen;
        private System.Windows.Forms.Label lbl_emailOntvanger;
        private System.Windows.Forms.Label lbl_onderwerp;
        private System.Windows.Forms.Label lbl_bericht;
        private System.Windows.Forms.Button btn_verstuurBericht;
        private System.Windows.Forms.TextBox txtbx_emailOntvanger;
        private System.Windows.Forms.TextBox txtbx_onderwerp;
        private System.Windows.Forms.TextBox txtbx_bericht;
    }
}