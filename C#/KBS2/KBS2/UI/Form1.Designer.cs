namespace KBS2.UI
{
    partial class Form1
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
            this.btn_stuurVergaderVerzoek = new System.Windows.Forms.Button();
            this.lbl_HulpNodig = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_stuurVergaderVerzoek
            // 
            this.btn_stuurVergaderVerzoek.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_stuurVergaderVerzoek.Location = new System.Drawing.Point(21, 102);
            this.btn_stuurVergaderVerzoek.Name = "btn_stuurVergaderVerzoek";
            this.btn_stuurVergaderVerzoek.Size = new System.Drawing.Size(251, 38);
            this.btn_stuurVergaderVerzoek.TabIndex = 0;
            this.btn_stuurVergaderVerzoek.Text = "Stuur vergaderverzoek";
            this.btn_stuurVergaderVerzoek.UseVisualStyleBackColor = true;
            // 
            // lbl_HulpNodig
            // 
            this.lbl_HulpNodig.AutoSize = true;
            this.lbl_HulpNodig.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_HulpNodig.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_HulpNodig.Location = new System.Drawing.Point(21, 56);
            this.lbl_HulpNodig.Name = "lbl_HulpNodig";
            this.lbl_HulpNodig.Size = new System.Drawing.Size(128, 26);
            this.lbl_HulpNodig.TabIndex = 1;
            this.lbl_HulpNodig.Text = "Hulp nodig?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lbl_HulpNodig);
            this.Controls.Add(this.btn_stuurVergaderVerzoek);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_stuurVergaderVerzoek;
        private System.Windows.Forms.Label lbl_HulpNodig;
    }
}