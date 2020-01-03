namespace Kutuphane_Otomasyonu
{
    partial class UyeEkranı
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kitapListesiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emanetKitaplarımToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hesapAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emanetKitapAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emanetKitapListeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parolaDeğiştirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kitapListesiToolStripMenuItem,
            this.emanetKitaplarımToolStripMenuItem,
            this.hesapAyarlarıToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(370, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kitapListesiToolStripMenuItem
            // 
            this.kitapListesiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emanetKitapAlToolStripMenuItem});
            this.kitapListesiToolStripMenuItem.Name = "kitapListesiToolStripMenuItem";
            this.kitapListesiToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.kitapListesiToolStripMenuItem.Text = "Kitap Emanet İşlemleri";
            this.kitapListesiToolStripMenuItem.Click += new System.EventHandler(this.kitapListesiToolStripMenuItem_Click);
            // 
            // emanetKitaplarımToolStripMenuItem
            // 
            this.emanetKitaplarımToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emanetKitapListeleToolStripMenuItem});
            this.emanetKitaplarımToolStripMenuItem.Name = "emanetKitaplarımToolStripMenuItem";
            this.emanetKitaplarımToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.emanetKitaplarımToolStripMenuItem.Text = "Emanet Kitaplarım";
            this.emanetKitaplarımToolStripMenuItem.Click += new System.EventHandler(this.emanetKitaplarımToolStripMenuItem_Click);
            // 
            // hesapAyarlarıToolStripMenuItem
            // 
            this.hesapAyarlarıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parolaDeğiştirToolStripMenuItem});
            this.hesapAyarlarıToolStripMenuItem.Name = "hesapAyarlarıToolStripMenuItem";
            this.hesapAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.hesapAyarlarıToolStripMenuItem.Text = "Hesap Ayarları";
            // 
            // emanetKitapAlToolStripMenuItem
            // 
            this.emanetKitapAlToolStripMenuItem.Name = "emanetKitapAlToolStripMenuItem";
            this.emanetKitapAlToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.emanetKitapAlToolStripMenuItem.Text = "Emanet Kitap Al";
            this.emanetKitapAlToolStripMenuItem.Click += new System.EventHandler(this.emanetKitapAlToolStripMenuItem_Click);
            // 
            // emanetKitapListeleToolStripMenuItem
            // 
            this.emanetKitapListeleToolStripMenuItem.Name = "emanetKitapListeleToolStripMenuItem";
            this.emanetKitapListeleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.emanetKitapListeleToolStripMenuItem.Text = "Emanet Kitap Listele";
            this.emanetKitapListeleToolStripMenuItem.Click += new System.EventHandler(this.emanetKitapListeleToolStripMenuItem_Click);
            // 
            // parolaDeğiştirToolStripMenuItem
            // 
            this.parolaDeğiştirToolStripMenuItem.Name = "parolaDeğiştirToolStripMenuItem";
            this.parolaDeğiştirToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.parolaDeğiştirToolStripMenuItem.Text = "Parola Değiştir";
            this.parolaDeğiştirToolStripMenuItem.Click += new System.EventHandler(this.parolaDeğiştirToolStripMenuItem_Click);
            // 
            // UyeEkranı
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 346);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UyeEkranı";
            this.Text = "Üye İşlem Ekranı";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kitapListesiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emanetKitaplarımToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hesapAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emanetKitapAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emanetKitapListeleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parolaDeğiştirToolStripMenuItem;
    }
}