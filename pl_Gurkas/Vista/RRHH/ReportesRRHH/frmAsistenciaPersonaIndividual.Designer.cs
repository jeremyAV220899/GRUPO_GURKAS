﻿
namespace pl_Gurkas.Vista.RRHH.ReportesRRHH
{
    partial class frmAsistenciaPersonaIndividual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAsistenciaPersonaIndividual));
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dgvAsistenciaPersonal = new System.Windows.Forms.DataGridView();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboempleadoActivo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaPersonal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 508);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1245, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::pl_Gurkas.Properties.Resources.Excel_32;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(616, 26);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(109, 46);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dgvAsistenciaPersonal
            // 
            this.dgvAsistenciaPersonal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAsistenciaPersonal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAsistenciaPersonal.Location = new System.Drawing.Point(12, 118);
            this.dgvAsistenciaPersonal.Name = "dgvAsistenciaPersonal";
            this.dgvAsistenciaPersonal.RowHeadersWidth = 51;
            this.dgvAsistenciaPersonal.Size = new System.Drawing.Size(1245, 384);
            this.dgvAsistenciaPersonal.TabIndex = 10;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultar.Image = global::pl_Gurkas.Properties.Resources.buscar_empleado_32;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(490, 26);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(109, 46);
            this.btnConsultar.TabIndex = 6;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboempleadoActivo);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpFechaFin);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFechaInicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(739, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asistencia de Personal ";
            // 
            // cboempleadoActivo
            // 
            this.cboempleadoActivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboempleadoActivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboempleadoActivo.FormattingEnabled = true;
            this.cboempleadoActivo.Location = new System.Drawing.Point(78, 25);
            this.cboempleadoActivo.Name = "cboempleadoActivo";
            this.cboempleadoActivo.Size = new System.Drawing.Size(386, 21);
            this.cboempleadoActivo.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Personal ";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(253, 60);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(98, 20);
            this.dtpFechaFin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(226, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "al";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(120, 60);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(96, 20);
            this.dtpFechaInicio.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rango de Fecha ";
            // 
            // frmAsistenciaPersonaIndividual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 543);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.dgvAsistenciaPersonal);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAsistenciaPersonaIndividual";
            this.Text = "..::Consulta de Personal Asistencia Individual ::..";
            this.Load += new System.EventHandler(this.frmAsistenciaPersonaIndividual_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAsistenciaPersonal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridView dgvAsistenciaPersonal;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboempleadoActivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label1;
    }
}