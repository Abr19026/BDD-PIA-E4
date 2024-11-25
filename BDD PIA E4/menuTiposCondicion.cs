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
    public partial class menuTiposCondicion : Form
    {
        public menuTiposCondicion()
        {
            InitializeComponent();
            dataGridView1.DataSource = llenar_Grid();
        }

        private void menuTiposCondicion_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }
        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from TiposCondicion";
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
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into TiposCondicion(NombreCondicion) values(@Nombre)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@ID", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Nombre", textBox2.Text);

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
            string insertar = "update TiposCondicion " +
                "set  NombreCondicion = @Nombre " +
                "where TipoCondicion_id = @ID";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar()); 
            cmdl.Parameters.AddWithValue("@ID", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Nombre", textBox2.Text);

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
            string eliminar = "delete from TiposCondicion " +
                "where TipoCondicion_id = @ID";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@ID", textBox1.Text);
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
