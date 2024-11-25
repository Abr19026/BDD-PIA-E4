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
    public partial class InventariosCatalogo : Form
    {
        public InventariosCatalogo()
        {
            InitializeComponent();
        }

        private void InventariosCatalogo_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            
            dataGridViewInvCat.DataSource = llenar_Grid();
        }

        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Catalogo_Insumos";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Catalogo_Insumos(Descripcion) values(@Descripcion)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Descripcion", txtDes.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridViewInvCat.DataSource = llenar_Grid();
        }

        private void dataGridViewInvCat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtInsumoID.Text = dataGridViewInvCat.CurrentRow.Cells[0].Value.ToString();
            txtDes.Text = dataGridViewInvCat.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE Catalogo_Insumos SET Descripcion = @Descripcion WHERE Insumo_id = @InsumoID";
            SqlCommand cmdl = new SqlCommand(actualizar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@InsumoID", txtInsumoID.Text);
            cmdl.Parameters.AddWithValue("@Descripcion", txtDes.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron modificados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridViewInvCat.DataSource = llenar_Grid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string Eliminar = "DELETE FROM Catalogo_Insumos WHERE Insumo_id = @InsumoID";
            SqlCommand cmdl = new SqlCommand(Eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@InsumoID", txtInsumoID.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron Eliminados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            dataGridViewInvCat.DataSource = llenar_Grid();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
