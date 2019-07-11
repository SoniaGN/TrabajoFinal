namespace WCFAplicationsMedical
{
    partial class LoginCliente
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
            this.lbcontra = new System.Windows.Forms.Label();
            this.lbusuario = new System.Windows.Forms.Label();
            this.txt_usuario = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbcontra
            // 
            this.lbcontra.AutoSize = true;
            this.lbcontra.Location = new System.Drawing.Point(99, 179);
            this.lbcontra.Name = "lbcontra";
            this.lbcontra.Size = new System.Drawing.Size(64, 13);
            this.lbcontra.TabIndex = 5;
            this.lbcontra.Text = "Contraseña:";
            // 
            // lbusuario
            // 
            this.lbusuario.AutoSize = true;
            this.lbusuario.Location = new System.Drawing.Point(99, 153);
            this.lbusuario.Name = "lbusuario";
            this.lbusuario.Size = new System.Drawing.Size(46, 13);
            this.lbusuario.TabIndex = 4;
            this.lbusuario.Text = "Usuario:";
            // 
            // txt_usuario
            // 
            this.txt_usuario.Location = new System.Drawing.Point(195, 153);
            this.txt_usuario.Name = "txt_usuario";
            this.txt_usuario.Size = new System.Drawing.Size(100, 20);
            this.txt_usuario.TabIndex = 6;
            // 
            // textBox1
            // 
            this.txt_pwd.Location = new System.Drawing.Point(195, 180);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.Size = new System.Drawing.Size(100, 20);
            this.txt_pwd.TabIndex = 7;
            // 
            // LoginCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 322);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_usuario);
            this.Controls.Add(this.lbcontra);
            this.Controls.Add(this.lbusuario);
            this.Name = "LoginCliente";
            this.Text = "LoginCliente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbusuario;
        private System.Windows.Forms.TextBox txt_usuario;
        private System.Windows.Forms.Label lbcontra;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button btn_sesion;
        private System.Windows.Forms.Button btn_registro;
       
    }
}