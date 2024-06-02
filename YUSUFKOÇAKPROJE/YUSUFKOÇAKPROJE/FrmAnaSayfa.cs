using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YUSUFKOÇAKPROJE
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void btnHareket_Click_1(object sender, EventArgs e)
        {
            FrmAracHareket frm = new FrmAracHareket();
            frm.Show();
        }

        private void btnMusteriler_Click_1(object sender, EventArgs e)
        {
            FrmMusteriler frm = new FrmMusteriler();
            frm.Show();

        }

        private void btnSatis_Click_1(object sender, EventArgs e)
        {
            FrmSatisKiralama frm = new FrmSatisKiralama();
            frm.Show();
        }

        private void btnAraç_Click_1(object sender, EventArgs e)
        {
            FrmArac frm = new FrmArac();
            frm.Show();
        }

        private void btnAracdurum_Click_1(object sender, EventArgs e)
        {
            FrmAracDurum frm = new FrmAracDurum();
            frm.Show();
        }

        private void btnAracbakım_Click_1(object sender, EventArgs e)
        {
            FrmBakimTakip frm = new FrmBakimTakip();
            frm.Show();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
