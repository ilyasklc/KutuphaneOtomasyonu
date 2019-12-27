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
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
        SqlCommand komut;
        SqlDataReader dataRead;
        bool durum;
        

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void mukerrerkitap()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM  kitap where barkod_no='" + txtBarkod.Text + "' or kitap_adi='" + txtKitapAdi.Text + "'", baglanti);

            dataRead = komut.ExecuteReader();
            if (dataRead.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }

            baglanti.Close();

        }
        private void btn_kitap_ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kayit = "insert into kitap(barkod_no,kitap_adi,yazari,yayinevi,sayfa_sayisi,turu,stok_sayisi,raf_no,aciklama,kayit_tarihi) values (@barkod_no,@kitap_adi,@yazari,@yayinevi,@sayfa_sayisi,@turu,@stok_sayisi,@raf_no,@aciklama,@kayit_tarihi)";
            komut = new SqlCommand(kayit, baglanti);
            komut.Parameters.AddWithValue("@barkod_no", txtBarkod.Text);
            komut.Parameters.AddWithValue("@kitap_adi", txtKitapAdi.Text);
            komut.Parameters.AddWithValue("@yazari", txtYazar.Text);
            komut.Parameters.AddWithValue("@yayinevi", txtYayinevi.Text);
            komut.Parameters.AddWithValue("@sayfa_sayisi", txtSayfaSayisi.Text);
            komut.Parameters.AddWithValue("@turu", comboTuru.Text);
            komut.Parameters.AddWithValue("@stok_sayisi", txtStokSayisi.Text);
            komut.Parameters.AddWithValue("@raf_no", txtRafNo.Text);
            komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            komut.Parameters.AddWithValue("@kayit_tarihi", DateTime.Now.ToShortDateString());
            baglanti.Close();
            mukerrerkitap();
            if (durum==true)
            {
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kitap Kayıt İşlemi Başarıyla Gerçekleşti");
                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {


                        item.Text = "";

                    }
                }
            }
            else
            {
                MessageBox.Show("Aynı Barkod Numaralı veya isimli Kitap Zaten Mevcut", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
           
        }

        private void KitapEkle_Load(object sender, EventArgs e)
        {

        }

       
    }
    }

