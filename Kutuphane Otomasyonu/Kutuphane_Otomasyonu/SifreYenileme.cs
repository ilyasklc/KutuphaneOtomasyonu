using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{
    public partial class SifreYenileme : Form
    {
        public SifreYenileme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");

       


        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update uye set sifre=@sifre where tc='" + txtTC.Text + "'", baglanti);
            komut.Parameters.AddWithValue("@sifre", txtYeniSifre.Text);
            if (txtYeniSifre.Text == txtYeniSifreTekrar.Text)
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("Sifre Degistirme Basarıyla Gerçekleşti", "Onay");

            }
            else
            {
                MessageBox.Show("Sifreler Aynı Uzunlukta Degil", "Hata");
            }
            baglanti.Close();
        }
    }
}
