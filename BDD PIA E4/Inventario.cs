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
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
        }

        private void Inventario_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            dataGridViewInv.DataSource = llenar_Grid();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Inventario";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Inventario(Insumo_id, Cantidad, Orden_id, Caducidad) values(@Inusmo_id, @Cantidad, @Orden_id, @Caducidad)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Inusmo_id", txtInsumoID.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCant.Text);
            cmdl.Parameters.AddWithValue("@Orden_id", txtOrdenID.Text);
            cmdl.Parameters.AddWithValue("@Caducidad", dateTimePickerCad.Value);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewInv.DataSource = llenar_Grid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE Inventario SET Insumo_id = @Inusmo_id, Cantidad = @Cantidad, Orden_id = @Orden_id, Caducidad = @Caducidad WHERE Lote_id = @LoteID";
            SqlCommand cmdl = new SqlCommand(actualizar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@LoteID", txtLoteID.Text);
            cmdl.Parameters.AddWithValue("@Inusmo_id", txtInsumoID.Text);
            cmdl.Parameters.AddWithValue("@Cantidad", txtCant.Text);
            cmdl.Parameters.AddWithValue("@Orden_id", txtOrdenID.Text);
            cmdl.Parameters.AddWithValue("@Caducidad", dateTimePickerCad.Value);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron modificados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridViewInv.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "DELETE Inventario WHERE Lote_id = @LoteID";
            SqlCommand cmdl = new SqlCommand(actualizar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@LoteID", txtLoteID.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron eliminados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridViewInv.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridViewInv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtLoteID.Text = dataGridViewInv.CurrentRow.Cells[0].Value.ToString();
            txtInsumoID.Text = dataGridViewInv.CurrentRow.Cells[1].Value.ToString();
            txtCant.Text = dataGridViewInv.CurrentRow.Cells[2].Value.ToString();
            txtOrdenID.Text = dataGridViewInv.CurrentRow.Cells[3].Value.ToString();
            dateTimePickerCad.Value = (DateTime)dataGridViewInv.CurrentRow.Cells[4].Value;
        }

    }
}
