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
    public class ServiciosController
    {
        ServiciosView vista;
        ServicioDAO servicioDAO = new ServicioDAO();
        Servicio servicio = new Servicio();
        string operacion = string.Empty;

        public ServiciosController(ServiciosView view)
        {
            vista = view;
            vista.NuevoButton.Click += new EventHandler(Nuevo);
            vista.GuardarButton.Click += new EventHandler(Guardar);
            vista.Load += new EventHandler(Load);
           
        }

        private void Load(object sender, EventArgs e)
        {
            ListarServicios();
        }

        private void ListarServicios()
        {
            vista.ServiciosDataGridView.DataSource = servicioDAO.GetServicios();
        }

        private void Nuevo(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void Guardar(object sender, EventArgs e)
        {
           
          
           
            servicio.Codigo = vista.CodigoTextBox.Text;
            servicio.Descripcion = vista.DescripcionTextBox.Text;
            servicio.Precio = decimal.Parse(vista.ValorTextBox.Text);
            

            if (operacion == "Nuevo")
            {
                bool inserto = servicioDAO.InsertarNuevoServicio(servicio);

                if (inserto)
                {
                    MessageBox.Show("Servicio creado correctamente", "Atención",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarControles();
                    DesabilitarControles();
                    ListarServicios();
                }
                else
                {
                    MessageBox.Show("Error al crear el servicio", "Atención",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                      
        }

        private void HabilitarControles()
        {
            vista.CodigoTextBox.Enabled = true;
            vista.DescripcionTextBox.Enabled = true;
            vista.ValorTextBox.Enabled = true;
            
            vista.GuardarButton.Enabled = true;
            vista.CancelarButton.Enabled = true;
            vista.ModificarButton.Enabled = false;
            vista.NuevoButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            vista.CodigoTextBox.Clear();
            vista.DescripcionTextBox.Clear();
            vista.ValorTextBox.Clear();            
        }

        private void DesabilitarControles()
        {
            vista.CodigoTextBox.Enabled = false;
            vista.DescripcionTextBox.Enabled = false;
            vista.ValorTextBox.Enabled = false;
           
            vista.GuardarButton.Enabled = false;
            vista.CancelarButton.Enabled = false;
            vista.ModificarButton.Enabled = true;
            vista.NuevoButton.Enabled = true;
        }
    }
}
