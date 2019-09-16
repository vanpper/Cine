namespace Proyecto_Cine.Forms
{
    partial class Funciones
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
            this.boxCines = new System.Windows.Forms.ComboBox();
            this.boxSalas = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.boxPeliculas = new System.Windows.Forms.ComboBox();
            this.boxFormatos = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbFormato = new System.Windows.Forms.CheckBox();
            this.cbPelicula = new System.Windows.Forms.CheckBox();
            this.cbFecha = new System.Windows.Forms.CheckBox();
            this.cbSala = new System.Windows.Forms.CheckBox();
            this.cbCine = new System.Windows.Forms.CheckBox();
            this.dgvFunciones = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PtxtMinutos = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.PcbEstado = new System.Windows.Forms.CheckBox();
            this.PtxtStock = new System.Windows.Forms.TextBox();
            this.PboxFormatos = new System.Windows.Forms.ComboBox();
            this.PboxPeliculas = new System.Windows.Forms.ComboBox();
            this.PtxtHora = new System.Windows.Forms.TextBox();
            this.PdtpFecha = new System.Windows.Forms.DateTimePicker();
            this.PboxSalas = new System.Windows.Forms.ComboBox();
            this.PboxCines = new System.Windows.Forms.ComboBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxCines
            // 
            this.boxCines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxCines.FormattingEnabled = true;
            this.boxCines.Location = new System.Drawing.Point(36, 6);
            this.boxCines.Name = "boxCines";
            this.boxCines.Size = new System.Drawing.Size(121, 21);
            this.boxCines.TabIndex = 0;
            this.boxCines.SelectedIndexChanged += new System.EventHandler(this.boxCines_SelectedIndexChanged);
            // 
            // boxSalas
            // 
            this.boxSalas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxSalas.FormattingEnabled = true;
            this.boxSalas.Location = new System.Drawing.Point(233, 7);
            this.boxSalas.Name = "boxSalas";
            this.boxSalas.Size = new System.Drawing.Size(121, 21);
            this.boxSalas.TabIndex = 1;
            this.boxSalas.SelectedIndexChanged += new System.EventHandler(this.boxSalas_SelectedIndexChanged);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(435, 7);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(124, 20);
            this.dtpFecha.TabIndex = 2;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // boxPeliculas
            // 
            this.boxPeliculas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxPeliculas.FormattingEnabled = true;
            this.boxPeliculas.Location = new System.Drawing.Point(633, 7);
            this.boxPeliculas.Name = "boxPeliculas";
            this.boxPeliculas.Size = new System.Drawing.Size(121, 21);
            this.boxPeliculas.TabIndex = 3;
            this.boxPeliculas.SelectedIndexChanged += new System.EventHandler(this.boxPeliculas_SelectedIndexChanged);
            // 
            // boxFormatos
            // 
            this.boxFormatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxFormatos.FormattingEnabled = true;
            this.boxFormatos.Location = new System.Drawing.Point(826, 7);
            this.boxFormatos.Name = "boxFormatos";
            this.boxFormatos.Size = new System.Drawing.Size(121, 21);
            this.boxFormatos.TabIndex = 4;
            this.boxFormatos.SelectedIndexChanged += new System.EventHandler(this.boxFormatos_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbFormato);
            this.panel1.Controls.Add(this.cbPelicula);
            this.panel1.Controls.Add(this.cbFecha);
            this.panel1.Controls.Add(this.cbSala);
            this.panel1.Controls.Add(this.cbCine);
            this.panel1.Controls.Add(this.boxCines);
            this.panel1.Controls.Add(this.boxFormatos);
            this.panel1.Controls.Add(this.boxSalas);
            this.panel1.Controls.Add(this.boxPeliculas);
            this.panel1.Controls.Add(this.dtpFecha);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(965, 37);
            this.panel1.TabIndex = 5;
            // 
            // cbFormato
            // 
            this.cbFormato.AutoSize = true;
            this.cbFormato.Location = new System.Drawing.Point(805, 10);
            this.cbFormato.Name = "cbFormato";
            this.cbFormato.Size = new System.Drawing.Size(15, 14);
            this.cbFormato.TabIndex = 7;
            this.cbFormato.UseVisualStyleBackColor = true;
            this.cbFormato.CheckedChanged += new System.EventHandler(this.cbFormato_CheckedChanged);
            // 
            // cbPelicula
            // 
            this.cbPelicula.AutoSize = true;
            this.cbPelicula.Location = new System.Drawing.Point(612, 10);
            this.cbPelicula.Name = "cbPelicula";
            this.cbPelicula.Size = new System.Drawing.Size(15, 14);
            this.cbPelicula.TabIndex = 7;
            this.cbPelicula.UseVisualStyleBackColor = true;
            this.cbPelicula.CheckedChanged += new System.EventHandler(this.cbPelicula_CheckedChanged);
            // 
            // cbFecha
            // 
            this.cbFecha.AutoSize = true;
            this.cbFecha.Location = new System.Drawing.Point(414, 10);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(15, 14);
            this.cbFecha.TabIndex = 7;
            this.cbFecha.UseVisualStyleBackColor = true;
            this.cbFecha.CheckedChanged += new System.EventHandler(this.cbFecha_CheckedChanged);
            // 
            // cbSala
            // 
            this.cbSala.AutoSize = true;
            this.cbSala.Location = new System.Drawing.Point(212, 10);
            this.cbSala.Name = "cbSala";
            this.cbSala.Size = new System.Drawing.Size(15, 14);
            this.cbSala.TabIndex = 7;
            this.cbSala.UseVisualStyleBackColor = true;
            this.cbSala.CheckedChanged += new System.EventHandler(this.cbSala_CheckedChanged);
            // 
            // cbCine
            // 
            this.cbCine.AutoSize = true;
            this.cbCine.Location = new System.Drawing.Point(15, 9);
            this.cbCine.Name = "cbCine";
            this.cbCine.Size = new System.Drawing.Size(15, 14);
            this.cbCine.TabIndex = 7;
            this.cbCine.UseVisualStyleBackColor = true;
            this.cbCine.CheckedChanged += new System.EventHandler(this.cbCine_CheckedChanged);
            // 
            // dgvFunciones
            // 
            this.dgvFunciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFunciones.Location = new System.Drawing.Point(2, 45);
            this.dgvFunciones.Name = "dgvFunciones";
            this.dgvFunciones.Size = new System.Drawing.Size(965, 253);
            this.dgvFunciones.TabIndex = 6;
            this.dgvFunciones.SelectionChanged += new System.EventHandler(this.dgvFunciones_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.PtxtMinutos);
            this.panel2.Controls.Add(this.btnGuardar);
            this.panel2.Controls.Add(this.btnVolver);
            this.panel2.Controls.Add(this.PcbEstado);
            this.panel2.Controls.Add(this.PtxtStock);
            this.panel2.Controls.Add(this.PboxFormatos);
            this.panel2.Controls.Add(this.PboxPeliculas);
            this.panel2.Controls.Add(this.PtxtHora);
            this.panel2.Controls.Add(this.PdtpFecha);
            this.panel2.Controls.Add(this.PboxSalas);
            this.panel2.Controls.Add(this.PboxCines);
            this.panel2.Location = new System.Drawing.Point(2, 304);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(965, 89);
            this.panel2.TabIndex = 7;
            this.panel2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "SALA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "FORMATO";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(612, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(10, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = ":";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(739, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "ACTIVA";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(741, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "STOCK";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(513, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "HORA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(509, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "FECHA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "PELICULA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "CINE";
            // 
            // PtxtMinutos
            // 
            this.PtxtMinutos.Location = new System.Drawing.Point(621, 33);
            this.PtxtMinutos.Name = "PtxtMinutos";
            this.PtxtMinutos.Size = new System.Drawing.Size(57, 20);
            this.PtxtMinutos.TabIndex = 9;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(621, 59);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(264, 59);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(75, 23);
            this.btnVolver.TabIndex = 8;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // PcbEstado
            // 
            this.PcbEstado.AutoSize = true;
            this.PcbEstado.Checked = true;
            this.PcbEstado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PcbEstado.Location = new System.Drawing.Point(790, 39);
            this.PcbEstado.Name = "PcbEstado";
            this.PcbEstado.Size = new System.Drawing.Size(15, 14);
            this.PcbEstado.TabIndex = 7;
            this.PcbEstado.UseVisualStyleBackColor = true;
            // 
            // PtxtStock
            // 
            this.PtxtStock.Location = new System.Drawing.Point(790, 6);
            this.PtxtStock.Name = "PtxtStock";
            this.PtxtStock.Size = new System.Drawing.Size(121, 20);
            this.PtxtStock.TabIndex = 6;
            // 
            // PboxFormatos
            // 
            this.PboxFormatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PboxFormatos.FormattingEnabled = true;
            this.PboxFormatos.Location = new System.Drawing.Point(319, 33);
            this.PboxFormatos.Name = "PboxFormatos";
            this.PboxFormatos.Size = new System.Drawing.Size(121, 21);
            this.PboxFormatos.TabIndex = 5;
            // 
            // PboxPeliculas
            // 
            this.PboxPeliculas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PboxPeliculas.FormattingEnabled = true;
            this.PboxPeliculas.Location = new System.Drawing.Point(319, 6);
            this.PboxPeliculas.Name = "PboxPeliculas";
            this.PboxPeliculas.Size = new System.Drawing.Size(121, 21);
            this.PboxPeliculas.TabIndex = 4;
            this.PboxPeliculas.SelectedIndexChanged += new System.EventHandler(this.PboxPeliculas_SelectedIndexChanged);
            // 
            // PtxtHora
            // 
            this.PtxtHora.Location = new System.Drawing.Point(557, 33);
            this.PtxtHora.Name = "PtxtHora";
            this.PtxtHora.Size = new System.Drawing.Size(54, 20);
            this.PtxtHora.TabIndex = 3;
            // 
            // PdtpFecha
            // 
            this.PdtpFecha.CustomFormat = "dd/MM/yyyy";
            this.PdtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PdtpFecha.Location = new System.Drawing.Point(557, 6);
            this.PdtpFecha.Name = "PdtpFecha";
            this.PdtpFecha.Size = new System.Drawing.Size(121, 20);
            this.PdtpFecha.TabIndex = 2;
            // 
            // PboxSalas
            // 
            this.PboxSalas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PboxSalas.FormattingEnabled = true;
            this.PboxSalas.Location = new System.Drawing.Point(65, 33);
            this.PboxSalas.Name = "PboxSalas";
            this.PboxSalas.Size = new System.Drawing.Size(121, 21);
            this.PboxSalas.TabIndex = 1;
            // 
            // PboxCines
            // 
            this.PboxCines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PboxCines.FormattingEnabled = true;
            this.PboxCines.Location = new System.Drawing.Point(65, 6);
            this.PboxCines.Name = "PboxCines";
            this.PboxCines.Size = new System.Drawing.Size(121, 21);
            this.PboxCines.TabIndex = 0;
            this.PboxCines.SelectedIndexChanged += new System.EventHandler(this.PboxCines_SelectedIndexChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(189, 399);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(691, 399);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 8;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // Funciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 426);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvFunciones);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Funciones";
            this.Text = "Funciones";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFunciones)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox boxCines;
        private System.Windows.Forms.ComboBox boxSalas;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox boxPeliculas;
        private System.Windows.Forms.ComboBox boxFormatos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFunciones;
        private System.Windows.Forms.CheckBox cbFecha;
        private System.Windows.Forms.CheckBox cbSala;
        private System.Windows.Forms.CheckBox cbCine;
        private System.Windows.Forms.CheckBox cbFormato;
        private System.Windows.Forms.CheckBox cbPelicula;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.ComboBox PboxSalas;
        private System.Windows.Forms.ComboBox PboxCines;
        private System.Windows.Forms.TextBox PtxtHora;
        private System.Windows.Forms.DateTimePicker PdtpFecha;
        private System.Windows.Forms.CheckBox PcbEstado;
        private System.Windows.Forms.TextBox PtxtStock;
        private System.Windows.Forms.ComboBox PboxFormatos;
        private System.Windows.Forms.ComboBox PboxPeliculas;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.TextBox PtxtMinutos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}