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
    public partial class menuEspecialiad_servicio : Form
    {
        public menuEspecialiad_servicio()
        {
            InitializeComponent();
            dataGridView1.DataSource = llenar_Grid();
        }

        private void menuEspecialiad_servicio_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from VistaEspecialidadServicio";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textespecialidad_id.Text = dataGridView1.CurrentRow.Cells["Especialidad_id"].Value.ToString();
                texttiposervicio_id.Text = dataGridView1.CurrentRow.Cells["TipoServicio_id"].Value.ToString();
                textprioridad.Text = dataGridView1.CurrentRow.Cells["Prioridad"].Value.ToString();
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Especialidad_Servicio(Especialidad_id, TipoServicio_id, Prioridad) values(@Especialidad_id, @Servicio_id, @Prioridad)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Especialidad_id", textespecialidad_id.Text);
            cmdl.Parameters.AddWithValue("@Servicio_id", texttiposervicio_id.Text);
            cmdl.Parameters.AddWithValue("@Prioridad", textprioridad.Text);

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
            string insertar = "update Especialidad_Servicio " +
                "set Especialidad_id = @Especialidad_id , TipoServicio_id = @Servicio_id , Prioridad = @Prioridad " +
                "where Especialidad_id = @Especialidad_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Especialidad_id", textespecialidad_id.Text);
            cmdl.Parameters.AddWithValue("@Servicio_id", texttiposervicio_id.Text);
            cmdl.Parameters.AddWithValue("@Prioridad", textprioridad.Text);

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
            string eliminar = "delete from Especialidad_Servicio " +
                 "where Especialidad_id = @Especialidad_id";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Especialidad_id", textespecialidad_id.Text);
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
