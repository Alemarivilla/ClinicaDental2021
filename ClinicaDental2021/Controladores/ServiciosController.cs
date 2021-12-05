using ClinicaDental2021.Modelos.DAO;
using ClinicaDental2021.Modelos.Entidades;
using ClinicaDental2021.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
