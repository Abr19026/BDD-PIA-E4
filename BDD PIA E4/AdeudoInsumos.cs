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
    public partial class AdeudoInsumos : Form
    {
        public AdeudoInsumos()
        {
            InitializeComponent();
        }

        private void AdeudoInsumos_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewAdIns.DataSource = llenar_Grid();
        }

        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from VInsumos";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dataGridViewAdIns_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtAdeudo.Text = dataGridViewAdIns.CurrentRow.Cells["Adeudo_id"].Value.ToString();
            txtLote.Text = dataGridViewAdIns.CurrentRow.Cells["Lote_id"].Value.ToString();
            txtCantidad.Text = dataGridViewAdIns.CurrentRow.Cells["Cantidad"].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Adeudo_Insumos(Adeudo_id, Lote_id, Cantidad) values(@Adeudo_id, @Lote_id, @Cantidad)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Adeudo_id", txtAdeudo.Text);
            cmdl.Parameters.AddWithValue("@Lote_id", txtLote.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            string obtenerInv = "Select Cantidad FROM Inventario WHERE Lote_id = @LoteID";

            SqlCommand cmoi = new SqlCommand(obtenerInv, Conexion.Conectar());
            cmoi.Parameters.AddWithValue("@LoteID", txtLote.Text);
            double total = (double)cmoi.ExecuteScalar();
            int reducir = Convert.ToInt32(txtCantidad.Text);
            if (total < reducir)
            {
                MessageBox.Show("Error: No hay cantidad necesaria en el inventario para completar la operacion");
            }
            else
            {
                try { 
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados exitosamente");
                string actualizar = "EXEC ActualizarInventario @Lote_id, @Adeudo_id";
                SqlCommand actualizarInv = new SqlCommand(actualizar, Conexion.Conectar());
                actualizarInv.Parameters.AddWithValue("@Adeudo_id", txtAdeudo.Text);
                actualizarInv.Parameters.AddWithValue("@Lote_id", txtLote.Text);
                actualizarInv.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            dataGridViewAdIns.DataSource = llenar_Grid();
        }
            
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "UPDATE Adeudo_Insumos SET Adeudo_id = @Adeudo_id, Lote_id = @Lote_id, Cantidad = @Cantidad WHERE Adeudo_id = @Adeudo_id AND Lote_id = @Lote_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Adeudo_id", txtAdeudo.Text);
            cmdl.Parameters.AddWithValue("@Lote_id", txtLote.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCantidad.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron actualizados exitosamente");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewAdIns.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "DELETE FROM Adeudo_Insumos WHERE Adeudo_id = @Adeudo_id AND Lote_id = @Lote_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());

            cmdl.Parameters.AddWithValue("@Adeudo_id", txtAdeudo.Text);
            cmdl.Parameters.AddWithValue("@Lote_id", txtLote.Text);
            
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron eliminados exitosamente"); 
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewAdIns.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
