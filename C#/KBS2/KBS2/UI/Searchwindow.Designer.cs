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
            this.zk_combo = new System.Windows.Forms.ComboBox();
            this.Zk_Error = new System.Windows.Forms.Label();
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
            this.Zk_Bx.Location = new System.Drawing.Point(61, 283);
            this.Zk_Bx.Name = "Zk_Bx";
            this.Zk_Bx.Size = new System.Drawing.Size(604, 26);
            this.Zk_Bx.TabIndex = 1;
            this.Zk_Bx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Zk_Bx_KeyPress);
            // 
            // zk_combo
            // 
            this.zk_combo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.zk_combo.FormattingEnabled = true;
            this.zk_combo.Items.AddRange(new object[] {
            "ToetsID"});
            this.zk_combo.Location = new System.Drawing.Point(61, 283);
            this.zk_combo.Name = "zk_combo";
            this.zk_combo.Size = new System.Drawing.Size(168, 28);
            this.zk_combo.TabIndex = 2;
            this.zk_combo.Text = "ToetsID";
            this.zk_combo.Visible = false;
            // 
            // Zk_Error
            // 
            this.Zk_Error.AutoSize = true;
            this.Zk_Error.ForeColor = System.Drawing.Color.OrangeRed;
            this.Zk_Error.Location = new System.Drawing.Point(230, 321);
            this.Zk_Error.Name = "Zk_Error";
            this.Zk_Error.Size = new System.Drawing.Size(110, 20);
            this.Zk_Error.TabIndex = 3;
            this.Zk_Error.Text = "DO NOT EDIT";
            // 
            // Searchwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Zk_Error);
            this.Controls.Add(this.zk_combo);
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
        private System.Windows.Forms.ComboBox zk_combo;
        private System.Windows.Forms.Label Zk_Error;
    }
}
