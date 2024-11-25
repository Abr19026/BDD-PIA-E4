
namespace Consultas
{
    partial class CitasRecepcion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dg_citas_hoy = new System.Windows.Forms.DataGridView();
            this.tabs_citas = new System.Windows.Forms.TabControl();
            this.tab_activas = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.boton_aceptar_ahora = new System.Windows.Forms.Button();
            this.DescAceptar = new System.Windows.Forms.Label();
            this.tab_todo = new System.Windows.Forms.TabPage();
            this.panel_modificar = new System.Windows.Forms.Panel();
            this.boton_cancelar_mod = new System.Windows.Forms.Button();
            this.boton_acept_modif = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.inp_mod_tel = new System.Windows.Forms.TextBox();
            this.inp_mod_contacto = new System.Windows.Forms.TextBox();
            this.inp_mod_fecha = new System.Windows.Forms.DateTimePicker();
            this.combo_mod_servicio = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.inp_mod_Hora = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.boton_atualizar_todos = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.boton_cancelar = new System.Windows.Forms.Button();
            this.boton_eliminar = new System.Windows.Forms.Button();
            this.boton_modificar = new System.Windows.Forms.Button();
            this.boton_descancelar = new System.Windows.Forms.Button();
            this.boton_todos_sig = new System.Windows.Forms.Button();
            this.boton_todos_ant = new System.Windows.Forms.Button();
            this.dg_Todascitas = new System.Windows.Forms.DataGridView();
            this.tab_nueva = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabla_nueva_cita = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inp_telefono = new System.Windows.Forms.TextBox();
            this.inp_contacto = new System.Windows.Forms.TextBox();
            this.fecha_programada = new System.Windows.Forms.DateTimePicker();
            this.combo_servicio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hora_cita = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dg_citas_hoy)).BeginInit();
            this.tabs_citas.SuspendLayout();
            this.tab_activas.SuspendLayout();
            this.tab_todo.SuspendLayout();
            this.panel_modificar.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_Todascitas)).BeginInit();
            this.tab_nueva.SuspendLayout();
            this.tabla_nueva_cita.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_citas_hoy
            // 
            this.dg_citas_hoy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_citas_hoy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_citas_hoy.Location = new System.Drawing.Point(9, 105);
            this.dg_citas_hoy.Name = "dg_citas_hoy";
            this.dg_citas_hoy.ReadOnly = true;
            this.dg_citas_hoy.Size = new System.Drawing.Size(753, 215);
            this.dg_citas_hoy.TabIndex = 0;
            // 
            // tabs_citas
            // 
            this.tabs_citas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs_citas.Controls.Add(this.tab_activas);
            this.tabs_citas.Controls.Add(this.tab_todo);
            this.tabs_citas.Controls.Add(this.tab_nueva);
            this.tabs_citas.Location = new System.Drawing.Point(12, 25);
            this.tabs_citas.Name = "tabs_citas";
            this.tabs_citas.SelectedIndex = 0;
            this.tabs_citas.Size = new System.Drawing.Size(760, 712);
            this.tabs_citas.TabIndex = 1;
            this.tabs_citas.Enter += new System.EventHandler(this.tabs_citas_Enter);
            // 
            // tab_activas
            // 
            this.tab_activas.Controls.Add(this.button2);
            this.tab_activas.Controls.Add(this.boton_aceptar_ahora);
            this.tab_activas.Controls.Add(this.dg_citas_hoy);
            this.tab_activas.Controls.Add(this.DescAceptar);
            this.tab_activas.Location = new System.Drawing.Point(4, 22);
            this.tab_activas.Name = "tab_activas";
            this.tab_activas.Padding = new System.Windows.Forms.Padding(3);
            this.tab_activas.Size = new System.Drawing.Size(769, 509);
            this.tab_activas.TabIndex = 0;
            this.tab_activas.Text = "Citas Activas";
            this.tab_activas.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(153, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 43);
            this.button2.TabIndex = 2;
            this.button2.Text = "Actualizar tabla";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // boton_aceptar_ahora
            // 
            this.boton_aceptar_ahora.Location = new System.Drawing.Point(9, 43);
            this.boton_aceptar_ahora.Name = "boton_aceptar_ahora";
            this.boton_aceptar_ahora.Size = new System.Drawing.Size(119, 44);
            this.boton_aceptar_ahora.TabIndex = 1;
            this.boton_aceptar_ahora.Text = "Aceptar cita";
            this.boton_aceptar_ahora.UseVisualStyleBackColor = true;
            this.boton_aceptar_ahora.Click += new System.EventHandler(this.boton_aceptar_ahora_Click);
            // 
            // DescAceptar
            // 
            this.DescAceptar.AutoSize = true;
            this.DescAceptar.Location = new System.Drawing.Point(6, 14);
            this.DescAceptar.Name = "DescAceptar";
            this.DescAceptar.Size = new System.Drawing.Size(255, 13);
            this.DescAceptar.TabIndex = 0;
            this.DescAceptar.Text = "Aceptar cita seleccionada cuando llegue el paciente";
            // 
            // tab_todo
            // 
            this.tab_todo.Controls.Add(this.panel_modificar);
            this.tab_todo.Controls.Add(this.boton_atualizar_todos);
            this.tab_todo.Controls.Add(this.tableLayoutPanel1);
            this.tab_todo.Controls.Add(this.boton_todos_sig);
            this.tab_todo.Controls.Add(this.boton_todos_ant);
            this.tab_todo.Controls.Add(this.dg_Todascitas);
            this.tab_todo.Location = new System.Drawing.Point(4, 22);
            this.tab_todo.Name = "tab_todo";
            this.tab_todo.Padding = new System.Windows.Forms.Padding(3);
            this.tab_todo.Size = new System.Drawing.Size(752, 686);
            this.tab_todo.TabIndex = 1;
            this.tab_todo.Text = "Ver todas";
            this.tab_todo.UseVisualStyleBackColor = true;
            // 
            // panel_modificar
            // 
            this.panel_modificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_modificar.Controls.Add(this.boton_cancelar_mod);
            this.panel_modificar.Controls.Add(this.boton_acept_modif);
            this.panel_modificar.Controls.Add(this.tableLayoutPanel2);
            this.panel_modificar.Enabled = false;
            this.panel_modificar.Location = new System.Drawing.Point(12, 551);
            this.panel_modificar.Name = "panel_modificar";
            this.panel_modificar.Size = new System.Drawing.Size(750, 129);
            this.panel_modificar.TabIndex = 10;
            this.panel_modificar.Visible = false;
            // 
            // boton_cancelar_mod
            // 
            this.boton_cancelar_mod.Location = new System.Drawing.Point(155, 106);
            this.boton_cancelar_mod.Name = "boton_cancelar_mod";
            this.boton_cancelar_mod.Size = new System.Drawing.Size(111, 23);
            this.boton_cancelar_mod.TabIndex = 3;
            this.boton_cancelar_mod.Text = "Cancelar";
            this.boton_cancelar_mod.UseVisualStyleBackColor = true;
            this.boton_cancelar_mod.Click += new System.EventHandler(this.boton_cancelar_mod_Click);
            // 
            // boton_acept_modif
            // 
            this.boton_acept_modif.Location = new System.Drawing.Point(19, 106);
            this.boton_acept_modif.Name = "boton_acept_modif";
            this.boton_acept_modif.Size = new System.Drawing.Size(121, 23);
            this.boton_acept_modif.TabIndex = 2;
            this.boton_acept_modif.Text = "Guardar Cambios";
            this.boton_acept_modif.UseVisualStyleBackColor = true;
            this.boton_acept_modif.Click += new System.EventHandler(this.boton_acept_modif_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.inp_mod_tel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.inp_mod_contacto, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.inp_mod_fecha, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.combo_mod_servicio, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label10, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.inp_mod_Hora, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(19, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(696, 102);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(246, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Tipo de servicio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Telefono";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Contacto";
            // 
            // inp_mod_tel
            // 
            this.inp_mod_tel.Location = new System.Drawing.Point(107, 3);
            this.inp_mod_tel.Name = "inp_mod_tel";
            this.inp_mod_tel.Size = new System.Drawing.Size(100, 20);
            this.inp_mod_tel.TabIndex = 4;
            // 
            // inp_mod_contacto
            // 
            this.inp_mod_contacto.Location = new System.Drawing.Point(107, 54);
            this.inp_mod_contacto.Name = "inp_mod_contacto";
            this.inp_mod_contacto.Size = new System.Drawing.Size(100, 20);
            this.inp_mod_contacto.TabIndex = 5;
            // 
            // inp_mod_fecha
            // 
            this.inp_mod_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inp_mod_fecha.ImeMode = System.Windows.Forms.ImeMode.On;
            this.inp_mod_fecha.Location = new System.Drawing.Point(350, 3);
            this.inp_mod_fecha.Name = "inp_mod_fecha";
            this.inp_mod_fecha.Size = new System.Drawing.Size(121, 20);
            this.inp_mod_fecha.TabIndex = 6;
            this.inp_mod_fecha.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // 
            // combo_mod_servicio
            // 
            this.combo_mod_servicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.combo_mod_servicio.FormattingEnabled = true;
            this.combo_mod_servicio.Location = new System.Drawing.Point(350, 54);
            this.combo_mod_servicio.Name = "combo_mod_servicio";
            this.combo_mod_servicio.Size = new System.Drawing.Size(121, 21);
            this.combo_mod_servicio.TabIndex = 7;
            this.combo_mod_servicio.Text = "Seleccionar Servicio";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(489, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Hora";
            // 
            // inp_mod_Hora
            // 
            this.inp_mod_Hora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.inp_mod_Hora.ImeMode = System.Windows.Forms.ImeMode.On;
            this.inp_mod_Hora.Location = new System.Drawing.Point(558, 3);
            this.inp_mod_Hora.Name = "inp_mod_Hora";
            this.inp_mod_Hora.ShowUpDown = true;
            this.inp_mod_Hora.Size = new System.Drawing.Size(125, 20);
            this.inp_mod_Hora.TabIndex = 9;
            this.inp_mod_Hora.Value = new System.DateTime(1970, 1, 1, 0, 1, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(246, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Programada";
            // 
            // boton_atualizar_todos
            // 
            this.boton_atualizar_todos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boton_atualizar_todos.Location = new System.Drawing.Point(304, 511);
            this.boton_atualizar_todos.Name = "boton_atualizar_todos";
            this.boton_atualizar_todos.Size = new System.Drawing.Size(98, 23);
            this.boton_atualizar_todos.TabIndex = 9;
            this.boton_atualizar_todos.Text = "Actualizar";
            this.boton_atualizar_todos.UseVisualStyleBackColor = true;
            this.boton_atualizar_todos.Click += new System.EventHandler(this.boton_atualizar_todos_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.boton_cancelar, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.boton_eliminar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.boton_modificar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.boton_descancelar, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(9, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(586, 51);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // boton_cancelar
            // 
            this.boton_cancelar.Location = new System.Drawing.Point(3, 3);
            this.boton_cancelar.Name = "boton_cancelar";
            this.boton_cancelar.Size = new System.Drawing.Size(93, 44);
            this.boton_cancelar.TabIndex = 0;
            this.boton_cancelar.Text = "Cancelar Cita";
            this.boton_cancelar.UseVisualStyleBackColor = true;
            this.boton_cancelar.Click += new System.EventHandler(this.boton_cancelar_Click);
            // 
            // boton_eliminar
            // 
            this.boton_eliminar.Location = new System.Drawing.Point(149, 3);
            this.boton_eliminar.Name = "boton_eliminar";
            this.boton_eliminar.Size = new System.Drawing.Size(100, 44);
            this.boton_eliminar.TabIndex = 3;
            this.boton_eliminar.Text = "Eliminar Cita";
            this.boton_eliminar.UseVisualStyleBackColor = true;
            this.boton_eliminar.Click += new System.EventHandler(this.boton_eliminar_Click);
            // 
            // boton_modificar
            // 
            this.boton_modificar.Location = new System.Drawing.Point(295, 3);
            this.boton_modificar.Name = "boton_modificar";
            this.boton_modificar.Size = new System.Drawing.Size(98, 44);
            this.boton_modificar.TabIndex = 4;
            this.boton_modificar.Text = "Modificar";
            this.boton_modificar.UseVisualStyleBackColor = true;
            this.boton_modificar.Click += new System.EventHandler(this.boton_modificar_Click);
            // 
            // boton_descancelar
            // 
            this.boton_descancelar.Location = new System.Drawing.Point(441, 3);
            this.boton_descancelar.Name = "boton_descancelar";
            this.boton_descancelar.Size = new System.Drawing.Size(89, 44);
            this.boton_descancelar.TabIndex = 5;
            this.boton_descancelar.Text = "Quitar Cancelación";
            this.boton_descancelar.UseVisualStyleBackColor = true;
            this.boton_descancelar.Click += new System.EventHandler(this.boton_descancelar_Click);
            // 
            // boton_todos_sig
            // 
            this.boton_todos_sig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boton_todos_sig.Location = new System.Drawing.Point(148, 511);
            this.boton_todos_sig.Name = "boton_todos_sig";
            this.boton_todos_sig.Size = new System.Drawing.Size(110, 23);
            this.boton_todos_sig.TabIndex = 6;
            this.boton_todos_sig.Text = "20 mas antigüos";
            this.boton_todos_sig.UseVisualStyleBackColor = true;
            this.boton_todos_sig.Click += new System.EventHandler(this.boton_todos_sig_Click);
            // 
            // boton_todos_ant
            // 
            this.boton_todos_ant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.boton_todos_ant.Location = new System.Drawing.Point(9, 511);
            this.boton_todos_ant.Name = "boton_todos_ant";
            this.boton_todos_ant.Size = new System.Drawing.Size(113, 23);
            this.boton_todos_ant.TabIndex = 5;
            this.boton_todos_ant.Text = "20 mas recientes";
            this.boton_todos_ant.UseVisualStyleBackColor = true;
            this.boton_todos_ant.Click += new System.EventHandler(this.boton_todos_ant_Click);
            // 
            // dg_Todascitas
            // 
            this.dg_Todascitas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dg_Todascitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_Todascitas.Location = new System.Drawing.Point(9, 102);
            this.dg_Todascitas.Name = "dg_Todascitas";
            this.dg_Todascitas.ReadOnly = true;
            this.dg_Todascitas.Size = new System.Drawing.Size(737, 394);
            this.dg_Todascitas.TabIndex = 2;
            // 
            // tab_nueva
            // 
            this.tab_nueva.Controls.Add(this.button1);
            this.tab_nueva.Controls.Add(this.tabla_nueva_cita);
            this.tab_nueva.Location = new System.Drawing.Point(4, 22);
            this.tab_nueva.Name = "tab_nueva";
            this.tab_nueva.Size = new System.Drawing.Size(769, 509);
            this.tab_nueva.TabIndex = 2;
            this.tab_nueva.Text = "Nueva Cita";
            this.tab_nueva.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(531, 228);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Agregar cita";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabla_nueva_cita
            // 
            this.tabla_nueva_cita.ColumnCount = 6;
            this.tabla_nueva_cita.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tabla_nueva_cita.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_nueva_cita.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tabla_nueva_cita.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_nueva_cita.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tabla_nueva_cita.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tabla_nueva_cita.Controls.Add(this.label2, 2, 0);
            this.tabla_nueva_cita.Controls.Add(this.label3, 2, 1);
            this.tabla_nueva_cita.Controls.Add(this.label4, 0, 0);
            this.tabla_nueva_cita.Controls.Add(this.label5, 0, 1);
            this.tabla_nueva_cita.Controls.Add(this.inp_telefono, 1, 0);
            this.tabla_nueva_cita.Controls.Add(this.inp_contacto, 1, 1);
            this.tabla_nueva_cita.Controls.Add(this.fecha_programada, 3, 0);
            this.tabla_nueva_cita.Controls.Add(this.combo_servicio, 3, 1);
            this.tabla_nueva_cita.Controls.Add(this.label6, 4, 0);
            this.tabla_nueva_cita.Controls.Add(this.hora_cita, 5, 0);
            this.tabla_nueva_cita.Location = new System.Drawing.Point(14, 16);
            this.tabla_nueva_cita.Name = "tabla_nueva_cita";
            this.tabla_nueva_cita.RowCount = 2;
            this.tabla_nueva_cita.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabla_nueva_cita.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tabla_nueva_cita.Size = new System.Drawing.Size(645, 154);
            this.tabla_nueva_cita.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha Programada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(228, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tipo de servicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Telefono";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Contacto";
            // 
            // inp_telefono
            // 
            this.inp_telefono.Location = new System.Drawing.Point(99, 3);
            this.inp_telefono.Name = "inp_telefono";
            this.inp_telefono.Size = new System.Drawing.Size(100, 20);
            this.inp_telefono.TabIndex = 4;
            // 
            // inp_contacto
            // 
            this.inp_contacto.Location = new System.Drawing.Point(99, 80);
            this.inp_contacto.Name = "inp_contacto";
            this.inp_contacto.Size = new System.Drawing.Size(100, 20);
            this.inp_contacto.TabIndex = 5;
            // 
            // fecha_programada
            // 
            this.fecha_programada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fecha_programada.ImeMode = System.Windows.Forms.ImeMode.On;
            this.fecha_programada.Location = new System.Drawing.Point(324, 3);
            this.fecha_programada.Name = "fecha_programada";
            this.fecha_programada.Size = new System.Drawing.Size(121, 20);
            this.fecha_programada.TabIndex = 6;
            this.fecha_programada.Value = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            // 
            // combo_servicio
            // 
            this.combo_servicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.combo_servicio.FormattingEnabled = true;
            this.combo_servicio.Location = new System.Drawing.Point(324, 80);
            this.combo_servicio.Name = "combo_servicio";
            this.combo_servicio.Size = new System.Drawing.Size(121, 21);
            this.combo_servicio.TabIndex = 7;
            this.combo_servicio.Text = "Seleccionar Servicio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(453, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Hora";
            // 
            // hora_cita
            // 
            this.hora_cita.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.hora_cita.ImeMode = System.Windows.Forms.ImeMode.On;
            this.hora_cita.Location = new System.Drawing.Point(517, 3);
            this.hora_cita.Name = "hora_cita";
            this.hora_cita.ShowUpDown = true;
            this.hora_cita.Size = new System.Drawing.Size(125, 20);
            this.hora_cita.TabIndex = 9;
            this.hora_cita.Value = new System.DateTime(1970, 1, 1, 0, 1, 0, 0);
            // 
            // CitasRecepcion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(784, 749);
            this.Controls.Add(this.tabs_citas);
            this.Name = "CitasRecepcion";
            this.Text = "Citas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_citas_hoy)).EndInit();
            this.tabs_citas.ResumeLayout(false);
            this.tab_activas.ResumeLayout(false);
            this.tab_activas.PerformLayout();
            this.tab_todo.ResumeLayout(false);
            this.panel_modificar.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_Todascitas)).EndInit();
            this.tab_nueva.ResumeLayout(false);
            this.tabla_nueva_cita.ResumeLayout(false);
            this.tabla_nueva_cita.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_citas_hoy;
        private System.Windows.Forms.TabControl tabs_citas;
        private System.Windows.Forms.TabPage tab_activas;
        private System.Windows.Forms.Button boton_aceptar_ahora;
        private System.Windows.Forms.Label DescAceptar;
        private System.Windows.Forms.TabPage tab_todo;
        private System.Windows.Forms.Button boton_cancelar;
        private System.Windows.Forms.TabPage tab_nueva;
        private System.Windows.Forms.TableLayoutPanel tabla_nueva_cita;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox inp_telefono;
        private System.Windows.Forms.TextBox inp_contacto;
        private System.Windows.Forms.DateTimePicker fecha_programada;
        private System.Windows.Forms.ComboBox combo_servicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker hora_cita;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button boton_modificar;
        private System.Windows.Forms.Button boton_eliminar;
        private System.Windows.Forms.DataGridView dg_Todascitas;
        private System.Windows.Forms.Button boton_todos_sig;
        private System.Windows.Forms.Button boton_todos_ant;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button boton_atualizar_todos;
        private System.Windows.Forms.Panel panel_modificar;
        private System.Windows.Forms.Button boton_acept_modif;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox inp_mod_tel;
        private System.Windows.Forms.TextBox inp_mod_contacto;
        private System.Windows.Forms.DateTimePicker inp_mod_fecha;
        private System.Windows.Forms.ComboBox combo_mod_servicio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker inp_mod_Hora;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button boton_cancelar_mod;
        private System.Windows.Forms.Button boton_descancelar;
    }
}

