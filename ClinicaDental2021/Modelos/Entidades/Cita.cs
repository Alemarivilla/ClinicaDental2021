using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDental2021.Modelos.Entidades
{
    public class Cita
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
       
        public int IdPaciente { get; set; }
        public int IdDoctor { get; set; }
        public string Motivo { get; set; }
    }
}
