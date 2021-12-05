using ClinicaDental2021.Controladores;
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
    public partial class CitasView : Form
    {
        public CitasView()
        {
            InitializeComponent();
            CitasController controller = new CitasController(this);
        }
    }
}
