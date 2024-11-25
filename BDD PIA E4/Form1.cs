using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDD_PIA_E4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();


            SqlCommand cmd = new SqlCommand("Select NivelAcceso from Acceso_Empleado Where Usuario = @Usuario AND Pass = @Password", Conexion.Conectar());
            cmd.Parameters.AddWithValue("@Usuario", txtUsr.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text);
            try
            {
                if (cmd.ExecuteScalar() == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }
                else
                {
                    int Acceso = (int)cmd.ExecuteScalar();
                    SqlCommand cmd2 = new SqlCommand("Select Empleado_id from Acceso_Empleado Where Usuario = @Usuario AND Pass = @Password", Conexion.Conectar());
                    cmd2.Parameters.AddWithValue("@Usuario", txtUsr.Text);
                    cmd2.Parameters.AddWithValue("@Password", txtPass.Text);

                    long UsuarioID = (long)cmd2.ExecuteScalar();

                    //MessageBox.Show("El valor de la variable existe es: " + Acceso);
                    //MessageBox.Show("El valor de la variabl ID Usuario es: " + UsuarioID);

                    if (Acceso <= 5 && Acceso >= 0)
                    {
                        MessageBox.Show("Se ha iniciado sesion correctamente");
                        MenuP Men = new MenuP(Acceso, UsuarioID);
                        this.Hide();
                        Men.Show();
                    }
                    else
                        MessageBox.Show("No se pudo iniciar sesion correctamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
 }

