namespace Mantenimiento_Ventas
{
    partial class Consultas
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnListaMedicos = new System.Windows.Forms.Button();
            this.txtMedico = new System.Windows.Forms.TextBox();
            this.btnListaTriajes = new System.Windows.Forms.Button();
            this.btnListaConsultorios = new System.Windows.Forms.Button();
            this.txtConsultorio = new System.Windows.Forms.TextBox();
            this.txtTriaje = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label1234 = new System.Windows.Forms.Label();
            this.labeDNI = new System.Windows.Forms.Label();
            this.tableListado = new System.Windows.Forms.DataGridView();
            this.btnEiminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableListado)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnListaMedicos);
            this.groupBox1.Controls.Add(this.txtMedico);
            this.groupBox1.Controls.Add(this.btnListaTriajes);
            this.groupBox1.Controls.Add(this.btnListaConsultorios);
            this.groupBox1.Controls.Add(this.txtConsultorio);
            this.groupBox1.Controls.Add(this.txtTriaje);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtFecha);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label1234);
            this.groupBox1.Controls.Add(this.labeDNI);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(648, 161);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto";
            // 
            // btnListaMedicos
            // 
            this.btnListaMedicos.BackColor = System.Drawing.Color.YellowGreen;
            this.btnListaMedicos.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaMedicos.Location = new System.Drawing.Point(234, 26);
            this.btnListaMedicos.Name = "btnListaMedicos";
            this.btnListaMedicos.Size = new System.Drawing.Size(142, 30);
            this.btnListaMedicos.TabIndex = 30;
            this.btnListaMedicos.Text = "Ver Lista Médicos";
            this.btnListaMedicos.UseVisualStyleBackColor = false;
            this.btnListaMedicos.Click += new System.EventHandler(this.btnListaMedicos_Click);
            // 
            // txtMedico
            // 
            this.txtMedico.Location = new System.Drawing.Point(113, 32);
            this.txtMedico.Name = "txtMedico";
            this.txtMedico.ReadOnly = true;
            this.txtMedico.Size = new System.Drawing.Size(115, 20);
            this.txtMedico.TabIndex = 29;
            // 
            // btnListaTriajes
            // 
            this.btnListaTriajes.BackColor = System.Drawing.Color.YellowGreen;
            this.btnListaTriajes.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaTriajes.Location = new System.Drawing.Point(234, 116);
            this.btnListaTriajes.Name = "btnListaTriajes";
            this.btnListaTriajes.Size = new System.Drawing.Size(142, 30);
            this.btnListaTriajes.TabIndex = 28;
            this.btnListaTriajes.Text = "Ver Lista Triajes";
            this.btnListaTriajes.UseVisualStyleBackColor = false;
            this.btnListaTriajes.Click += new System.EventHandler(this.btnListaTriajes_Click);
            // 
            // btnListaConsultorios
            // 
            this.btnListaConsultorios.BackColor = System.Drawing.Color.YellowGreen;
            this.btnListaConsultorios.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListaConsultorios.Location = new System.Drawing.Point(234, 71);
            this.btnListaConsultorios.Name = "btnListaConsultorios";
            this.btnListaConsultorios.Size = new System.Drawing.Size(142, 30);
            this.btnListaConsultorios.TabIndex = 27;
            this.btnListaConsultorios.Text = "Ver Lista Consultorios";
            this.btnListaConsultorios.UseVisualStyleBackColor = false;
            this.btnListaConsultorios.Click += new System.EventHandler(this.btnListaConsultorios_Click);
            // 
            // txtConsultorio
            // 
            this.txtConsultorio.Location = new System.Drawing.Point(113, 77);
            this.txtConsultorio.Name = "txtConsultorio";
            this.txtConsultorio.ReadOnly = true;
            this.txtConsultorio.Size = new System.Drawing.Size(115, 20);
            this.txtConsultorio.TabIndex = 26;
            // 
            // txtTriaje
            // 
            this.txtTriaje.Location = new System.Drawing.Point(113, 122);
            this.txtTriaje.Name = "txtTriaje";
            this.txtTriaje.ReadOnly = true;
            this.txtTriaje.Size = new System.Drawing.Size(115, 20);
            this.txtTriaje.TabIndex = 25;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(397, 37);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(233, 63);
            this.txtDescripcion.TabIndex = 17;
            this.txtDescripcion.Text = "";
            // 
            // txtFecha
            // 
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtFecha.Location = new System.Drawing.Point(397, 123);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(115, 20);
            this.txtFecha.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(113, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Médico";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(394, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Descripción del diagnóstico:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(394, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(9, 32);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(82, 20);
            this.txtID.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label1234
            // 
            this.label1234.AutoSize = true;
            this.label1234.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1234.Location = new System.Drawing.Point(113, 59);
            this.label1234.Name = "label1234";
            this.label1234.Size = new System.Drawing.Size(68, 15);
            this.label1234.TabIndex = 1;
            this.label1234.Text = "Consultorio:";
            // 
            // labeDNI
            // 
            this.labeDNI.AutoSize = true;
            this.labeDNI.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeDNI.Location = new System.Drawing.Point(113, 104);
            this.labeDNI.Name = "labeDNI";
            this.labeDNI.Size = new System.Drawing.Size(42, 15);
            this.labeDNI.TabIndex = 2;
            this.labeDNI.Text = "Triaje:";
            // 
            // tableListado
            // 
            this.tableListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableListado.Location = new System.Drawing.Point(12, 189);
            this.tableListado.Name = "tableListado";
            this.tableListado.ReadOnly = true;
            this.tableListado.RowHeadersVisible = false;
            this.tableListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableListado.Size = new System.Drawing.Size(776, 252);
            this.tableListado.TabIndex = 6;
            this.tableListado.SelectionChanged += new System.EventHandler(this.tableListado_SelectionChanged);
            // 
            // btnEiminar
            // 
            this.btnEiminar.BackColor = System.Drawing.Color.Chocolate;
            this.btnEiminar.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEiminar.Location = new System.Drawing.Point(689, 138);
            this.btnEiminar.Name = "btnEiminar";
            this.btnEiminar.Size = new System.Drawing.Size(75, 30);
            this.btnEiminar.TabIndex = 13;
            this.btnEiminar.Text = "Eliminar";
            this.btnEiminar.UseVisualStyleBackColor = false;
            this.btnEiminar.Click += new System.EventHandler(this.btnEiminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.Chocolate;
            this.btnModificar.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.Location = new System.Drawing.Point(689, 102);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 30);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.Chocolate;
            this.btnAgregar.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(689, 66);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 30);
            this.btnAgregar.TabIndex = 11;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnListar
            // 
            this.btnListar.BackColor = System.Drawing.Color.Chocolate;
            this.btnListar.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListar.Location = new System.Drawing.Point(689, 30);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(75, 30);
            this.btnListar.TabIndex = 10;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = false;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // Consultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Mantenimiento_Ventas.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEiminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.tableListado);
            this.Controls.Add(this.groupBox1);
            this.Name = "Consultas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.Consultas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableListado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label1234;
        private System.Windows.Forms.Label labeDNI;
        private System.Windows.Forms.DataGridView tableListado;
        private System.Windows.Forms.Button btnEiminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Button btnListaMedicos;
        private System.Windows.Forms.TextBox txtMedico;
        private System.Windows.Forms.Button btnListaTriajes;
        private System.Windows.Forms.Button btnListaConsultorios;
        private System.Windows.Forms.TextBox txtConsultorio;
        private System.Windows.Forms.TextBox txtTriaje;
    }
}