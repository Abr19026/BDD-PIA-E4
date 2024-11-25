using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CshaepBDD;
using Consultas;
using FaltanteInventarios;

namespace BDD_PIA_E4
{
    public partial class MenuP : Form
    {
        int Acceso;
        long Empleado;
        public MenuP(int NivelAcceso, long UsuarioID)
        {
            Acceso = NivelAcceso;
            Empleado = UsuarioID;
            InitializeComponent();
        }

        private void Diseno()
        {
            panelCitasSub.Visible = false;
            panelEmpleadosSub.Visible = false;
            panelInventariosSub.Visible = false;
            panelPacientesSub.Visible = false;
            panelReporteSub.Visible = false;

        }

        private void OcultarSubMenu()
        {
            if (panelCitasSub.Visible == true)
                panelCitasSub.Visible = false;

            if (panelEmpleadosSub.Visible == true)
                panelEmpleadosSub.Visible = false;

            if (panelInventariosSub.Visible == true)
                panelInventariosSub.Visible = false;

            if (panelPacientesSub.Visible == true)
                panelPacientesSub.Visible = false;

            if (panelReporteSub.Visible == true)
                panelReporteSub.Visible = false;

        }

        private void MostrarSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                OcultarSubMenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }

        private void MenuP_Load(object sender, EventArgs e)
        {
            OcultarSubMenu();
        }

        #region Desplegar sub menus
        private void btnCitas_Click(object sender, EventArgs e)
        {
            if (Acceso == 5 || Acceso == 1 || Acceso == 4 || Acceso == 3)
            {
                MostrarSubMenu(panelCitasSub);
            }
            else
            {
                MessageBox.Show("No tiene acceso a esta opcion");
            }
        }

        private void btnPac_Click(object sender, EventArgs e)
        {
            if (Acceso == 5 || Acceso == 3)
            {
                MostrarSubMenu(panelPacientesSub);
            }
            else
            {
                MessageBox.Show("No tiene acceso a esta opcion");
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (Acceso == 5 || Acceso == 3 || Acceso ==1)
            {
                MostrarSubMenu(panelReporteSub);
            }
            else
            {
                MessageBox.Show("No tiene acceso a esta opcion");
            }
            
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            if (Acceso == 5 || Acceso == 4)
            {
                MostrarSubMenu(panelEmpleadosSub);
            }
            else
            {
                MessageBox.Show("No tiene acceso a esta opcion");
            }
            
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            if (Acceso == 5 || Acceso == 2)
            {
                MostrarSubMenu(panelInventariosSub);
            }
            else
            {
                MessageBox.Show("No tiene acceso a esta opcion");
            }
        }
        #endregion

        #region Mostrar forms

        private Form FormActivo = null;
        private void Mostrarform(Form FormMostrado)
        {
            if(FormActivo != null)
                FormActivo.Close();
            FormActivo = FormMostrado;
            FormMostrado.TopLevel = false;
            FormMostrado.FormBorderStyle = FormBorderStyle.None;
            FormMostrado.Dock = DockStyle.Fill;
            panelForms.Controls.Add(FormMostrado);
            panelForms.Tag = FormMostrado;
            FormMostrado.BringToFront();
            FormMostrado.Show();
        }
        #endregion

        
        private void button4_Click(object sender, EventArgs e)
        {
                Mostrarform(new InventariosCatalogo());
        }

        private void button8_Click(object sender, EventArgs e)
        {
                Mostrarform(new Proveedores());
        }

        private void button9_Click(object sender, EventArgs e)
        {
                Mostrarform(new OrdenCompra());
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Mostrarform(new Inventario());
        }

        private void panelForms_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mostrarform(new MenuDoctores());
        }

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            Mostrarform(new MenuPacientes());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mostrarform(new MenuPuestos());
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Mostrarform(new MenuEmpleados());
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Mostrarform(new CitasRecepcion(Empleado));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Mostrarform(new InsumoProveedor());
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Mostrarform(new AdeudoInsumos());
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Mostrarform(new MenuMedicamentos());
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Mostrarform(new MenuPago());
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Mostrarform(new MenuAdeudos());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mostrarform(new MenuReporte());
        }

        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            Mostrarform(new menuTiposCondicion());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Mostrarform(new menuObservaciones());
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Mostrarform(new menuRecetas());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Mostrarform(new menuEspecialidad());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Mostrarform(new menuEspecialiad_servicio());
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Mostrarform(new menuServicios());
        }

        private void btnModificarP_Click(object sender, EventArgs e)
        {

        }

        private void MenuP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
