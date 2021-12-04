using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDental2021.Modelos.Entidades
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Especialidad { get; set; }
        public int IdUsuario { get; set; }
        public byte[] Foto { get; set; }
    }
}
