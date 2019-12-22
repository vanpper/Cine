namespace Proyecto_Cine.Forms
{
    partial class Precios
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnModificarTDE = new System.Windows.Forms.Button();
            this.btnNuevoTDE = new System.Windows.Forms.Button();
            this.panelTDE = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcionTDE = new System.Windows.Forms.TextBox();
            this.btnGuardarTDE = new System.Windows.Forms.Button();
            this.btnVolverTDE = new System.Windows.Forms.Button();
            this.dgvTDE = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnModificarPrecio = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNuevoPrecio = new System.Windows.Forms.Button();
            this.panelPrecio = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuardarPrecio = new System.Windows.Forms.Button();
            this.btnVolverPrecio = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.boxTDE = new System.Windows.Forms.ComboBox();
            this.BoxTDS = new System.Windows.Forms.ComboBox();
            this.BoxCines = new System.Windows.Forms.ComboBox();
            this.dgvPrecios = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelTDE.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTDE)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelPrecio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnModificarTDE);
            this.panel1.Controls.Add(this.btnNuevoTDE);
            this.panel1.Controls.Add(this.panelTDE);
            this.panel1.Controls.Add(this.dgvTDE);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 426);
            this.panel1.TabIndex = 0;
            // 
            // btnModificarTDE
            // 
            this.btnModificarTDE.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarTDE.Location = new System.Drawing.Point(237, 390);
            this.btnModificarTDE.Name = "btnModificarTDE";
            this.btnModificarTDE.Size = new System.Drawing.Size(75, 23);
            this.btnModificarTDE.TabIndex = 2;
            this.btnModificarTDE.Text = "Modificar";
            this.btnModificarTDE.UseVisualStyleBackColor = true;
            this.btnModificarTDE.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevoTDE
            // 
            this.btnNuevoTDE.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoTDE.Location = new System.Drawing.Point(11, 390);
            this.btnNuevoTDE.Name = "btnNuevoTDE";
            this.btnNuevoTDE.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoTDE.TabIndex = 2;
            this.btnNuevoTDE.Text = "Nuevo";
            this.btnNuevoTDE.UseVisualStyleBackColor = true;
            this.btnNuevoTDE.Click += new System.EventHandler(this.btnNuevoTDE_Click);
            // 
            // panelTDE
            // 
            this.panelTDE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTDE.Controls.Add(this.label1);
            this.panelTDE.Controls.Add(this.txtDescripcionTDE);
            this.panelTDE.Controls.Add(this.btnGuardarTDE);
            this.panelTDE.Controls.Add(this.btnVolverTDE);
            this.panelTDE.Location = new System.Drawing.Point(12, 302);
            this.panelTDE.Name = "panelTDE";
            this.panelTDE.Size = new System.Drawing.Size(300, 82);
            this.panelTDE.TabIndex = 1;
            this.panelTDE.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(29, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Descripcion";
            // 
            // txtDescripcionTDE
            // 
            this.txtDescripcionTDE.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionTDE.Location = new System.Drawing.Point(108, 15);
            this.txtDescripcionTDE.MaxLength = 100;
            this.txtDescripcionTDE.Name = "txtDescripcionTDE";
            this.txtDescripcionTDE.Size = new System.Drawing.Size(169, 23);
            this.txtDescripcionTDE.TabIndex = 3;
            // 
            // btnGuardarTDE
            // 
            this.btnGuardarTDE.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarTDE.Location = new System.Drawing.Point(202, 47);
            this.btnGuardarTDE.Name = "btnGuardarTDE";
            this.btnGuardarTDE.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarTDE.TabIndex = 2;
            this.btnGuardarTDE.Text = "Guardar";
            this.btnGuardarTDE.UseVisualStyleBackColor = true;
            this.btnGuardarTDE.Click += new System.EventHandler(this.btnGuardarTDE_Click);
            // 
            // btnVolverTDE
            // 
            this.btnVolverTDE.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverTDE.Location = new System.Drawing.Point(32, 47);
            this.btnVolverTDE.Name = "btnVolverTDE";
            this.btnVolverTDE.Size = new System.Drawing.Size(71, 23);
            this.btnVolverTDE.TabIndex = 2;
            this.btnVolverTDE.Text = "Volver";
            this.btnVolverTDE.UseVisualStyleBackColor = true;
            this.btnVolverTDE.Click += new System.EventHandler(this.btnVolverTDE_Click);
            // 
            // dgvTDE
            // 
            this.dgvTDE.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
            this.dgvTDE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTDE.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTDE.Location = new System.Drawing.Point(11, 7);
            this.dgvTDE.Name = "dgvTDE";
            this.dgvTDE.Size = new System.Drawing.Size(301, 286);
            this.dgvTDE.TabIndex = 0;
            this.dgvTDE.SelectionChanged += new System.EventHandler(this.dgvTDE_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnModificarPrecio);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnNuevoPrecio);
            this.panel2.Controls.Add(this.panelPrecio);
            this.panel2.Controls.Add(this.BoxTDS);
            this.panel2.Controls.Add(this.BoxCines);
            this.panel2.Controls.Add(this.dgvPrecios);
            this.panel2.Location = new System.Drawing.Point(329, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(639, 426);
            this.panel2.TabIndex = 1;
            // 
            // btnModificarPrecio
            // 
            this.btnModificarPrecio.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarPrecio.Location = new System.Drawing.Point(453, 390);
            this.btnModificarPrecio.Name = "btnModificarPrecio";
            this.btnModificarPrecio.Size = new System.Drawing.Size(75, 23);
            this.btnModificarPrecio.TabIndex = 3;
            this.btnModificarPrecio.Text = "Modificar";
            this.btnModificarPrecio.UseVisualStyleBackColor = true;
            this.btnModificarPrecio.Click += new System.EventHandler(this.btnModificarPrecio_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.AliceBlue;
            this.label5.Location = new System.Drawing.Point(383, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Sala";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.AliceBlue;
            this.label4.Location = new System.Drawing.Point(78, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cine";
            // 
            // btnNuevoPrecio
            // 
            this.btnNuevoPrecio.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoPrecio.Location = new System.Drawing.Point(103, 390);
            this.btnNuevoPrecio.Name = "btnNuevoPrecio";
            this.btnNuevoPrecio.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoPrecio.TabIndex = 3;
            this.btnNuevoPrecio.Text = "Nuevo";
            this.btnNuevoPrecio.UseVisualStyleBackColor = true;
            this.btnNuevoPrecio.Click += new System.EventHandler(this.btnNuevoPrecio_Click);
            // 
            // panelPrecio
            // 
            this.panelPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPrecio.Controls.Add(this.label3);
            this.panelPrecio.Controls.Add(this.label2);
            this.panelPrecio.Controls.Add(this.btnGuardarPrecio);
            this.panelPrecio.Controls.Add(this.btnVolverPrecio);
            this.panelPrecio.Controls.Add(this.txtPrecio);
            this.panelPrecio.Controls.Add(this.boxTDE);
            this.panelPrecio.Location = new System.Drawing.Point(9, 302);
            this.panelPrecio.Name = "panelPrecio";
            this.panelPrecio.Size = new System.Drawing.Size(618, 82);
            this.panelPrecio.TabIndex = 2;
            this.panelPrecio.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.AliceBlue;
            this.label3.Location = new System.Drawing.Point(404, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.Location = new System.Drawing.Point(27, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo";
            // 
            // btnGuardarPrecio
            // 
            this.btnGuardarPrecio.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarPrecio.Location = new System.Drawing.Point(367, 46);
            this.btnGuardarPrecio.Name = "btnGuardarPrecio";
            this.btnGuardarPrecio.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarPrecio.TabIndex = 3;
            this.btnGuardarPrecio.Text = "Guardar";
            this.btnGuardarPrecio.UseVisualStyleBackColor = true;
            this.btnGuardarPrecio.Click += new System.EventHandler(this.btnGuardarPrecio_Click);
            // 
            // btnVolverPrecio
            // 
            this.btnVolverPrecio.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolverPrecio.Location = new System.Drawing.Point(164, 46);
            this.btnVolverPrecio.Name = "btnVolverPrecio";
            this.btnVolverPrecio.Size = new System.Drawing.Size(75, 23);
            this.btnVolverPrecio.TabIndex = 2;
            this.btnVolverPrecio.Text = "Volver";
            this.btnVolverPrecio.UseVisualStyleBackColor = true;
            this.btnVolverPrecio.Click += new System.EventHandler(this.btnVolverPrecio_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(457, 11);
            this.txtPrecio.MaxLength = 15;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 23);
            this.txtPrecio.TabIndex = 1;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // boxTDE
            // 
            this.boxTDE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxTDE.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boxTDE.FormattingEnabled = true;
            this.boxTDE.Location = new System.Drawing.Point(65, 11);
            this.boxTDE.Name = "boxTDE";
            this.boxTDE.Size = new System.Drawing.Size(276, 23);
            this.boxTDE.TabIndex = 0;
            // 
            // BoxTDS
            // 
            this.BoxTDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxTDS.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxTDS.FormattingEnabled = true;
            this.BoxTDS.Location = new System.Drawing.Point(423, 7);
            this.BoxTDS.Name = "BoxTDS";
            this.BoxTDS.Size = new System.Drawing.Size(121, 23);
            this.BoxTDS.TabIndex = 1;
            this.BoxTDS.SelectedIndexChanged += new System.EventHandler(this.BoxTDS_SelectedIndexChanged);
            // 
            // BoxCines
            // 
            this.BoxCines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxCines.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BoxCines.FormattingEnabled = true;
            this.BoxCines.Location = new System.Drawing.Point(116, 7);
            this.BoxCines.Name = "BoxCines";
            this.BoxCines.Size = new System.Drawing.Size(121, 23);
            this.BoxCines.TabIndex = 1;
            this.BoxCines.SelectedIndexChanged += new System.EventHandler(this.BoxCines_SelectedIndexChanged);
            // 
            // dgvPrecios
            // 
            this.dgvPrecios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(60)))));
            this.dgvPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrecios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPrecios.Location = new System.Drawing.Point(9, 34);
            this.dgvPrecios.Name = "dgvPrecios";
            this.dgvPrecios.Size = new System.Drawing.Size(622, 259);
            this.dgvPrecios.TabIndex = 0;
            this.dgvPrecios.SelectionChanged += new System.EventHandler(this.dgvPrecios_SelectionChanged);
            // 
            // Precios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(969, 426);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Precios";
            this.Text = "Precios";
            this.panel1.ResumeLayout(false);
            this.panelTDE.ResumeLayout(false);
            this.panelTDE.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTDE)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panelPrecio.ResumeLayout(false);
            this.panelPrecio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnModificarTDE;
        private System.Windows.Forms.Button btnNuevoTDE;
        private System.Windows.Forms.Panel panelTDE;
        private System.Windows.Forms.TextBox txtDescripcionTDE;
        private System.Windows.Forms.Button btnGuardarTDE;
        private System.Windows.Forms.Button btnVolverTDE;
        private System.Windows.Forms.DataGridView dgvTDE;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox BoxTDS;
        private System.Windows.Forms.ComboBox BoxCines;
        private System.Windows.Forms.DataGridView dgvPrecios;
        private System.Windows.Forms.Panel panelPrecio;
        private System.Windows.Forms.ComboBox boxTDE;
        private System.Windows.Forms.Button btnModificarPrecio;
        private System.Windows.Forms.Button btnNuevoPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnVolverPrecio;
        private System.Windows.Forms.Button btnGuardarPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}