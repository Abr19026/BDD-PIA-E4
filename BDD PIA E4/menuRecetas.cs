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

namespace BDD_PIA_E4
{
    public partial class menuRecetas : Form
    {
        public menuRecetas()
        {
            InitializeComponent();
            dataGridView1.DataSource = llenar_Grid();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from RecetaVista";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textreporte_id.Text = dataGridView1.CurrentRow.Cells["Reporte_id"].Value.ToString();
                textmedicamento_id.Text = dataGridView1.CurrentRow.Cells["Medicamento_id"].Value.ToString();
                textcantidad.Text = dataGridView1.CurrentRow.Cells["Dosis"].Value.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Receta_Conceptos(Reporte_id,Medicamento_id,Cantidad) values(@Reporte_id, @Medicamento_id , @Cantidad)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Reporte_id", textreporte_id.Text);
            cmdl.Parameters.AddWithValue("@Medicamento_id", textmedicamento_id.Text);
            cmdl.Parameters.Add("@Cantidad", SqlDbType.Money).Value = Decimal.Parse(textcantidad.Text);

            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron agregados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            dataGridView1.DataSource = llenar_Grid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "update Receta_conceptos " +
                "set Medicamento_id = @Medicamento_id , Cantidad = @Cantidad " +
                "where Reporte_id = @Reporte_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar()); 
            cmdl.Parameters.AddWithValue("@Reporte_id", textreporte_id.Text);
            cmdl.Parameters.AddWithValue("@Medicamento_id", textmedicamento_id.Text);
            cmdl.Parameters.Add("@Cantidad", SqlDbType.Money).Value = Decimal.Parse(textcantidad.Text);

            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron editados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            dataGridView1.DataSource = llenar_Grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "delete from Receta_conceptos " +
               "where Reporte_id = @Reporte_id";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Reporte_id", textreporte_id.Text);
            cmdl.Parameters.AddWithValue("@Medicamento_id", textmedicamento_id.Text);
            cmdl.Parameters.Add("@Cantidad", SqlDbType.Money).Value = Decimal.Parse(textcantidad.Text);

            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron eliminados exitosamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            dataGridView1.DataSource = llenar_Grid();
        }

        private void menuRecetas_Load(object sender, EventArgs e)
        {

        }
    }
}
