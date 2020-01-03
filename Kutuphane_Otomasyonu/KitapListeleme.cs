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
    public partial class KitapListeleme : Form
    {
        public KitapListeleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
        DataSet ds = new DataSet();
       
        private void kitaplistele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from kitap ", baglanti);
            da.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];
            baglanti.Close();
        }

        private void KitapListeleme_Load(object sender, EventArgs e)
        {
            kitaplistele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kaydı Silmek İstediğinizden Emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from kitap where barkod_no=@barkod_no", baglanti);
                komut.Parameters.AddWithValue("@barkod_no", dataGridView1.CurrentRow.Cells["barkod_no"].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi gerçekleşti.");
                ds.Tables["kitap"].Clear();
                kitaplistele();

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }

            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kitap where barkod_no like '%" + txtBarkod.Text + "%'", baglanti);
            SqlDataReader dataRead = komut.ExecuteReader();
            while (dataRead.Read())
            {
                txtKitapAdi.Text = dataRead["kitap_adi"].ToString();
                txtYazar.Text = dataRead["yazari"].ToString();
                txtYayinevi.Text = dataRead["yayinevi"].ToString();
                txtSayfaSayisi.Text = dataRead["sayfa_sayisi"].ToString();
                comboTuru.Text = dataRead["turu"].ToString();
                txtStokSayisi.Text = dataRead["stok_sayisi"].ToString();
                txtRafNo.Text = dataRead["raf_no"].ToString();
                txtAciklama.Text = dataRead["aciklama"].ToString();



            }
            baglanti.Close();
        }

        

        private void btn_guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update kitap set kitap_adi=@kitap_adi,yazari=@yazari,yayinevi=@yayinevi,sayfa_sayisi=@sayfa_sayisi,turu=@turu,stok_sayisi=@stok_sayisi,raf_no=@raf_no,aciklama=@aciklama where barkod_no=@barkod_no", baglanti);
            komut.Parameters.AddWithValue("@barkod_no", txtBarkod.Text.ToString());
            komut.Parameters.AddWithValue("@kitap_adi", txtKitapAdi.Text);
            komut.Parameters.AddWithValue("@yazari", txtYazar.Text);
            komut.Parameters.AddWithValue("@yayinevi", txtYayinevi.Text);
            komut.Parameters.AddWithValue("@sayfa_sayisi", txtSayfaSayisi.Text.ToString());
            komut.Parameters.AddWithValue("@turu", comboTuru.Text);
            komut.Parameters.AddWithValue("@stok_sayisi", txtStokSayisi.Text.ToString() );
            komut.Parameters.AddWithValue("@raf_no", txtRafNo.Text.ToString());

            komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Gerçekleştirildi");
            ds.Tables["kitap"].Clear();
            kitaplistele();

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            txtKitapAdi.Text = "";
            txtStokSayisi.Text = "";
            txtRafNo.Text = "";
            comboTuru.Text = "";
            txtYayinevi.Text = "";
            txtYazar.Text = "";
            txtSayfaSayisi.Text = "";

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {

                txtBarkod.Text = dataGridView1.CurrentRow.Cells["barkod_no"].Value.ToString();
                txtKitapAdi.Text = dataGridView1.CurrentRow.Cells["kitap_adi"].Value.ToString();
                txtYazar.Text = dataGridView1.CurrentRow.Cells["yazari"].Value.ToString();
                txtYayinevi.Text = dataGridView1.CurrentRow.Cells["yayinevi"].Value.ToString();
                txtSayfaSayisi.Text = dataGridView1.CurrentRow.Cells["sayfa_sayisi"].Value.ToString();
                comboTuru.Text = dataGridView1.CurrentRow.Cells["turu"].Value.ToString();
                txtStokSayisi.Text = dataGridView1.CurrentRow.Cells["stok_sayisi"].Value.ToString();
                txtRafNo.Text = dataGridView1.CurrentRow.Cells["raf_no"].Value.ToString();
                txtAciklama.Text = dataGridView1.CurrentRow.Cells["aciklama"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Lütfen Satır Seçin");
            }
        }

        private void txtAra_TextChanged_1(object sender, EventArgs e)
        {
            ds.Tables["kitap"].Clear();
            baglanti.Open();

            SqlDataAdapter da = new SqlDataAdapter("select * from kitap where barkod_no like '%" + txtAra.Text + "%'", baglanti);
            da.Fill(ds, "kitap");
            dataGridView1.DataSource = ds.Tables["kitap"];

            baglanti.Close();
        }

        
    }
    }

