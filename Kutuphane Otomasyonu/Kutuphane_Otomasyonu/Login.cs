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
    public partial class Login : Form
    {
        Form1 f1 = new Form1();
        UyeEkranı uye_kitap = new UyeEkranı();
        public bool Admin = false;
        public string tc;
        public Login()
        {
            InitializeComponent();
            

        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");

        public void login()
        {
            if (Connection.Giris_Yap(textBox1.Text, textBox2.Text) == false)
            {
                MessageBox.Show("Lütfen Bir Kullanıcı Adı ve Şifre Giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else 
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from uye where kullanici_adi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'", baglanti);

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read() == true)
                {
                    if (Convert.ToBoolean(dr["kullanici_tipi"]) == true)
                    {
                        //admin girişi//

                        MessageBox.Show("Giriş Yapıldı !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        f1.ShowDialog();

                    }

                    else
                    {    // kullanici girisi//
                        if (Convert.ToBoolean(dr["kullanici_tipi"]) == false)
                        {
                            dr.Close();
                            SqlCommand cmd = new SqlCommand("select * from uye  where kullanici_adi='" + textBox1.Text + "'", baglanti);
                            SqlDataReader dataread = cmd.ExecuteReader();
                            while (dataread.Read()==true)
                            {
                                tc = dataread["tc"].ToString();
                            }
                           
                            Connection.tcAta(tc);
                            tc = Connection.tcDondur();                    
                            dataread.Close();

                            
                            uye_kitap.ShowDialog();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sistemde Kayıtlı Üye Bulunamadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
                baglanti.Close();
                dr.Close();

            }        
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            login();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

       
        private void btnKaydol_Click(object sender, EventArgs e)
        {
            Uye_Ekle hesapekle = new Uye_Ekle();
            hesapekle.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            SifreYenileme sifre_yenile = new SifreYenileme();
            this.Hide();
            sifre_yenile.ShowDialog();
        }
    }
}

    