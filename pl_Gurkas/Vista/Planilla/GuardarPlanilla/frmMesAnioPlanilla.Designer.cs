
namespace pl_Gurkas.Vista.Planilla.GuardarPlanilla
{
    partial class frmMesAnioPlanilla
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
            this.txtanio = new System.Windows.Forms.TextBox();
            this.txtmes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGuardadAsistencia
            // 
            this.btnGuardadAsistencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardadAsistencia.Image = global::pl_Gurkas.Properties.Resources.save_32_png_32;
            this.btnGuardadAsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardadAsistencia.Location = new System.Drawing.Point(165, 13);
            this.btnGuardadAsistencia.Name = "btnGuardadAsistencia";
            this.btnGuardadAsistencia.Size = new System.Drawing.Size(129, 46);
            this.btnGuardadAsistencia.TabIndex = 65;
            this.btnGuardadAsistencia.Text = "Guardar";
            this.btnGuardadAsistencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardadAsistencia.UseVisualStyleBackColor = true;
            this.btnGuardadAsistencia.Click += new System.EventHandler(this.btnGuardadAsistencia_Click);
            // 
            // txtanio
            // 
            this.txtanio.Location = new System.Drawing.Point(59, 44);
            this.txtanio.Name = "txtanio";
            this.txtanio.Size = new System.Drawing.Size(100, 20);
            this.txtanio.TabIndex = 64;
            // 
            // txtmes
            // 
            this.txtmes.Location = new System.Drawing.Point(59, 12);
            this.txtmes.Name = "txtmes";
            this.txtmes.Size = new System.Drawing.Size(100, 20);
            this.txtmes.TabIndex = 63;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 62;
            this.label2.Text = "Año :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 61;
            this.label1.Text = "Mes :";
            // 
            // frmMesAnioPlanilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 76);
            this.Controls.Add(this.btnGuardadAsistencia);
            this.Controls.Add(this.txtanio);
            this.Controls.Add(this.txtmes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmMesAnioPlanilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMesAnioPlanilla";
            this.Load += new System.EventHandler(this.frmMesAnioPlanilla_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardadAsistencia;
        private System.Windows.Forms.TextBox txtanio;
        private System.Windows.Forms.TextBox txtmes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}