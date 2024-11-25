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
    public partial class menuCondicion_pac : Form
    {
        private string curp_pac; 
        public menuCondicion_pac(string CURP_PAC)
        {
            InitializeComponent();
            this.curp_pac = CURP_PAC;
            dataGridView1.DataSource = llenar_Grid();
        }

        private void menuCondicion_pac_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = $"select * from VerCondicionPac WHERE paciente_id = '{this.curp_pac}'";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = ((DateTime)dataGridView1.CurrentRow.Cells[2].Value).ToString("yyyy-MM-dd");
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Condicion_Pac(Descripcion,FechaInicio, TipoCondicion_id, Paciente_id) values(@Descripcion, @Fecha, @Condicion, @Paciente_id)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Descripcion", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Fecha", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Condicion", textBox4.Text);
            cmdl.Parameters.AddWithValue("@Paciente_id", textBox5.Text);

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
            string insertar = "update Condicion_Pac " +
                "set Descripcion = @Descripcion , FechaInicio = @Fecha , TipoCondicion_id = @Condicion, Paciente_id = @Paciente_id " +
                "where Condicion_id = @Condicion_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Condicion_id", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Descripcion", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Fecha", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Condicion", textBox4.Text);
            cmdl.Parameters.AddWithValue("@Paciente_id", textBox5.Text);

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
            string eliminar = "delete from Condicion_Pac " +
                "where Condicion_id = @Condicion_id";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Condicion_id", textBox1.Text);
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
    }
}
