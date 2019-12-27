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
using Kutuphane_Otomasyonu;
	

	

namespace Kutuphane_Otomasyonu
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
       
private void btnUye_Ekle_Click(object sender, EventArgs e)
        {
            Uye_Ekle uye_ekle = new Uye_Ekle();
            uye_ekle.ShowDialog();
        }

        private void btnUye_Listele_Click(object sender, EventArgs e)
        {
            UyeListeleme uye_liste = new UyeListeleme();
            uye_liste.ShowDialog();
        }

        private void btnKitap_Ekle_Click(object sender, EventArgs e)
        {
            KitapEkle kitap_ekle = new KitapEkle();
            kitap_ekle.ShowDialog(); 
        }

        private void btnKitap_Listele_Click(object sender, EventArgs e)
        {
            KitapListeleme kitap_listele = new KitapListeleme();
            kitap_listele.ShowDialog();
        }

        private void btnEmanet_Ver_Click(object sender, EventArgs e)
        {
            EmanetKitapVer emanet_kitap_ver = new EmanetKitapVer();
            emanet_kitap_ver.ShowDialog();
        }

        private void btnEmanet_Listele_Click(object sender, EventArgs e)
        {
            EmanetKitapListeleme emanet_kitap_listele = new EmanetKitapListeleme();
            emanet_kitap_listele.ShowDialog();
        }

        private void btnEmanet_İade_Click(object sender, EventArgs e)
        {
            EmanetKitapİade emanet_kitap_iade = new EmanetKitapİade();
            emanet_kitap_iade.ShowDialog();
        }

        private void btn_Siralama_Click(object sender, EventArgs e)
        {
            Siralama siralama_sayfasi = new Siralama();
            siralama_sayfasi.ShowDialog();

        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            Grafik grafik = new Grafik();
            grafik.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        
    }
}
