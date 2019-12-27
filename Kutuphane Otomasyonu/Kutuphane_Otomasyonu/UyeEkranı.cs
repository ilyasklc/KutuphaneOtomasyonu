using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{
    public partial class UyeEkranı : Form
    {
        public UyeEkranı()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UyeKitapListesi uye_kitap_liste = new UyeKitapListesi();
            this.Hide();
            uye_kitap_liste.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UyeEmanetListele uye_emanet_listele = new UyeEmanetListele();
            this.Hide();
            uye_emanet_listele.ShowDialog();
        }
    }
}
