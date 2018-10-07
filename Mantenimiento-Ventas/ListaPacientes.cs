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
    public partial class ListaPacientes : Form
    {
        public ListaPacientes()
        {
            InitializeComponent();
            btnAdd.DialogResult = DialogResult.OK;
        }
        SqlConnection conn;
        public String idPaciente = "";
        public String IDHospital = "";

        private void ListaPacientes_Load(object sender, EventArgs e)
        {
            String str = "Server=.;DataBase=sistema;Integrated Security=true;";
            conn = new SqlConnection(str);
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            conn.Open();
            listarTabla();
        }

        private void listarTabla()
        {
            String sql = "SELECT pac_codigo as 'Código', pac_nomape as 'Nombre'," +
                " pac_dni as 'DNI', pac_fecnac as 'Fecha Nacimiento', pac_hospital as 'Hospital' " +
                " FROM paciente WHERE pac_hospital ='"+this.IDHospital+"';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();
            conn.Close();
        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            conn.Open();
            String parametro = txtSearch.Text;

            /*SqlCommand cmd   = new SqlCommand();
            cmd.CommandText  = "BuscarPaciente";
            cmd.CommandType  = CommandType.StoredProcedure;
            cmd.Connection   = conn;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Parametro";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = parametro;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();*/

            String sql = "SELECT pac_codigo as 'Código', pac_nomape as 'Nombre', pac_dni as 'DNI', pac_fecnac as 'Fecha Nacimiento'" +
                " , pac_hospital as 'Hospital' FROM paciente WHERE (pac_nomape like '%" + parametro+"%'" +
                " or pac_dni like '%"+parametro+"%' or pac_codigo like '%"+parametro+"%') AND " +
                " pac_hospital ='"+this.IDHospital+"';";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();

            conn.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            this.Close();
        }

        private void tableListado_SelectionChanged(object sender, EventArgs e)
        {
            if (tableListado.SelectedRows.Count > 0)
            {
                idPaciente = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                btnAdd.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                btnBuscarPaciente.Enabled = true;
            }
            else
            {
                btnBuscarPaciente.Enabled = false;
            }
        }
    }
}
