namespace Kutuphane_Otomasyonu
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUye_Listele = new System.Windows.Forms.Button();
            this.btnUye_Ekle = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnEmanet_İade = new System.Windows.Forms.Button();
            this.btnEmanet_Listele = new System.Windows.Forms.Button();
            this.btnEmanet_Ver = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGrafik = new System.Windows.Forms.Button();
            this.btn_Siralama = new System.Windows.Forms.Button();
            this.btnKitap_Ekle = new System.Windows.Forms.Button();
            this.btnKitap_Listele = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUye_Listele);
            this.groupBox1.Controls.Add(this.btnUye_Ekle);
            this.groupBox1.Location = new System.Drawing.Point(85, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 123);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Üye İşlemleri";
            // 
            // btnUye_Listele
            // 
            this.btnUye_Listele.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUye_Listele.Location = new System.Drawing.Point(17, 77);
            this.btnUye_Listele.Name = "btnUye_Listele";
            this.btnUye_Listele.Size = new System.Drawing.Size(273, 28);
            this.btnUye_Listele.TabIndex = 1;
            this.btnUye_Listele.Text = "Üye Listeleme İşlemleri";
            this.btnUye_Listele.UseVisualStyleBackColor = true;
            this.btnUye_Listele.Click += new System.EventHandler(this.btnUye_Listele_Click);
            // 
            // btnUye_Ekle
            // 
            this.btnUye_Ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUye_Ekle.Location = new System.Drawing.Point(17, 28);
            this.btnUye_Ekle.Name = "btnUye_Ekle";
            this.btnUye_Ekle.Size = new System.Drawing.Size(273, 33);
            this.btnUye_Ekle.TabIndex = 0;
            this.btnUye_Ekle.Text = "Üye Ekleme İşlemleri";
            this.btnUye_Ekle.UseVisualStyleBackColor = true;
            this.btnUye_Ekle.Click += new System.EventHandler(this.btnUye_Ekle_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnEmanet_İade);
            this.groupBox3.Controls.Add(this.btnEmanet_Listele);
            this.groupBox3.Controls.Add(this.btnEmanet_Ver);
            this.groupBox3.Location = new System.Drawing.Point(85, 245);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(308, 136);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Emanet Kitap İşlemleri";
            // 
            // btnEmanet_İade
            // 
            this.btnEmanet_İade.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEmanet_İade.Location = new System.Drawing.Point(17, 96);
            this.btnEmanet_İade.Name = "btnEmanet_İade";
            this.btnEmanet_İade.Size = new System.Drawing.Size(273, 34);
            this.btnEmanet_İade.TabIndex = 6;
            this.btnEmanet_İade.Text = "Emanet Kitap İade İşlemleri";
            this.btnEmanet_İade.UseVisualStyleBackColor = true;
            this.btnEmanet_İade.Click += new System.EventHandler(this.btnEmanet_İade_Click);
            // 
            // btnEmanet_Listele
            // 
            this.btnEmanet_Listele.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEmanet_Listele.Location = new System.Drawing.Point(17, 57);
            this.btnEmanet_Listele.Name = "btnEmanet_Listele";
            this.btnEmanet_Listele.Size = new System.Drawing.Size(273, 33);
            this.btnEmanet_Listele.TabIndex = 5;
            this.btnEmanet_Listele.Text = "Emanet Kitap Listeleme İşlemleri";
            this.btnEmanet_Listele.UseVisualStyleBackColor = true;
            this.btnEmanet_Listele.Click += new System.EventHandler(this.btnEmanet_Listele_Click);
            // 
            // btnEmanet_Ver
            // 
            this.btnEmanet_Ver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEmanet_Ver.Location = new System.Drawing.Point(17, 19);
            this.btnEmanet_Ver.Name = "btnEmanet_Ver";
            this.btnEmanet_Ver.Size = new System.Drawing.Size(273, 33);
            this.btnEmanet_Ver.TabIndex = 4;
            this.btnEmanet_Ver.Text = "Emanet Kitap Verme İşlemleri";
            this.btnEmanet_Ver.UseVisualStyleBackColor = true;
            this.btnEmanet_Ver.Click += new System.EventHandler(this.btnEmanet_Ver_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGrafik);
            this.groupBox4.Controls.Add(this.btn_Siralama);
            this.groupBox4.Location = new System.Drawing.Point(453, 245);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(304, 136);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sıralama ve Grafikler";
            // 
            // btnGrafik
            // 
            this.btnGrafik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGrafik.Location = new System.Drawing.Point(19, 79);
            this.btnGrafik.Name = "btnGrafik";
            this.btnGrafik.Size = new System.Drawing.Size(266, 32);
            this.btnGrafik.TabIndex = 8;
            this.btnGrafik.Text = "Grafikler";
            this.btnGrafik.UseVisualStyleBackColor = true;
            
            // 
            // btn_Siralama
            // 
            this.btn_Siralama.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Siralama.Location = new System.Drawing.Point(19, 30);
            this.btn_Siralama.Name = "btn_Siralama";
            this.btn_Siralama.Size = new System.Drawing.Size(266, 33);
            this.btn_Siralama.TabIndex = 7;
            this.btn_Siralama.Text = "Sıralama";
            this.btn_Siralama.UseVisualStyleBackColor = true;
            
            // 
            // btnKitap_Ekle
            // 
            this.btnKitap_Ekle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKitap_Ekle.Location = new System.Drawing.Point(19, 28);
            this.btnKitap_Ekle.Name = "btnKitap_Ekle";
            this.btnKitap_Ekle.Size = new System.Drawing.Size(266, 33);
            this.btnKitap_Ekle.TabIndex = 2;
            this.btnKitap_Ekle.Text = "Kitap Ekleme İşlemleri";
            this.btnKitap_Ekle.UseVisualStyleBackColor = true;
            this.btnKitap_Ekle.Click += new System.EventHandler(this.btnKitap_Ekle_Click);
            // 
            // btnKitap_Listele
            // 
            this.btnKitap_Listele.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKitap_Listele.Location = new System.Drawing.Point(19, 77);
            this.btnKitap_Listele.Name = "btnKitap_Listele";
            this.btnKitap_Listele.Size = new System.Drawing.Size(266, 28);
            this.btnKitap_Listele.TabIndex = 3;
            this.btnKitap_Listele.Text = "Kitap Listeleme İşlemleri";
            this.btnKitap_Listele.UseVisualStyleBackColor = true;
            this.btnKitap_Listele.Click += new System.EventHandler(this.btnKitap_Listele_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKitap_Listele);
            this.groupBox2.Controls.Add(this.btnKitap_Ekle);
            this.groupBox2.Location = new System.Drawing.Point(453, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kitap İşlemleri";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(807, 444);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUye_Listele;
        private System.Windows.Forms.Button btnUye_Ekle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnEmanet_İade;
        private System.Windows.Forms.Button btnEmanet_Listele;
        private System.Windows.Forms.Button btnEmanet_Ver;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGrafik;
        private System.Windows.Forms.Button btn_Siralama;
        private System.Windows.Forms.Button btnKitap_Ekle;
        private System.Windows.Forms.Button btnKitap_Listele;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

