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
    public partial class FrmAracHareket : Form
    {
        SqlConnection Baglanti = new SqlConnection("Data Source=DESKTOP-B1SHALI\\SQLEXPRESS;Initial Catalog=Yusuf;Integrated Security=True");
        public FrmAracHareket()
        {
            InitializeComponent();
            LoadPlaka();
            InitializeListView();
        }

       
       

        private void LoadPlaka()
        {
            try
            {
                Baglanti.Open();
                SqlCommand veri = new SqlCommand("SELECT Plaka FROM TBL_Arac1", Baglanti);
                SqlDataReader rdr = veri.ExecuteReader();
                while (rdr.Read())
                {
                    cmbPlaka.Items.Add(rdr["Plaka"].ToString());
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Plaka yükleme sırasında bir hata oluştu: " + ex.Message);
            }
            finally
            {
                Baglanti.Close();
            }
        }
        private void InitializeListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("Hareket ID", 100);
            listView1.Columns.Add("Plaka", 100);
            listView1.Columns.Add("İşlem Türü", 100);
            listView1.Columns.Add("İşlem Tarihi", 100);
            listView1.Columns.Add("Müşteri Adı", 150);
        }

        private void Listele(string plaka = null)
        {
            listView1.Items.Clear();

            try
            {
                Baglanti.Open();

                string query = "SELECT h.HareketID, a.Plaka, h.IslemTuru, h.IslemTarihi, m.Ad + ' ' + m.Soyad AS MusteriAdSoyad " +
                               "FROM TBL_AracHareket h " +
                               "JOIN TBL_Arac1 a ON h.AracID = a.ıd " +
                               "JOIN TBL_Musteriler1 m ON h.MusteriID = m.ıd " +
                               "WHERE (@plaka IS NULL OR a.Plaka = @plaka) " +
                               "UNION " +
                               "SELECT sk.ID AS HareketID, a.Plaka, sk.IslemTuru, sk.SatisKiralamaTarihi AS IslemTarihi, m.Ad + ' ' + m.Soyad AS MusteriAdSoyad " +
                               "FROM TBL_SatisKiralama1 sk " +
                               "JOIN TBL_Arac1 a ON sk.AracID = a.ıd " +
                               "JOIN TBL_Musteriler1 m ON sk.MusteriID = m.ıd " +
                               "WHERE (@plaka IS NULL OR a.Plaka = @plaka)";

                SqlCommand veri = new SqlCommand(query, Baglanti);
                if (!string.IsNullOrEmpty(plaka))
                {
                    veri.Parameters.AddWithValue("@plaka", plaka);
                }
                else
                {
                    veri.Parameters.AddWithValue("@plaka", DBNull.Value);
                }

                SqlDataReader rdr = veri.ExecuteReader();

                if (!rdr.HasRows)
                {
                    MessageBox.Show("Kayıt bulunamadı.");
                    return;
                }

                while (rdr.Read())
                {
                    ListViewItem item = new ListViewItem(rdr["HareketID"].ToString());
                    item.SubItems.Add(rdr["Plaka"].ToString());
                    item.SubItems.Add(rdr["IslemTuru"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(rdr["IslemTarihi"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(rdr["MusteriAdSoyad"].ToString());
                    listView1.Items.Add(item);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                Baglanti.Close();
            }
        }

        private void FrmAracHareket_Load(object sender, EventArgs e)
        {

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            string plaka = cmbPlaka.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(plaka))
            {
                Listele(plaka);
            }
            else
            {
                MessageBox.Show("Lütfen bir plaka seçin.");
            }
        }
    }
}
