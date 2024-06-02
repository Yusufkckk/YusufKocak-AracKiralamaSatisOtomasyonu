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
    public partial class FrmSatisKiralama : Form
    {
        SqlConnection Baglanti = new SqlConnection("Data Source=DESKTOP-B1SHALI\\SQLEXPRESS;Initial Catalog=Yusuf;Integrated Security=True");
        public FrmSatisKiralama()
        {
            InitializeComponent();
            LoadMusteri();
            LoadArac();
        }

        private void LoadMusteri()
        {
            Baglanti.Open();
            SqlCommand veri = new SqlCommand("SELECT ID, Ad + ' ' + Soyad AS AdSoyad FROM TBL_Musteriler1", Baglanti);
            SqlDataReader rdr = veri.ExecuteReader();
            while (rdr.Read())
            {
                cmbMusteri.Items.Add(new KeyValuePair<int, string>((int)rdr["ID"], rdr["AdSoyad"].ToString()));
            }
            rdr.Close();
            Baglanti.Close();
            cmbMusteri.DisplayMember = "Value";
            cmbMusteri.ValueMember = "Key";
        }

        private void LoadArac()
        {
            Baglanti.Open();
            SqlCommand veri = new SqlCommand("SELECT ID, Marka + ' ' + Model + ' (' + Plaka + ')' AS AracBilgi FROM TBL_Arac1", Baglanti);
            SqlDataReader rdr = veri.ExecuteReader();
            while (rdr.Read())
            {
                cmbArac.Items.Add(new KeyValuePair<int, string>((int)rdr["ID"], rdr["AracBilgi"].ToString()));
            }
            rdr.Close();
            Baglanti.Close();
            cmbArac.DisplayMember = "Value";
            cmbArac.ValueMember = "Key";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbIslemturu.SelectedItem == null || cmbMusteri.SelectedItem == null || cmbArac.SelectedItem == null || string.IsNullOrWhiteSpace(txtFiyat.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Baglanti.Open();

            string kayit = "INSERT INTO TBL_SatisKiralama1(IslemTuru, MusteriID, AracID, SatisKiralamaTarihi,KiralamaBitisTarihi, Fiyat) VALUES (@islemTuru, @musteriID, @aracID, @tarih,@kiralamaBitisTarihi, @fiyat)";
            SqlCommand komut = new SqlCommand(kayit, Baglanti);
            komut.Parameters.AddWithValue("@islemTuru", cmbIslemturu.SelectedItem.ToString());
            komut.Parameters.AddWithValue("@musteriID", ((KeyValuePair<int, string>)cmbMusteri.SelectedItem).Key);
            komut.Parameters.AddWithValue("@aracID", ((KeyValuePair<int, string>)cmbArac.SelectedItem).Key);
            komut.Parameters.AddWithValue("@tarih", dtpTarih.Value);


            if (cmbIslemturu.SelectedItem.ToString() == "Kiralama")
            {
                komut.Parameters.AddWithValue("@kiralamaBitisTarihi", dtpKiralamaBitisTarihi.Value);
            }
            else
            {
                komut.Parameters.AddWithValue("@kiralamaBitisTarihi", DBNull.Value);
            }
            komut.Parameters.AddWithValue("@fiyat", decimal.Parse(txtFiyat.Text));

            komut.ExecuteNonQuery();

            string durumGuncelle = "IF EXISTS (SELECT 1 FROM TBL_AracDurum1 WHERE Plaka = @plaka) " +
                           "UPDATE TBL_AracDurum1 SET Durum = @durum, SonIslemTarihi = @sonIslemTarihi WHERE Plaka = @plaka " +
                           "ELSE " +
                           "INSERT INTO TBL_AracDurum1 (Plaka, Durum, SonIslemTarihi) VALUES (@plaka, @durum, @sonIslemTarihi)";
            SqlCommand durumKomut = new SqlCommand(durumGuncelle, Baglanti);

            string durum = cmbIslemturu.SelectedItem.ToString() == "Satış" ? "Satılmış" : "Kirada";
            durumKomut.Parameters.AddWithValue("@durum", durum);
            durumKomut.Parameters.AddWithValue("@sonIslemTarihi", dtpTarih.Value);

            // Plaka bilgisi için TBL_Arac1 tablosundan plaka çekiliyor
            SqlCommand plakaKomut = new SqlCommand("SELECT Plaka FROM TBL_Arac1 WHERE ID = @aracID", Baglanti);
            plakaKomut.Parameters.AddWithValue("@aracID", ((KeyValuePair<int, string>)cmbArac.SelectedItem).Key);
            string plaka = plakaKomut.ExecuteScalar()?.ToString();
            durumKomut.Parameters.AddWithValue("@plaka", plaka);

            durumKomut.ExecuteNonQuery();
            Baglanti.Close();

            MessageBox.Show("İşlem başarıyla kaydedildi.");
            Temizle();
            Listele();
        }
        private void Listele()
        {
            listView1.Items.Clear();

            Baglanti.Open();
            SqlCommand veri = new SqlCommand("SELECT * FROM TBL_SatisKiralama1", Baglanti);
            SqlDataReader rdr = veri.ExecuteReader();
            while (rdr.Read())
            {
                ListViewItem item = new ListViewItem(rdr["ID"].ToString());
                item.SubItems.Add(rdr["IslemTuru"].ToString());
                item.SubItems.Add(rdr["MusteriID"].ToString());
                item.SubItems.Add(rdr["AracID"].ToString());
                item.SubItems.Add(rdr["SatisKiralamaTarihi"].ToString());
                item.SubItems.Add(rdr["KiralamaBitisTarihi"].ToString());
                item.SubItems.Add(rdr["Fiyat"].ToString());
                listView1.Items.Add(item);
            }
            rdr.Close();
            Baglanti.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void Temizle()
        {
            cmbIslemturu.SelectedIndex = -1;
            cmbMusteri.SelectedIndex = -1;
            cmbArac.SelectedIndex = -1;
            dtpTarih.Value = DateTime.Now;
            dtpKiralamaBitisTarihi.Value = DateTime.Now;
            txtFiyat.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Seçili kaydı silmek istediğinizden emin misiniz?", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Baglanti.Open();
                    int id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    string silmeSorgusu = "DELETE FROM TBL_SatisKiralama1 WHERE ID = @id";
                    SqlCommand komut = new SqlCommand(silmeSorgusu, Baglanti);
                    komut.Parameters.AddWithValue("@id", id);
                    komut.ExecuteNonQuery();
                    Baglanti.Close();

                    MessageBox.Show("Kayıt başarıyla silindi.");
                    Listele();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kayıt seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FrmSatisKiralama_Load(object sender, EventArgs e)
        {

        }
    }
}
