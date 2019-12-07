namespace Proyecto_Cine.Forms
{
    partial class Formatos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvFormatos = new System.Windows.Forms.DataGridView();
            this.panelFormato = new System.Windows.Forms.Panel();
            this.txtDescripcionFormato = new System.Windows.Forms.TextBox();
            this.btnGuardarFormato = new System.Windows.Forms.Button();
            this.btnVolverFormato = new System.Windows.Forms.Button();
            this.btnModificarFormato = new System.Windows.Forms.Button();
            this.btnNuevoFormato = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnHabilitacionPXF = new System.Windows.Forms.Button();
            this.btnNuevoPXF = new System.Windows.Forms.Button();
            this.panelPXF = new System.Windows.Forms.Panel();
            this.boxFormatos = new System.Windows.Forms.ComboBox();
            this.btnGuardarPXF = new System.Windows.Forms.Button();
            this.btnVolverPXF = new System.Windows.Forms.Button();
            this.dgvPXF = new System.Windows.Forms.DataGridView();
            this.boxPeliculas = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormatos)).BeginInit();
            this.panelFormato.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelPXF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPXF)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dgvFormatos);
            this.panel1.Controls.Add(this.panelFormato);
            this.panel1.Controls.Add(this.btnModificarFormato);
            this.panel1.Controls.Add(this.btnNuevoFormato);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 426);
            this.panel1.TabIndex = 0;
            // 
            // dgvFormatos
            // 
            this.dgvFormatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormatos.Location = new System.Drawing.Point(14, 11);
            this.dgvFormatos.Name = "dgvFormatos";
            this.dgvFormatos.Size = new System.Drawing.Size(401, 277);
            this.dgvFormatos.TabIndex = 2;
            this.dgvFormatos.SelectionChanged += new System.EventHandler(this.dgvFormatos_SelectionChanged);
            // 
            // panelFormato
            // 
            this.panelFormato.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormato.Controls.Add(this.txtDescripcionFormato);
            this.panelFormato.Controls.Add(this.btnGuardarFormato);
            this.panelFormato.Controls.Add(this.btnVolverFormato);
            this.panelFormato.Location = new System.Drawing.Point(14, 294);
            this.panelFormato.Name = "panelFormato";
            this.panelFormato.Size = new System.Drawing.Size(401, 91);
            this.panelFormato.TabIndex = 1;
            this.panelFormato.Visible = false;
            // 
            // txtDescripcionFormato
            // 
            this.txtDescripcionFormato.Location = new System.Drawing.Point(37, 18);
            this.txtDescripcionFormato.MaxLength = 30;
            this.txtDescripcionFormato.Name = "txtDescripcionFormato";
            this.txtDescripcionFormato.Size = new System.Drawing.Size(329, 20);
            this.txtDescripcionFormato.TabIndex = 1;
            // 
            // btnGuardarFormato
            // 
            this.btnGuardarFormato.Location = new System.Drawing.Point(290, 53);
            this.btnGuardarFormato.Name = "btnGuardarFormato";
            this.btnGuardarFormato.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarFormato.TabIndex = 0;
            this.btnGuardarFormato.Text = "Guardar";
            this.btnGuardarFormato.UseVisualStyleBackColor = true;
            this.btnGuardarFormato.Click += new System.EventHandler(this.btnGuardarFormato_Click);
            // 
            // btnVolverFormato
            // 
            this.btnVolverFormato.Location = new System.Drawing.Point(36, 53);
            this.btnVolverFormato.Name = "btnVolverFormato";
            this.btnVolverFormato.Size = new System.Drawing.Size(75, 23);
            this.btnVolverFormato.TabIndex = 0;
            this.btnVolverFormato.Text = "Volver";
            this.btnVolverFormato.UseVisualStyleBackColor = true;
            this.btnVolverFormato.Click += new System.EventHandler(this.btnVolverFormato_Click);
            // 
            // btnModificarFormato
            // 
            this.btnModificarFormato.Location = new System.Drawing.Point(340, 391);
            this.btnModificarFormato.Name = "btnModificarFormato";
            this.btnModificarFormato.Size = new System.Drawing.Size(75, 23);
            this.btnModificarFormato.TabIndex = 0;
            this.btnModificarFormato.Text = "Modificar";
            this.btnModificarFormato.UseVisualStyleBackColor = true;
            this.btnModificarFormato.Click += new System.EventHandler(this.btnModificarFormato_Click);
            // 
            // btnNuevoFormato
            // 
            this.btnNuevoFormato.Location = new System.Drawing.Point(14, 391);
            this.btnNuevoFormato.Name = "btnNuevoFormato";
            this.btnNuevoFormato.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoFormato.TabIndex = 0;
            this.btnNuevoFormato.Text = "Nuevo";
            this.btnNuevoFormato.UseVisualStyleBackColor = true;
            this.btnNuevoFormato.Click += new System.EventHandler(this.btnNuevoFormato_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnHabilitacionPXF);
            this.panel2.Controls.Add(this.btnNuevoPXF);
            this.panel2.Controls.Add(this.panelPXF);
            this.panel2.Controls.Add(this.dgvPXF);
            this.panel2.Controls.Add(this.boxPeliculas);
            this.panel2.Location = new System.Drawing.Point(438, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 426);
            this.panel2.TabIndex = 1;
            // 
            // btnHabilitacionPXF
            // 
            this.btnHabilitacionPXF.Location = new System.Drawing.Point(332, 391);
            this.btnHabilitacionPXF.Name = "btnHabilitacionPXF";
            this.btnHabilitacionPXF.Size = new System.Drawing.Size(94, 23);
            this.btnHabilitacionPXF.TabIndex = 3;
            this.btnHabilitacionPXF.Text = "Cambiar Estado";
            this.btnHabilitacionPXF.UseVisualStyleBackColor = true;
            this.btnHabilitacionPXF.Click += new System.EventHandler(this.btnHabilitacionPXF_Click);
            // 
            // btnNuevoPXF
            // 
            this.btnNuevoPXF.Location = new System.Drawing.Point(14, 391);
            this.btnNuevoPXF.Name = "btnNuevoPXF";
            this.btnNuevoPXF.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoPXF.TabIndex = 3;
            this.btnNuevoPXF.Text = "Nuevo";
            this.btnNuevoPXF.UseVisualStyleBackColor = true;
            this.btnNuevoPXF.Click += new System.EventHandler(this.btnNuevoPXF_Click);
            // 
            // panelPXF
            // 
            this.panelPXF.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPXF.Controls.Add(this.boxFormatos);
            this.panelPXF.Controls.Add(this.btnGuardarPXF);
            this.panelPXF.Controls.Add(this.btnVolverPXF);
            this.panelPXF.Location = new System.Drawing.Point(14, 294);
            this.panelPXF.Name = "panelPXF";
            this.panelPXF.Size = new System.Drawing.Size(412, 91);
            this.panelPXF.TabIndex = 2;
            this.panelPXF.Visible = false;
            // 
            // boxFormatos
            // 
            this.boxFormatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxFormatos.FormattingEnabled = true;
            this.boxFormatos.Location = new System.Drawing.Point(34, 18);
            this.boxFormatos.Name = "boxFormatos";
            this.boxFormatos.Size = new System.Drawing.Size(343, 21);
            this.boxFormatos.TabIndex = 4;
            // 
            // btnGuardarPXF
            // 
            this.btnGuardarPXF.Location = new System.Drawing.Point(302, 53);
            this.btnGuardarPXF.Name = "btnGuardarPXF";
            this.btnGuardarPXF.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarPXF.TabIndex = 3;
            this.btnGuardarPXF.Text = "Guardar";
            this.btnGuardarPXF.UseVisualStyleBackColor = true;
            this.btnGuardarPXF.Click += new System.EventHandler(this.btnGuardarPXF_Click);
            // 
            // btnVolverPXF
            // 
            this.btnVolverPXF.Location = new System.Drawing.Point(34, 53);
            this.btnVolverPXF.Name = "btnVolverPXF";
            this.btnVolverPXF.Size = new System.Drawing.Size(75, 23);
            this.btnVolverPXF.TabIndex = 3;
            this.btnVolverPXF.Text = "Volver";
            this.btnVolverPXF.UseVisualStyleBackColor = true;
            this.btnVolverPXF.Click += new System.EventHandler(this.btnVolverPXF_Click);
            // 
            // dgvPXF
            // 
            this.dgvPXF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPXF.Location = new System.Drawing.Point(14, 53);
            this.dgvPXF.Name = "dgvPXF";
            this.dgvPXF.Size = new System.Drawing.Size(412, 235);
            this.dgvPXF.TabIndex = 1;
            // 
            // boxPeliculas
            // 
            this.boxPeliculas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxPeliculas.FormattingEnabled = true;
            this.boxPeliculas.Location = new System.Drawing.Point(94, 11);
            this.boxPeliculas.Name = "boxPeliculas";
            this.boxPeliculas.Size = new System.Drawing.Size(241, 21);
            this.boxPeliculas.TabIndex = 0;
            this.boxPeliculas.SelectedIndexChanged += new System.EventHandler(this.boxPeliculas_SelectedIndexChanged);
            // 
            // Formatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 430);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Formatos";
            this.Text = "Formatos";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormatos)).EndInit();
            this.panelFormato.ResumeLayout(false);
            this.panelFormato.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panelPXF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPXF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvFormatos;
        private System.Windows.Forms.Panel panelFormato;
        private System.Windows.Forms.TextBox txtDescripcionFormato;
        private System.Windows.Forms.Button btnGuardarFormato;
        private System.Windows.Forms.Button btnVolverFormato;
        private System.Windows.Forms.Button btnModificarFormato;
        private System.Windows.Forms.Button btnNuevoFormato;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox boxPeliculas;
        private System.Windows.Forms.Button btnHabilitacionPXF;
        private System.Windows.Forms.Button btnNuevoPXF;
        private System.Windows.Forms.Panel panelPXF;
        private System.Windows.Forms.ComboBox boxFormatos;
        private System.Windows.Forms.Button btnGuardarPXF;
        private System.Windows.Forms.Button btnVolverPXF;
        private System.Windows.Forms.DataGridView dgvPXF;
    }
}