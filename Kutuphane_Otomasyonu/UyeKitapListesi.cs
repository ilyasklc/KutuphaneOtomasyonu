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
    public partial class UyeKitapListesi : Form
    {
        public UyeKitapListesi()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
        DataSet ds = new DataSet();
        SqlCommand komut;

        private void kitaplistele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from kitap ", baglanti);
            da.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];
            
            baglanti.Close();
            baglanti.Open();
            SqlCommand cmd = new SqlCommand("select sum(kitap_sayisi) from emanet_kitaplar  where tc='" + Connection.tc + "'", baglanti);
            lblKayitliKitapSayisi.Text = cmd.ExecuteScalar().ToString();
            int gelen;
            if (lblKayitliKitapSayisi.Text == "")
            {
                gelen = 0;
            }
            else
            {
                gelen = Convert.ToInt32(lblKayitliKitapSayisi.Text);
            }
            lblKayitliKitapSayisi.Text = gelen.ToString();
            txtTC.Text = Connection.tc;
            baglanti.Close();
        }
        
        private void UyeKitapListesi_Load(object sender, EventArgs e)
        {
            kitaplistele();
            
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            UyeEkranı uye_ekranı = new UyeEkranı();
            this.Hide();
            uye_ekranı.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["kitap"].Clear();
            baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from kitap where kitap_adi like '%" + txtKitapAra.Text + "%'", baglanti);
            da.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];

            SqlCommand komut = new SqlCommand("select * from kitap where kitap_adi like '%" + txtKitapAra.Text + "%'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtBarkod.Text = dr["barkod_no"].ToString();

            }

          
            if (txtKitapAra.Text == "")
            {
                txtBarkod.Text = "";
            }
          

            baglanti.Close();
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTC.Text != "" && txtKitapSayisi.Text != "" && txtBarkod.Text != "")
            {
                baglanti.Open();

                string kayit = "insert into emanet_kitaplar(barkod_no,kitap_sayisi,teslim_tarihi,iade_tarihi,tc) values (@barkod_no,@kitap_sayisi,@teslim_tarihi,@iade_tarihi,@tc)";
                komut = new SqlCommand(kayit, baglanti);
                komut.Parameters.AddWithValue("@barkod_no", txtBarkod.Text);
                komut.Parameters.AddWithValue("@kitap_sayisi", int.Parse(txtKitapSayisi.Text));
                komut.Parameters.AddWithValue("@teslim_tarihi", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@iade_tarihi", dateTimePicker2.Text);
                komut.Parameters.AddWithValue("@tc", Connection.tc);
               
                if (lblKayitliKitapSayisi.Text == "" || (int.Parse(lblKayitliKitapSayisi.Text) + Convert.ToInt32(txtKitapSayisi.Text)) <= 3)
                {

                    int gelenveri;

                    if (lblKayitliKitapSayisi.Text == "")
                    {
                        gelenveri = 0;

                    }
                    else
                    {
                        gelenveri = Convert.ToInt32(lblKayitliKitapSayisi.Text) + Convert.ToInt32(txtKitapSayisi.Text);
                    }


                    if (gelenveri <= 3)
                    {

                        komut.ExecuteNonQuery();

                        SqlCommand komut2 = new SqlCommand("update uye set okunankitapsayisi=okunankitapsayisi+'" + txtKitapSayisi.Text + "' where tc='" + txtTC.Text + "' ", baglanti);
                        komut2.ExecuteNonQuery();
                        SqlCommand komut3 = new SqlCommand("update kitap set stok_sayisi=stok_sayisi-'" + txtKitapSayisi.Text + "' where barkod_no='" + txtBarkod.Text + "'", baglanti);
                        komut3.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Kitap(lar) Emanet Edildi");
                    }

                    else
                    {
                        MessageBox.Show("Emanet Kitap Sayısı 3 ten Fazla Olamaz !!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglanti.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Emanet Kitap Sayısı 3 ten Fazla Olamaz !!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    baglanti.Close();
                }

            }
        
            else
            {
                MessageBox.Show("Önce Kitap Seçmeniz Gerekir !!!", "Uyarı");

            }


            txtKitapAra.Text = "";
            txtKitapSayisi.Text = "";
            txtBarkod.Text = "";
            lblKayitliKitapSayisi.Text = "";
            ds.Tables["kitap"].Clear();
            baglanti.Close();
            kitaplistele();    
        }

        private void UyeKitapListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            UyeEkranı uye_ekranı = new UyeEkranı();
            this.Hide();
            uye_ekranı.ShowDialog();

        }

        
    }
}
