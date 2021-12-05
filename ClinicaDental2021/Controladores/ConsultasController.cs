using ClinicaDental2021.Modelos.DAO;
using ClinicaDental2021.Modelos.Entidades;
using ClinicaDental2021.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaDental2021.Controladores
{
    public class ConsultasController
    {
        ConsultaView vista;
        ConsultaDAO consultaDAO = new ConsultaDAO();
        Consulta consulta = new Consulta();
        PacienteDAO pacienteDAO = new PacienteDAO();
        Paciente paciente = new Paciente();
        DoctorDAO doctorDAO = new DoctorDAO();
        Doctor doctor = new Doctor();
        string operacion = string.Empty;

        public ConsultasController(ConsultaView view)
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
            ListarConsultas();
        }

        private void ListarConsultas()
        {
            vista.ConsultasDataGridView.DataSource = consultaDAO.GetConsultas();
        }

        private void Guardar(object sender, EventArgs e)
        {

           
            consulta.IdPaciente = paciente.Id;
            consulta.IdDoctor = doctor.Id;
            consulta.Motivo = vista.MotivoTextBox.Text;
            consulta.Antecedentes = vista.AntecedentesTextBox.Text;
            consulta.Sintomas = vista.SintomasTextBox.Text;
            consulta.Diagnostico = vista.DiagnosticoTextBox.Text;
            consulta.Tratamiento = vista.TratamientoTextBox.Text;

            if (operacion == "Nuevo")
            {
                bool inserto = consultaDAO.InsertarNuevaConsulta(consulta);
                if (inserto)
                {
                    MessageBox.Show("Consulta agregada correctamente");
                    DesabilitarControles();
                    LimpiarControles();
                    ListarConsultas();
                }
                else
                {
                    MessageBox.Show("Consulta no se pudo insertar");
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
            vista.AntecedentesTextBox.Enabled = true;
            vista.SintomasTextBox.Enabled = true;
            vista.DiagnosticoTextBox.Enabled = true;
            vista.TratamientoTextBox.Enabled = true;
            vista.DoctorTextBox.Enabled = true;
            vista.PacienteTextBox.Enabled = true;

            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;

            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            vista.MotivoTextBox.Clear();
            vista.PacienteTextBox.Clear();
            vista.AntecedentesTextBox.Clear();
            vista.SintomasTextBox.Clear();
            vista.DiagnosticoTextBox.Clear();
            vista.TratamientoTextBox.Clear();
            vista.DoctorTextBox.Clear();
        }

        private void DesabilitarControles()
        {
            vista.MotivoTextBox.Enabled = false;
            vista.PacienteTextBox.Enabled = false;
            vista.DoctorTextBox.Enabled = false;
            vista.AntecedentesTextBox.Enabled = false;
            vista.SintomasTextBox.Enabled = false;
            vista.DiagnosticoTextBox.Enabled = false;
            vista.TratamientoTextBox.Enabled = false;
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
                vista.PacienteTextBox.Text = paciente.Nombre;
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
