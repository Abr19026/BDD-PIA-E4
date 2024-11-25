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
using BDD_PIA_E4;


namespace FaltanteInventarios
{
    public partial class InsumoProveedor : Form
    {
        public InsumoProveedor()
        {
            InitializeComponent();
        }

        private void InsumoProveedor_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewInsumoProv.DataSource = llenar_Grid();
        }

        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Insumo_Proveedor";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dataGridViewInsumoProv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtInsumo.Text = dataGridViewInsumoProv.CurrentRow.Cells[0].Value.ToString();
            txtProv.Text = dataGridViewInsumoProv.CurrentRow.Cells[1].Value.ToString();
            txtCantidad.Text = dataGridViewInsumoProv.CurrentRow.Cells[2].Value.ToString();
            txtPreci.Text = dataGridViewInsumoProv.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Insumo_Proveedor(Insumo_id, Proveedor_id, Cantidad, Precio) values(@Insumo_id, @Proveedor_id, @Cantidad, @Precio)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Insumo_id", txtInsumo.Text);
            cmdl.Parameters.AddWithValue("@Proveedor_id", txtProv.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmdl.Parameters.AddWithValue("@Precio", txtPreci.Text); 
            try 
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            dataGridViewInsumoProv.DataSource = llenar_Grid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "UPDATE Insumo_Proveedor SET Insumo_id = @Insumo_id, Proveedor_id = @Proveedor_id, Cantidad = @Cantidad, Precio = @Precio WHERE Insumo_id = @Insumo_id AND Proveedor_id = @Proveedor_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Insumo_id", txtInsumo.Text);
            cmdl.Parameters.AddWithValue("@Proveedor_id", txtProv.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmdl.Parameters.AddWithValue("@Precio", txtPreci.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron actualizados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridViewInsumoProv.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "DELETE Insumo_Proveedor WHERE Insumo_id = @Insumo_id AND Proveedor_id = @Proveedor_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Insumo_id", txtInsumo.Text);
            cmdl.Parameters.AddWithValue("@Proveedor_id", txtProv.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron eliminados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewInsumoProv.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
