namespace Proyecto_Cine.Forms
{
    partial class Salas
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
            this.PanelTDS = new System.Windows.Forms.Panel();
            this.txtDescripcionTDS = new System.Windows.Forms.TextBox();
            this.btnGuardarTDS = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVolverTDS = new System.Windows.Forms.Button();
            this.btnModificarTDS = new System.Windows.Forms.Button();
            this.btnNuevoTDS = new System.Windows.Forms.Button();
            this.dgvTDS = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNuevoSalas = new System.Windows.Forms.Button();
            this.btnModificarSalas = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.PanelSalas = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.checkSala = new System.Windows.Forms.CheckBox();
            this.btnGuardarSalas = new System.Windows.Forms.Button();
            this.btnVolverSalas = new System.Windows.Forms.Button();
            this.txtDescripcionSalas = new System.Windows.Forms.TextBox();
            this.boxTDS = new System.Windows.Forms.ComboBox();
            this.boxCines = new System.Windows.Forms.ComboBox();
            this.dgvSalas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.PanelTDS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTDS)).BeginInit();
            this.panel2.SuspendLayout();
            this.PanelSalas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.PanelTDS);
            this.panel1.Controls.Add(this.btnModificarTDS);
            this.panel1.Controls.Add(this.btnNuevoTDS);
            this.panel1.Controls.Add(this.dgvTDS);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 426);
            this.panel1.TabIndex = 0;
            // 
            // PanelTDS
            // 
            this.PanelTDS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelTDS.Controls.Add(this.txtDescripcionTDS);
            this.PanelTDS.Controls.Add(this.btnGuardarTDS);
            this.PanelTDS.Controls.Add(this.label4);
            this.PanelTDS.Controls.Add(this.btnVolverTDS);
            this.PanelTDS.Location = new System.Drawing.Point(11, 302);
            this.PanelTDS.Name = "PanelTDS";
            this.PanelTDS.Size = new System.Drawing.Size(251, 83);
            this.PanelTDS.TabIndex = 3;
            this.PanelTDS.Visible = false;
            // 
            // txtDescripcionTDS
            // 
            this.txtDescripcionTDS.Location = new System.Drawing.Point(109, 16);
            this.txtDescripcionTDS.MaxLength = 100;
            this.txtDescripcionTDS.Name = "txtDescripcionTDS";
            this.txtDescripcionTDS.Size = new System.Drawing.Size(123, 20);
            this.txtDescripcionTDS.TabIndex = 0;
            // 
            // btnGuardarTDS
            // 
            this.btnGuardarTDS.Location = new System.Drawing.Point(172, 48);
            this.btnGuardarTDS.Name = "btnGuardarTDS";
            this.btnGuardarTDS.Size = new System.Drawing.Size(71, 23);
            this.btnGuardarTDS.TabIndex = 2;
            this.btnGuardarTDS.Text = "Guardar";
            this.btnGuardarTDS.UseVisualStyleBackColor = true;
            this.btnGuardarTDS.Click += new System.EventHandler(this.btnGuardarTDS_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "DESCRIPCION";
            // 
            // btnVolverTDS
            // 
            this.btnVolverTDS.Location = new System.Drawing.Point(8, 49);
            this.btnVolverTDS.Name = "btnVolverTDS";
            this.btnVolverTDS.Size = new System.Drawing.Size(71, 23);
            this.btnVolverTDS.TabIndex = 2;
            this.btnVolverTDS.Text = "Volver";
            this.btnVolverTDS.UseVisualStyleBackColor = true;
            this.btnVolverTDS.Click += new System.EventHandler(this.btnVolverTDS_Click);
            // 
            // btnModificarTDS
            // 
            this.btnModificarTDS.Location = new System.Drawing.Point(187, 391);
            this.btnModificarTDS.Name = "btnModificarTDS";
            this.btnModificarTDS.Size = new System.Drawing.Size(75, 23);
            this.btnModificarTDS.TabIndex = 2;
            this.btnModificarTDS.Text = "Modificar";
            this.btnModificarTDS.UseVisualStyleBackColor = true;
            this.btnModificarTDS.Click += new System.EventHandler(this.btnModificarTDS_Click);
            // 
            // btnNuevoTDS
            // 
            this.btnNuevoTDS.Location = new System.Drawing.Point(11, 391);
            this.btnNuevoTDS.Name = "btnNuevoTDS";
            this.btnNuevoTDS.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoTDS.TabIndex = 2;
            this.btnNuevoTDS.Text = "Nuevo";
            this.btnNuevoTDS.UseVisualStyleBackColor = true;
            this.btnNuevoTDS.Click += new System.EventHandler(this.btnNuevoTDS_Click);
            // 
            // dgvTDS
            // 
            this.dgvTDS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTDS.Location = new System.Drawing.Point(11, 8);
            this.dgvTDS.Name = "dgvTDS";
            this.dgvTDS.Size = new System.Drawing.Size(251, 283);
            this.dgvTDS.TabIndex = 0;
            this.dgvTDS.SelectionChanged += new System.EventHandler(this.dgvTDS_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnNuevoSalas);
            this.panel2.Controls.Add(this.btnModificarSalas);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.PanelSalas);
            this.panel2.Controls.Add(this.boxCines);
            this.panel2.Controls.Add(this.dgvSalas);
            this.panel2.Location = new System.Drawing.Point(279, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(598, 426);
            this.panel2.TabIndex = 0;
            // 
            // btnNuevoSalas
            // 
            this.btnNuevoSalas.Location = new System.Drawing.Point(102, 391);
            this.btnNuevoSalas.Name = "btnNuevoSalas";
            this.btnNuevoSalas.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoSalas.TabIndex = 2;
            this.btnNuevoSalas.Text = "Nuevo";
            this.btnNuevoSalas.UseVisualStyleBackColor = true;
            this.btnNuevoSalas.Click += new System.EventHandler(this.btnNuevoSalas_Click);
            // 
            // btnModificarSalas
            // 
            this.btnModificarSalas.Location = new System.Drawing.Point(411, 391);
            this.btnModificarSalas.Name = "btnModificarSalas";
            this.btnModificarSalas.Size = new System.Drawing.Size(75, 23);
            this.btnModificarSalas.TabIndex = 2;
            this.btnModificarSalas.Text = "Modificar";
            this.btnModificarSalas.UseVisualStyleBackColor = true;
            this.btnModificarSalas.Click += new System.EventHandler(this.btnModificarSalas_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "CINE";
            // 
            // PanelSalas
            // 
            this.PanelSalas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelSalas.Controls.Add(this.label3);
            this.PanelSalas.Controls.Add(this.label2);
            this.PanelSalas.Controls.Add(this.label1);
            this.PanelSalas.Controls.Add(this.checkSala);
            this.PanelSalas.Controls.Add(this.btnGuardarSalas);
            this.PanelSalas.Controls.Add(this.btnVolverSalas);
            this.PanelSalas.Controls.Add(this.txtDescripcionSalas);
            this.PanelSalas.Controls.Add(this.boxTDS);
            this.PanelSalas.Location = new System.Drawing.Point(9, 302);
            this.PanelSalas.Name = "PanelSalas";
            this.PanelSalas.Size = new System.Drawing.Size(577, 83);
            this.PanelSalas.TabIndex = 2;
            this.PanelSalas.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ACTIVA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TIPO";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "NOMBRE";
            // 
            // checkSala
            // 
            this.checkSala.AutoSize = true;
            this.checkSala.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkSala.Checked = true;
            this.checkSala.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSala.Location = new System.Drawing.Point(505, 15);
            this.checkSala.Name = "checkSala";
            this.checkSala.Size = new System.Drawing.Size(15, 14);
            this.checkSala.TabIndex = 3;
            this.checkSala.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkSala.UseVisualStyleBackColor = true;
            // 
            // btnGuardarSalas
            // 
            this.btnGuardarSalas.Location = new System.Drawing.Point(401, 49);
            this.btnGuardarSalas.Name = "btnGuardarSalas";
            this.btnGuardarSalas.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarSalas.TabIndex = 2;
            this.btnGuardarSalas.Text = "Guardar";
            this.btnGuardarSalas.UseVisualStyleBackColor = true;
            this.btnGuardarSalas.Click += new System.EventHandler(this.btnGuardarSalas_Click);
            // 
            // btnVolverSalas
            // 
            this.btnVolverSalas.Location = new System.Drawing.Point(92, 49);
            this.btnVolverSalas.Name = "btnVolverSalas";
            this.btnVolverSalas.Size = new System.Drawing.Size(75, 23);
            this.btnVolverSalas.TabIndex = 2;
            this.btnVolverSalas.Text = "Volver";
            this.btnVolverSalas.UseVisualStyleBackColor = true;
            this.btnVolverSalas.Click += new System.EventHandler(this.btnVolverSalas_Click);
            // 
            // txtDescripcionSalas
            // 
            this.txtDescripcionSalas.Location = new System.Drawing.Point(78, 12);
            this.txtDescripcionSalas.MaxLength = 50;
            this.txtDescripcionSalas.Name = "txtDescripcionSalas";
            this.txtDescripcionSalas.Size = new System.Drawing.Size(121, 20);
            this.txtDescripcionSalas.TabIndex = 1;
            // 
            // boxTDS
            // 
            this.boxTDS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxTDS.FormattingEnabled = true;
            this.boxTDS.Location = new System.Drawing.Point(271, 11);
            this.boxTDS.Name = "boxTDS";
            this.boxTDS.Size = new System.Drawing.Size(121, 21);
            this.boxTDS.TabIndex = 0;
            // 
            // boxCines
            // 
            this.boxCines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxCines.FormattingEnabled = true;
            this.boxCines.Location = new System.Drawing.Point(239, 8);
            this.boxCines.Name = "boxCines";
            this.boxCines.Size = new System.Drawing.Size(121, 21);
            this.boxCines.TabIndex = 1;
            this.boxCines.SelectedIndexChanged += new System.EventHandler(this.boxCines_SelectedIndexChanged);
            // 
            // dgvSalas
            // 
            this.dgvSalas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalas.Location = new System.Drawing.Point(9, 35);
            this.dgvSalas.Name = "dgvSalas";
            this.dgvSalas.Size = new System.Drawing.Size(577, 256);
            this.dgvSalas.TabIndex = 0;
            this.dgvSalas.SelectionChanged += new System.EventHandler(this.dgvSalas_SelectionChanged);
            // 
            // Salas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 426);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Salas";
            this.Text = "Salas";
            this.panel1.ResumeLayout(false);
            this.PanelTDS.ResumeLayout(false);
            this.PanelTDS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTDS)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PanelSalas.ResumeLayout(false);
            this.PanelSalas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvTDS;
        private System.Windows.Forms.DataGridView dgvSalas;
        private System.Windows.Forms.Panel PanelSalas;
        private System.Windows.Forms.ComboBox boxCines;
        private System.Windows.Forms.Panel PanelTDS;
        private System.Windows.Forms.TextBox txtDescripcionTDS;
        private System.Windows.Forms.Button btnModificarTDS;
        private System.Windows.Forms.Button btnNuevoTDS;
        private System.Windows.Forms.Button btnNuevoSalas;
        private System.Windows.Forms.Button btnModificarSalas;
        private System.Windows.Forms.Button btnGuardarSalas;
        private System.Windows.Forms.Button btnVolverSalas;
        private System.Windows.Forms.TextBox txtDescripcionSalas;
        private System.Windows.Forms.ComboBox boxTDS;
        private System.Windows.Forms.Button btnGuardarTDS;
        private System.Windows.Forms.Button btnVolverTDS;
        private System.Windows.Forms.CheckBox checkSala;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}