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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lbcontraseña = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.lbemail = new System.Windows.Forms.Label();
            this.panelSuperior.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.panelSuperior.Controls.Add(this.btnCerrarSesion);
            this.panelSuperior.Location = new System.Drawing.Point(2, 2);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1067, 38);
            this.panelSuperior.TabIndex = 2;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.DarkRed;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Corbel", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnCerrarSesion.Location = new System.Drawing.Point(1001, 8);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(57, 24);
            this.btnCerrarSesion.TabIndex = 0;
            this.btnCerrarSesion.Text = "Salir";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.panelPrincipal.Controls.Add(this.panelLogin);
            this.panelPrincipal.Location = new System.Drawing.Point(2, 42);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1067, 435);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.AliceBlue;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.button1);
            this.panelLogin.Controls.Add(this.btnIngresar);
            this.panelLogin.Controls.Add(this.txtEmail);
            this.panelLogin.Controls.Add(this.lbcontraseña);
            this.panelLogin.Controls.Add(this.txtContraseña);
            this.panelLogin.Controls.Add(this.lbemail);
            this.panelLogin.Location = new System.Drawing.Point(208, 19);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(662, 343);
            this.panelLogin.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.AliceBlue;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(163, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(335, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Olvidé mi clave";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.Orange;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(163, 218);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(335, 35);
            this.btnIngresar.TabIndex = 2;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.AliceBlue;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(167, 53);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(325, 31);
            this.txtEmail.TabIndex = 0;
            this.txtEmail.Text = "anthonystark@live.com";
            // 
            // lbcontraseña
            // 
            this.lbcontraseña.AutoSize = true;
            this.lbcontraseña.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcontraseña.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbcontraseña.Location = new System.Drawing.Point(164, 112);
            this.lbcontraseña.Name = "lbcontraseña";
            this.lbcontraseña.Size = new System.Drawing.Size(63, 15);
            this.lbcontraseña.TabIndex = 1;
            this.lbcontraseña.Text = "Password";
            // 
            // txtContraseña
            // 
            this.txtContraseña.BackColor = System.Drawing.Color.AliceBlue;
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContraseña.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(166, 130);
            this.txtContraseña.MaxLength = 20;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(325, 29);
            this.txtContraseña.TabIndex = 1;
            this.txtContraseña.Text = "anthonystark";
            this.txtContraseña.UseSystemPasswordChar = true;
            // 
            // lbemail
            // 
            this.lbemail.AutoSize = true;
            this.lbemail.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbemail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbemail.Location = new System.Drawing.Point(164, 35);
            this.lbemail.Name = "lbemail";
            this.lbemail.Size = new System.Drawing.Size(38, 15);
            this.lbemail.TabIndex = 1;
            this.lbemail.Text = "Email";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1071, 478);
            this.Controls.Add(this.panelSuperior);
            this.Controls.Add(this.panelPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenido a Movix";
            this.panelSuperior.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbcontraseña;
        private System.Windows.Forms.Label lbemail;
    }
}