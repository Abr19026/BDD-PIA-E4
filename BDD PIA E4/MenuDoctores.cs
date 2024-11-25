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
    public partial class MenuDoctores : Form
    {
        public MenuDoctores()
        {
            
            InitializeComponent();
            dataGridView1.DataSource = llenar_Grid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
        }

        public DataTable llenar_Grid()
        {
            Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from VistaDoctoresD";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "EXEC ValidarDoctorMed @EmpleadoID, @Cedula, @EspecialidadID ";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@EmpleadoID", textempleado_id.Text);
            cmdl.Parameters.AddWithValue("@Cedula", textcedula.Text);
            cmdl.Parameters.AddWithValue("@EspecialidadID", textespecialidad_id.Text);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textempleado_id.Text = dataGridView1.CurrentRow.Cells["Empleado_id"].Value.ToString();
                textcedula.Text = dataGridView1.CurrentRow.Cells["Cedula"].Value.ToString();
                textespecialidad_id.Text = dataGridView1.CurrentRow.Cells["Especialidad_id"].Value.ToString();
            }
            catch
            {

            }
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "update Doctores " +
                "set Empleado_Id = @Empleado_ID ,Cedula = @Cedula ,Especialidad_id = @Especialidad_id " +
                "where Empleado_Id = @Empleado_ID";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Empleado_ID", textempleado_id.Text);
            cmdl.Parameters.AddWithValue("@Cedula", textcedula.Text);
            cmdl.Parameters.AddWithValue("@Especialidad_id", textespecialidad_id.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "delete from  Doctores " +
                "where Empleado_Id= @Empleado_Id";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Empleado_Id", textempleado_id.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show(" Los datos fueron eliminados exitosamente");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = llenar_Grid();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

