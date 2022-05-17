
namespace pl_Gurkas.Vista.Operaciones.Unidad
{
    partial class frmActivarUnidad
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
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.cboUnidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGuardadAsistencia
            // 
            this.btnGuardadAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardadAsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardadAsistencia.Location = new System.Drawing.Point(453, 30);
            this.btnGuardadAsistencia.Name = "btnGuardadAsistencia";
            this.btnGuardadAsistencia.Size = new System.Drawing.Size(106, 46);
            this.btnGuardadAsistencia.TabIndex = 15;
            this.btnGuardadAsistencia.Text = "Guardar";
            this.btnGuardadAsistencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardadAsistencia.UseVisualStyleBackColor = true;
            this.btnGuardadAsistencia.Click += new System.EventHandler(this.btnGuardadAsistencia_Click);
            // 
            // cboEstado
            // 
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(102, 60);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(325, 21);
            this.cboEstado.TabIndex = 14;
            // 
            // cboUnidad
            // 
            this.cboUnidad.FormattingEnabled = true;
            this.cboUnidad.Location = new System.Drawing.Point(102, 24);
            this.cboUnidad.Name = "cboUnidad";
            this.cboUnidad.Size = new System.Drawing.Size(325, 21);
            this.cboUnidad.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Estado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Unidad";
            // 
            // frmActivarUnidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 105);
            this.Controls.Add(this.btnGuardadAsistencia);
            this.Controls.Add(this.cboEstado);
            this.Controls.Add(this.cboUnidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmActivarUnidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "..::Activar Unidad ::..";
            this.Load += new System.EventHandler(this.frmActivarUnidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardadAsistencia;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}