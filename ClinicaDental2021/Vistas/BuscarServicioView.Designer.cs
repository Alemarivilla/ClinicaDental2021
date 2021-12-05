namespace ClinicaDental2021.Vistas
{
    partial class BuscarServicioView
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
            this.ServiciosDataGridView = new System.Windows.Forms.DataGridView();
            this.Cancelarbutton = new System.Windows.Forms.Button();
            this.Aceptarbutton = new System.Windows.Forms.Button();
            this.NombreServicioTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ServiciosDataGridView
            // 
            this.ServiciosDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiciosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiciosDataGridView.Location = new System.Drawing.Point(0, 244);
            this.ServiciosDataGridView.Name = "ServiciosDataGridView";
            this.ServiciosDataGridView.Size = new System.Drawing.Size(801, 206);
            this.ServiciosDataGridView.TabIndex = 6;
            // 
            // Cancelarbutton
            // 
            this.Cancelarbutton.Location = new System.Drawing.Point(353, 106);
            this.Cancelarbutton.Name = "Cancelarbutton";
            this.Cancelarbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelarbutton.TabIndex = 13;
            this.Cancelarbutton.Text = "Cancelar";
            this.Cancelarbutton.UseVisualStyleBackColor = true;
            // 
            // Aceptarbutton
            // 
            this.Aceptarbutton.Location = new System.Drawing.Point(252, 106);
            this.Aceptarbutton.Name = "Aceptarbutton";
            this.Aceptarbutton.Size = new System.Drawing.Size(75, 23);
            this.Aceptarbutton.TabIndex = 12;
            this.Aceptarbutton.Text = "Aceptar";
            this.Aceptarbutton.UseVisualStyleBackColor = true;
            // 
            // NombreServicioTextBox
            // 
            this.NombreServicioTextBox.Location = new System.Drawing.Point(220, 38);
            this.NombreServicioTextBox.Name = "NombreServicioTextBox";
            this.NombreServicioTextBox.Size = new System.Drawing.Size(219, 20);
            this.NombreServicioTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nombre Servicio:";
            // 
            // BuscarServicioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Cancelarbutton);
            this.Controls.Add(this.Aceptarbutton);
            this.Controls.Add(this.NombreServicioTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServiciosDataGridView);
            this.Name = "BuscarServicioView";
            this.Text = "Buscar Servicio";
            ((System.ComponentModel.ISupportInitialize)(this.ServiciosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ServiciosDataGridView;
        private System.Windows.Forms.Button Cancelarbutton;
        private System.Windows.Forms.Button Aceptarbutton;
        private System.Windows.Forms.TextBox NombreServicioTextBox;
        private System.Windows.Forms.Label label1;
    }
}