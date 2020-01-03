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
    public partial class EmanetKitapListeleme : Form
    {

        public EmanetKitapListeleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = KutuphaneOtomasyonu; Integrated Security = True");
        DataSet ds = new DataSet();
        DataGridViewCellStyle renk = new DataGridViewCellStyle();
        DateTime iade_Tarihi = new DateTime();
        TimeSpan fark = new TimeSpan();
        private void EmanetKitapListeleme_Load(object sender, EventArgs e)
        {
            emanetlistele();
            comboBox1.SelectedIndex = 0;
        }

        private void emanetlistele()
        {   
            
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from emanet_kitaplar", baglanti);
            da.Fill(ds, "emanet_kitaplar");
            dataGridView1.DataSource = ds.Tables["emanet_kitaplar"];


            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {




                iade_Tarihi = Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value);
                fark = iade_Tarihi - DateTime.Today;
                double toplamFark = fark.TotalDays;


                if(toplamFark>0 && toplamFark<=3)
               
                        {
                            renk.BackColor = Color.Yellow;
                        }
                else if(toplamFark==0)
                        
                        {
                            renk.BackColor = Color.Blue;
                        }
                else if(toplamFark<0)
                       
                        {
                            renk.BackColor = Color.Red;
                        }


                dataGridView1.Rows[i].DefaultCellStyle.BackColor = renk.BackColor;



            }
            

            baglanti.Close();
        }
        // emanet edilen tüm kitaplar//
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds.Tables["emanet_kitaplar"].Clear();
            if(comboBox1.SelectedIndex==0)
            {
                emanetlistele();
            }
            // geç kalan kitaplar//
            else if (comboBox1.SelectedIndex==1)
            {
                baglanti.Open();
               
                SqlDataAdapter da = new SqlDataAdapter("select * from emanet_kitaplar where '"+DateTime.Now.ToShortDateString()+"'>iade_tarihi ", baglanti);
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

                for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
                {
                    if (Convert.ToDateTime (dataGridView1.Rows[i].Cells[5].Value) > DateTime.Now)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    
                }                

                baglanti.Close();
               
            }
        }

       
    }
    }

