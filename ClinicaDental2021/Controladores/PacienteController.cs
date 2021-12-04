using ClinicaDental2021.Modelos.DAO;
using ClinicaDental2021.Modelos.Entidades;
using ClinicaDental2021.Vistas;
using System;
using System.Windows.Forms;

namespace ClinicaDental2021.Controladores
{
    public class PacienteController
    {
        PacienteView vista;
        PacienteDAO pacienteDAO = new PacienteDAO();
        Paciente paciente = new Paciente();
        string operacion = string.Empty;

        public PacienteController(PacienteView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);           
            vista.Load += new EventHandler(Load);
            vista.ModificarButton.Click += new EventHandler(Modificar);
            vista.EliminarButton.Click += new EventHandler(Eliminar);
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.PacientesDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = pacienteDAO.EliminarPaciente(Convert.ToInt32(vista.PacientesDataGridView.CurrentRow.Cells[0].Value));
                if (elimino)
                {
                    MessageBox.Show("Paciente eliminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarPacientes();
                }
                else
                {
                    MessageBox.Show("Paciente no se pudo eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Modificar(object sender, EventArgs e)
        {
            if (vista.PacientesDataGridView.SelectedRows.Count > 0)
            {
                operacion = "Modificar";
                HabilitarControles();

                vista.IdTextBox.Text = vista.PacientesDataGridView.CurrentRow.Cells["ID"].Value.ToString();
                vista.IdentidadTextBox.Text = vista.PacientesDataGridView.CurrentRow.Cells["IDENTIDAD"].Value.ToString();
                vista.NombreTextBox.Text = vista.PacientesDataGridView.CurrentRow.Cells["NOMBRE"].Value.ToString();
                vista.DireccionTextBox.Text = vista.PacientesDataGridView.CurrentRow.Cells["DIRECCION"].Value.ToString();              
                vista.TelefonoTextBox.Text = vista.PacientesDataGridView.CurrentRow.Cells["TELEFONO"].Value.ToString();
                vista.FechaNac.Text = vista.PacientesDataGridView.CurrentRow.Cells["FECHANAC"].Value.ToString();
                vista.GeneroComboBox.Text = vista.PacientesDataGridView.CurrentRow.Cells["GENERO"].Value.ToString();                
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarPacientes();
        }

        private void ListarPacientes()
        {
            vista.PacientesDataGridView.DataSource = pacienteDAO.GetPacientes();
        }

        private void Guardar(object sender, EventArgs e)
        {
            if (vista.IdentidadTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.IdentidadTextBox, "Ingrese una identidad");
                vista.IdentidadTextBox.Focus();
                return;
            }
            if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Ingrese un nombre");
                vista.NombreTextBox.Focus();
                return;
            }
            if (vista.DireccionTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.DireccionTextBox, "Ingrese un dirección");
                vista.DireccionTextBox.Focus();
                return;
            }
            if (vista.TelefonoTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.TelefonoTextBox, "Ingrese un telefono");
                vista.TelefonoTextBox.Focus();
                return;
            }
            if (vista.FechaNac.Text == "")
            {
                vista.errorProvider1.SetError(vista.FechaNac, "Ingrese una fecha");
                vista.FechaNac.Focus();
                return;
            }
            if (vista.GeneroComboBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.GeneroComboBox, "Ingrese un genero");
                vista.GeneroComboBox.Focus();
                return;
            }
            paciente.Identidad = vista.IdentidadTextBox.Text;
            paciente.Nombre = vista.NombreTextBox.Text;           
            paciente.Direccion = vista.DireccionTextBox.Text;
            paciente.Telefono = vista.TelefonoTextBox.Text;
            paciente.FechaNac = Convert.ToDateTime(vista.FechaNac.Text);
            paciente.Genero = vista.GeneroComboBox.Text;
        

            if (operacion == "Nuevo")
            {
                bool inserto = pacienteDAO.InsertarNuevoPaciente(paciente);
                if (inserto)
                {
                    MessageBox.Show("Paciente insertado correctamente");
                   
                    LimpiarControles();
                    DesabilitarControles();
                    ListarPacientes();
                }
                else
                {
                    MessageBox.Show("Paciente no se pudo insertar");
                }
            }
            else if (operacion == "Modificar")
            {
                paciente.Id = Convert.ToInt32(vista.IdTextBox.Text);
                bool modifico = pacienteDAO.ActualizarPaciente(paciente);
                if (modifico)
                {
                    MessageBox.Show("Paciente modificado correctamente", "Atanción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DesabilitarControles();
                    LimpiarControles();
                    ListarPacientes();
                }
                else
                {
                    MessageBox.Show("Paciente no se pudo modificar", "Atanción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void HabilitarControles()
        {
            vista.IdentidadTextBox.Enabled = true;
            vista.NombreTextBox.Enabled = true;            
            vista.DireccionTextBox.Enabled = true;
            vista.TelefonoTextBox.Enabled = true;
            vista.FechaNac.Enabled = true;
            vista.GeneroComboBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            vista.IdentidadTextBox.Clear();
            vista.NombreTextBox.Clear();          
            vista.DireccionTextBox.Clear();
            vista.TelefonoTextBox.Clear();          
            vista.IdTextBox.Clear();
        }

        private void DesabilitarControles()
        {
            vista.IdentidadTextBox.Enabled = false;
            vista.NombreTextBox.Enabled = false;
            vista.DireccionTextBox.Enabled = false;
            vista.TelefonoTextBox.Enabled = false;
            vista.FechaNac.Enabled = false;
            vista.GeneroComboBox.Enabled = false;
            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;

            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
        }

    }
}
