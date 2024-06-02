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
    public partial class FrmAracDurum : Form
    {
        SqlConnection Baglanti = new SqlConnection("Data Source=DESKTOP-B1SHALI\\SQLEXPRESS;Initial Catalog=Yusuf;Integrated Security=True");
        

        public FrmAracDurum()
        {
            InitializeComponent();
          
        }

        private void FrmAracDurum_Load(object sender, EventArgs e)
        {
            Listele();
           

        }
        private void Listele()
        {
            listView1.Items.Clear();

            try
            {
                Baglanti.Open();
                string query = "SELECT * FROM TBL_AracDurum1";
                SqlCommand cmd = new SqlCommand(query, Baglanti);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    ListViewItem item = new ListViewItem(rdr["AracID"].ToString());
                    item.SubItems.Add(rdr["Plaka"].ToString());
                    item.SubItems.Add(rdr["Durum"].ToString());
                    item.SubItems.Add(rdr["SonIslemTarihi"].ToString());
                    listView1.Items.Add(item);
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme sırasında bir hata oluştu: " + ex.Message);
            }
            finally
            {
                if (Baglanti.State == ConnectionState.Open)
                {
                    Baglanti.Close();
                }

            }
        }

            public void DurumGuncelle(string plaka, string durum, DateTime sonIslemTarihi)
        {
            Baglanti.Open();

            string guncelleSorgusu = "UPDATE TBL_AracDurum1 SET Durum = @durum, SonIslemTarihi = @sonIslemTarihi WHERE Plaka = @plaka";
            SqlCommand komut = new SqlCommand(guncelleSorgusu, Baglanti);
            komut.Parameters.AddWithValue("@durum", durum);
            komut.Parameters.AddWithValue("@sonIslemTarihi", sonIslemTarihi);
            komut.Parameters.AddWithValue("@plaka", plaka);
            komut.ExecuteNonQuery();

            Baglanti.Close();

            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            try
            {
                Listele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme sırasında bir hata oluştu: " + ex.Message);
            }
        }
     }
}