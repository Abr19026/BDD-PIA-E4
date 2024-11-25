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
    public partial class MenuPago : Form
    {
        public MenuPago()
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
            string consulta = "select * from Pago";
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

        private void MenuPago_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Pago(Monto,Fecha, NumeroTransaccion, Adeudo_id) values(@Monto, @Fecha, @Numero, @Adeudo_id)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.Add("@Monto", SqlDbType.Money).Value = Decimal.Parse(textBox2.Text);
            cmdl.Parameters.AddWithValue("@Fecha", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Numero", textBox4.Text);
            cmdl.Parameters.AddWithValue("@Adeudo_id", textBox5.Text);

            string ObtenerAdeudo = "Select Precio FROM Adeudos WHERE Adeudo_id = @AdeudoID";
            SqlCommand cmoi = new SqlCommand(ObtenerAdeudo, Conexion.Conectar());
            cmoi.Parameters.AddWithValue("@AdeudoID", textBox5.Text);
            decimal total = (decimal)cmoi.ExecuteScalar();
            if (total == 0)
            {
                MessageBox.Show("Error: El adeudo ya fue pagado");
            }
            else
            {
                try
                { 
                    cmdl.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron agregados exitosamente");
                    string actualizar = "EXEC PagarAdeudo @PagoID, @AdeudoID";
                    SqlCommand actualizarAdeudo = new SqlCommand(actualizar, Conexion.Conectar());
                    actualizarAdeudo.Parameters.AddWithValue("@PagoID", textBox1.Text);
                    actualizarAdeudo.Parameters.AddWithValue("@AdeudoID", textBox5.Text);
                    actualizarAdeudo.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            dataGridView1.DataSource = llenar_Grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "delete from Pago " +
                "where Pago_id = @Pago_id";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Pago_id", textBox1.Text);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "update Pago " +
                "set Monto = @Monto , Fecha = @Fecha , NumeroTransaccion = @Numero, Adeudo_id = @Adeudo_id " +
                "where Pago_id = @Pago_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Pago_id", textBox1.Text);
            cmdl.Parameters.Add("@Monto", SqlDbType.Money).Value = Decimal.Parse(textBox2.Text);
            cmdl.Parameters.AddWithValue("@Fecha", textBox3.Text);
            cmdl.Parameters.AddWithValue("@Numero", textBox4.Text);
            cmdl.Parameters.AddWithValue("@Adeudo_id", textBox5.Text);

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
    }
}
