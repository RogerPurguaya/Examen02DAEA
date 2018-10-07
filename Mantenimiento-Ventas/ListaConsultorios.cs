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
    public partial class ListaConsultorios : Form
    {
        public ListaConsultorios()
        {
            InitializeComponent();
            btnAdd.DialogResult = DialogResult.OK;
        }

        SqlConnection conn;
        public String idConsultorio = "";
        public String IDHospital = "";

        private void ListaConsultorios_Load(object sender, EventArgs e)
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
            String sql = "SELECT cto_codigo as 'Codigo', cto_hospital as 'Cod. Hospital', " +
                " cto_piso as 'Piso', cto_numero as 'Número' FROM consultorio " +
                " WHERE cto_hospital ='"+ this.IDHospital +"';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();
            conn.Close();
        }

        private void btnBuscarConsultorio_Click(object sender, EventArgs e)
        {
            String parametro = txtSearch.Text;

            conn.Open();
            /*SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BuscarConsultorio";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

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
            String sql = "SELECT cto_codigo as 'Codigo', cto_hospital as 'Cod. Hospital', " +
                " cto_piso as 'Piso', cto_numero as 'Número' FROM consultorio" +
                " WHERE (cto_codigo like '%" + parametro + "%') AND " +
                " cto_hospital = '"+this.IDHospital+"';";
            Console.WriteLine(sql);
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
                idConsultorio = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                btnAdd.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                btnBuscarConsultorio.Enabled = true;
            }
            else
            {
                btnBuscarConsultorio.Enabled = false;
            }
        }

        
    }
}
