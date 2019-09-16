namespace Proyecto_Cine.Forms
{
    partial class ClasificacionesYGeneros
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
            this.btnModificarClasificacion = new System.Windows.Forms.Button();
            this.btnNuevoClasificacion = new System.Windows.Forms.Button();
            this.panelClasificacion = new System.Windows.Forms.Panel();
            this.txtDescripcionClasificacion = new System.Windows.Forms.TextBox();
            this.btnGuardarClasificacion = new System.Windows.Forms.Button();
            this.btnVolverClasificacion = new System.Windows.Forms.Button();
            this.dgvClasificaciones = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnModificarGenero = new System.Windows.Forms.Button();
            this.btnNuevoGenero = new System.Windows.Forms.Button();
            this.panelGenero = new System.Windows.Forms.Panel();
            this.txtDescripcionGenero = new System.Windows.Forms.TextBox();
            this.btnGuardarGenero = new System.Windows.Forms.Button();
            this.btnVolverGenero = new System.Windows.Forms.Button();
            this.dgvGeneros = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelClasificacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificaciones)).BeginInit();
            this.panel2.SuspendLayout();
            this.panelGenero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneros)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnModificarClasificacion);
            this.panel1.Controls.Add(this.btnNuevoClasificacion);
            this.panel1.Controls.Add(this.panelClasificacion);
            this.panel1.Controls.Add(this.dgvClasificaciones);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 426);
            this.panel1.TabIndex = 0;
            // 
            // btnModificarClasificacion
            // 
            this.btnModificarClasificacion.Location = new System.Drawing.Point(340, 391);
            this.btnModificarClasificacion.Name = "btnModificarClasificacion";
            this.btnModificarClasificacion.Size = new System.Drawing.Size(75, 23);
            this.btnModificarClasificacion.TabIndex = 2;
            this.btnModificarClasificacion.Text = "Modificar";
            this.btnModificarClasificacion.UseVisualStyleBackColor = true;
            this.btnModificarClasificacion.Click += new System.EventHandler(this.btnModificarClasificacion_Click);
            // 
            // btnNuevoClasificacion
            // 
            this.btnNuevoClasificacion.Location = new System.Drawing.Point(13, 391);
            this.btnNuevoClasificacion.Name = "btnNuevoClasificacion";
            this.btnNuevoClasificacion.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoClasificacion.TabIndex = 2;
            this.btnNuevoClasificacion.Text = "Nuevo";
            this.btnNuevoClasificacion.UseVisualStyleBackColor = true;
            this.btnNuevoClasificacion.Click += new System.EventHandler(this.btnNuevoClasificacion_Click);
            // 
            // panelClasificacion
            // 
            this.panelClasificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelClasificacion.Controls.Add(this.txtDescripcionClasificacion);
            this.panelClasificacion.Controls.Add(this.btnGuardarClasificacion);
            this.panelClasificacion.Controls.Add(this.btnVolverClasificacion);
            this.panelClasificacion.Location = new System.Drawing.Point(13, 294);
            this.panelClasificacion.Name = "panelClasificacion";
            this.panelClasificacion.Size = new System.Drawing.Size(401, 91);
            this.panelClasificacion.TabIndex = 1;
            this.panelClasificacion.Visible = false;
            // 
            // txtDescripcionClasificacion
            // 
            this.txtDescripcionClasificacion.Location = new System.Drawing.Point(35, 19);
            this.txtDescripcionClasificacion.Name = "txtDescripcionClasificacion";
            this.txtDescripcionClasificacion.Size = new System.Drawing.Size(331, 20);
            this.txtDescripcionClasificacion.TabIndex = 0;
            // 
            // btnGuardarClasificacion
            // 
            this.btnGuardarClasificacion.Location = new System.Drawing.Point(291, 53);
            this.btnGuardarClasificacion.Name = "btnGuardarClasificacion";
            this.btnGuardarClasificacion.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarClasificacion.TabIndex = 2;
            this.btnGuardarClasificacion.Text = "Guardar";
            this.btnGuardarClasificacion.UseVisualStyleBackColor = true;
            this.btnGuardarClasificacion.Click += new System.EventHandler(this.btnGuardarClasificacion_Click);
            // 
            // btnVolverClasificacion
            // 
            this.btnVolverClasificacion.Location = new System.Drawing.Point(35, 53);
            this.btnVolverClasificacion.Name = "btnVolverClasificacion";
            this.btnVolverClasificacion.Size = new System.Drawing.Size(75, 23);
            this.btnVolverClasificacion.TabIndex = 2;
            this.btnVolverClasificacion.Text = "Volver";
            this.btnVolverClasificacion.UseVisualStyleBackColor = true;
            this.btnVolverClasificacion.Click += new System.EventHandler(this.btnVolverClasificacion_Click);
            // 
            // dgvClasificaciones
            // 
            this.dgvClasificaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClasificaciones.Location = new System.Drawing.Point(13, 11);
            this.dgvClasificaciones.Name = "dgvClasificaciones";
            this.dgvClasificaciones.Size = new System.Drawing.Size(402, 277);
            this.dgvClasificaciones.TabIndex = 0;
            this.dgvClasificaciones.SelectionChanged += new System.EventHandler(this.dgvClasificaciones_SelectionChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnModificarGenero);
            this.panel2.Controls.Add(this.btnNuevoGenero);
            this.panel2.Controls.Add(this.panelGenero);
            this.panel2.Controls.Add(this.dgvGeneros);
            this.panel2.Location = new System.Drawing.Point(438, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(439, 426);
            this.panel2.TabIndex = 0;
            // 
            // btnModificarGenero
            // 
            this.btnModificarGenero.Location = new System.Drawing.Point(351, 391);
            this.btnModificarGenero.Name = "btnModificarGenero";
            this.btnModificarGenero.Size = new System.Drawing.Size(75, 23);
            this.btnModificarGenero.TabIndex = 2;
            this.btnModificarGenero.Text = "Modificar";
            this.btnModificarGenero.UseVisualStyleBackColor = true;
            this.btnModificarGenero.Click += new System.EventHandler(this.btnModificarGenero_Click);
            // 
            // btnNuevoGenero
            // 
            this.btnNuevoGenero.Location = new System.Drawing.Point(13, 391);
            this.btnNuevoGenero.Name = "btnNuevoGenero";
            this.btnNuevoGenero.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoGenero.TabIndex = 2;
            this.btnNuevoGenero.Text = "Nuevo";
            this.btnNuevoGenero.UseVisualStyleBackColor = true;
            this.btnNuevoGenero.Click += new System.EventHandler(this.btnNuevoGenero_Click);
            // 
            // panelGenero
            // 
            this.panelGenero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGenero.Controls.Add(this.txtDescripcionGenero);
            this.panelGenero.Controls.Add(this.btnGuardarGenero);
            this.panelGenero.Controls.Add(this.btnVolverGenero);
            this.panelGenero.Location = new System.Drawing.Point(13, 294);
            this.panelGenero.Name = "panelGenero";
            this.panelGenero.Size = new System.Drawing.Size(413, 91);
            this.panelGenero.TabIndex = 1;
            this.panelGenero.Visible = false;
            // 
            // txtDescripcionGenero
            // 
            this.txtDescripcionGenero.Location = new System.Drawing.Point(33, 19);
            this.txtDescripcionGenero.Name = "txtDescripcionGenero";
            this.txtDescripcionGenero.Size = new System.Drawing.Size(344, 20);
            this.txtDescripcionGenero.TabIndex = 0;
            // 
            // btnGuardarGenero
            // 
            this.btnGuardarGenero.Location = new System.Drawing.Point(302, 53);
            this.btnGuardarGenero.Name = "btnGuardarGenero";
            this.btnGuardarGenero.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarGenero.TabIndex = 2;
            this.btnGuardarGenero.Text = "Guardar";
            this.btnGuardarGenero.UseVisualStyleBackColor = true;
            this.btnGuardarGenero.Click += new System.EventHandler(this.btnGuardarGenero_Click);
            // 
            // btnVolverGenero
            // 
            this.btnVolverGenero.Location = new System.Drawing.Point(33, 53);
            this.btnVolverGenero.Name = "btnVolverGenero";
            this.btnVolverGenero.Size = new System.Drawing.Size(75, 23);
            this.btnVolverGenero.TabIndex = 2;
            this.btnVolverGenero.Text = "Volver";
            this.btnVolverGenero.UseVisualStyleBackColor = true;
            this.btnVolverGenero.Click += new System.EventHandler(this.btnVolverGenero_Click);
            // 
            // dgvGeneros
            // 
            this.dgvGeneros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneros.Location = new System.Drawing.Point(13, 11);
            this.dgvGeneros.Name = "dgvGeneros";
            this.dgvGeneros.Size = new System.Drawing.Size(413, 277);
            this.dgvGeneros.TabIndex = 0;
            this.dgvGeneros.SelectionChanged += new System.EventHandler(this.dgvGeneros_SelectionChanged);
            // 
            // ClasificacionesYGeneros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 427);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClasificacionesYGeneros";
            this.Text = "ClasificacionesYGeneros";
            this.panel1.ResumeLayout(false);
            this.panelClasificacion.ResumeLayout(false);
            this.panelClasificacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClasificaciones)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panelGenero.ResumeLayout(false);
            this.panelGenero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvClasificaciones;
        private System.Windows.Forms.Button btnModificarClasificacion;
        private System.Windows.Forms.Button btnNuevoClasificacion;
        private System.Windows.Forms.Panel panelClasificacion;
        private System.Windows.Forms.TextBox txtDescripcionClasificacion;
        private System.Windows.Forms.Button btnGuardarClasificacion;
        private System.Windows.Forms.Button btnVolverClasificacion;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnModificarGenero;
        private System.Windows.Forms.Button btnNuevoGenero;
        private System.Windows.Forms.Panel panelGenero;
        private System.Windows.Forms.TextBox txtDescripcionGenero;
        private System.Windows.Forms.Button btnGuardarGenero;
        private System.Windows.Forms.Button btnVolverGenero;
        private System.Windows.Forms.DataGridView dgvGeneros;
    }
}