﻿namespace KBS2
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
            this.btn_zoek = new System.Windows.Forms.Button();
            this.txb_zoek = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_zoek
            // 
            this.btn_zoek.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_zoek.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_zoek.Location = new System.Drawing.Point(1055, 259);
            this.btn_zoek.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_zoek.Name = "btn_zoek";
            this.btn_zoek.Size = new System.Drawing.Size(108, 49);
            this.btn_zoek.TabIndex = 0;
            this.btn_zoek.Text = "Zoek";
            this.btn_zoek.UseVisualStyleBackColor = true;
            this.btn_zoek.Click += new System.EventHandler(this.btn_zoek_Click);
            // 
            // txb_zoek
            // 
            this.txb_zoek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_zoek.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txb_zoek.Location = new System.Drawing.Point(434, 259);
            this.txb_zoek.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txb_zoek.Name = "txb_zoek";
            this.txb_zoek.Size = new System.Drawing.Size(613, 44);
            this.txb_zoek.TabIndex = 1;
            this.txb_zoek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_zoek_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1597, 566);
            this.Controls.Add(this.txb_zoek);
            this.Controls.Add(this.btn_zoek);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_zoek;
        private System.Windows.Forms.TextBox txb_zoek;
    }
}

