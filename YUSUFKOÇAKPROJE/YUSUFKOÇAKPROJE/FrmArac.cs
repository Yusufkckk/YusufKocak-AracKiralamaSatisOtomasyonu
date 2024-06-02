using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YUSUFKOÇAKPROJE
{
    public partial class FrmArac : Form
    {
        SqlConnection Baglanti = new SqlConnection("Data Source=DESKTOP-B1SHALI\\SQLEXPRESS;Initial Catalog=Yusuf;Integrated Security=True");

        public int numara;
        public FrmArac()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Baglanti.Open();

            string kayit = "INSERT INTO TBL_Arac1 (Marka, Model, Yıl, Plaka, Yakıt, Aractipi) VALUES (@marka, @model, @yıl, @plaka, @yakıt, @aracTipi)";
            SqlCommand komut = new SqlCommand(kayit, Baglanti);
            komut.Parameters.AddWithValue("@marka", txtMarka.Text);
            komut.Parameters.AddWithValue("@model", txtModel.Text);
            komut.Parameters.AddWithValue("@yıl", txtYıl.Text);
            komut.Parameters.AddWithValue("@plaka", txtPlaka.Text);
            komut.Parameters.AddWithValue("@yakıt", cmbYakıt.SelectedItem != null ? cmbYakıt.SelectedItem.ToString() : "");
            komut.Parameters.AddWithValue("@aracTipi", cmbAractipi.SelectedItem != null ? cmbAractipi.SelectedItem.ToString() : "");


            komut.ExecuteNonQuery();
            Baglanti.Close();

            MessageBox.Show("Araç başarıyla kaydedildi.");
            Temizle();

            Listele();
        }
        private void FrmArac_Load(object sender, EventArgs e)
        {
            Listele();
        }
        private void Listele()
        {
            listView1.Items.Clear();

            Baglanti.Open();
            SqlCommand veri = new SqlCommand("SELECT * FROM TBL_Arac1", Baglanti);
            SqlDataReader rdr = veri.ExecuteReader();
            while (rdr.Read())
            {
                ListViewItem item = new ListViewItem(rdr["ID"].ToString());
                item.SubItems.Add(rdr["Marka"].ToString());
                item.SubItems.Add(rdr["Model"].ToString());
                item.SubItems.Add(rdr["Yıl"].ToString());
                item.SubItems.Add(rdr["Plaka"].ToString());
                item.SubItems.Add(rdr["Yakıt"].ToString());
                item.SubItems.Add(rdr["Aractipi"].ToString());
                listView1.Items.Add(item);
            }
            rdr.Close();
            Baglanti.Close();
        }
        private void Temizle()
        {
            txtMarka.Clear();
            txtModel.Clear();
            txtYıl.Clear();
            txtPlaka.Clear();
            cmbYakıt.SelectedIndex = -1;
            cmbAractipi.SelectedIndex = -1;
        }

       

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçili aracı silmek istediğinizden emin misiniz?", "Araç Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Baglanti.Open();
                    string plaka = listView1.SelectedItems[0].SubItems[4].Text; 
                    string silmeSorgusu = "DELETE FROM TBL_Arac1 WHERE Plaka = @plaka";
                    SqlCommand komut = new SqlCommand(silmeSorgusu, Baglanti);
                    komut.Parameters.AddWithValue("@plaka", plaka);
                    komut.ExecuteNonQuery();
                    Baglanti.Close();

                    Listele(); 
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir araç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

      

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçili aracın bilgilerini güncellemek istediğinizden emin misiniz?", "Araç Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Baglanti.Open();
                    string plaka = listView1.SelectedItems[0].SubItems[4].Text;
                    string guncellemeSorgusu = "UPDATE TBL_Arac1 SET Marka = @marka, Model = @model, Yıl = @yil, Yakıt = @yakıt, AracTipi = @aracTipi WHERE Plaka = @plaka";
                    SqlCommand komut = new SqlCommand(guncellemeSorgusu, Baglanti);
                    komut.Parameters.AddWithValue("@marka", txtMarka.Text);
                    komut.Parameters.AddWithValue("@model", txtModel.Text);
                    komut.Parameters.AddWithValue("@yil", txtYıl.Text);
                    komut.Parameters.AddWithValue("@yakıt", cmbYakıt.SelectedItem?.ToString());
                    komut.Parameters.AddWithValue("@aracTipi", cmbAractipi.SelectedItem?.ToString());
                    komut.Parameters.AddWithValue("@plaka", plaka);
                    komut.ExecuteNonQuery();
                    Baglanti.Close();

                    Listele();
                    Temizle();
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için bir araç seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_DoubleClick_1(object sender, EventArgs e)
        {
            numara = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txtMarka.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtModel.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtYıl.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtPlaka.Text = listView1.SelectedItems[0].SubItems[4].Text;
            cmbYakıt.Text = listView1.SelectedItems[0].SubItems[5].Text;
            cmbAractipi.Text = listView1.SelectedItems[0].SubItems[6].Text;

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();

        }

        
    }
}
