namespace KBS2.UI
{
    partial class MainWindow
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
            this.btn_zoek = new System.Windows.Forms.Button();
            this.txbx_zoek = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chrt_ = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtgrd = new System.Windows.Forms.DataGridView();
            this.lbl_behaald = new System.Windows.Forms.Label();
            this.lbl_nietbehaald = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chrt_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd)).BeginInit();
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
            this.txbx_zoek.Location = new System.Drawing.Point(55, 9);
            this.txbx_zoek.Name = "txbx_zoek";
            this.txbx_zoek.Size = new System.Drawing.Size(610, 35);
            this.txbx_zoek.TabIndex = 1;
            // 
            // lbl_name
            // 
            this.lbl_name.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(362, 47);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(77, 29);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "Naam";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(55, 119);
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
            this.chrt_.Location = new System.Drawing.Point(55, 178);
            this.chrt_.Name = "chrt_";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrt_.Series.Add(series1);
            this.chrt_.Size = new System.Drawing.Size(691, 288);
            this.chrt_.TabIndex = 4;
            this.chrt_.Text = "chart1";
            // 
            // dtgrd
            // 
            this.dtgrd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgrd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrd.Location = new System.Drawing.Point(55, 472);
            this.dtgrd.Name = "dtgrd";
            this.dtgrd.RowTemplate.Height = 28;
            this.dtgrd.Size = new System.Drawing.Size(691, 119);
            this.dtgrd.TabIndex = 5;
            // 
            // lbl_behaald
            // 
            this.lbl_behaald.AutoSize = true;
            this.lbl_behaald.Location = new System.Drawing.Point(50, 87);
            this.lbl_behaald.Name = "lbl_behaald";
            this.lbl_behaald.Size = new System.Drawing.Size(153, 29);
            this.lbl_behaald.TabIndex = 6;
            this.lbl_behaald.Text = "Behaald: 000";
            // 
            // lbl_nietbehaald
            // 
            this.lbl_nietbehaald.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbl_nietbehaald.AutoSize = true;
            this.lbl_nietbehaald.Location = new System.Drawing.Point(299, 87);
            this.lbl_nietbehaald.Name = "lbl_nietbehaald";
            this.lbl_nietbehaald.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_nietbehaald.Size = new System.Drawing.Size(203, 29);
            this.lbl_nietbehaald.TabIndex = 7;
            this.lbl_nietbehaald.Text = "Niet Behaald: 000";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Percentage: 100%";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_nietbehaald);
            this.Controls.Add(this.lbl_behaald);
            this.Controls.Add(this.dtgrd);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgrd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_zoek;
        private System.Windows.Forms.TextBox txbx_zoek;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrt_;
        private System.Windows.Forms.DataGridView dtgrd;
        private System.Windows.Forms.Label lbl_behaald;
        private System.Windows.Forms.Label lbl_nietbehaald;
        private System.Windows.Forms.Label label1;
    }
}
