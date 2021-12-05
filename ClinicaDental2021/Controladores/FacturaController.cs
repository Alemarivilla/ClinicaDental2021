using ClinicaDental2021.Modelos.DAO;
using ClinicaDental2021.Modelos.Entidades;
using ClinicaDental2021.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaDental2021.Controladores
{
    public class FacturaController
    {
        FacturaView vista;
        PacienteDAO pacienteDAO = new PacienteDAO();
        Paciente paciente = new Paciente();
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        Servicio servicio = new Servicio();
        Usuario user = new Usuario();

        ServicioDAO servicioDAO = new ServicioDAO();
        decimal subTotal = 0;
        decimal isv = 0;
        decimal totalPagar = 0;
        FacturaDAO facturaDAO = new FacturaDAO();
        List<DetalleFactura> listaDetalleFactura = new List<DetalleFactura>();

        public FacturaController(FacturaView view)
        {
            vista = view;
            vista.IdentidadTextBox.KeyPress += IdentidadTextBox_KeyPress;
            vista.BuscarClienteButton.Click += BuscarPacienteButton_Click;
            vista.Load += Vista_Load;
            vista.CodigoServicioTextBox.KeyPress += CodigoServicioTextBox_KeyPress;
            vista.BuscarServicioButton.Click += BuscarServicioButton_Click;
            vista.CantidadTextBox.KeyPress += CantidadTextBox_KeyPress;
            vista.GuardarButton.Click += GuardarButton_Click;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Factura factura = new Factura();
            factura.Fecha = vista.dateTimePicker1.Value;
            factura.IdPaciente = paciente.Id;
            factura.IdUsuario = user.Id;
            factura.ISV = isv;
            factura.SubTotal = subTotal;
            factura.Descuento = Convert.ToDecimal(vista.DescuentoTextBox.Text);
            factura.Total = Convert.ToDecimal(vista.TotalTextBox.Text);

            bool inserto = facturaDAO.InsertarNuevaFactura(factura, listaDetalleFactura);
            if (inserto)
            {
                MessageBox.Show("Factura insertada correctamente");
            }
            else
            {
                MessageBox.Show("Error al insertar la factura");
            }
        }

        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(vista.CantidadTextBox.Text))
            {
                DetalleFactura detalle = new DetalleFactura();
                detalle.IdServicio = servicio.Id;
                detalle.Cantidad = Convert.ToInt32(vista.CantidadTextBox.Text);
                detalle.Precio = servicio.Precio;
                detalle.Total = Convert.ToInt32(vista.CantidadTextBox.Text) * servicio.Precio;

                subTotal += detalle.Total;
                isv = subTotal * 0.15M;
                totalPagar = subTotal + isv;

                listaDetalleFactura.Add(detalle);
                vista.DetalleDataGridView.DataSource = null;
                vista.DetalleDataGridView.DataSource = listaDetalleFactura;

                vista.SubTotalTextBox.Text = subTotal.ToString("N2");
                vista.ImpuestoTextBox.Text = isv.ToString("N2");
                vista.TotalTextBox.Text = totalPagar.ToString("N2");
            }
        }

        private void BuscarServicioButton_Click(object sender, EventArgs e)
        {
            BuscarServicioView form = new BuscarServicioView();
            form.ShowDialog();
            servicio = form._servicio;
            vista.CodigoServicioTextBox.Text = servicio.Codigo;
            vista.DescripcionServicioText.Text = servicio.Descripcion;
        }

        private void CodigoServicioTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                servicio = servicioDAO.GetServicioPorCodigo(vista.CodigoServicioTextBox.Text);
                vista.DescripcionServicioText.Text = servicio.Descripcion;
            }
            else
            {
                servicio = null;
            }
        }

        private void BuscarPacienteButton_Click(object sender, EventArgs e)
        {
            BuscarPacienteView form = new BuscarPacienteView();
            form.ShowDialog();
            paciente = form._paciente;
            vista.IdentidadTextBox.Text = paciente.Identidad;
            vista.NombrePacienteTextBox.Text = paciente.Nombre;
        }

        private void Vista_Load(object sender, EventArgs e)
        {

            //user = usuarioDAO.GetUsuarioPorEmail(Thread.CurrentPrincipal.Identity.Name);
            user = usuarioDAO.GetUsuarioPorEmail("alejandra.villatoro@gmail.com");
            vista.UsuarioTextBox.Text = user.Nombre;           
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

    }
}
