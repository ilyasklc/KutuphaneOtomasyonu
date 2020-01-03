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




namespace Kutuphane_Otomasyonu
{
    class Connection
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");

        public static SqlCommand komut = new SqlCommand();
        public  static SqlDataReader dr;

        public static string tc;
        public static void tcAta(string gelenTc)
        {
            tc = gelenTc;
        }
        public static string tcDondur()
        {
            return tc;
        }
        public static bool Giris_Yap(string name, string password)
        {
                if (name != "" && password != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
          }

        
        public static bool durum = false;
        public static bool Mukerrer_Kayit (string a,string b)   
        {
            baglanti.Open();
            komut = new SqlCommand("SELECT KullaniciAdi,Sifre,KullaniciTipi FROM kullanicigiris where KullaniciAdi='" + a + "' AND Sifre='" + b + "'", baglanti);

            dr= komut.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
                return durum;
            }
            else
            {
                durum = true;
                return durum;
            }
            
        }

    }
}
