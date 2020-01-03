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
    public partial class UyeListeleme : Form
    {
        public UyeListeleme()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                txtKullaniciAdi.Text = dataGridView1.CurrentRow.Cells["kullanici_adi"].Value.ToString();
                txtSifre.Text = dataGridView1.CurrentRow.Cells["sifre"].Value.ToString();
                comboTip.Text = dataGridView1.CurrentRow.Cells["kullanici_tipi"].Value.ToString();
                txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
                txtAdSoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
                txtYas.Text = dataGridView1.CurrentRow.Cells["yas"].Value.ToString();
                comboCinsiyet.Text = dataGridView1.CurrentRow.Cells["cinsiyet"].Value.ToString();
                txtTelefon.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
                txtAdres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
                txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
                txtOkunanKitapSayisi.Text = dataGridView1.CurrentRow.Cells["okunankitapsayisi"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Lütfen Satır Seçin");
            }

        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");

       
        DataSet ds = new DataSet();
        

        private void btnİptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kaydı Silmek İstediğinizden Emin misiniz?","Sil",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from uye where tc=@tc", baglanti);
                komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
                komut.ExecuteNonQuery();
                
                baglanti.Close();
                MessageBox.Show("Silme İşlemi gerçekleşti.");
                ds.Tables["uye"].Clear();
                uyelistele();

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                txtTc.Text = "";
                comboCinsiyet.Text = "";
                txtTelefon.Text = "";
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                comboTip.Text = "";

            }



        }
        private void uyelistele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from uye ", baglanti);
            da.Fill(ds, "uye");
            dataGridView1.DataSource = ds.Tables["uye"];
            baglanti.Close();
        }
        private void UyeListeleme_Load(object sender, EventArgs e)
        {
            uyelistele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update uye set adsoyad=@adsoyad,kullanici_adi=@kullanici_adi,sifre=@sifre,kullanici_tipi=@kullanici_tipi,yas=@yas,cinsiyet=@cinsiyet,telefon=@telefon,adres=@adres,email=@email,okunankitapsayisi=@okunankitapsayisi where tc=@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@kullanici_adi", txtKullaniciAdi.Text); 
            komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@kullanici_tipi  ", comboTip.Text);
            komut.Parameters.AddWithValue("@yas", txtYas.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtEmail.Text);
            komut.Parameters.AddWithValue("@okunankitapsayisi", int.Parse (txtOkunanKitapSayisi.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Gerçekleştirildi");
            ds.Tables["uye"].Clear();
            uyelistele();

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            txtTc.Text = "";
            comboCinsiyet.Text = "";
            txtTelefon.Text = "";
            txtKullaniciAdi.Text = "";
            txtSifre.Text = "";
            comboTip.Text = "";


        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from uye where tc like '%" + txtTc.Text + "%'", baglanti);
            SqlDataReader dataRead = komut.ExecuteReader();
            while (dataRead.Read())
            {
                txtKullaniciAdi.Text = dataRead["kullanici_adi"].ToString();
                txtSifre.Text = dataRead["sifre"].ToString();
                comboTip.Text = dataRead["kullanici_tipi"].ToString();
                txtAdSoyad.Text = dataRead["adsoyad"].ToString();
                txtYas.Text = dataRead["yas"].ToString();
                comboCinsiyet.Text = dataRead["cinsiyet"].ToString();
                txtTelefon.Text = dataRead["telefon"].ToString();
                txtAdres.Text = dataRead["adres"].ToString();
                txtEmail.Text = dataRead["email"].ToString();
                txtOkunanKitapSayisi.Text = dataRead["okunankitapsayisi"].ToString();

            }

            baglanti.Close();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["uye"].Clear();
            baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from uye where tc like '%" + textBox1.Text + "%'", baglanti);
            da.Fill(ds, "uye");
            dataGridView1.DataSource = ds.Tables["uye"];

            baglanti.Close();
        }

       
    }
    }

