using ClinicaDental2021.Modelos.DAO;
using ClinicaDental2021.Modelos.Entidades;
using ClinicaDental2021.Vistas;
using System;
using System.Windows.Forms;

namespace ClinicaDental2021.Controladores
{
    public class CitasController
    {
        CitasView vista;
        CitaDAO citaDAO = new CitaDAO();
        Cita cita = new Cita();
        PacienteDAO pacienteDAO = new PacienteDAO();
        Paciente paciente = new Paciente();
        DoctorDAO doctorDAO = new DoctorDAO();
        Doctor doctor = new Doctor();
        string operacion = string.Empty;

        public CitasController(CitasView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);           
            vista.Load += new EventHandler(Load);
            vista.IdentidadTextBox.KeyPress += IdentidadTextBox_KeyPress;
            vista.CodigoTextBox.KeyPress += CodigoTextBox_KeyPress;
        }

        private void Load(object sender, EventArgs e)
        {
            ListarCitas();
        }

        private void ListarCitas()
        {
            vista.CitasDataGridView.DataSource = citaDAO.GetCitas();
        }

        private void Guardar(object sender, EventArgs e)
        {
           
            cita.Fecha = vista.dateTimePicker1.Value;           
            cita.IdPaciente = paciente.Id;
            cita.IdDoctor = doctor.Id;
            cita.Motivo = vista.MotivoTextBox.Text;
           
            if (operacion == "Nuevo")
            {
                bool inserto = citaDAO.InsertarNuevaCita(cita);
                if (inserto)
                {
                    MessageBox.Show("Cita agregada correctamente");
                    DesabilitarControles();
                    LimpiarControles();
                    ListarCitas();
                }
                else
                {
                    MessageBox.Show("Cita no se pudo insertar");
                }
            }
        }

        private void Nuevo(object sender, EventArgs e)
        {
            operacion = "Nuevo";
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            vista.MotivoTextBox.Enabled = true;
            vista.DoctorTextBox.Enabled = true;
            vista.NombrePacienteTextBox.Enabled = true;
           
            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;

            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            vista.MotivoTextBox.Clear();
            vista.NombrePacienteTextBox.Clear();
            vista.DoctorTextBox.Clear();          
        }

        private void DesabilitarControles()
        {
            vista.MotivoTextBox.Enabled = false;
            vista.NombrePacienteTextBox.Enabled = false;
            vista.DoctorTextBox.Enabled = false;
            
            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;

            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
        }

        private void IdentidadTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                paciente = pacienteDAO.GetPacientePorIdentidad(vista.IdentidadTextBox.Text);
                vista.NombrePacienteTextBox.Text = paciente.Nombre;
            }
            else
            {
                paciente = null;

            }
        }

        private void CodigoTextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
               doctor = doctorDAO.GetDoctorPorCodigo(vista.CodigoTextBox.Text);
                vista.DoctorTextBox.Text = doctor.Nombre;
            }
            else
            {
                doctor = null;

            }
        }
    }
}
