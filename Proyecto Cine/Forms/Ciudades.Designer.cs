namespace Proyecto_Cine.Forms
{
    partial class Ciudades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvProvincias = new System.Windows.Forms.DataGridView();
            this.dgvCiudades = new System.Windows.Forms.DataGridView();
            this.btnNuevaProvincia = new System.Windows.Forms.Button();
            this.btnNuevaCiudad = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnModificarProvincia = new System.Windows.Forms.Button();
            this.btnModificarCiudad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvincias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudades)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProvincias
            // 
            this.dgvProvincias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvProvincias.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProvincias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProvincias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProvincias.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProvincias.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvProvincias.Location = new System.Drawing.Point(31, 2);
            this.dgvProvincias.Name = "dgvProvincias";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProvincias.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvProvincias.RowHeadersWidth = 60;
            this.dgvProvincias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProvincias.Size = new System.Drawing.Size(299, 422);
            this.dgvProvincias.TabIndex = 0;
            this.dgvProvincias.SelectionChanged += new System.EventHandler(this.dgvProvincias_SelectionChanged);
            // 
            // dgvCiudades
            // 
            this.dgvCiudades.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvCiudades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCiudades.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.dgvCiudades.Location = new System.Drawing.Point(636, 2);
            this.dgvCiudades.Name = "dgvCiudades";
            this.dgvCiudades.Size = new System.Drawing.Size(300, 422);
            this.dgvCiudades.TabIndex = 3;
            this.dgvCiudades.SelectionChanged += new System.EventHandler(this.dgvCiudades_SelectionChanged);
            // 
            // btnNuevaProvincia
            // 
            this.btnNuevaProvincia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNuevaProvincia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaProvincia.Location = new System.Drawing.Point(1, 1);
            this.btnNuevaProvincia.Name = "btnNuevaProvincia";
            this.btnNuevaProvincia.Size = new System.Drawing.Size(28, 28);
            this.btnNuevaProvincia.TabIndex = 1;
            this.btnNuevaProvincia.UseVisualStyleBackColor = true;
            this.btnNuevaProvincia.Click += new System.EventHandler(this.btnNuevaProvincia_Click);
            // 
            // btnNuevaCiudad
            // 
            this.btnNuevaCiudad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnNuevaCiudad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaCiudad.Location = new System.Drawing.Point(939, 2);
            this.btnNuevaCiudad.Name = "btnNuevaCiudad";
            this.btnNuevaCiudad.Size = new System.Drawing.Size(28, 28);
            this.btnNuevaCiudad.TabIndex = 4;
            this.btnNuevaCiudad.UseVisualStyleBackColor = true;
            this.btnNuevaCiudad.Click += new System.EventHandler(this.btnNuevaCiudad_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnVolver);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtDescripcion);
            this.panel1.Location = new System.Drawing.Point(336, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(295, 423);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "NOMBRE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(118, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "TEXT";
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Transparent;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(19, 357);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(257, 38);
            this.btnVolver.TabIndex = 7;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGuardar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(19, 313);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(257, 38);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescripcion.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(37, 196);
            this.txtDescripcion.MaxLength = 50;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(215, 26);
            this.txtDescripcion.TabIndex = 6;
            // 
            // btnModificarProvincia
            // 
            this.btnModificarProvincia.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnModificarProvincia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnModificarProvincia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarProvincia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarProvincia.Location = new System.Drawing.Point(1, 30);
            this.btnModificarProvincia.Name = "btnModificarProvincia";
            this.btnModificarProvincia.Size = new System.Drawing.Size(28, 28);
            this.btnModificarProvincia.TabIndex = 2;
            this.btnModificarProvincia.UseVisualStyleBackColor = false;
            this.btnModificarProvincia.Click += new System.EventHandler(this.btnModificarProvincia_Click);
            // 
            // btnModificarCiudad
            // 
            this.btnModificarCiudad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnModificarCiudad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarCiudad.Location = new System.Drawing.Point(939, 31);
            this.btnModificarCiudad.Name = "btnModificarCiudad";
            this.btnModificarCiudad.Size = new System.Drawing.Size(28, 28);
            this.btnModificarCiudad.TabIndex = 5;
            this.btnModificarCiudad.UseVisualStyleBackColor = true;
            this.btnModificarCiudad.Click += new System.EventHandler(this.btnModificarCiudad_Click);
            // 
            // Ciudades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(965, 430);
            this.Controls.Add(this.btnModificarCiudad);
            this.Controls.Add(this.btnModificarProvincia);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNuevaCiudad);
            this.Controls.Add(this.btnNuevaProvincia);
            this.Controls.Add(this.dgvCiudades);
            this.Controls.Add(this.dgvProvincias);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ciudades";
            this.Text = "Ciudades2";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProvincias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCiudades)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProvincias;
        private System.Windows.Forms.DataGridView dgvCiudades;
        private System.Windows.Forms.Button btnNuevaProvincia;
        private System.Windows.Forms.Button btnNuevaCiudad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnModificarProvincia;
        private System.Windows.Forms.Button btnModificarCiudad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}