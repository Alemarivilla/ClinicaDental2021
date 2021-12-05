using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDental2021.Modelos.Entidades
{
    public class Servicio
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }      
        public decimal Precio { get; set; }
    }
}
