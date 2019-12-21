namespace Proyecto_Cine.Forms
{
    partial class Usuarios
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
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.panelUsuario = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.boxTipoDeUsuario = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cbEstado = new System.Windows.Forms.CheckBox();
            this.dtpCumpleaños = new System.Windows.Forms.DateTimePicker();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.BoxCiudad = new System.Windows.Forms.ComboBox();
            this.BoxProvincia = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.panelUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(4, 0);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(961, 232);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // panelUsuario
            // 
            this.panelUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUsuario.Controls.Add(this.label7);
            this.panelUsuario.Controls.Add(this.label6);
            this.panelUsuario.Controls.Add(this.label5);
            this.panelUsuario.Controls.Add(this.txtEmail);
            this.panelUsuario.Controls.Add(this.label4);
            this.panelUsuario.Controls.Add(this.label3);
            this.panelUsuario.Controls.Add(this.label2);
            this.panelUsuario.Controls.Add(this.label13);
            this.panelUsuario.Controls.Add(this.label12);
            this.panelUsuario.Controls.Add(this.label11);
            this.panelUsuario.Controls.Add(this.label10);
            this.panelUsuario.Controls.Add(this.label9);
            this.panelUsuario.Controls.Add(this.label8);
            this.panelUsuario.Controls.Add(this.label1);
            this.panelUsuario.Controls.Add(this.boxTipoDeUsuario);
            this.panelUsuario.Controls.Add(this.btnGuardar);
            this.panelUsuario.Controls.Add(this.btnVolver);
            this.panelUsuario.Controls.Add(this.cbEstado);
            this.panelUsuario.Controls.Add(this.dtpCumpleaños);
            this.panelUsuario.Controls.Add(this.txtCP);
            this.panelUsuario.Controls.Add(this.txtDireccion);
            this.panelUsuario.Controls.Add(this.txtTelefono);
            this.panelUsuario.Controls.Add(this.txtDNI);
            this.panelUsuario.Controls.Add(this.txtContraseña);
            this.panelUsuario.Controls.Add(this.txtApellido);
            this.panelUsuario.Controls.Add(this.txtNombre);
            this.panelUsuario.Controls.Add(this.BoxCiudad);
            this.panelUsuario.Controls.Add(this.BoxProvincia);
            this.panelUsuario.Location = new System.Drawing.Point(4, 238);
            this.panelUsuario.Name = "panelUsuario";
            this.panelUsuario.Size = new System.Drawing.Size(961, 156);
            this.panelUsuario.TabIndex = 1;
            this.panelUsuario.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(646, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "CP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "DIRECCION";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "TELEFONO";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(378, 15);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(181, 20);
            this.txtEmail.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "DNI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "APELLIDO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "NOMBRE";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(839, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "ESTADO";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(630, 93);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "CIUDAD";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(623, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "PROVINCIA";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(607, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "CUMPLEAÑOS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(291, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "CONTRASEÑA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(323, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "EMAIL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "TIPO";
            // 
            // boxTipoDeUsuario
            // 
            this.boxTipoDeUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxTipoDeUsuario.FormattingEnabled = true;
            this.boxTipoDeUsuario.Location = new System.Drawing.Point(81, 15);
            this.boxTipoDeUsuario.Name = "boxTipoDeUsuario";
            this.boxTipoDeUsuario.Size = new System.Drawing.Size(181, 21);
            this.boxTipoDeUsuario.TabIndex = 5;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(594, 124);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(312, 124);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cbEstado
            // 
            this.cbEstado.AutoSize = true;
            this.cbEstado.Checked = true;
            this.cbEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbEstado.Location = new System.Drawing.Point(903, 19);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(15, 14);
            this.cbEstado.TabIndex = 3;
            this.cbEstado.UseVisualStyleBackColor = true;
            // 
            // dtpCumpleaños
            // 
            this.dtpCumpleaños.CustomFormat = "dd/MM/yyyy";
            this.dtpCumpleaños.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCumpleaños.Location = new System.Drawing.Point(694, 41);
            this.dtpCumpleaños.Name = "dtpCumpleaños";
            this.dtpCumpleaños.Size = new System.Drawing.Size(121, 20);
            this.dtpCumpleaños.TabIndex = 2;
            this.dtpCumpleaños.Value = new System.DateTime(2000, 1, 1, 13, 40, 0, 0);
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(694, 15);
            this.txtCP.MaxLength = 5;
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(121, 20);
            this.txtCP.TabIndex = 1;
            this.txtCP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCP_KeyPress);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(378, 90);
            this.txtDireccion.MaxLength = 100;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(181, 20);
            this.txtDireccion.TabIndex = 1;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(378, 64);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(181, 20);
            this.txtTelefono.TabIndex = 1;
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(81, 94);
            this.txtDNI.MaxLength = 10;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(181, 20);
            this.txtDNI.TabIndex = 1;
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Location = new System.Drawing.Point(378, 40);
            this.txtContraseña.MaxLength = 20;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(181, 20);
            this.txtContraseña.TabIndex = 1;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(81, 68);
            this.txtApellido.MaxLength = 100;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(181, 20);
            this.txtApellido.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(81, 42);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(181, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // BoxCiudad
            // 
            this.BoxCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxCiudad.FormattingEnabled = true;
            this.BoxCiudad.Location = new System.Drawing.Point(694, 90);
            this.BoxCiudad.Name = "BoxCiudad";
            this.BoxCiudad.Size = new System.Drawing.Size(121, 21);
            this.BoxCiudad.TabIndex = 0;
            // 
            // BoxProvincia
            // 
            this.BoxProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxProvincia.FormattingEnabled = true;
            this.BoxProvincia.Location = new System.Drawing.Point(694, 65);
            this.BoxProvincia.Name = "BoxProvincia";
            this.BoxProvincia.Size = new System.Drawing.Size(121, 21);
            this.BoxProvincia.TabIndex = 0;
            this.BoxProvincia.SelectedIndexChanged += new System.EventHandler(this.BoxProvincia_SelectedIndexChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(176, 399);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 4;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(736, 400);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 426);
            this.Controls.Add(this.panelUsuario);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvUsuarios);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Usuarios";
            this.Text = "Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.panelUsuario.ResumeLayout(false);
            this.panelUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Panel panelUsuario;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox BoxCiudad;
        private System.Windows.Forms.ComboBox BoxProvincia;
        private System.Windows.Forms.DateTimePicker dtpCumpleaños;
        private System.Windows.Forms.CheckBox cbEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox boxTipoDeUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
    }
}