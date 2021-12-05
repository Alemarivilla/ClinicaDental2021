namespace ClinicaDental2021.Vistas
{
    partial class BuscarPacienteView
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
            this.PacientesDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.NombrePacienteTextBox = new System.Windows.Forms.TextBox();
            this.Aceptarbutton = new System.Windows.Forms.Button();
            this.Cancelarbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PacientesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PacientesDataGridView
            // 
            this.PacientesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PacientesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PacientesDataGridView.Location = new System.Drawing.Point(1, 173);
            this.PacientesDataGridView.Name = "PacientesDataGridView";
            this.PacientesDataGridView.Size = new System.Drawing.Size(801, 204);
            this.PacientesDataGridView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre Paciente:";
            // 
            // NombrePacienteTextBox
            // 
            this.NombrePacienteTextBox.Location = new System.Drawing.Point(256, 36);
            this.NombrePacienteTextBox.Name = "NombrePacienteTextBox";
            this.NombrePacienteTextBox.Size = new System.Drawing.Size(221, 20);
            this.NombrePacienteTextBox.TabIndex = 2;
            // 
            // Aceptarbutton
            // 
            this.Aceptarbutton.Location = new System.Drawing.Point(321, 90);
            this.Aceptarbutton.Name = "Aceptarbutton";
            this.Aceptarbutton.Size = new System.Drawing.Size(75, 23);
            this.Aceptarbutton.TabIndex = 3;
            this.Aceptarbutton.Text = "Aceptar";
            this.Aceptarbutton.UseVisualStyleBackColor = true;
            // 
            // Cancelarbutton
            // 
            this.Cancelarbutton.Location = new System.Drawing.Point(402, 90);
            this.Cancelarbutton.Name = "Cancelarbutton";
            this.Cancelarbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelarbutton.TabIndex = 4;
            this.Cancelarbutton.Text = "Cancelar";
            this.Cancelarbutton.UseVisualStyleBackColor = true;
            // 
            // BuscarPacienteView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.Cancelarbutton);
            this.Controls.Add(this.Aceptarbutton);
            this.Controls.Add(this.NombrePacienteTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PacientesDataGridView);
            this.Name = "BuscarPacienteView";
            this.Text = "Buscar Paciente";
            ((System.ComponentModel.ISupportInitialize)(this.PacientesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PacientesDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NombrePacienteTextBox;
        private System.Windows.Forms.Button Aceptarbutton;
        private System.Windows.Forms.Button Cancelarbutton;
    }
}