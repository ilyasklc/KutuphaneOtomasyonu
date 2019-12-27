namespace Kutuphane_Otomasyonu
{
    partial class Siralama
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEnCokOkuyan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEnAzOkuyan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(33, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(599, 238);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(30, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "En Çok Kitap Okuyan Üye";
            // 
            // lblEnCokOkuyan
            // 
            this.lblEnCokOkuyan.AutoSize = true;
            this.lblEnCokOkuyan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEnCokOkuyan.Location = new System.Drawing.Point(235, 342);
            this.lblEnCokOkuyan.Name = "lblEnCokOkuyan";
            this.lblEnCokOkuyan.Size = new System.Drawing.Size(0, 17);
            this.lblEnCokOkuyan.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(30, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "En Az Kitap Okuyan Üye";
            // 
            // lblEnAzOkuyan
            // 
            this.lblEnAzOkuyan.AutoSize = true;
            this.lblEnAzOkuyan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblEnAzOkuyan.Location = new System.Drawing.Point(235, 384);
            this.lblEnAzOkuyan.Name = "lblEnAzOkuyan";
            this.lblEnAzOkuyan.Size = new System.Drawing.Size(0, 17);
            this.lblEnAzOkuyan.TabIndex = 4;
            // 
            // Siralama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblEnAzOkuyan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEnCokOkuyan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Siralama";
            this.Text = "Siralama Sayfası";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Siralama_FormClosed);
            this.Load += new System.EventHandler(this.Siralama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEnCokOkuyan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEnAzOkuyan;
    }
}