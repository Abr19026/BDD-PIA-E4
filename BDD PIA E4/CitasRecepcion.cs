using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BDD_PIA_E4;

namespace Consultas
{
    public partial class CitasRecepcion : Form
    {
        private string qrystring = "SELECT * FROM Citas_Activas_Hoy";
        private string srvstring = "SELECT TipoServicio_id,Descripcion FROM TiposServicio";
        private string allsrvstring = "SELECT top(20) * FROM Cita_Datos ORDER BY [Fecha de Registro] DESC";
        private SqlConnection cnxn;
        private long empleado_id;
        private DataTable servicios;
        private long id_cita_modif;
        public CitasRecepcion(long empleado_id)
        {
            InitializeComponent();
            this.empleado_id = empleado_id;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Crea string de la conexión
            this.cnxn = Conexion.Conectar();
            //Llena tabla citas_activas de datos
            this.dg_citas_hoy.DataSource = obtenerDatos(this.qrystring);
            //Obtiene los servicios para el combobox
            this.servicios = obtenerDatos(this.srvstring);
            
            this.combo_servicio.DataSource = this.servicios;
            this.combo_servicio.DisplayMember = "Descripcion";

            this.combo_mod_servicio.DataSource = this.servicios;
            this.combo_mod_servicio.DisplayMember = "Descripcion";
            //Obtiene datos para toas_citas
            this.dg_Todascitas.DataSource = obtenerDatos(this.allsrvstring);
        }

        private DataTable obtenerDatos(string qurystr)
        {
            //Crea string de la conexión
            this.cnxn = Conexion.Conectar();
            SqlDataAdapter adaptador = new SqlDataAdapter(qurystr, this.cnxn);
            DataTable resultado = new DataTable();
            adaptador.Fill(resultado);
            return resultado;
        }

        private void boton_aceptar_ahora_Click(object sender, EventArgs e)
        {
            //Crea nuevo form para preguntar si quiere aceptar la acción
            using (var frmModal = new ModalConfirmar("Seguro que quiere marcar esta cita?"))
            {
                //Retorna DialogResult.Ok p DialogResult.Cancel dependiendo que le dió click
                var resultado = frmModal.ShowDialog();
                //Realiza accí+on si le dio click a Aceptar
                if (resultado == DialogResult.OK)
                {
                    aceptar_cita();
                    this.dg_citas_hoy.DataSource = obtenerDatos(this.qrystring);
                }
            }
        }

        //Aceptar cita
        private void aceptar_cita()
        {
            string qryacept = "EXECUTE ACEPTAR_CITA_NOW @id_cita";
            var rowsSeleccionadas = this.dg_citas_hoy.SelectedRows;

            if (rowsSeleccionadas.Count != 1)
            {
                MessageBox.Show("Solo puede aceptar 1 cita, Seleccionó mas de 1 o ninguna");
                return;
            }

            using (this.cnxn = Conexion.Conectar())
            {
                var rowModif = rowsSeleccionadas[0];
               // this.cnxn.Open();
                var comando = new SqlCommand(qryacept, this.cnxn);
                comando.Parameters.AddWithValue("@id_cita", rowModif.Cells["Cita_id"].Value);
                try
                {
                    comando.ExecuteNonQuery();
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        //Cancelar cita
        private void boton_cancelar_Click(object sender, EventArgs e)
        {
            string cmnd = "EXECUTE CANCELAR_CITA @Cita_id";
            var rowsSeleccionadas = this.dg_Todascitas.SelectedRows;

            if (rowsSeleccionadas.Count != 1)
            {
                MessageBox.Show("Solo puede cancelar 1 cita, Seleccionó mas de 1 o ninguna");
                return;
            }

            using (this.cnxn = Conexion.Conectar())
            {
                var rowModif = rowsSeleccionadas[0];
            //    this.cnxn.Open();
                var comando = new SqlCommand(cmnd, this.cnxn);
                comando.Parameters.AddWithValue("@Cita_id", rowModif.Cells["Cita_id"].Value);
                try
                {
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cita Cancelada");
                    this.dg_Todascitas.DataSource = obtenerDatos(this.allsrvstring);
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        //Para agregar cita
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime horaProgramada = this.fecha_programada.Value.Date + this.hora_cita.Value.TimeOfDay;
            string telefono = this.inp_telefono.Text.Trim();
            string contacto = this.inp_contacto.Text.Trim();
            if (this.combo_servicio.SelectedIndex > -1)
            {
                var tipoServicio = ((DataRowView)this.combo_servicio.SelectedItem).Row["TipoServicio_id"];

                string cmdstr = "EXECUTE INSERTAR_CITA @EmpleadoID, @Telefono, @TipoServicio, @Contacto, @HoraProgramada";
                using (this.cnxn = Conexion.Conectar())
                {
                  //  this.cnxn.Open();
                    var comando = new SqlCommand(cmdstr, this.cnxn);
                    comando.Parameters.AddWithValue("@EmpleadoID", this.empleado_id);
                    comando.Parameters.AddWithValue("@HoraProgramada", horaProgramada);
                    comando.Parameters.AddWithValue("@TipoServicio", tipoServicio);


                    if (telefono.Length > 0)
                    {
                        comando.Parameters.AddWithValue("@Telefono", telefono);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@Telefono", DBNull.Value);
                    }
                    if (contacto.Length > 0)
                    {
                        comando.Parameters.AddWithValue("@Contacto", contacto);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@Contacto", DBNull.Value);
                    }

                    try
                    {
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Cita agregada con éxito");
                    }
                    catch (SqlException exc)
                    {
                        MessageBox.Show(exc.Message);
                    }

                }
            }
            else
            {
                MessageBox.Show("No ha seleccionado un servicio");
            }
        }

        //Actualiza citas de hoy
        private void button2_Click(object sender, EventArgs e)
        {
            this.dg_citas_hoy.DataSource = obtenerDatos(this.qrystring);
        }

        //Halla las 20 citas inmediatamente mas recientes a las mostradas
        private void boton_todos_ant_Click(object sender, EventArgs e)
        {
            long primeroKey = -1;
            DataTable tabla = (DataTable)this.dg_Todascitas.DataSource;

            if (tabla.Rows.Count > 0)
            {
                primeroKey = tabla.Rows[0].Field<long>("Cita_id");
                string getanteriores = $"SELECT TOP(20) * FROM Cita_Datos WHERE Cita_id > {primeroKey} ORDER BY Cita_id ASC";
                DataTable salida = this.obtenerDatos(getanteriores);
                if (salida.Rows.Count >= 1)
                {
                    salida.DefaultView.Sort = "Cita_id DESC";
                    salida = salida.DefaultView.ToTable();
                    this.dg_Todascitas.DataSource = salida;
                }
            }
        }

        //Muestra las 20 citas inmediatamente mas antiguas a las mostrada
        private void boton_todos_sig_Click(object sender, EventArgs e)
        {
            long ultimokey = -1;
            DataTable tabla = (DataTable)this.dg_Todascitas.DataSource;

            if (tabla.Rows.Count > 0)
            {
                ultimokey = tabla.Rows[tabla.Rows.Count-1].Field<long>("Cita_id");
                string getanteriores = $"SELECT TOP(20) * FROM Cita_Datos WHERE Cita_id < {ultimokey} ORDER BY Cita_id DESC";
                DataTable salida = this.obtenerDatos(getanteriores);
                if (salida.Rows.Count >= 1)
                {
                    this.dg_Todascitas.DataSource = salida;
                }
            }
        }

        //Cuando da click al boton actualizar en la tabla que muestra todas las citas
        private void boton_atualizar_todos_Click(object sender, EventArgs e)
        {
            this.dg_Todascitas.DataSource = obtenerDatos(this.allsrvstring);
        }

        //Elimina la cita seleccionada
        private void boton_eliminar_Click(object sender, EventArgs e)
        {
            string cmnd = "EXECUTE ELIMINAR_CITA @Cita_id";
            var rowsSeleccionadas = this.dg_Todascitas.SelectedRows;

            if (rowsSeleccionadas.Count != 1)
            {
                MessageBox.Show("Solo puede eliminar 1 cita, Seleccionó mas de 1 o ninguna");
                return;
            }

            using (this.cnxn = Conexion.Conectar())
            {
                var rowModif = rowsSeleccionadas[0];
             //   this.cnxn.Open();
                var comando = new SqlCommand(cmnd, this.cnxn);
                comando.Parameters.AddWithValue("@Cita_id", rowModif.Cells["Cita_id"].Value);
                try
                {
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cita Eliminada");
                    this.dg_Todascitas.DataSource = obtenerDatos(this.allsrvstring);
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        //Muestra campos para modificar una cita
        private void boton_modificar_Click(object sender, EventArgs e)
        {
            
            var rowsSeleccionadas = this.dg_Todascitas.SelectedRows;
            if (rowsSeleccionadas.Count != 1)
            {
                MessageBox.Show("Solo puede modificar 1 cita, Seleccionó mas de 1 o ninguna");
                return;
            }

            this.panel_modificar.Visible = true;
            this.panel_modificar.Enabled = true;

            var rowModif = rowsSeleccionadas[0];

            this.id_cita_modif = (long)rowModif.Cells["Cita_id"].Value;
            var contacto = rowModif.Cells["Contacto"].Value;
            var llamada = rowModif.Cells["Teléfono Llamada"].Value;
            int servicio = (int)rowModif.Cells["Servicio_id"].Value;
            DateTime FechaPrgramada = (DateTime)rowModif.Cells["Fecha Programada"].Value;
            bool cancelado = (bool)rowModif.Cells["Cancelado"].Value;

            if (contacto != DBNull.Value)
            {
                this.inp_mod_contacto.Text = (string)contacto;
            }
            if (llamada != DBNull.Value)
            {
                this.inp_mod_tel.Text = (string)llamada;
            }
            this.inp_mod_fecha.Value = FechaPrgramada;
            this.inp_mod_Hora.Value = FechaPrgramada;
            var servicio_index = hallar_serv_conindex(servicio);
            if(servicio_index != -1)
            {
                this.combo_mod_servicio.SelectedIndex = hallar_serv_conindex(servicio);
            }
            else
            {
                MessageBox.Show("Hubo un error al poner el servicio, Cierre ventana y vuelva a intentar");
            }
        }
        
        //Halla el servicio del combobox dado el index del row en el combobox
        private int hallar_serv_conindex(int index)
        {
            var RowsHalladas = this.servicios.Select($"TipoServicio_id = {index}");
            if(RowsHalladas.Length >0 )
            {
                return this.servicios.Rows.IndexOf(RowsHalladas[0]);
            }
            else
            {
                return -1;
            }
        }

        //Cancela la modificación y deja de mostrar los datos
        private void boton_cancelar_mod_Click(object sender, EventArgs e)
        {
            this.panel_modificar.Visible = false;
            this.panel_modificar.Enabled = false;
        }

        //Modifica cita
        private void boton_acept_modif_Click(object sender, EventArgs e)
        {
            string cmnd = "EXECUTE MODIFICAR_CITA @citaID, @Telefono, @TipoServicio, @Contacto, @HoraProgramada";
            var tipoServicio = ((DataRowView)this.combo_mod_servicio.SelectedItem).Row["TipoServicio_id"];
            using (this.cnxn = Conexion.Conectar())
            {
             //   this.cnxn.Open();
                var comando = new SqlCommand(cmnd, this.cnxn);
                DateTime horaprogramada = this.inp_mod_fecha.Value.Date + this.inp_mod_Hora.Value.TimeOfDay;
                var telefono = this.inp_mod_tel.Text.Trim();
                var contacto = this.inp_mod_contacto.Text.Trim();

                comando.Parameters.AddWithValue("@citaID", this.id_cita_modif);
                if(telefono.Length != 0)
                {
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                }
                else
                {
                    comando.Parameters.AddWithValue("@Telefono", DBNull.Value);
                }

                if (contacto.Length != 0)
                {
                    comando.Parameters.AddWithValue("@Contacto", contacto);
                }
                else
                {
                    comando.Parameters.AddWithValue("@Contacto", DBNull.Value);
                }
                comando.Parameters.AddWithValue("@TipoServicio",tipoServicio);
                comando.Parameters.AddWithValue("@HoraProgramada",horaprogramada);

                try
                {
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cita modificada");
                    this.panel_modificar.Visible = false;
                    this.panel_modificar.Enabled = false;
                    this.dg_Todascitas.DataSource = obtenerDatos(this.allsrvstring);
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void boton_descancelar_Click(object sender, EventArgs e)
        {
            string cmnd = "EXECUTE ACTIVAR_CITA @Cita_id";
            var rowsSeleccionadas = this.dg_Todascitas.SelectedRows;

            if (rowsSeleccionadas.Count != 1)
            {
                MessageBox.Show("Solo puede activar 1 cita, Seleccionó mas de 1 o ninguna");
                return;
            }

            using (this.cnxn = Conexion.Conectar())
            {
                var rowModif = rowsSeleccionadas[0];
            //    this.cnxn.Open();
                var comando = new SqlCommand(cmnd, this.cnxn);
                comando.Parameters.AddWithValue("@Cita_id", rowModif.Cells["Cita_id"].Value);
                try
                {
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Cita Activada");
                    this.dg_Todascitas.DataSource = obtenerDatos(this.allsrvstring);
                }
                catch (SqlException exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }

        private void tabs_citas_Enter(object sender, EventArgs e)
        {
            this.fecha_programada.Value = DateTime.Now;
           
        }
    }
}
