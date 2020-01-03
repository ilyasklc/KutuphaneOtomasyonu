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
using Kutuphane_Otomasyonu;

namespace Kutuphane_Otomasyonu
{
    public partial class UyeEmanetListele : Form
    {
        Login giris = new Login();
        public UyeEmanetListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
        DataSet ds = new DataSet();
        DataGridViewCellStyle renk = new DataGridViewCellStyle();
        DateTime iade_Tarihi = new DateTime();
        TimeSpan fark = new TimeSpan();
        
        public void renklendir()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {




                iade_Tarihi = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value);
                fark = iade_Tarihi - DateTime.Today;
                double toplamFark = fark.TotalDays;


                if (toplamFark > 0 && toplamFark <= 3)

                {
                    renk.BackColor = Color.Yellow;
                }
                else if (toplamFark == 0)

                {
                    renk.BackColor = Color.Blue;
                }
                else if (toplamFark < 0)

                {
                    renk.BackColor = Color.Red;
                }


                dataGridView1.Rows[i].DefaultCellStyle.BackColor = renk.BackColor;



            }
        }
        
        


        public void emanetlistele()
        {
            

            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from emanet_kitaplar where tc='"+ Connection.tc + "'", baglanti);
            da.Fill(ds, "emanet_kitaplar");

            dataGridView1.DataSource = ds.Tables["emanet_kitaplar"];


            


            baglanti.Close();
        }
        
       
        private void UyeEmanetListele_Load(object sender, EventArgs e)
        {
            emanetlistele();
            renklendir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {



                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from emanet_kitaplar where tc=@tc and barkod_no=@barkod_no", baglanti);
                komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
                komut.Parameters.AddWithValue("@barkod_no", dataGridView1.CurrentRow.Cells["barkod_no"].Value.ToString());
                komut.ExecuteNonQuery();
                SqlCommand komut2 = new SqlCommand("update kitap set stok_sayisi=stok_sayisi+'" + dataGridView1.CurrentRow.Cells["kitap_sayisi"].Value.ToString() + "' where barkod_no=@barkod_no", baglanti);
                komut2.Parameters.AddWithValue("@barkod_no", dataGridView1.CurrentRow.Cells["barkod_no"].Value.ToString());
                komut2.ExecuteNonQuery();
                MessageBox.Show("Kitap(lar) İade Edildi");

                ds.Tables["emanet_kitaplar"].Clear();
                baglanti.Close();
                emanetlistele();
                renklendir();
            }
            
            else
            {
                MessageBox.Show("Lütfen iade Edilecek Kitabı Seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // emanet edilen tüm kitaplar//

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ds.Tables["emanet_kitaplar"].Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                emanetlistele();
                renklendir();
            }
            // geç kalan kitaplar//
            else if (comboBox1.SelectedIndex == 1)
            {
                baglanti.Open();

                SqlDataAdapter da = new SqlDataAdapter("select * from emanet_kitaplar where '" + DateTime.Now.ToShortDateString() + "'>iade_tarihi ", baglanti);
                da.Fill(ds, "emanet_kitaplar");
                renk.BackColor = Color.Red;
                dataGridView1.DataSource = ds.Tables["emanet_kitaplar"];

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value) < DateTime.Now)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }

                }

                baglanti.Close();

            }
            // geç kalmayan kitaplar//
            else if (comboBox1.SelectedIndex == 2)
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from emanet_kitaplar where '" + DateTime.Now.ToShortDateString() + "'<iade_tarihi ", baglanti);
                da.Fill(ds, "emanet_kitaplar");

                dataGridView1.DataSource = ds.Tables["emanet_kitaplar"];

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value) > DateTime.Now)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }

                }

                baglanti.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UyeEkranı uye_ekranı = new UyeEkranı();
            this.Hide();
            uye_ekranı.ShowDialog();
        }

        private void UyeEmanetListele_FormClosed(object sender, FormClosedEventArgs e)
        {
            UyeEkranı uye_ekranı = new UyeEkranı();
            this.Hide();
            uye_ekranı.ShowDialog();
        }
    }
}

