
namespace pl_Gurkas.Vista.Planilla.MensajeConfirmacion
{
    partial class frmGuardarPlanilla
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
            this.btnGuardadAsistencia = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbotipocarga = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardadAsistencia
            // 
            this.btnGuardadAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardadAsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardadAsistencia.Location = new System.Drawing.Point(245, 87);
            this.btnGuardadAsistencia.Name = "btnGuardadAsistencia";
            this.btnGuardadAsistencia.Size = new System.Drawing.Size(129, 46);
            this.btnGuardadAsistencia.TabIndex = 62;
            this.btnGuardadAsistencia.Text = "Guardar";
            this.btnGuardadAsistencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardadAsistencia.UseVisualStyleBackColor = true;
            this.btnGuardadAsistencia.Click += new System.EventHandler(this.btnGuardadAsistencia_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(12, 87);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(129, 46);
            this.btnCerrar.TabIndex = 61;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbotipocarga);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(362, 69);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Carga";
            // 
            // cbotipocarga
            // 
            this.cbotipocarga.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbotipocarga.FormattingEnabled = true;
            this.cbotipocarga.Location = new System.Drawing.Point(54, 28);
            this.cbotipocarga.Name = "cbotipocarga";
            this.cbotipocarga.Size = new System.Drawing.Size(302, 21);
            this.cbotipocarga.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 62;
            this.label1.Text = "Tipo :";
            // 
            // frmGuardarPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 141);
            this.Controls.Add(this.btnGuardadAsistencia);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmGuardarPlanilla";
            this.Text = "frmGuardarPlanilla";
            this.Load += new System.EventHandler(this.frmGuardarPlanilla_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardadAsistencia;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbotipocarga;
        private System.Windows.Forms.Label label1;
    }
}