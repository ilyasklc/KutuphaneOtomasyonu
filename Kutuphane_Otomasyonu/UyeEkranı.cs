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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void kitapListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void emanetKitaplarımToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void emanetKitapAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UyeKitapListesi uye_kitap_liste = new UyeKitapListesi();
            this.Hide();
            uye_kitap_liste.ShowDialog();
        }

        private void emanetKitapListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UyeEmanetListele uye_emanet_listele = new UyeEmanetListele();
            this.Hide();
            uye_emanet_listele.ShowDialog();
        }

        private void parolaDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SifreYenileme uye_sifre_degistir = new SifreYenileme();
            this.Hide();
            uye_sifre_degistir.ShowDialog();
        }
    }
}
