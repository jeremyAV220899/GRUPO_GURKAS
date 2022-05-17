
namespace pl_Gurkas.Vista.CentroControl
{
    partial class frmAsistenciaPersonal
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboempleadoActivo = new System.Windows.Forms.ComboBox();
            this.btnBuscarAVP = new System.Windows.Forms.Button();
            this.txtcodavp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnRenganche = new System.Windows.Forms.Button();
            this.btnTardanza = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnGuardadAsistencia = new System.Windows.Forms.Button();
            this.dgvAsistencia = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboHoras = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboUnidad = new System.Windows.Forms.ComboBox();
            this.Unida = new System.Windows.Forms.Label();
            this.cboFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.cboCede = new System.Windows.Forms.ComboBox();
            this.cboturnos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgvPersonalEstatura = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.lblCantidadDePersonalSinMarcacion = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalMarcaciones = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPersonalConMarcacion = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalEstatura)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboempleadoActivo);
            this.groupBox2.Controls.Add(this.btnBuscarAVP);
            this.groupBox2.Controls.Add(this.txtcodavp);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(663, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 119);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Buscar Codigo AVP";
            // 
            // cboempleadoActivo
            // 
            this.cboempleadoActivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboempleadoActivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboempleadoActivo.FormattingEnabled = true;
            this.cboempleadoActivo.Location = new System.Drawing.Point(84, 35);
            this.cboempleadoActivo.Name = "cboempleadoActivo";
            this.cboempleadoActivo.Size = new System.Drawing.Size(386, 21);
            this.cboempleadoActivo.TabIndex = 47;
            // 
            // btnBuscarAVP
            // 
            this.btnBuscarAVP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarAVP.Image = global::pl_Gurkas.Properties.Resources.buscar_empleado_32;
            this.btnBuscarAVP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarAVP.Location = new System.Drawing.Point(329, 65);
            this.btnBuscarAVP.Name = "btnBuscarAVP";
            this.btnBuscarAVP.Size = new System.Drawing.Size(129, 46);
            this.btnBuscarAVP.TabIndex = 46;
            this.btnBuscarAVP.Text = "Buscar AVP";
            this.btnBuscarAVP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscarAVP.UseVisualStyleBackColor = true;
            this.btnBuscarAVP.Click += new System.EventHandler(this.btnBuscarAVP_Click);
            // 
            // txtcodavp
            // 
            this.txtcodavp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcodavp.Location = new System.Drawing.Point(94, 73);
            this.txtcodavp.Name = "txtcodavp";
            this.txtcodavp.Size = new System.Drawing.Size(211, 22);
            this.txtcodavp.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Codigo AVP";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Empleado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pl_Gurkas.Properties.Resources.png;
            this.pictureBox1.Location = new System.Drawing.Point(1145, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 53;
            this.pictureBox1.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Image = global::pl_Gurkas.Properties.Resources.salir_empleado_32;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(381, 137);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(129, 46);
            this.btnCerrar.TabIndex = 52;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnRenganche
            // 
            this.btnRenganche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRenganche.Image = global::pl_Gurkas.Properties.Resources.RENGANCHYE_32;
            this.btnRenganche.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRenganche.Location = new System.Drawing.Point(528, 25);
            this.btnRenganche.Name = "btnRenganche";
            this.btnRenganche.Size = new System.Drawing.Size(129, 46);
            this.btnRenganche.TabIndex = 51;
            this.btnRenganche.Text = "Renganche";
            this.btnRenganche.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRenganche.UseVisualStyleBackColor = true;
            this.btnRenganche.Click += new System.EventHandler(this.btnRenganche_Click);
            // 
            // btnTardanza
            // 
            this.btnTardanza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTardanza.Image = global::pl_Gurkas.Properties.Resources.time_32;
            this.btnTardanza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTardanza.Location = new System.Drawing.Point(528, 88);
            this.btnTardanza.Name = "btnTardanza";
            this.btnTardanza.Size = new System.Drawing.Size(129, 46);
            this.btnTardanza.TabIndex = 50;
            this.btnTardanza.Text = "Tardanza";
            this.btnTardanza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTardanza.UseVisualStyleBackColor = true;
            this.btnTardanza.Click += new System.EventHandler(this.btnTardanza_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::pl_Gurkas.Properties.Resources.buscar_empleado_32;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(381, 85);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(129, 46);
            this.btnBuscar.TabIndex = 49;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnGuardadAsistencia
            // 
            this.btnGuardadAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardadAsistencia.Image = global::pl_Gurkas.Properties.Resources.save_32_png_32;
            this.btnGuardadAsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardadAsistencia.Location = new System.Drawing.Point(381, 25);
            this.btnGuardadAsistencia.Name = "btnGuardadAsistencia";
            this.btnGuardadAsistencia.Size = new System.Drawing.Size(129, 46);
            this.btnGuardadAsistencia.TabIndex = 48;
            this.btnGuardadAsistencia.Text = "Guardar";
            this.btnGuardadAsistencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardadAsistencia.UseVisualStyleBackColor = true;
            this.btnGuardadAsistencia.Click += new System.EventHandler(this.btnGuardadAsistencia_Click);
            // 
            // dgvAsistencia
            // 
            this.dgvAsistencia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAsistencia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAsistencia.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAsistencia.Location = new System.Drawing.Point(12, 226);
            this.dgvAsistencia.Name = "dgvAsistencia";
            this.dgvAsistencia.Size = new System.Drawing.Size(667, 413);
            this.dgvAsistencia.TabIndex = 47;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboEmpresa);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblHora);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboHoras);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboUnidad);
            this.groupBox1.Controls.Add(this.Unida);
            this.groupBox1.Controls.Add(this.cboFechaInicio);
            this.groupBox1.Controls.Add(this.cboCede);
            this.groupBox1.Controls.Add(this.cboturnos);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 208);
            this.groupBox1.TabIndex = 46;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asistencia";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(75, 112);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(268, 24);
            this.cboEmpresa.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Empresa";
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(214, 144);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(38, 16);
            this.lblHora.TabIndex = 12;
            this.lblHora.Text = "Hora";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(170, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Hora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Horas Trabajadas";
            // 
            // cboHoras
            // 
            this.cboHoras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHoras.FormattingEnabled = true;
            this.cboHoras.Location = new System.Drawing.Point(129, 171);
            this.cboHoras.Name = "cboHoras";
            this.cboHoras.Size = new System.Drawing.Size(214, 21);
            this.cboHoras.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha";
            // 
            // cboUnidad
            // 
            this.cboUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUnidad.FormattingEnabled = true;
            this.cboUnidad.Location = new System.Drawing.Point(64, 51);
            this.cboUnidad.Name = "cboUnidad";
            this.cboUnidad.Size = new System.Drawing.Size(279, 24);
            this.cboUnidad.TabIndex = 7;
            this.cboUnidad.SelectedIndexChanged += new System.EventHandler(this.cboUnidad_SelectedIndexChanged);
            // 
            // Unida
            // 
            this.Unida.AutoSize = true;
            this.Unida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Unida.Location = new System.Drawing.Point(6, 54);
            this.Unida.Name = "Unida";
            this.Unida.Size = new System.Drawing.Size(52, 16);
            this.Unida.TabIndex = 6;
            this.Unida.Text = "Unidad";
            // 
            // cboFechaInicio
            // 
            this.cboFechaInicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cboFechaInicio.Location = new System.Drawing.Point(64, 143);
            this.cboFechaInicio.Name = "cboFechaInicio";
            this.cboFechaInicio.Size = new System.Drawing.Size(99, 20);
            this.cboFechaInicio.TabIndex = 2;
            // 
            // cboCede
            // 
            this.cboCede.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCede.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCede.FormattingEnabled = true;
            this.cboCede.Location = new System.Drawing.Point(64, 82);
            this.cboCede.Name = "cboCede";
            this.cboCede.Size = new System.Drawing.Size(279, 24);
            this.cboCede.TabIndex = 5;
            // 
            // cboturnos
            // 
            this.cboturnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboturnos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboturnos.FormattingEnabled = true;
            this.cboturnos.Location = new System.Drawing.Point(64, 20);
            this.cboturnos.Name = "cboturnos";
            this.cboturnos.Size = new System.Drawing.Size(279, 24);
            this.cboturnos.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sede ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Turno";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgvPersonalEstatura
            // 
            this.dgvPersonalEstatura.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPersonalEstatura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonalEstatura.Location = new System.Drawing.Point(697, 226);
            this.dgvPersonalEstatura.Name = "dgvPersonalEstatura";
            this.dgvPersonalEstatura.Size = new System.Drawing.Size(652, 413);
            this.dgvPersonalEstatura.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(159, 16);
            this.label9.TabIndex = 48;
            this.label9.Text = "Personal Sin Marcacion : ";
            // 
            // lblCantidadDePersonalSinMarcacion
            // 
            this.lblCantidadDePersonalSinMarcacion.AutoSize = true;
            this.lblCantidadDePersonalSinMarcacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadDePersonalSinMarcacion.Location = new System.Drawing.Point(204, 49);
            this.lblCantidadDePersonalSinMarcacion.Name = "lblCantidadDePersonalSinMarcacion";
            this.lblCantidadDePersonalSinMarcacion.Size = new System.Drawing.Size(21, 24);
            this.lblCantidadDePersonalSinMarcacion.TabIndex = 48;
            this.lblCantidadDePersonalSinMarcacion.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotalMarcaciones);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.lblPersonalConMarcacion);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lblCantidadDePersonalSinMarcacion);
            this.groupBox3.Location = new System.Drawing.Point(663, 137);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(476, 83);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Resumen De Asistencia Diario";
            // 
            // lblTotalMarcaciones
            // 
            this.lblTotalMarcaciones.AutoSize = true;
            this.lblTotalMarcaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMarcaciones.Location = new System.Drawing.Point(396, 19);
            this.lblTotalMarcaciones.Name = "lblTotalMarcaciones";
            this.lblTotalMarcaciones.Size = new System.Drawing.Size(21, 24);
            this.lblTotalMarcaciones.TabIndex = 52;
            this.lblTotalMarcaciones.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(252, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 16);
            this.label11.TabIndex = 51;
            this.label11.Text = "Total de Titulares : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(164, 16);
            this.label10.TabIndex = 49;
            this.label10.Text = "Personal Con Marcacion : ";
            // 
            // lblPersonalConMarcacion
            // 
            this.lblPersonalConMarcacion.AutoSize = true;
            this.lblPersonalConMarcacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonalConMarcacion.Location = new System.Drawing.Point(204, 20);
            this.lblPersonalConMarcacion.Name = "lblPersonalConMarcacion";
            this.lblPersonalConMarcacion.Size = new System.Drawing.Size(21, 24);
            this.lblPersonalConMarcacion.TabIndex = 50;
            this.lblPersonalConMarcacion.Text = "0";
            // 
            // frmAsistenciaPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 651);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvPersonalEstatura);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnRenganche);
            this.Controls.Add(this.btnTardanza);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnGuardadAsistencia);
            this.Controls.Add(this.dgvAsistencia);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAsistenciaPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAsistenciaPersonal";
            this.Load += new System.EventHandler(this.frmAsistenciaPersonal_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistencia)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalEstatura)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboempleadoActivo;
        private System.Windows.Forms.Button btnBuscarAVP;
        private System.Windows.Forms.TextBox txtcodavp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnRenganche;
        private System.Windows.Forms.Button btnTardanza;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnGuardadAsistencia;
        private System.Windows.Forms.DataGridView dgvAsistencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboHoras;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.Label Unida;
        private System.Windows.Forms.DateTimePicker cboFechaInicio;
        private System.Windows.Forms.ComboBox cboCede;
        private System.Windows.Forms.ComboBox cboturnos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvPersonalEstatura;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblCantidadDePersonalSinMarcacion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotalMarcaciones;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblPersonalConMarcacion;
    }
}