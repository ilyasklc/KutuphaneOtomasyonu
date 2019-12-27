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
    public partial class EmanetKitapİade : Form
    {
        public EmanetKitapİade()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
        DataSet ds = new DataSet();

        private void emanetlistele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from emanet_kitaplar", baglanti);
            da.Fill(ds, "emanet_kitaplar");
            dataGridView1.DataSource = ds.Tables["emanet_kitaplar"];
            baglanti.Close();
        }
        private void EmanetKitapİade_Load(object sender, EventArgs e)
        {
            emanetlistele();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["emanet_kitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from emanet_kitaplar where tc like '%"+txtTcAra.Text+"%'", baglanti);
            da.Fill(ds, "emanet_kitaplar");
            baglanti.Close();
            if (txtTcAra.Text == "")
            {
                ds.Tables["emanet_kitaplar"].Clear();
                emanetlistele();
            }

        }

        private void txtBarkodNoAra_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["emanet_kitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from emanet_kitaplar where barkod_no like '%" + txtBarkodNoAra.Text + "%'", baglanti);
            da.Fill(ds, "emanet_kitaplar");
            baglanti.Close();
            if (txtBarkodNoAra.Text == "")
            {
                ds.Tables["emanet_kitaplar"].Clear();
                emanetlistele();
            }
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from emanet_kitaplar where tc=@tc and barkod_no=@barkod_no", baglanti);
            komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            komut.Parameters.AddWithValue("@barkod_no", dataGridView1.CurrentRow.Cells["barkod_no"].Value.ToString());
            komut.ExecuteNonQuery();
            SqlCommand komut2 = new SqlCommand("update kitap set stok_sayisi=stok_sayisi+'"+dataGridView1.CurrentRow.Cells["kitap_sayisi"].Value.ToString()+"' where barkod_no=@barkod_no",baglanti);
            komut2.Parameters.AddWithValue("@barkod_no", dataGridView1.CurrentRow.Cells["barkod_no"].Value.ToString());
            komut2.ExecuteNonQuery();
            MessageBox.Show("Kitap(lar) İade Edildi");

            ds.Tables["emanet_kitaplar"].Clear();
            baglanti.Close();
            emanetlistele();
           
        }

        
    }
    }

