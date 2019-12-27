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
    public partial class EmanetKitapVer : Form 
    {
        public EmanetKitapVer()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
       
        DataSet ds = new DataSet();
        private void btn_İptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void kitaplistele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from kitap ", baglanti);
            da.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];
            baglanti.Close();
        }

        private void EmanetKitapVer_Load(object sender, EventArgs e)
        {
            kitaplistele();
            //kitapsayisi();
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select *from uye where tc like '" +txtTcAra.Text+ "'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAdSoyad.Text = dr["adsoyad"].ToString();
                txtYas.Text = dr["yas"].ToString();
                txtTelefon.Text = dr["telefon"].ToString();


            }
            baglanti.Close();

            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("select sum(kitap_sayisi) from emanet_kitaplar where tc='"+txtTcAra.Text+"' ", baglanti);
            label13.Text = komut2.ExecuteScalar().ToString();
            baglanti.Close();


            if (txtTcAra.Text =="") 
            {
                foreach (Control item in groupBox1Uye.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                        
                    }
                    
                }
                label13.Text = "";
            }

        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kitap where barkod_no like '"+ txtBarkodNo.Text+"'",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                txtKitapAdi.Text = dr["kitap_adi"].ToString();
                txtYazari.Text =   dr["yazari"].ToString();
                txtYayinevi.Text = dr["yayinevi"].ToString();
                txtSayfaSayisi.Text = dr["sayfa_sayisi"].ToString();
                
            }
            
            if (txtBarkodNo.Text=="")
            {
                foreach (Control item in groupBox2Kitap.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != txtKitapSayisi)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
            baglanti.Close();

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTcAra.Text != "" && txtAdSoyad.Text != "" && txtYas.Text != "" && txtTelefon.Text != "")
            {
                
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into emanet_kitaplar(tc,barkod_no,kitap_sayisi,teslim_tarihi,iade_tarihi) values(@tc,@barkod_no,@kitap_sayisi,@teslim_tarihi,@iade_tarihi)", baglanti);
                    komut.Parameters.AddWithValue("@tc", txtTcAra.Text);
                    komut.Parameters.AddWithValue("@barkod_no", txtBarkodNo.Text);
                    komut.Parameters.AddWithValue("@kitap_sayisi", txtKitapSayisi.Text.ToString());
                    komut.Parameters.AddWithValue("@teslim_tarihi", dateTimePicker1.Text.ToString());
                    komut.Parameters.AddWithValue("@iade_tarihi", dateTimePicker2.Text.ToString());
                    SqlCommand cmd = new SqlCommand("select sum(kitap_sayisi) from emanet_kitaplar  where tc='" + txtTcAra.Text + "'", baglanti);
                    label13.Text = cmd.ExecuteScalar().ToString();
                if (label13.Text == "" || (int.Parse(label13.Text) + Convert.ToInt32(txtKitapSayisi.Text)) <= 3)
                {

                    int gelenveri;

                    if (label13.Text == "")
                    {
                        gelenveri = 0;

                    }
                    else
                    {
                        gelenveri = Convert.ToInt32(label13.Text + Convert.ToInt32(txtKitapSayisi.Text));
                    }


                    if (gelenveri + Convert.ToInt32(txtKitapSayisi.Text) <= 3)
                    {

                        komut.ExecuteNonQuery();

                        SqlCommand komut2 = new SqlCommand("update uye set okunankitapsayisi=okunankitapsayisi+'" + txtKitapSayisi.Text + "' where tc='" + txtTcAra.Text + "' ", baglanti);
                        komut2.ExecuteNonQuery();
                        SqlCommand komut3 = new SqlCommand("update kitap set stok_sayisi=stok_sayisi-'" + txtKitapSayisi.Text + "' where barkod_no='" + txtBarkodNo.Text + "'", baglanti);
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

               
            }
            else
            {
                MessageBox.Show("Önce Üye İsmi Seçmeniz Gerekir !!!", "Uyarı");

            }

            
            
            txtBarkodNo.Text = "";
            txtKitapAdi.Text = "";
            txtYazari.Text = "";
            txtYayinevi.Text = "";
            txtSayfaSayisi.Text = "";
            label13.Text = "";
            ds.Tables["kitap"].Clear();
            baglanti.Close();
            kitaplistele();
            

        }

        
    }
    }
    

