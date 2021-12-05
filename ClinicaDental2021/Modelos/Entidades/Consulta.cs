using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaDental2021.Modelos.Entidades
{
    public class Consulta
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public string Antecedentes { get; set; }
        public string Motivo { get; set; }
        public string Sintomas { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
        public int IdDoctor { get; set; }
    }
}
