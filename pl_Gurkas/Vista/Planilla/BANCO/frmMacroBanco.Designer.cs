
namespace pl_Gurkas.Vista.Planilla.BANCO
{
    partial class frmMacroBanco
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnGenerarMacros = new System.Windows.Forms.Button();
            this.dgvBancoExcel = new System.Windows.Forms.DataGridView();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cboBanco = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBancoExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 81);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(337, 16);
            this.progressBar1.TabIndex = 56;
            // 
            // btnGenerarMacros
            // 
            this.btnGenerarMacros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarMacros.Image = global::pl_Gurkas.Properties.Resources.asistencias_32;
            this.btnGenerarMacros.Location = new System.Drawing.Point(353, 9);
            this.btnGenerarMacros.Name = "btnGenerarMacros";
            this.btnGenerarMacros.Size = new System.Drawing.Size(68, 88);
            this.btnGenerarMacros.TabIndex = 55;
            this.btnGenerarMacros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarMacros.UseVisualStyleBackColor = true;
            this.btnGenerarMacros.Click += new System.EventHandler(this.btnGenerarMacros_Click);
            // 
            // dgvBancoExcel
            // 
            this.dgvBancoExcel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBancoExcel.Location = new System.Drawing.Point(137, 36);
            this.dgvBancoExcel.Name = "dgvBancoExcel";
            this.dgvBancoExcel.Size = new System.Drawing.Size(210, 39);
            this.dgvBancoExcel.TabIndex = 54;
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::pl_Gurkas.Properties.Resources.Excel_32;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(63, 28);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(41, 48);
            this.btnExcel.TabIndex = 53;
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrar.Image = global::pl_Gurkas.Properties.Resources.salir_empleado_32;
            this.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrar.Location = new System.Drawing.Point(10, 29);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(47, 48);
            this.btnCerrar.TabIndex = 52;
            this.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cboBanco
            // 
            this.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBanco.FormattingEnabled = true;
            this.cboBanco.Location = new System.Drawing.Point(137, 9);
            this.cboBanco.Name = "cboBanco";
            this.cboBanco.Size = new System.Drawing.Size(210, 21);
            this.cboBanco.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Seleccione un Banco :";
            // 
            // frmMacroBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 106);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnGenerarMacros);
            this.Controls.Add(this.dgvBancoExcel);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.cboBanco);
            this.Controls.Add(this.label1);
            this.Name = "frmMacroBanco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMacroBanco";
            this.Load += new System.EventHandler(this.frmMacroBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBancoExcel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnGenerarMacros;
        private System.Windows.Forms.DataGridView dgvBancoExcel;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cboBanco;
        private System.Windows.Forms.Label label1;
    }
}