using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ClinicaDental2021.Vistas
{
    public partial class MenuView : Syncfusion.Windows.Forms.Office2010Form
    {
        public MenuView()
        {
            InitializeComponent();
        }

        UsuariosView users;
        PacienteView pacientes;
        DoctoresView doctores;
        FacturaView factura;
        CitasView citas;
        ConsultaView consultas;
        ServiciosView servicios;

        private void Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            users = null;
        }

        private void UsuariosToolStripButton_Click_1(object sender, EventArgs e)
        {
            if (users == null)
            {
                users = new UsuariosView();
                users.MdiParent = this;
                users.FormClosed += Users_FormClosed;
                users.Show();
            }
            else
            {
                users.Activate();
            }
        }

        private void Pacientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            pacientes = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (pacientes == null)
            {
                pacientes = new PacienteView();
                pacientes.MdiParent = this;
                pacientes.FormClosed += Pacientes_FormClosed;
                pacientes.Show();
            }
            else
            {
                pacientes.Activate();
            }
        }

        private void Doctores_FormClosed(object sender, FormClosedEventArgs e)
        {
            doctores = null;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (doctores == null)
            {
                doctores = new DoctoresView();
                doctores.MdiParent = this;
                doctores.FormClosed += Doctores_FormClosed;
                doctores.Show();
            }
            else
            {
                doctores.Activate();
            }
        }

        private void Facturas_FormClosed(object sender, FormClosedEventArgs e)
        {
            factura = null;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (factura == null)
            {
                factura = new FacturaView();
                factura.MdiParent = this;
                factura.FormClosed += Facturas_FormClosed;
                factura.Show();
            }
            else
            {
                factura.Activate();
            }
        }

        private void Citas_FormClosed(object sender, FormClosedEventArgs e)
        {
            citas = null;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (citas == null)
            {
                citas = new CitasView();
                citas.MdiParent = this;
                citas.FormClosed += Citas_FormClosed;
                citas.Show();
            }
            else
            {
                citas.Activate();
            }
        }

        private void Consultas_FormClosed(object sender, FormClosedEventArgs e)
        {
            consultas = null;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (consultas == null)
            {
                consultas = new ConsultaView();
                consultas.MdiParent = this;
                consultas.FormClosed += Consultas_FormClosed;
                consultas.Show();
            }
            else
            {
                consultas.Activate();
            }
        }

        private void Servicios_FormClosed(object sender, FormClosedEventArgs e)
        {
            servicios = null;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (servicios == null)
            {
                servicios = new ServiciosView();
                servicios.MdiParent = this;
                servicios.FormClosed += Servicios_FormClosed;
                servicios.Show();
            }
            else
            {
                servicios.Activate();
            }
        }
    }
}
