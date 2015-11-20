namespace KBS2
{
    partial class TestForm
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
            this.testbtn_zoek = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_gemisteEC = new System.Windows.Forms.Label();
            this.lbl_gehaaldeEC = new System.Windows.Forms.Label();
            this.testprb_gehaald = new System.Windows.Forms.ProgressBar();
            this.lbl_totaalEC = new System.Windows.Forms.Label();
            this.dgv_gemisteEC = new System.Windows.Forms.DataGridView();
            this.Vak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijfer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_behaaldeEC = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_gehaald = new System.Windows.Forms.Label();
            this.lbl_gemist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gemisteEC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_behaaldeEC)).BeginInit();
            this.SuspendLayout();
            // 
            // testbtn_zoek
            // 
            this.testbtn_zoek.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.testbtn_zoek.Location = new System.Drawing.Point(977, 20);
            this.testbtn_zoek.Name = "testbtn_zoek";
            this.testbtn_zoek.Size = new System.Drawing.Size(72, 32);
            this.testbtn_zoek.TabIndex = 0;
            this.testbtn_zoek.Text = "Zoek";
            this.testbtn_zoek.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBox1.Location = new System.Drawing.Point(334, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(628, 32);
            this.textBox1.TabIndex = 1;
            // 
            // lbl_gemisteEC
            // 
            this.lbl_gemisteEC.AutoSize = true;
            this.lbl_gemisteEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_gemisteEC.Location = new System.Drawing.Point(951, 127);
            this.lbl_gemisteEC.Name = "lbl_gemisteEC";
            this.lbl_gemisteEC.Size = new System.Drawing.Size(152, 26);
            this.lbl_gemisteEC.TabIndex = 5;
            this.lbl_gemisteEC.Text = "Gemiste EC\'s:";
            // 
            // lbl_gehaaldeEC
            // 
            this.lbl_gehaaldeEC.AutoSize = true;
            this.lbl_gehaaldeEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_gehaaldeEC.Location = new System.Drawing.Point(95, 127);
            this.lbl_gehaaldeEC.Name = "lbl_gehaaldeEC";
            this.lbl_gehaaldeEC.Size = new System.Drawing.Size(233, 26);
            this.lbl_gehaaldeEC.TabIndex = 3;
            this.lbl_gehaaldeEC.Text = "Behaalde EC\'s dit jaar:";
            this.lbl_gehaaldeEC.Click += new System.EventHandler(this.testlbl_aantalvoldoendes_Click);
            // 
            // testprb_gehaald
            // 
            this.testprb_gehaald.ForeColor = System.Drawing.Color.Lime;
            this.testprb_gehaald.Location = new System.Drawing.Point(100, 156);
            this.testprb_gehaald.Name = "testprb_gehaald";
            this.testprb_gehaald.Size = new System.Drawing.Size(1089, 23);
            this.testprb_gehaald.TabIndex = 6;
            this.testprb_gehaald.Value = 80;
            // 
            // lbl_totaalEC
            // 
            this.lbl_totaalEC.AutoSize = true;
            this.lbl_totaalEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_totaalEC.Location = new System.Drawing.Point(532, 127);
            this.lbl_totaalEC.Name = "lbl_totaalEC";
            this.lbl_totaalEC.Size = new System.Drawing.Size(57, 26);
            this.lbl_totaalEC.TabIndex = 4;
            this.lbl_totaalEC.Text = "Van:";
            // 
            // dgv_gemisteEC
            // 
            this.dgv_gemisteEC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_gemisteEC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_gemisteEC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Vak,
            this.Cijfer,
            this.EC});
            this.dgv_gemisteEC.Location = new System.Drawing.Point(100, 234);
            this.dgv_gemisteEC.Name = "dgv_gemisteEC";
            this.dgv_gemisteEC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_gemisteEC.Size = new System.Drawing.Size(1089, 230);
            this.dgv_gemisteEC.TabIndex = 7;
            // 
            // Vak
            // 
            this.Vak.HeaderText = "Vak";
            this.Vak.Name = "Vak";
            this.Vak.ReadOnly = true;
            // 
            // Cijfer
            // 
            this.Cijfer.HeaderText = "CIJFER";
            this.Cijfer.Name = "Cijfer";
            this.Cijfer.ReadOnly = true;
            // 
            // EC
            // 
            this.EC.HeaderText = "EC\'s";
            this.EC.Name = "EC";
            this.EC.ReadOnly = true;
            // 
            // dgv_behaaldeEC
            // 
            this.dgv_behaaldeEC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_behaaldeEC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_behaaldeEC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dgv_behaaldeEC.Location = new System.Drawing.Point(100, 516);
            this.dgv_behaaldeEC.Name = "dgv_behaaldeEC";
            this.dgv_behaaldeEC.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_behaaldeEC.Size = new System.Drawing.Size(1089, 230);
            this.dgv_behaaldeEC.TabIndex = 8;
            this.dgv_behaaldeEC.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_behaaldeEC_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Vak";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "CIJFER";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "EC\'s";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // lbl_gehaald
            // 
            this.lbl_gehaald.AutoSize = true;
            this.lbl_gehaald.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_gehaald.Location = new System.Drawing.Point(95, 487);
            this.lbl_gehaald.Name = "lbl_gehaald";
            this.lbl_gehaald.Size = new System.Drawing.Size(144, 26);
            this.lbl_gehaald.TabIndex = 9;
            this.lbl_gehaald.Text = "Gehaalde Ec:";
            this.lbl_gehaald.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl_gemist
            // 
            this.lbl_gemist.AutoSize = true;
            this.lbl_gemist.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lbl_gemist.Location = new System.Drawing.Point(95, 205);
            this.lbl_gemist.Name = "lbl_gemist";
            this.lbl_gemist.Size = new System.Drawing.Size(132, 26);
            this.lbl_gemist.TabIndex = 10;
            this.lbl_gemist.Text = "Gemiste Ec:";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 761);
            this.Controls.Add(this.lbl_gemist);
            this.Controls.Add(this.lbl_gehaald);
            this.Controls.Add(this.dgv_behaaldeEC);
            this.Controls.Add(this.dgv_gemisteEC);
            this.Controls.Add(this.testprb_gehaald);
            this.Controls.Add(this.lbl_gemisteEC);
            this.Controls.Add(this.lbl_totaalEC);
            this.Controls.Add(this.lbl_gehaaldeEC);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.testbtn_zoek);
            this.Name = "TestForm";
            this.Text = "TestForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_gemisteEC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_behaaldeEC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button testbtn_zoek;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_gemisteEC;
        private System.Windows.Forms.Label lbl_gehaaldeEC;
        private System.Windows.Forms.ProgressBar testprb_gehaald;
        private System.Windows.Forms.Label lbl_totaalEC;
        private System.Windows.Forms.DataGridView dgv_gemisteEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vak;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijfer;
        private System.Windows.Forms.DataGridViewTextBoxColumn EC;
        private System.Windows.Forms.DataGridView dgv_behaaldeEC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label lbl_gehaald;
        private System.Windows.Forms.Label lbl_gemist;

    }
}