namespace WCFAplicationsMedical
{
    partial class BandejaMensajes
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
            this.btnMensLinea = new System.Windows.Forms.Button();
            this.btnBandejaEn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMensLinea
            // 
            this.btnMensLinea.Location = new System.Drawing.Point(89, 115);
            this.btnMensLinea.Name = "btnMensLinea";
            this.btnMensLinea.Size = new System.Drawing.Size(132, 23);
            this.btnMensLinea.TabIndex = 0;
            this.btnMensLinea.Text = "Ver Mensajes en Linea";
            this.btnMensLinea.UseVisualStyleBackColor = true;
            this.btnMensLinea.Click += new System.EventHandler(this.btnMensLinea_Click);
            // 
            // btnBandejaEn
            // 
            this.btnBandejaEn.Location = new System.Drawing.Point(103, 86);
            this.btnBandejaEn.Name = "btnBandejaEn";
            this.btnBandejaEn.Size = new System.Drawing.Size(104, 23);
            this.btnBandejaEn.TabIndex = 1;
            this.btnBandejaEn.Text = "Bandeja Entrada";
            this.btnBandejaEn.UseVisualStyleBackColor = true;
            this.btnBandejaEn.Click += new System.EventHandler(this.btnBandejaEn_Click);
            // 
            // BandejaMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 269);
            this.Controls.Add(this.btnBandejaEn);
            this.Controls.Add(this.btnMensLinea);
            this.Name = "BandejaMensajes";
            this.Text = "BandejaMensajes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMensLinea;
        private System.Windows.Forms.Button btnBandejaEn;
    }
}