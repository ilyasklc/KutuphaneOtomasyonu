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
    public partial class Siralama : Form
    {
        public Siralama()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
        DataSet ds = new DataSet();

        private void Siralama_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from uye order  by okunankitapsayisi desc", baglanti);
            da.Fill(ds, "uye");
            dataGridView1.DataSource = ds.Tables["uye"];
            baglanti.Close();
            lblEnCokOkuyan.Text = "";
            lblEnCokOkuyan.Text = "";
            lblEnCokOkuyan.Text = ds.Tables["uye"].Rows[0]["adsoyad"].ToString()+"=";
            lblEnCokOkuyan.Text += ds.Tables["uye"].Rows[0]["okunankitapsayisi"].ToString();
            lblEnAzOkuyan.Text = ds.Tables["uye"].Rows[dataGridView1.Rows.Count-2]["adsoyad"].ToString()+"=";
            lblEnAzOkuyan.Text += ds.Tables["uye"].Rows[dataGridView1.Rows.Count-2]["okunankitapsayisi"].ToString();

        }

        private void Siralama_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
    }

