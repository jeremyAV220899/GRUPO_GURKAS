
namespace pl_Gurkas.Vista.RRHH
{
    partial class frmActualizarEstadoPersonal
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
            this.cboempleadoActivo = new System.Windows.Forms.ComboBox();
            this.label42 = new System.Windows.Forms.Label();
            this.cboEstadoEmp = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cboEstadoPersonalTareaje = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnActualizarDatos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboempleadoActivo
            // 
            this.cboempleadoActivo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboempleadoActivo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboempleadoActivo.FormattingEnabled = true;
            this.cboempleadoActivo.Location = new System.Drawing.Point(171, 12);
            this.cboempleadoActivo.Name = "cboempleadoActivo";
            this.cboempleadoActivo.Size = new System.Drawing.Size(350, 21);
            this.cboempleadoActivo.TabIndex = 61;
            this.cboempleadoActivo.SelectedIndexChanged += new System.EventHandler(this.cboempleadoActivo_SelectedIndexChanged);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(13, 13);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(111, 15);
            this.label42.TabIndex = 60;
            this.label42.Text = "Buscar Empleado :";
            // 
            // cboEstadoEmp
            // 
            this.cboEstadoEmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoEmp.FormattingEnabled = true;
            this.cboEstadoEmp.Location = new System.Drawing.Point(171, 39);
            this.cboEstadoEmp.Name = "cboEstadoEmp";
            this.cboEstadoEmp.Size = new System.Drawing.Size(350, 21);
            this.cboEstadoEmp.TabIndex = 63;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(13, 40);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(106, 15);
            this.label25.TabIndex = 62;
            this.label25.Text = "Estado Personal  :";
            // 
            // cboEstadoPersonalTareaje
            // 
            this.cboEstadoPersonalTareaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstadoPersonalTareaje.FormattingEnabled = true;
            this.cboEstadoPersonalTareaje.Location = new System.Drawing.Point(171, 66);
            this.cboEstadoPersonalTareaje.Name = "cboEstadoPersonalTareaje";
            this.cboEstadoPersonalTareaje.Size = new System.Drawing.Size(350, 21);
            this.cboEstadoPersonalTareaje.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 15);
            this.label1.TabIndex = 64;
            this.label1.Text = "Estado  Tareaje Personal :";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = global::pl_Gurkas.Properties.Resources.buscar_empleado_32;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(546, 9);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(109, 46);
            this.btnBuscar.TabIndex = 66;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnActualizarDatos
            // 
            this.btnActualizarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarDatos.Image = global::pl_Gurkas.Properties.Resources.empleado_update_32;
            this.btnActualizarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarDatos.Location = new System.Drawing.Point(661, 9);
            this.btnActualizarDatos.Name = "btnActualizarDatos";
            this.btnActualizarDatos.Size = new System.Drawing.Size(153, 51);
            this.btnActualizarDatos.TabIndex = 67;
            this.btnActualizarDatos.Text = "Actualizar Datos\r\n";
            this.btnActualizarDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarDatos.UseVisualStyleBackColor = true;
            this.btnActualizarDatos.Click += new System.EventHandler(this.btnActualizarDatos_Click);
            // 
            // frmActualizarEstadoPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 101);
            this.Controls.Add(this.btnActualizarDatos);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboEstadoPersonalTareaje);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEstadoEmp);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.cboempleadoActivo);
            this.Controls.Add(this.label42);
            this.Name = "frmActualizarEstadoPersonal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "..:: Actualizar Estado Personal ::..";
            this.Load += new System.EventHandler(this.frmActualizarEstadoPersonal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboempleadoActivo;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.ComboBox cboEstadoEmp;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cboEstadoPersonalTareaje;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnActualizarDatos;
    }
}