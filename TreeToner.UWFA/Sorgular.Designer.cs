namespace TreeToner.UWFA
{
    partial class Sorgular
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTumKayitlar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBaslik = new System.Windows.Forms.Label();
            this.btnHazir = new System.Windows.Forms.Button();
            this.btnIslemAsamasinda = new System.Windows.Forms.Button();
            this.btnParcaBekliyor = new System.Windows.Forms.Button();
            this.btnTeslimEdildi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIade = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1338, 244);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnTumKayitlar
            // 
            this.btnTumKayitlar.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTumKayitlar.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnTumKayitlar.Location = new System.Drawing.Point(692, 21);
            this.btnTumKayitlar.Name = "btnTumKayitlar";
            this.btnTumKayitlar.Size = new System.Drawing.Size(120, 74);
            this.btnTumKayitlar.TabIndex = 4;
            this.btnTumKayitlar.Text = "TÜM KAYITLAR";
            this.btnTumKayitlar.UseVisualStyleBackColor = true;
            this.btnTumKayitlar.Click += new System.EventHandler(this.btnTumKayitlar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIade);
            this.groupBox1.Controls.Add(this.lblBaslik);
            this.groupBox1.Controls.Add(this.btnHazir);
            this.groupBox1.Controls.Add(this.btnIslemAsamasinda);
            this.groupBox1.Controls.Add(this.btnParcaBekliyor);
            this.groupBox1.Controls.Add(this.btnTeslimEdildi);
            this.groupBox1.Controls.Add(this.btnTumKayitlar);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1344, 185);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblBaslik
            // 
            this.lblBaslik.AutoSize = true;
            this.lblBaslik.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBaslik.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.lblBaslik.Location = new System.Drawing.Point(12, 126);
            this.lblBaslik.Name = "lblBaslik";
            this.lblBaslik.Size = new System.Drawing.Size(101, 34);
            this.lblBaslik.TabIndex = 6;
            this.lblBaslik.Text = "label1";
            // 
            // btnHazir
            // 
            this.btnHazir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnHazir.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHazir.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnHazir.Location = new System.Drawing.Point(314, 21);
            this.btnHazir.Name = "btnHazir";
            this.btnHazir.Size = new System.Drawing.Size(120, 74);
            this.btnHazir.TabIndex = 5;
            this.btnHazir.Text = "HAZIR";
            this.btnHazir.UseVisualStyleBackColor = false;
            this.btnHazir.Click += new System.EventHandler(this.btnParcaBekliyor_Click);
            // 
            // btnIslemAsamasinda
            // 
            this.btnIslemAsamasinda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnIslemAsamasinda.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIslemAsamasinda.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnIslemAsamasinda.Location = new System.Drawing.Point(155, 21);
            this.btnIslemAsamasinda.Name = "btnIslemAsamasinda";
            this.btnIslemAsamasinda.Size = new System.Drawing.Size(153, 74);
            this.btnIslemAsamasinda.TabIndex = 5;
            this.btnIslemAsamasinda.Text = "İŞLEM AŞAMASINDA";
            this.btnIslemAsamasinda.UseVisualStyleBackColor = false;
            this.btnIslemAsamasinda.Click += new System.EventHandler(this.btnParcaBekliyor_Click);
            // 
            // btnParcaBekliyor
            // 
            this.btnParcaBekliyor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnParcaBekliyor.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParcaBekliyor.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnParcaBekliyor.Location = new System.Drawing.Point(6, 21);
            this.btnParcaBekliyor.Name = "btnParcaBekliyor";
            this.btnParcaBekliyor.Size = new System.Drawing.Size(143, 74);
            this.btnParcaBekliyor.TabIndex = 5;
            this.btnParcaBekliyor.Text = "PARÇA BEKLENİYOR";
            this.btnParcaBekliyor.UseVisualStyleBackColor = false;
            this.btnParcaBekliyor.Click += new System.EventHandler(this.btnParcaBekliyor_Click);
            // 
            // btnTeslimEdildi
            // 
            this.btnTeslimEdildi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTeslimEdildi.Font = new System.Drawing.Font("Candara", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeslimEdildi.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnTeslimEdildi.Location = new System.Drawing.Point(440, 21);
            this.btnTeslimEdildi.Name = "btnTeslimEdildi";
            this.btnTeslimEdildi.Size = new System.Drawing.Size(120, 74);
            this.btnTeslimEdildi.TabIndex = 5;
            this.btnTeslimEdildi.Text = "TESLİM EDİLDİ";
            this.btnTeslimEdildi.UseVisualStyleBackColor = false;
            this.btnTeslimEdildi.Click += new System.EventHandler(this.btnParcaBekliyor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 185);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1344, 265);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sonuçlar";
            // 
            // btnIade
            // 
            this.btnIade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnIade.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIade.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnIade.Location = new System.Drawing.Point(566, 21);
            this.btnIade.Name = "btnIade";
            this.btnIade.Size = new System.Drawing.Size(120, 74);
            this.btnIade.TabIndex = 7;
            this.btnIade.Text = "İADE";
            this.btnIade.UseVisualStyleBackColor = false;
            this.btnIade.Click += new System.EventHandler(this.btnParcaBekliyor_Click);
            // 
            // Sorgular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Sorgular";
            this.Text = "Sorgular";
            this.Load += new System.EventHandler(this.Sorgular_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTumKayitlar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHazir;
        private System.Windows.Forms.Button btnIslemAsamasinda;
        private System.Windows.Forms.Button btnParcaBekliyor;
        private System.Windows.Forms.Button btnTeslimEdildi;
        private System.Windows.Forms.Label lblBaslik;
        private System.Windows.Forms.Button btnIade;
    }
}