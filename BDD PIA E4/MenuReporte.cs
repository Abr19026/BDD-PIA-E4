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

namespace CshaepBDD
{
    public partial class MenuReporte : Form
    {
        public MenuReporte()
        {
            InitializeComponent();

            dataGridView1.DataSource = llenar_Grid();
        }

        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Reporte";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        private void MenuReporte_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox4.Text = ((DateTime)dataGridView1.CurrentRow.Cells[4].Value).ToString("yyyy-MM-dd");
                textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            }
            catch
            {

            }
        }

        private void addRepBtn_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Reporte(Cita_id,Empleado_id,Paciente_id,Fecha,Diagnostico,Altura,Peso) values(@CitaID,@EmpleadoID,@PacienteID,@Fecha,@Diagnostico,@Altura,@Peso)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@ReporteID", textBox1.Text);
            cmdl.Parameters.AddWithValue("@CitaID", textBox6.Text);
            cmdl.Parameters.AddWithValue("@EmpleadoID", textBox2.Text);
            cmdl.Parameters.AddWithValue("@PacienteID", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Fecha", textBox4.Text);
            cmdl.Parameters.AddWithValue("@Diagnostico", textBox5.Text);
            cmdl.Parameters.AddWithValue("@Altura", textBox7.Text);
            cmdl.Parameters.AddWithValue("@Peso", textBox8.Text);
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

        private void deleteRepBtn_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "delete from Reporte " +
                "where Reporte_id = @ReporteID";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@ReporteID", textBox1.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show(" El Reporte fue eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = llenar_Grid();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
