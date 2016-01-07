namespace KBS2.UI
{
    partial class ToetsPanel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 3D);
            this.btn_zoek = new System.Windows.Forms.Button();
            this.txbx_zoek = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chrt_ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgv_toets = new System.Windows.Forms.DataGridView();
            this.lbl_behaald = new System.Windows.Forms.Label();
            this.lbl_nietbehaald = new System.Windows.Forms.Label();
            this.lbl_perc = new System.Windows.Forms.Label();
            this.cb_Zoek = new System.Windows.Forms.ComboBox();
            this.lbl_gem = new System.Windows.Forms.Label();
            this.lbl_type = new System.Windows.Forms.Label();
            this.lbl_err = new System.Windows.Forms.Label();
            this.cb_datum = new System.Windows.Forms.ComboBox();
            this.cb_jaar = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chrt_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_toets)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_zoek
            // 
            this.btn_zoek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_zoek.Location = new System.Drawing.Point(671, 3);
            this.btn_zoek.Name = "btn_zoek";
            this.btn_zoek.Size = new System.Drawing.Size(75, 46);
            this.btn_zoek.TabIndex = 0;
            this.btn_zoek.Text = "Zoek!";
            this.btn_zoek.UseVisualStyleBackColor = true;
            this.btn_zoek.Click += new System.EventHandler(this.Zk_Btn_Click);
            // 
            // txbx_zoek
            // 
            this.txbx_zoek.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbx_zoek.Location = new System.Drawing.Point(247, 9);
            this.txbx_zoek.Name = "txbx_zoek";
            this.txbx_zoek.Size = new System.Drawing.Size(418, 35);
            this.txbx_zoek.TabIndex = 1;
            this.txbx_zoek.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbx_zoek_KeyPress);
            // 
            // lbl_name
            // 
            this.lbl_name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(362, 81);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(77, 29);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Naam";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(55, 153);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(691, 29);
            this.progressBar1.TabIndex = 3;
            // 
            // chrt_
            // 
            this.chrt_.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chrt_.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrt_.Legends.Add(legend1);
            this.chrt_.Location = new System.Drawing.Point(55, 235);
            this.chrt_.Name = "chrt_";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.Points.Add(dataPoint1);
            this.chrt_.Series.Add(series1);
            this.chrt_.Size = new System.Drawing.Size(691, 233);
            this.chrt_.TabIndex = 4;
            this.chrt_.Text = "chart1";
            // 
            // dgv_toets
            // 
            this.dgv_toets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_toets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_toets.Location = new System.Drawing.Point(55, 474);
            this.dgv_toets.Name = "dgv_toets";
            this.dgv_toets.RowTemplate.Height = 28;
            this.dgv_toets.Size = new System.Drawing.Size(691, 117);
            this.dgv_toets.TabIndex = 5;
            this.dgv_toets.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_toets_CellDoubleClick);
            // 
            // lbl_behaald
            // 
            this.lbl_behaald.AutoSize = true;
            this.lbl_behaald.Location = new System.Drawing.Point(50, 121);
            this.lbl_behaald.Name = "lbl_behaald";
            this.lbl_behaald.Size = new System.Drawing.Size(208, 29);
            this.lbl_behaald.TabIndex = 6;
            this.lbl_behaald.Text = "BEHAALDERROR";
            // 
            // lbl_nietbehaald
            // 
            this.lbl_nietbehaald.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_nietbehaald.AutoSize = true;
            this.lbl_nietbehaald.Location = new System.Drawing.Point(299, 121);
            this.lbl_nietbehaald.Name = "lbl_nietbehaald";
            this.lbl_nietbehaald.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_nietbehaald.Size = new System.Drawing.Size(226, 29);
            this.lbl_nietbehaald.TabIndex = 7;
            this.lbl_nietbehaald.Text = "NBEHAALDERROR";
            // 
            // lbl_perc
            // 
            this.lbl_perc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_perc.AutoSize = true;
            this.lbl_perc.Location = new System.Drawing.Point(581, 121);
            this.lbl_perc.Name = "lbl_perc";
            this.lbl_perc.Size = new System.Drawing.Size(165, 29);
            this.lbl_perc.TabIndex = 8;
            this.lbl_perc.Text = "PERCERROR";
            // 
            // cb_Zoek
            // 
            this.cb_Zoek.FormattingEnabled = true;
            this.cb_Zoek.Items.AddRange(new object[] {
            "ToetsID"});
            this.cb_Zoek.Location = new System.Drawing.Point(55, 9);
            this.cb_Zoek.Name = "cb_Zoek";
            this.cb_Zoek.Size = new System.Drawing.Size(186, 37);
            this.cb_Zoek.TabIndex = 9;
            this.cb_Zoek.Text = "ToetsID";
            // 
            // lbl_gem
            // 
            this.lbl_gem.AutoSize = true;
            this.lbl_gem.Location = new System.Drawing.Point(55, 189);
            this.lbl_gem.Name = "lbl_gem";
            this.lbl_gem.Size = new System.Drawing.Size(172, 29);
            this.lbl_gem.TabIndex = 10;
            this.lbl_gem.Text = "LABELERROR";
            // 
            // lbl_type
            // 
            this.lbl_type.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(247, 185);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(147, 29);
            this.lbl_type.TabIndex = 11;
            this.lbl_type.Text = "TYPERROR";
            // 
            // lbl_err
            // 
            this.lbl_err.AutoSize = true;
            this.lbl_err.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbl_err.Location = new System.Drawing.Point(247, 51);
            this.lbl_err.Name = "lbl_err";
            this.lbl_err.Size = new System.Drawing.Size(99, 29);
            this.lbl_err.TabIndex = 12;
            this.lbl_err.Text = "ERROR";
            // 
            // cb_datum
            // 
            this.cb_datum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_datum.FormattingEnabled = true;
            this.cb_datum.Location = new System.Drawing.Point(425, 189);
            this.cb_datum.Name = "cb_datum";
            this.cb_datum.Size = new System.Drawing.Size(155, 37);
            this.cb_datum.TabIndex = 13;
            this.cb_datum.SelectionChangeCommitted += new System.EventHandler(this.cb_datum_SelectionChangeCommitted);
            // 
            // cb_jaar
            // 
            this.cb_jaar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_jaar.FormattingEnabled = true;
            this.cb_jaar.Location = new System.Drawing.Point(586, 188);
            this.cb_jaar.Name = "cb_jaar";
            this.cb_jaar.Size = new System.Drawing.Size(160, 37);
            this.cb_jaar.TabIndex = 14;
            this.cb_jaar.SelectionChangeCommitted += new System.EventHandler(this.cb_jaar_SelectionChangeCommitted);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cb_jaar);
            this.Controls.Add(this.cb_datum);
            this.Controls.Add(this.lbl_err);
            this.Controls.Add(this.lbl_type);
            this.Controls.Add(this.lbl_gem);
            this.Controls.Add(this.cb_Zoek);
            this.Controls.Add(this.lbl_perc);
            this.Controls.Add(this.lbl_nietbehaald);
            this.Controls.Add(this.lbl_behaald);
            this.Controls.Add(this.dgv_toets);
            this.Controls.Add(this.chrt_);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.txbx_zoek);
            this.Controls.Add(this.btn_zoek);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainWindow";
            this.Size = new System.Drawing.Size(800, 614);
            ((System.ComponentModel.ISupportInitialize)(this.chrt_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_toets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_zoek;
        private System.Windows.Forms.TextBox txbx_zoek;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrt_;
        private System.Windows.Forms.DataGridView dgv_toets;
        private System.Windows.Forms.Label lbl_behaald;
        private System.Windows.Forms.Label lbl_nietbehaald;
        private System.Windows.Forms.Label lbl_perc;
        private System.Windows.Forms.ComboBox cb_Zoek;
        private System.Windows.Forms.Label lbl_gem;
        private System.Windows.Forms.Label lbl_type;
        private System.Windows.Forms.Label lbl_err;
        private System.Windows.Forms.ComboBox cb_datum;
        private System.Windows.Forms.ComboBox cb_jaar;
    }
}
