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
    public partial class Grafik : Form
    {
        public Grafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
        DataSet ds = new DataSet();
        private void Grafik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select adsoyad,okunankitapsayisi from uye", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Okunan Kitap Sayısı"].Points.AddXY(dr["adsoyad"].ToString(), dr["okunankitapsayisi"]);

            }

            baglanti.Close();
            chart1.Series["Okunan Kitap Sayısı"].Color = Color.Orange;
        }

        private void Grafik_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    }

