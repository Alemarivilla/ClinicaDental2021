using ClinicaDental2021.Modelos.DAO;
using ClinicaDental2021.Modelos.Entidades;
using ClinicaDental2021.Vistas;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace ClinicaDental2021.Controladores
{
    public class DoctoresController
    {
        DoctoresView vista;
        DoctorDAO clienteDAO = new DoctorDAO();
        Doctor doctor = new Doctor();
        string operacion = string.Empty;

        public DoctoresController(DoctoresView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.ImagenButton.Click += new EventHandler(CargarImagen);
            vista.Load += new EventHandler(Load);          
            vista.EliminarButton.Click += new EventHandler(Eliminar);
        }

        private void Eliminar(object sender, EventArgs e)
        {
            if (vista.DoctoresDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = clienteDAO.EliminarDoctor(Convert.ToInt32(vista.DoctoresDataGridView.CurrentRow.Cells[0].Value));
                if (elimino)
                {
                    MessageBox.Show("Cliente eliminado correctamente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListarDoctores();
                }
                else
                {
                    MessageBox.Show("Cliente no se pudo eliminar", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Load(object sender, EventArgs e)
        {
            ListarDoctores();
        }

        private void ListarDoctores()
        {
            vista.DoctoresDataGridView.DataSource = clienteDAO.GetDoctores();
        }

        private void CargarImagen(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                vista.ImagenPictureBox.Image = Image.FromFile(dialog.FileName);
            }

        }

        private void Guardar(object sender, EventArgs e)
        {
            
            if (vista.NombreTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.NombreTextBox, "Ingrese un nombre");
                vista.NombreTextBox.Focus();
                return;
            }
            if (vista.TelefonoTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.TelefonoTextBox, "Ingrese un telefono");
                vista.TelefonoTextBox.Focus();
                return;
            }
            if (vista.EspecialidadTextBox.Text == "")
            {
                vista.errorProvider1.SetError(vista.EspecialidadTextBox, "Ingrese una especialidad");
                vista.EspecialidadTextBox.Focus();
                return;
            }

            doctor.Codigo = vista.CodigoTextBox.Text;
            doctor.Nombre = vista.NombreTextBox.Text;
            doctor.Telefono = vista.TelefonoTextBox.Text;
            doctor.Especialidad = vista.EspecialidadTextBox.Text;
            

            if (vista.ImagenPictureBox.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                vista.ImagenPictureBox.Image.Save(ms, ImageFormat.Jpeg);
                doctor.Foto = ms.GetBuffer();
            }

            if (operacion == "Nuevo")
            {
                bool inserto = clienteDAO.InsertarNuevoDoctor(doctor);
                if (inserto)
                {
                    MessageBox.Show("Doctor insertado correctamente");
                    DesabilitarControles();
                    LimpiarControles();
                    ListarDoctores();
                }
                else
                {
                    MessageBox.Show("Doctor no se pudo insertar");
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
            
            vista.NombreTextBox.Enabled = true;
            vista.EspecialidadTextBox.Enabled = true;
            vista.TelefonoTextBox.Enabled = true;
            vista.CodigoTextBox.Enabled = true;
            vista.ImagenPictureBox.Enabled = true;
            vista.ImagenButton.Enabled = true;
            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;

            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void LimpiarControles()
        {          
            vista.NombreTextBox.Clear();
            vista.CodigoTextBox.Clear();
            vista.EspecialidadTextBox.Clear();
            vista.TelefonoTextBox.Clear();
            vista.ImagenPictureBox.Image = null;
            vista.IdTextBox.Clear();
        }

        private void DesabilitarControles()
        {
            vista.NombreTextBox.Enabled = false;
            vista.CodigoTextBox.Enabled = false;
            vista.EspecialidadTextBox.Enabled = false;
            vista.TelefonoTextBox.Enabled = false;

            vista.ImagenPictureBox.Enabled = false;
            vista.ImagenButton.Enabled = false;
            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
        }
    }
}
