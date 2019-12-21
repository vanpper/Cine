namespace Proyecto_Cine.Forms
{
    partial class SalasYCines
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
            this.btnSalas = new System.Windows.Forms.Button();
            this.btnCines = new System.Windows.Forms.Button();
            this.Panel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSalas);
            this.panel1.Controls.Add(this.btnCines);
            this.panel1.Location = new System.Drawing.Point(0, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(85, 182);
            this.panel1.TabIndex = 0;
            // 
            // btnSalas
            // 
            this.btnSalas.BackColor = System.Drawing.Color.Orange;
            this.btnSalas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalas.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalas.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnSalas.Location = new System.Drawing.Point(3, 121);
            this.btnSalas.Name = "btnSalas";
            this.btnSalas.Size = new System.Drawing.Size(77, 59);
            this.btnSalas.TabIndex = 0;
            this.btnSalas.Text = "Salas";
            this.btnSalas.UseVisualStyleBackColor = false;
            this.btnSalas.Click += new System.EventHandler(this.btnSalas_Click);
            // 
            // btnCines
            // 
            this.btnCines.BackColor = System.Drawing.Color.Orange;
            this.btnCines.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCines.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCines.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCines.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnCines.Location = new System.Drawing.Point(4, 3);
            this.btnCines.Name = "btnCines";
            this.btnCines.Size = new System.Drawing.Size(77, 59);
            this.btnCines.TabIndex = 0;
            this.btnCines.Text = "Cines";
            this.btnCines.UseVisualStyleBackColor = false;
            this.btnCines.Click += new System.EventHandler(this.btnCines_Click);
            // 
            // Panel
            // 
            this.Panel.Location = new System.Drawing.Point(91, 0);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(878, 426);
            this.Panel.TabIndex = 1;
            // 
            // SalasYCines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(969, 426);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SalasYCines";
            this.Text = "SalasYCines";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Button btnSalas;
        private System.Windows.Forms.Button btnCines;
    }
}