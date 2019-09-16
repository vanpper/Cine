namespace Proyecto_Cine
{
    partial class AdminView
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
            this.Panel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPeliculas = new System.Windows.Forms.Button();
            this.btnCines = new System.Windows.Forms.Button();
            this.btnPrecios = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnFunciones = new System.Windows.Forms.Button();
            this.btnCiudades = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel
            // 
            this.Panel.Location = new System.Drawing.Point(94, 3);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(969, 426);
            this.Panel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPeliculas);
            this.panel1.Controls.Add(this.btnCines);
            this.panel1.Controls.Add(this.btnPrecios);
            this.panel1.Controls.Add(this.btnVentas);
            this.panel1.Controls.Add(this.btnUsuarios);
            this.panel1.Controls.Add(this.btnFunciones);
            this.panel1.Controls.Add(this.btnCiudades);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 426);
            this.panel1.TabIndex = 2;
            // 
            // btnPeliculas
            // 
            this.btnPeliculas.Location = new System.Drawing.Point(4, 145);
            this.btnPeliculas.Name = "btnPeliculas";
            this.btnPeliculas.Size = new System.Drawing.Size(75, 23);
            this.btnPeliculas.TabIndex = 1;
            this.btnPeliculas.Text = "Peliculas";
            this.btnPeliculas.UseVisualStyleBackColor = true;
            this.btnPeliculas.Click += new System.EventHandler(this.btnPeliculas_Click);
            // 
            // btnCines
            // 
            this.btnCines.Location = new System.Drawing.Point(4, 85);
            this.btnCines.Name = "btnCines";
            this.btnCines.Size = new System.Drawing.Size(75, 23);
            this.btnCines.TabIndex = 2;
            this.btnCines.Text = "Cines";
            this.btnCines.UseVisualStyleBackColor = true;
            this.btnCines.Click += new System.EventHandler(this.btnCines_Click);
            // 
            // btnPrecios
            // 
            this.btnPrecios.Location = new System.Drawing.Point(4, 262);
            this.btnPrecios.Name = "btnPrecios";
            this.btnPrecios.Size = new System.Drawing.Size(75, 23);
            this.btnPrecios.TabIndex = 3;
            this.btnPrecios.Text = "Precios";
            this.btnPrecios.UseVisualStyleBackColor = true;
            this.btnPrecios.Click += new System.EventHandler(this.btnPrecios_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(4, 385);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(75, 23);
            this.btnVentas.TabIndex = 4;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.UseVisualStyleBackColor = true;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(4, 327);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(75, 23);
            this.btnUsuarios.TabIndex = 5;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnFunciones
            // 
            this.btnFunciones.Location = new System.Drawing.Point(4, 201);
            this.btnFunciones.Name = "btnFunciones";
            this.btnFunciones.Size = new System.Drawing.Size(75, 23);
            this.btnFunciones.TabIndex = 6;
            this.btnFunciones.Text = "Funciones";
            this.btnFunciones.UseVisualStyleBackColor = true;
            this.btnFunciones.Click += new System.EventHandler(this.btnFunciones_Click);
            // 
            // btnCiudades
            // 
            this.btnCiudades.Location = new System.Drawing.Point(4, 23);
            this.btnCiudades.Name = "btnCiudades";
            this.btnCiudades.Size = new System.Drawing.Size(75, 23);
            this.btnCiudades.TabIndex = 7;
            this.btnCiudades.Text = "Ciudades";
            this.btnCiudades.UseVisualStyleBackColor = true;
            this.btnCiudades.Click += new System.EventHandler(this.btnCiudades_Click);
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 433);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Panel);
            this.Name = "AdminView";
            this.Text = "AdminView";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPeliculas;
        private System.Windows.Forms.Button btnCines;
        private System.Windows.Forms.Button btnPrecios;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnFunciones;
        private System.Windows.Forms.Button btnCiudades;
    }
}