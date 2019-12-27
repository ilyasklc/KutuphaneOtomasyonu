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

        
        


        public void emanetlistele()
        {
            

            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from emanet_kitaplar where tc='"+ Connection.tc + "'", baglanti);
            da.Fill(ds, "emanet_kitaplar");

            dataGridView1.DataSource = ds.Tables["emanet_kitaplar"];


            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                iade_Tarihi = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value);
                fark = iade_Tarihi - DateTime.Now;
                double toplamFark = fark.TotalDays;
                double toplamFark2 = fark.TotalDays;

                if (toplamFark <= 3)
                {
                    renk.BackColor = Color.Yellow;
                }
                else if (toplamFark2 == 0)
                {
                    renk.BackColor = Color.Blue;
                }
                else if (DateTime.Now > iade_Tarihi)
                {
                    renk.BackColor = Color.Red;
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;

            }

            baglanti.Close();
        }
        // emanet edilen tüm kitaplar//
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds.Tables["emanet_kitaplar"].Clear();
            if (comboBox1.SelectedIndex == 0)
            {
                emanetlistele();
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
        private void UyeEmanetListele_Load(object sender, EventArgs e)
        {
            emanetlistele();
        }
    }
}

