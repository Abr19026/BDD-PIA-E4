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
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewProv.DataSource = llenar_Grid();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Proveedores";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Proveedores(Nombre, Telefono, Correo, Direccion) values(@Nombre, @Telefono, @Correo, @Direccion)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Nombre", txtNom.Text);
            cmdl.Parameters.AddWithValue("@Telefono", txtTel.Text);
            cmdl.Parameters.AddWithValue("@Correo", txtCor.Text);
            cmdl.Parameters.AddWithValue("@Direccion", txtDir.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewProv.DataSource = llenar_Grid();
        }

        private void dataGridViewProv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProvID.Text = dataGridViewProv.CurrentRow.Cells[0].Value.ToString();
            txtNom.Text = dataGridViewProv.CurrentRow.Cells[1].Value.ToString();
            txtTel.Text = dataGridViewProv.CurrentRow.Cells[2].Value.ToString();
            txtCor.Text = dataGridViewProv.CurrentRow.Cells[3].Value.ToString();
            txtDir.Text = dataGridViewProv.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string modificar = "UPDATE Proveedores SET Nombre = @Nombre, Telefono = @Telefono, Correo = @Correo, Direccion = @Direccion WHERE Proveedor_id = @ProveedorID";
            SqlCommand cmdl = new SqlCommand(modificar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@ProveedorID", txtProvID.Text);
            cmdl.Parameters.AddWithValue("@Nombre", txtNom.Text);
            cmdl.Parameters.AddWithValue("@Telefono", txtTel.Text);
            cmdl.Parameters.AddWithValue("@Correo", txtCor.Text);
            cmdl.Parameters.AddWithValue("@Direccion", txtDir.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron modificados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridViewProv.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string eliminar = "DELETE Proveedores WHERE Proveedor_id = @ProveedorID";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@ProveedorID", txtProvID.Text);
            cmdl.Parameters.AddWithValue("@Nombre", txtNom.Text);
            cmdl.Parameters.AddWithValue("@Telefono", txtTel.Text);
            cmdl.Parameters.AddWithValue("@Correo", txtCor.Text);
            cmdl.Parameters.AddWithValue("@Direccion", txtDir.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron eliminados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewProv.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == null)
            {
                MessageBox.Show("No se ha ingresado parametro de busqueda");
            }
            else
            {
                Conexion.Conectar();
                DataTable dt = new DataTable();
                string buscar = "select * FROM Proveedores WHERE Nombre LIKE '@Prov%' ";
                SqlCommand cmdl = new SqlCommand(buscar, Conexion.Conectar());
                cmdl.Parameters.AddWithValue("@Prov", txtBuscar.Text);
                cmdl.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmdl);

                da.Fill(dt);
                dataGridViewProv.DataSource = dt;
            }
        }
    }

}
