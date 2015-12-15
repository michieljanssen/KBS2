namespace KBS2.UI
{
    partial class Searchwindow
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Zk_btn = new System.Windows.Forms.Button();
            this.Zk_Bx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Zk_btn
            // 
            this.Zk_btn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Zk_btn.Location = new System.Drawing.Point(671, 277);
            this.Zk_btn.Name = "Zk_btn";
            this.Zk_btn.Size = new System.Drawing.Size(75, 46);
            this.Zk_btn.TabIndex = 0;
            this.Zk_btn.Text = "Zoek";
            this.Zk_btn.UseVisualStyleBackColor = true;
            this.Zk_btn.Click += new System.EventHandler(this.Zk_btn_Click);
            // 
            // Zk_Bx
            // 
            this.Zk_Bx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Zk_Bx.Location = new System.Drawing.Point(55, 283);
            this.Zk_Bx.Name = "Zk_Bx";
            this.Zk_Bx.Size = new System.Drawing.Size(610, 35);
            this.Zk_Bx.TabIndex = 1;
            // 
            // Searchwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Zk_Bx);
            this.Controls.Add(this.Zk_btn);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Searchwindow";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Zk_btn;
        private System.Windows.Forms.TextBox Zk_Bx;
    }
}
