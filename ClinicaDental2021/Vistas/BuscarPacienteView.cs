using ClinicaDental2021.Modelos.DAO;
using ClinicaDental2021.Modelos.Entidades;
using System;
using System.Windows.Forms;

namespace ClinicaDental2021.Vistas
{
    public partial class BuscarPacienteView : Form
    {
        public BuscarPacienteView()
        {
            InitializeComponent();           
        }

        PacienteDAO pacienteDAO = new PacienteDAO();

        public Paciente _paciente = new Paciente();

        private void BuscarPacienteView_Load(object sender, EventArgs e)
        {
            PacientesDataGridView.DataSource = pacienteDAO.GetPacientes();
        }

        private void NombrePacienteTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            PacientesDataGridView.DataSource = pacienteDAO.GetPacientesPorNombre(NombrePacienteTextBox.Text);
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (PacientesDataGridView.RowCount > 0)
            {
                if (PacientesDataGridView.SelectedRows.Count > 0)
                {
                    _paciente.Id = (int)PacientesDataGridView.CurrentRow.Cells["ID"].Value;
                    _paciente.Identidad = PacientesDataGridView.CurrentRow.Cells["IDENTIDAD"].Value.ToString();
                    _paciente.Nombre = PacientesDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                    this.Close();
                }
            }
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
