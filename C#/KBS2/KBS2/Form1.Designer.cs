namespace KBS2
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
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.graphpanel1 = new KBS2Test.model.Graphpanel();
            this.GraphPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_zoek
            // 
            this.btn_zoek.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_zoek.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.btn_zoek.Location = new System.Drawing.Point(902, 364);
            this.btn_zoek.Name = "btn_zoek";
            this.btn_zoek.Size = new System.Drawing.Size(72, 32);
            this.btn_zoek.TabIndex = 0;
            this.btn_zoek.Text = "Zoek";
            this.btn_zoek.UseVisualStyleBackColor = true;
            this.btn_zoek.Click += new System.EventHandler(this.btn_zoek_Click);
            // 
            // txb_zoek
            // 
            this.txb_zoek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txb_zoek.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.txb_zoek.Location = new System.Drawing.Point(289, 364);
            this.txb_zoek.Name = "txb_zoek";
            this.txb_zoek.Size = new System.Drawing.Size(609, 32);
            this.txb_zoek.TabIndex = 1;
            this.txb_zoek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_zoek_KeyPress);
            // 
            // GraphPanel
            // 
            this.GraphPanel.Controls.Add(this.graphpanel1);
            this.GraphPanel.Location = new System.Drawing.Point(289, 25);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(685, 290);
            this.GraphPanel.TabIndex = 2;
            this.GraphPanel.Visible = false;
            this.GraphPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphPanel_Paint);
            // 
            // graphpanel1
            // 
            this.graphpanel1.BackColor = System.Drawing.Color.White;
            this.graphpanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphpanel1.Location = new System.Drawing.Point(65, 11);
            this.graphpanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.graphpanel1.Name = "graphpanel1";
            this.graphpanel1.Size = new System.Drawing.Size(606, 259);
            this.graphpanel1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 684);
            this.Controls.Add(this.GraphPanel);
            this.Controls.Add(this.txb_zoek);
            this.Controls.Add(this.btn_zoek);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GraphPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_zoek;
        private System.Windows.Forms.TextBox txb_zoek;
        private System.Windows.Forms.Panel GraphPanel;
        private KBS2Test.model.Graphpanel graphpanel1;
    }
}

