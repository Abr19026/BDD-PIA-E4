﻿using System;
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
    public partial class MenuPuestos : Form
    {
        public MenuPuestos()
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
            string consulta = "select * from Puestos";
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
            }
            catch
            {

            }
        }

        private void MenuPuestos_Load(object sender, EventArgs e)
        {

        }

        private void MenuPuestos_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string insertar = "Insert into Puestos(PuestoNombre,NivelAcceso, SalarioBase) values(@Nombre , @Nivel, @Salariobase)";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Puesto_id", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Nombre", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Nivel", textBox3.Text);
            cmdl.Parameters.Add("@Salariobase", SqlDbType.Money).Value = Decimal.Parse(textBox4.Text);

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
            string insertar = "update Puestos " +
                "set PuestoNombre = @Nombre , NivelAcceso = @Nivel , SalarioBase = @Salariobase " +
                "where Puesto_id = @Puesto_id";
            SqlCommand cmdl = new SqlCommand(insertar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Puesto_id", textBox1.Text);
            cmdl.Parameters.AddWithValue("@Nombre", textBox2.Text);
            cmdl.Parameters.AddWithValue("@Nivel", textBox3.Text);
            cmdl.Parameters.Add("@Salariobase", SqlDbType.Money).Value = Decimal.Parse(textBox4.Text);

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
            string eliminar = "delete from Puestos " +
                "where Puesto_id = @Puesto_id";
            SqlCommand cmdl = new SqlCommand(eliminar, Conexion.Conectar());
            cmdl.Parameters.AddWithValue("@Puesto_id", textBox1.Text);

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
