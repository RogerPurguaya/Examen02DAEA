namespace Mantenimiento_Ventas
{
    partial class ListaMedicos
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tableListado = new System.Windows.Forms.DataGridView();
            this.btnBuscarMedico = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tableListado)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Chocolate;
            this.btnCancelar.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(300, 51);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(114, 30);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.YellowGreen;
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(12, 51);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(141, 30);
            this.btnAdd.TabIndex = 38;
            this.btnAdd.Text = "Agregar Seleccionado";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // tableListado
            // 
            this.tableListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableListado.Location = new System.Drawing.Point(12, 87);
            this.tableListado.Name = "tableListado";
            this.tableListado.ReadOnly = true;
            this.tableListado.RowHeadersVisible = false;
            this.tableListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableListado.Size = new System.Drawing.Size(466, 285);
            this.tableListado.TabIndex = 37;
            this.tableListado.SelectionChanged += new System.EventHandler(this.tableListado_SelectionChanged);
            // 
            // btnBuscarMedico
            // 
            this.btnBuscarMedico.BackColor = System.Drawing.Color.YellowGreen;
            this.btnBuscarMedico.Enabled = false;
            this.btnBuscarMedico.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarMedico.Location = new System.Drawing.Point(165, 6);
            this.btnBuscarMedico.Name = "btnBuscarMedico";
            this.btnBuscarMedico.Size = new System.Drawing.Size(120, 30);
            this.btnBuscarMedico.TabIndex = 36;
            this.btnBuscarMedico.Text = "Buscar Médico";
            this.btnBuscarMedico.UseVisualStyleBackColor = false;
            this.btnBuscarMedico.Click += new System.EventHandler(this.btnBuscarMedico_Click);
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnListar.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Location = new System.Drawing.Point(165, 51);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(120, 30);
            this.btnListar.TabIndex = 35;
            this.btnListar.Text = "Listar todo";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(147, 20);
            this.txtSearch.TabIndex = 34;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ListaMedicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mantenimiento_Ventas.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(490, 382);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tableListado);
            this.Controls.Add(this.btnBuscarMedico);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.txtSearch);
            this.Name = "ListaMedicos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista Medicos";
            this.Load += new System.EventHandler(this.ListaMedicos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tableListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView tableListado;
        private System.Windows.Forms.Button btnBuscarMedico;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.TextBox txtSearch;
    }
}