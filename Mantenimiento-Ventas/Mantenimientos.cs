using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Mantenimiento_Ventas
{
    public partial class Mantenimientos : Form
    {
        public Mantenimientos()
        {
            InitializeComponent();
        }

        String HospitalSelected = "";

        Pacientes paciente;
        Medicos medico;
        Enfermeras enfermera;
        Proveedores proveedor;
        Hospitales hospital;
        Consultas consulta;
        Consultorios consultorio;
        Triajes triaje;
        Medicinas medicina;
        TiposPago tipos;
        Pagos pago;

        SqlConnection conn;

        private void Mantenimientos_Load(object sender, EventArgs e)
        {
            String str = "Server=.;DataBase=sistema;Integrated Security=true;";
            conn = new SqlConnection(str);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT hos_codigo, hos_nombre FROM hospital;", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            /*String codigo = "";
            while (reader.Read())
            {
                codigo = (String)reader.GetValue(0);
                cmbHospital.Items.Add(codigo);
            }
            cmbHospital.SelectedIndex = 0;*/
            DataTable table = new DataTable();
            table.Load(reader);
            cmbHospital.DataSource = table;
            cmbHospital.DisplayMember = "hos_nombre";
            cmbHospital.ValueMember = "hos_codigo";

            conn.Close();
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            medico = new Medicos();
            medico.IDHospital = this.HospitalSelected;
            medico.Show();
        }

        private void btnEnfermeras_Click(object sender, EventArgs e)
        {
            enfermera = new Enfermeras();
            enfermera.Cod_hospital = this.HospitalSelected;
            enfermera.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            proveedor = new Proveedores();
            proveedor.Show();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            consulta = new Consultas();
            consulta.IDHospital = this.HospitalSelected; 
            consulta.Show();
        }


        private void btnConsultorio_Click(object sender, EventArgs e)
        {
            consultorio = new Consultorios();
            consultorio.IDHospital = this.HospitalSelected;
            consultorio.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            medicina = new Medicinas();
            medicina.Show();
        }

        private void btnTriaje_Click(object sender, EventArgs e)
        {
            triaje = new Triajes();
            triaje.IDHospital = this.HospitalSelected; 
            triaje.Show();
        }

        private void btnPaciente_Click(object sender, EventArgs e)
        {
            paciente = new Pacientes();
            paciente.IDHospital = this.HospitalSelected;
            paciente.Show();
        }

        private void menuTiposPago_Click(object sender, EventArgs e)
        {
            tipos = new TiposPago();
            tipos.Show();
        }

        private void cmbHospital_SelectedValueChanged(object sender, EventArgs e)
        {
            this.HospitalSelected = cmbHospital.SelectedValue.ToString();
        }

        private void pagarConsultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pago = new Pagos();
            pago.IDHospital = this.HospitalSelected;
            pago.Show();
        }

        private void hospitalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hospital = new Hospitales();
            hospital.Show();
        }

        private void menuProveedores_Click(object sender, EventArgs e)
        {
            proveedor = new Proveedores();
            proveedor.Show();
        }

        private void medicinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            medicina = new Medicinas();
            medicina.Show();
        }
    }
}
