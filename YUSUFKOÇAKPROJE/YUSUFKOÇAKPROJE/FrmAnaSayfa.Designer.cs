namespace YUSUFKOÇAKPROJE
{
    partial class FrmAnaSayfa
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHareket = new System.Windows.Forms.Button();
            this.btnAraç = new System.Windows.Forms.Button();
            this.btnAracdurum = new System.Windows.Forms.Button();
            this.btnAracbakım = new System.Windows.Forms.Button();
            this.btnSatis = new System.Windows.Forms.Button();
            this.btnMusteriler = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHareket
            // 
            this.btnHareket.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHareket.Image = global::YUSUFKOÇAKPROJE.Properties.Resources.Hareketler;
            this.btnHareket.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnHareket.Location = new System.Drawing.Point(375, 300);
            this.btnHareket.Name = "btnHareket";
            this.btnHareket.Size = new System.Drawing.Size(173, 54);
            this.btnHareket.TabIndex = 2;
            this.btnHareket.Text = "Hareketler";
            this.btnHareket.UseVisualStyleBackColor = true;
            this.btnHareket.Click += new System.EventHandler(this.btnHareket_Click_1);
            // 
            // btnAraç
            // 
            this.btnAraç.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAraç.Image = global::YUSUFKOÇAKPROJE.Properties.Resources.Araç;
            this.btnAraç.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAraç.Location = new System.Drawing.Point(615, 161);
            this.btnAraç.Name = "btnAraç";
            this.btnAraç.Size = new System.Drawing.Size(173, 54);
            this.btnAraç.TabIndex = 3;
            this.btnAraç.Text = "Araçlar";
            this.btnAraç.UseVisualStyleBackColor = true;
            this.btnAraç.Click += new System.EventHandler(this.btnAraç_Click_1);
            // 
            // btnAracdurum
            // 
            this.btnAracdurum.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAracdurum.Image = global::YUSUFKOÇAKPROJE.Properties.Resources.Araç_Durumu;
            this.btnAracdurum.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAracdurum.Location = new System.Drawing.Point(615, 227);
            this.btnAracdurum.Name = "btnAracdurum";
            this.btnAracdurum.Size = new System.Drawing.Size(173, 54);
            this.btnAracdurum.TabIndex = 4;
            this.btnAracdurum.Text = "Araç Durumları";
            this.btnAracdurum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAracdurum.UseVisualStyleBackColor = true;
            this.btnAracdurum.Click += new System.EventHandler(this.btnAracdurum_Click_1);
            // 
            // btnAracbakım
            // 
            this.btnAracbakım.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAracbakım.Image = global::YUSUFKOÇAKPROJE.Properties.Resources.Araç_Bakım;
            this.btnAracbakım.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAracbakım.Location = new System.Drawing.Point(615, 300);
            this.btnAracbakım.Name = "btnAracbakım";
            this.btnAracbakım.Size = new System.Drawing.Size(173, 54);
            this.btnAracbakım.TabIndex = 5;
            this.btnAracbakım.Text = "Araç Bakım";
            this.btnAracbakım.UseVisualStyleBackColor = true;
            this.btnAracbakım.Click += new System.EventHandler(this.btnAracbakım_Click_1);
            // 
            // btnSatis
            // 
            this.btnSatis.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatis.Image = global::YUSUFKOÇAKPROJE.Properties.Resources.Satış_Ve_Kiralama1;
            this.btnSatis.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSatis.Location = new System.Drawing.Point(375, 227);
            this.btnSatis.Name = "btnSatis";
            this.btnSatis.Size = new System.Drawing.Size(173, 54);
            this.btnSatis.TabIndex = 1;
            this.btnSatis.Text = "Satış Ve Kiralama";
            this.btnSatis.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSatis.UseVisualStyleBackColor = true;
            this.btnSatis.Click += new System.EventHandler(this.btnSatis_Click_1);
            // 
            // btnMusteriler
            // 
            this.btnMusteriler.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteriler.Image = global::YUSUFKOÇAKPROJE.Properties.Resources.Müşteriler3;
            this.btnMusteriler.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnMusteriler.Location = new System.Drawing.Point(375, 161);
            this.btnMusteriler.Name = "btnMusteriler";
            this.btnMusteriler.Size = new System.Drawing.Size(173, 54);
            this.btnMusteriler.TabIndex = 0;
            this.btnMusteriler.Text = "Müşteriler";
            this.btnMusteriler.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMusteriler.UseVisualStyleBackColor = true;
            this.btnMusteriler.Click += new System.EventHandler(this.btnMusteriler_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::YUSUFKOÇAKPROJE.Properties.Resources.seramik;
            this.pictureBox1.Location = new System.Drawing.Point(1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 452);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(495, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Araç Kiralama";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(554, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ve";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(476, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Satış Otomasyonu";
            // 
            // FrmAnaSayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAracbakım);
            this.Controls.Add(this.btnAracdurum);
            this.Controls.Add(this.btnAraç);
            this.Controls.Add(this.btnHareket);
            this.Controls.Add(this.btnSatis);
            this.Controls.Add(this.btnMusteriler);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAnaSayfa";
            this.Text = "Araç Kiralama";
            this.Load += new System.EventHandler(this.FrmAnaSayfa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMusteriler;
        private System.Windows.Forms.Button btnSatis;
        private System.Windows.Forms.Button btnHareket;
        private System.Windows.Forms.Button btnAraç;
        private System.Windows.Forms.Button btnAracdurum;
        private System.Windows.Forms.Button btnAracbakım;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

