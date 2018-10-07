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
    public partial class ListaEnfermeras : Form
    {
        public ListaEnfermeras()
        {
            InitializeComponent();
            btnAdd.DialogResult = DialogResult.OK;
        }

        SqlConnection conn;
        public String idEnfermera = "";
        public String IDHospital = "";

        private void ListaEnfermeras_Load(object sender, EventArgs e)
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
            String sql = "SELECT enf_codigo as 'Código', enf_nomape as 'Nombres', enf_dni as 'DNI'," +
                " enf_fecnac as 'Fecha Nacimiento', enf_hospital as 'Hospital'" +
                " FROM enfermera WHERE enf_hospital ='"+this.IDHospital+"';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();
            conn.Close();
        }

        private void btnBuscarEnfermera_Click(object sender, EventArgs e)
        {
            String parametro = txtSearch.Text;

            conn.Open();
            /* SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BuscarEnfermera";
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

            String sql = "SELECT enf_codigo as 'Código', enf_nomape as 'Nombres', enf_dni as 'DNI'," +
                " enf_fecnac as 'Fecha Nacimiento', enf_hospital as 'Hospital'" +
                " FROM enfermera WHERE (enf_nomape like '%" + parametro + "%' or" +
                " enf_dni like '%" + parametro + "%' or enf_codigo like '%" + parametro + "%') " +
                " AND enf_hospital ='" +this.IDHospital+"';" ;

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
                idEnfermera = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                btnAdd.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                btnBuscarEnfermera.Enabled = true;
            }
            else
            {
                btnBuscarEnfermera.Enabled = false;
            }
        }
    }
}
