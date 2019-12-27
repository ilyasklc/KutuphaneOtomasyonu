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
    public partial class Uye_Ekle : Form
    {
        public Uye_Ekle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
        SqlDataReader dataRead;
        SqlCommand komut;
        bool durum;

        private void btnİptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void Mukerrer_Kayit()
        {
            baglanti.Open();
           SqlCommand komut = new SqlCommand("SELECT * FROM  uye where kullanici_adi='" + txtKullaniciAdi.Text + "' or tc='" + txtTc.Text + "'", baglanti);

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
        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            if(txtSifre.Text !="" && txtSifreTekrar.Text != "")
            {
                baglanti.Open();
                string kayit = "insert into uye(tc,adsoyad,kullanici_adi,sifre,kullanici_tipi,yas,cinsiyet,telefon,adres,email,okunankitapsayisi) values (@tc,@adsoyad,@kullanici_adi,@sifre,@kullanici_tipi,@yas,@cinsiyet,@telefon,@adres,@email,@okunankitapsayisi)";
                komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@kullanici_adi", txtKullaniciAdi.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
                komut.Parameters.AddWithValue("@kullanici_tipi", "");
                komut.Parameters.AddWithValue("@yas", txtYas.Text);
                komut.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.Text);
                komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@email", txtEmail.Text);
                komut.Parameters.AddWithValue("@okunankitapsayisi", 0);
                baglanti.Close();
                Mukerrer_Kayit();

            }
            else
            {
                MessageBox.Show("Sifre Kısmı Boş Kalamaz");

            }

            if (txtSifre.Text != txtSifreTekrar.Text)
                {
                    MessageBox.Show("Sifreler Aynı Değil", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
                else if(durum==true)
                {
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Üye Kayıt İşlemi Başarıyla Gerçekleşti");
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
                MessageBox.Show("Aynı Kullanıcı Adı veya TC Sistemde Kayıtlı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }


            baglanti.Close();
            


        }

        
    }
    }

