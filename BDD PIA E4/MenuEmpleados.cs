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
    public partial class MenuEmpleados : Form
    {
        public MenuEmpleados()
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
            string consulta = "select * from Empleados";
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
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox13.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox12.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                textBox11.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                textBox17.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                textBox16.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
                textBox15.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
                textBox14.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
                textBox8.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
                textBox6.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            }
            catch
            {

            }
        }

        private void agregarEmpleadoBtn_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Empleados(Usuario,Pass,Nombre,Apellidos,FechaNacimiento,FechaContratado,Salario,Telefono,CodigoPostal,Calle,NumeroExterior,NumeroInterior,Puesto_id,CURP,HoraEntrada,HoraSalida) " +
                "values(@Usuario,@Password,@Nombre,@Apellido,@FechaNacimiento,@FechaContratado,@Salario,@Telefono,@CodigoPostal,@Calle,@NumeroExterior,@NumeroInterior,@PuestoID,@CURP,@HoraEntrada,@HoraSalida)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            //cmdl.Parameters.AddWithValue("@EmpleadoID", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Usuario", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Password", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Nombre", textBox4.Text);
            cmdl.Parameters.AddWithValue("@Apellido", textBox5.Text);
            cmdl.Parameters.AddWithValue("@FechaNacimiento", textBox13.Text);
            cmdl.Parameters.AddWithValue("@FechaContratado", textBox12.Text);
            cmdl.Parameters.Add("@Salario", SqlDbType.Money).Value = Decimal.Parse(textBox11.Text);
            cmdl.Parameters.AddWithValue("@Telefono", textBox10.Text);
            cmdl.Parameters.AddWithValue("@CodigoPostal", textBox9.Text);
            cmdl.Parameters.AddWithValue("@Calle", textBox17.Text);
            cmdl.Parameters.AddWithValue("@NumeroExterior", textBox16.Text);
            cmdl.Parameters.AddWithValue("@NumeroInterior", textBox15.Text);
            cmdl.Parameters.AddWithValue("@PuestoID", textBox14.Text);
            cmdl.Parameters.AddWithValue("@CURP", textBox8.Text);
            cmdl.Parameters.AddWithValue("@HoraEntrada", textBox7.Text);
            cmdl.Parameters.AddWithValue("@HoraSalida", textBox6.Text);
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

        private void editEmpleadoBtn_Click(object sender, EventArgs e)
        {
            //(Usuario,Pass,Nombre,Apellidos,FechaNacimiento,FechaContratado,Salario,Telefono,CodigoPostal,Calle,NumeroExterior,NumeroInterior,Puesto_id,CURP,HoraEntrada,HoraSalida)
            Conexion.Conectar();
            string insertar = "update Empleados " +
                "set Usuario = @Usuario ,Pass = @Password ,Nombre = @Nombre, Apellidos = @Apellido, FechaNacimiento = @FechaNacimiento, FechaContratado = @FechaContratado, Salario = @Salario, Telefono = @Telefono, CodigoPostal = @CodigoPostal, " +
                "Calle = @Calle, NumeroExterior = @NumeroExterior, NumeroInterior = @NumeroInterior, Puesto_id = @PuestoID, CURP = @CURP, HoraEntrada = @HoraEntrada, HoraSalida = @HoraSalida " +
                "where Empleado_id = @EmpleadoID";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@EmpleadoID", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Usuario", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Password", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Nombre", textBox4.Text);
            cmdl.Parameters.AddWithValue("@Apellido", textBox5.Text);
            cmdl.Parameters.AddWithValue("@FechaNacimiento", textBox13.Text);
            cmdl.Parameters.AddWithValue("@FechaContratado", textBox12.Text);
            cmdl.Parameters.Add("@Salario", SqlDbType.Money).Value = Decimal.Parse(textBox11.Text);
            cmdl.Parameters.AddWithValue("@Telefono", textBox10.Text);
            cmdl.Parameters.AddWithValue("@CodigoPostal", textBox9.Text);
            cmdl.Parameters.AddWithValue("@Calle", textBox17.Text);
            cmdl.Parameters.AddWithValue("@NumeroExterior", textBox16.Text);
            cmdl.Parameters.AddWithValue("@NumeroInterior", textBox15.Text);
            cmdl.Parameters.AddWithValue("@PuestoID", textBox14.Text);
            cmdl.Parameters.AddWithValue("@CURP", textBox8.Text);
            cmdl.Parameters.AddWithValue("@HoraEntrada", textBox7.Text);
            cmdl.Parameters.AddWithValue("@HoraSalida", textBox6.Text);
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

        private void eliminarEmpleadoBtn_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "delete from Empleados " +
                "where Empleado_Id= @Empleado_Id";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Empleado_Id", textBox1.Text);
            try
            {
                cmdl.ExecuteNonQuery();
                MessageBox.Show(" El empleado fue eliminado");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = llenar_Grid();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
