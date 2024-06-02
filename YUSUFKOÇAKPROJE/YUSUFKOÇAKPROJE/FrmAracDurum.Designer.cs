namespace YUSUFKOÇAKPROJE
{
    partial class FrmAracDurum
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
            this.components = new System.ComponentModel.Container();
            this.btnListele = new System.Windows.Forms.Button();
            this.yusufDataSet = new YUSUFKOÇAKPROJE.YusufDataSet();
            this.yusufDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.AracID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Plaka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Durum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SonIslemTarihi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.yusufDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yusufDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListele
            // 
            this.btnListele.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnListele.Image = global::YUSUFKOÇAKPROJE.Properties.Resources.Listele;
            this.btnListele.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListele.Location = new System.Drawing.Point(367, 387);
            this.btnListele.Name = "btnListele";
            this.btnListele.Size = new System.Drawing.Size(113, 51);
            this.btnListele.TabIndex = 1;
            this.btnListele.Text = "Listele";
            this.btnListele.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnListele.UseVisualStyleBackColor = true;
            this.btnListele.Click += new System.EventHandler(this.btnListele_Click);
            // 
            // yusufDataSet
            // 
            this.yusufDataSet.DataSetName = "YusufDataSet";
            this.yusufDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yusufDataSetBindingSource
            // 
            this.yusufDataSetBindingSource.DataSource = this.yusufDataSet;
            this.yusufDataSetBindingSource.Position = 0;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AracID,
            this.Plaka,
            this.Durum,
            this.SonIslemTarihi});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(104, 67);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(624, 300);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // AracID
            // 
            this.AracID.Text = "AracID";
            this.AracID.Width = 72;
            // 
            // Plaka
            // 
            this.Plaka.Text = "Plaka";
            this.Plaka.Width = 118;
            // 
            // Durum
            // 
            this.Durum.Text = "Durum";
            this.Durum.Width = 251;
            // 
            // SonIslemTarihi
            // 
            this.SonIslemTarihi.Text = "SonIslemTarihi";
            this.SonIslemTarihi.Width = 350;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(308, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Araç Durumları";
            // 
            // FrmAracDurum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnListele);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAracDurum";
            this.Text = "FrmAracDurum";
            this.Load += new System.EventHandler(this.FrmAracDurum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yusufDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yusufDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnListele;
        private YusufDataSet yusufDataSet;
        private System.Windows.Forms.BindingSource yusufDataSetBindingSource;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader AracID;
        private System.Windows.Forms.ColumnHeader Plaka;
        private System.Windows.Forms.ColumnHeader Durum;
        private System.Windows.Forms.ColumnHeader SonIslemTarihi;
        private System.Windows.Forms.Label label1;
    }
}