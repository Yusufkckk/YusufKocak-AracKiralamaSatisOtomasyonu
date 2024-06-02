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
    public partial class FrmMusteriler : Form
    {
        SqlConnection Baglanti = new SqlConnection("Data Source=DESKTOP-B1SHALI\\SQLEXPRESS;Initial Catalog=Yusuf;Integrated Security=True");

        public int numara;
        public FrmMusteriler()
        {
            InitializeComponent();
        }

        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            Listele();
           
        }

        private void Listele()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            Baglanti.Open();
            SqlCommand veri = new SqlCommand("Select * From TBL_Musteriler1", Baglanti);
            SqlDataReader rdr = veri.ExecuteReader();
            while (rdr.Read())
            {
                ListViewItem item = new ListViewItem(rdr["ıd"].ToString());
                item.SubItems.Add(rdr["Ad"].ToString());
                item.SubItems.Add(rdr["Soyad"].ToString());
                item.SubItems.Add(rdr["Telefon"].ToString());
                item.SubItems.Add(rdr["Yas"].ToString());
                item.SubItems.Add(rdr["Cinsiyet"].ToString());
                item.SubItems.Add(rdr["Adres"].ToString());
                item.SubItems.Add(rdr["TC"].ToString());
                listView1.Items.Add(item);
                
            }
            Baglanti.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Baglanti.Open();
            string kayit = "insert into TBL_Musteriler1 (Ad,Soyad,Telefon,Yas,Cinsiyet,Adres,TC) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)";
            SqlCommand ekle = new SqlCommand(kayit , Baglanti);
            ekle.Parameters.AddWithValue("@p1", txtAd.Text);
            ekle.Parameters.AddWithValue("@p2", txtSoyad.Text);
            ekle.Parameters.AddWithValue("@p3", txtTelefon.Text);
            ekle.Parameters.AddWithValue("@p4", txtYas.Text);
            ekle.Parameters.AddWithValue("@p5", txtCinsiyet.Text);
            ekle.Parameters.AddWithValue("@p6", txtAdres.Text);
            ekle.Parameters.AddWithValue("@p7", txtTc.Text);
            ekle.ExecuteNonQuery();
            Baglanti.Close();

            Listele();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            numara = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txtAd.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtSoyad.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtTelefon.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtYas.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txtCinsiyet.Text = listView1.SelectedItems[0].SubItems[5].Text;
            txtAdres.Text = listView1.SelectedItems[0].SubItems[6].Text;
            txtTc.Text = listView1.SelectedItems[0].SubItems[7].Text;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Baglanti.Open();

                string silmeCumlesi = "Delete From TBL_Musteriler1 where TC=@tc";
                SqlCommand sil = new SqlCommand(silmeCumlesi, Baglanti);
                sil.Parameters.AddWithValue("@tc", listView1.SelectedItems[0].SubItems[7].Text);
                sil.ExecuteNonQuery();
                Baglanti.Close();

                Listele();
            }
        }

        public void Temizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTc.Clear();
            txtTelefon.Clear();
            txtYas.Clear();
         }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
              if (listView1.SelectedItems.Count > 0)
                {
                  DialogResult result = MessageBox.Show("Seçili müşterinin bilgilerini güncellemek istediğinizden emin misiniz?", "Müşteri Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                  if (result == DialogResult.Yes)
                  {                
                    Baglanti.Open();

                    string Tc = listView1.SelectedItems[0].SubItems[7].Text;
                    string güncelleCumlesi = "Update TBL_Musteriler1 SET Ad = @ad, Soyad = @soyad, Telefon = @telefon, Yas = @yas, Cinsiyet = @cinsiyet, Adres = @adres WHERE TC = @tc";
                    SqlCommand komut = new SqlCommand(güncelleCumlesi, Baglanti);

                    komut.Parameters.AddWithValue("@ad", txtAd.Text);
                    komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                    komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                    komut.Parameters.AddWithValue("@yas", txtYas.Text);
                    komut.Parameters.AddWithValue("@cinsiyet", txtCinsiyet.Text);
                    komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                    komut.Parameters.AddWithValue("@tc", Tc);
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
    }
}
