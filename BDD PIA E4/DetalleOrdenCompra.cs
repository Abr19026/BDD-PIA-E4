using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BDD_PIA_E4;

namespace FaltanteInventarios
{
    public partial class DetalleOrdenCompra : Form
    {
        long orden;
        public DetalleOrdenCompra(long orden_id)
        {
            InitializeComponent();
            this.orden = orden_id;
        }

        private void DetalleOrdenCompra_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewOrdenDetalle.DataSource = llenar_Grid();
        }

        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = $"SELECT ocs.Orden_id, ocs.Insumo_id,cs.Descripcion ,ocs.Cantidad, ocs.Costo, ocs.IVA FROM OrdenCompra_Conceptos ocs INNER JOIN Catalogo_Insumos cs ON ocs.Insumo_id = cs.Insumo_id  WHERE orden_id = {this.orden}";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dataGridViewOrdenDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtInsumo.Text = dataGridViewOrdenDetalle.CurrentRow.Cells["Insumo_id"].Value.ToString();
            txtCantidad.Text = dataGridViewOrdenDetalle.CurrentRow.Cells["Cantidad"].Value.ToString();
            txtCosto.Text = dataGridViewOrdenDetalle.CurrentRow.Cells["Costo"].Value.ToString();
            txtIva.Text = dataGridViewOrdenDetalle.CurrentRow.Cells["IVA"].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into OrdenCompra_Conceptos(Orden_id, Insumo_id, Cantidad, Costo, IVA) values(@Orden_id, @Insumo_id, @Cantidad, @Costo, @IVA)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Orden_id", this.orden);
            cmdl.Parameters.AddWithValue("@Insumo_id", txtInsumo.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmdl.Parameters.AddWithValue("@Costo", txtCosto.Text);
            cmdl.Parameters.AddWithValue("@IVA", txtIva.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridViewOrdenDetalle.DataSource = llenar_Grid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE OrdenCompra_Conceptos SET Insumo_id = @Insumo_id, Cantidad = @Cantidad, Costo = @Costo, IVA = @IVA WHERE Insumo_id = @Insumo_ant AND Orden_id = @Orden_id";
            SqlCommand cmdl = new SqlCommand(actualizar, Conexion.Conectar());
            string insumoant;


            try
            {
                insumoant = this.dataGridViewOrdenDetalle.CurrentRow.Cells["Insumo_id"].Value.ToString();
            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningun elemento");
                return;
            }
            
            cmdl.Parameters.AddWithValue("@Insumo_id", txtInsumo.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            cmdl.Parameters.AddWithValue("@Costo", txtCosto.Text);
            cmdl.Parameters.AddWithValue("@IVA", txtIva.Text);
            cmdl.Parameters.AddWithValue("@Insumo_ant", insumoant);
            cmdl.Parameters.AddWithValue("@Orden_id", this.orden);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron modificados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridViewOrdenDetalle.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string Eliminar = "DELETE FROM OrdenCompra_Conceptos WHERE Insumo_id = @InsumoID AND Orden_id = @Orden_id";
            SqlCommand cmdl = new SqlCommand(Eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@InsumoID", txtInsumo.Text);
            cmdl.Parameters.AddWithValue("@Orden_id", this.orden);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron Eliminados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
            dataGridViewOrdenDetalle.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
