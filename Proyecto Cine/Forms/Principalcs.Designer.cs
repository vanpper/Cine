namespace Proyecto_Cine.Forms
{
    partial class Principal
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbcontraseña = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lbemail = new System.Windows.Forms.Label();
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.labelBienvenvida = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelPrincipal.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.panelLogin);
            this.panelPrincipal.Location = new System.Drawing.Point(2, 42);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1067, 435);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panelLogin
            // 
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.btnIngresar);
            this.panelLogin.Controls.Add(this.txtEmail);
            this.panelLogin.Controls.Add(this.lbcontraseña);
            this.panelLogin.Controls.Add(this.txtContraseña);
            this.panelLogin.Controls.Add(this.lbemail);
            this.panelLogin.Location = new System.Drawing.Point(320, 45);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(418, 281);
            this.panelLogin.TabIndex = 4;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(100, 201);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(226, 23);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(100, 57);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(226, 20);
            this.txtEmail.TabIndex = 0;
            // 
            // lbcontraseña
            // 
            this.lbcontraseña.AutoSize = true;
            this.lbcontraseña.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcontraseña.Location = new System.Drawing.Point(173, 109);
            this.lbcontraseña.Name = "lbcontraseña";
            this.lbcontraseña.Size = new System.Drawing.Size(78, 15);
            this.lbcontraseña.TabIndex = 1;
            this.lbcontraseña.Text = "PASSWORD";
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(100, 134);
            this.txtContraseña.MaxLength = 20;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(226, 20);
            this.txtContraseña.TabIndex = 1;
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // lbemail
            // 
            this.lbemail.AutoSize = true;
            this.lbemail.Font = new System.Drawing.Font("Arial", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbemail.Location = new System.Drawing.Point(189, 32);
            this.lbemail.Name = "lbemail";
            this.lbemail.Size = new System.Drawing.Size(45, 15);
            this.lbemail.TabIndex = 1;
            this.lbemail.Text = "EMAIL";
            // 
            // panelSuperior
            // 
            this.panelSuperior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSuperior.Controls.Add(this.labelBienvenvida);
            this.panelSuperior.Controls.Add(this.btnCerrarSesion);
            this.panelSuperior.Location = new System.Drawing.Point(2, 2);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1067, 38);
            this.panelSuperior.TabIndex = 2;
            // 
            // labelBienvenvida
            // 
            this.labelBienvenvida.AutoSize = true;
            this.labelBienvenvida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBienvenvida.Location = new System.Drawing.Point(451, 9);
            this.labelBienvenvida.Name = "labelBienvenvida";
            this.labelBienvenvida.Size = new System.Drawing.Size(162, 20);
            this.labelBienvenvida.TabIndex = 1;
            this.labelBienvenvida.Text = "Bienvenido nombre";
            this.labelBienvenvida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(973, 6);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(84, 23);
            this.btnCerrarSesion.TabIndex = 0;
            this.btnCerrarSesion.Text = "Cerrar sesion";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 478);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "Principal";
            this.Text = "Principal";
            this.panelPrincipal.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lbcontraseña;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label lbemail;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Label labelBienvenvida;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}