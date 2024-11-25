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
    public partial class OrdenCompra : Form
    {
        
        public OrdenCompra()
        {
            
            InitializeComponent();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "SELECT oc.Orden_id,oc.Proveedor_id,P.Nombre,oc.Fecha FROM OrdenCompra oc INNER JOIN Proveedores p on p.Proveedor_id = oc.Proveedor_id";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into OrdenCompra(Proveedor_id, Fecha) values(@Proveedor_id, @Fecha)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Proveedor_id", txtProvID.Text);
            cmdl.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Value);

            cmdl.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados exitosamente");
            dataGridViewOrd.DataSource = llenar_Grid();
        }

        private void OrdenCompra_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewOrd.DataSource = llenar_Grid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string Actualizar = "UPDATE OrdenCompra SET Proveedor_id = @Proveedor_id, Fecha = @Fecha WHERE Orden_id = @OrdenID";
            SqlCommand cmdl = new SqlCommand(Actualizar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@OrdenID", txtOrdID.Text);
            cmdl.Parameters.AddWithValue("@Proveedor_id", txtProvID.Text);
            cmdl.Parameters.AddWithValue("@Fecha", dateTimePickerFecha.Value);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron modificados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewOrd.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string Actualizar = "DELETE FROM OrdenCompra WHERE Orden_id = @OrdenID";
            SqlCommand cmdl = new SqlCommand(Actualizar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@OrdenID", txtOrdID.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron eliminados exitosamente");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridViewOrd.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewOrd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOrdID.Text = dataGridViewOrd.CurrentRow.Cells["Orden_id"].Value.ToString();
            txtProvID.Text = dataGridViewOrd.CurrentRow.Cells["Proveedor_id"].Value.ToString();
            dateTimePickerFecha.Value = (DateTime)dataGridViewOrd.CurrentRow.Cells["Fecha"].Value;
            
        }

        private void boton_detalle_ord_compra_Click(object sender, EventArgs e)
        {
            var sel_id = (long)dataGridViewOrd.CurrentRow.Cells[0].Value;
            var Formdetalle = new FaltanteInventarios.DetalleOrdenCompra(sel_id);
            Formdetalle.Show();
        }

    }
}
