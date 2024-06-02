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
    public partial class FrmBakimTakip : Form
    {
        SqlConnection Baglanti = new SqlConnection("Data Source=DESKTOP-B1SHALI\\SQLEXPRESS;Initial Catalog=Yusuf;Integrated Security=True");
        public FrmBakimTakip()
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
            listView1.Columns.Add("Bakım ID", 100);
            listView1.Columns.Add("Plaka", 100);
            listView1.Columns.Add("Bakım Tarihi", 100);
            listView1.Columns.Add("Bakım Türü", 100);
            listView1.Columns.Add("Bakım Yapan", 100);
            listView1.Columns.Add("Maliyet", 100);
            listView1.Columns.Add("Açıklama", 200);
        }

        private void Listele(string plaka = null)
        {
            listView1.Items.Clear();

            try
            {
                Baglanti.Open();

                string query = "SELECT * FROM TBL_BakimTakip";

                if (!string.IsNullOrEmpty(plaka))
                {
                    query += " WHERE Plaka = @plaka";
                }

                SqlCommand veri = new SqlCommand(query, Baglanti);
                if (!string.IsNullOrEmpty(plaka))
                {
                    veri.Parameters.AddWithValue("@plaka", plaka);
                }

                SqlDataReader rdr = veri.ExecuteReader();

                if (!rdr.HasRows)
                {
                    MessageBox.Show("Kayıt bulunamadı.");
                    return;
                }

                while (rdr.Read())
                {
                    ListViewItem item = new ListViewItem(rdr["BakimID"].ToString());
                    item.SubItems.Add(rdr["Plaka"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(rdr["BakimTarihi"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(rdr["BakimTuru"].ToString());
                    item.SubItems.Add(rdr["BakimYapan"].ToString());
                    item.SubItems.Add(rdr["Maliyet"].ToString());
                    item.SubItems.Add(rdr["Aciklama"].ToString());
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

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Baglanti.Open();
                string query = "INSERT INTO TBL_BakimTakip (Plaka, BakimTarihi, BakimTuru, BakimYapan, Maliyet, Aciklama) VALUES (@Plaka, @BakimTarihi, @BakimTuru, @BakimYapan, @Maliyet, @Aciklama)";
                SqlCommand komut = new SqlCommand(query, Baglanti);
                komut.Parameters.AddWithValue("@Plaka", cmbPlaka.SelectedItem.ToString());
                komut.Parameters.AddWithValue("@BakimTarihi", dtpBakimTarihi.Value);
                komut.Parameters.AddWithValue("@BakimTuru", txtBakimTuru.Text);
                komut.Parameters.AddWithValue("@BakimYapan", txtBakimYapan.Text);
                komut.Parameters.AddWithValue("@Maliyet", decimal.Parse(txtMaliyet.Text));
                komut.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);

                komut.ExecuteNonQuery();
                MessageBox.Show("Bakım bilgisi başarıyla eklendi.");

                Listele();
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

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                try
                {
                    Baglanti.Open();
                    int bakimID = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                    string query = "DELETE FROM TBL_BakimTakip WHERE BakimID = @BakimID";
                    SqlCommand komut = new SqlCommand(query, Baglanti);
                    komut.Parameters.AddWithValue("@BakimID", bakimID);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Bakım kaydı başarıyla silindi.");

                    Listele();
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
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçin.");
            }
        }
    
    }
}
