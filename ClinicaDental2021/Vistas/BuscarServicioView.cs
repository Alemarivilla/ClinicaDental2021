using ClinicaDental2021.Modelos.DAO;
using ClinicaDental2021.Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicaDental2021.Vistas
{
    public partial class BuscarServicioView : Form
    {
        public BuscarServicioView()
        {
            InitializeComponent();
        }
        ServicioDAO servicioDAO = new ServicioDAO();
        public Servicio _servicio = new Servicio();

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            if (ServiciosDataGridView.RowCount > 0)
            {
                if (ServiciosDataGridView.SelectedRows.Count > 0)
                {
                    _servicio.Id = (int)ServiciosDataGridView.CurrentRow.Cells["ID"].Value;
                    _servicio.Codigo = (string)ServiciosDataGridView.CurrentRow.Cells["CODIGO"].Value;
                    _servicio.Descripcion = (string)ServiciosDataGridView.CurrentRow.Cells["DESCRIPCION"].Value;                   
                    _servicio.Precio = (decimal)ServiciosDataGridView.CurrentRow.Cells["PRECIO"].Value;
                    this.Close();
                }
            }
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BuscarServicioView_Load(object sender, EventArgs e)
        {
            ServiciosDataGridView.DataSource = servicioDAO.GetServicios();
        }

        private void NombreServicioTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            ServiciosDataGridView.DataSource = servicioDAO.GetServiciosPorDescripcion(NombreServicioTextBox.Text);
        }

    }
}
