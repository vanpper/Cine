namespace Proyecto_Cine.Forms
{
    partial class MenuPeliculas
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
            this.btnPeliculas = new System.Windows.Forms.Button();
            this.btnFormatos = new System.Windows.Forms.Button();
            this.btnGYC = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPeliculas
            // 
            this.btnPeliculas.BackColor = System.Drawing.Color.Orange;
            this.btnPeliculas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPeliculas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPeliculas.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPeliculas.ForeColor = System.Drawing.Color.White;
            this.btnPeliculas.Location = new System.Drawing.Point(3, 64);
            this.btnPeliculas.Name = "btnPeliculas";
            this.btnPeliculas.Size = new System.Drawing.Size(77, 59);
            this.btnPeliculas.TabIndex = 0;
            this.btnPeliculas.Text = "Peliculas";
            this.btnPeliculas.UseVisualStyleBackColor = false;
            this.btnPeliculas.Click += new System.EventHandler(this.btnPeliculas_Click);
            // 
            // btnFormatos
            // 
            this.btnFormatos.BackColor = System.Drawing.Color.Orange;
            this.btnFormatos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFormatos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFormatos.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFormatos.ForeColor = System.Drawing.Color.White;
            this.btnFormatos.Location = new System.Drawing.Point(3, 187);
            this.btnFormatos.Name = "btnFormatos";
            this.btnFormatos.Size = new System.Drawing.Size(77, 59);
            this.btnFormatos.TabIndex = 0;
            this.btnFormatos.Text = "Formatos";
            this.btnFormatos.UseVisualStyleBackColor = false;
            this.btnFormatos.Click += new System.EventHandler(this.btnFormatos_Click);
            // 
            // btnGYC
            // 
            this.btnGYC.BackColor = System.Drawing.Color.Orange;
            this.btnGYC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGYC.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGYC.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGYC.ForeColor = System.Drawing.Color.White;
            this.btnGYC.Location = new System.Drawing.Point(3, 303);
            this.btnGYC.Name = "btnGYC";
            this.btnGYC.Size = new System.Drawing.Size(77, 59);
            this.btnGYC.TabIndex = 0;
            this.btnGYC.Text = "Generos Clas.";
            this.btnGYC.UseVisualStyleBackColor = false;
            this.btnGYC.Click += new System.EventHandler(this.btnGYC_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnFormatos);
            this.panel1.Controls.Add(this.btnGYC);
            this.panel1.Controls.Add(this.btnPeliculas);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 426);
            this.panel1.TabIndex = 1;
            // 
            // Panel
            // 
            this.Panel.Location = new System.Drawing.Point(91, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(884, 427);
            this.Panel.TabIndex = 2;
            // 
            // MenuPeliculas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(975, 428);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuPeliculas";
            this.Text = "MenuPeliculas";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPeliculas;
        private System.Windows.Forms.Button btnFormatos;
        private System.Windows.Forms.Button btnGYC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Panel;
    }
}