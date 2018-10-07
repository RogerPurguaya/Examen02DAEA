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
    public partial class ListaTriajes : Form
    {
        public ListaTriajes()
        {
            InitializeComponent();
            btnAdd.DialogResult = DialogResult.OK;
        }

        SqlConnection conn;
        public String idTriaje = "";
        public String IDHospital = "";

        private void ListaTriajes_Load(object sender, EventArgs e)
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
            String sql = "select t.trj_codigo as 'Código', p.pac_codigo as 'Cod. Paciente'," +
                " p.pac_nomape as 'Nomb. Paciente', e.enf_codigo as 'Cod. Triaje'," +
                " e.enf_nomape as 'Nomb. Triaje', t.trj_fechora as 'Fecha' from" +
                " triaje t, enfermera e, paciente p WHERE e.enf_codigo = t.trj_enfermera" +
                " AND t.trj_paciente = p.pac_codigo AND t.trj_activo = 1 AND e.enf_hospital ='" + this.IDHospital+"';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();
            conn.Close();
        }

        private void btnBuscarTriaje_Click(object sender, EventArgs e)
        {
            String parametro = txtSearch.Text;

            conn.Open();
            /*SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BuscarTriaje";
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
            String sql = "select t.trj_codigo as 'Código', p.pac_codigo as 'Cod. Paciente'," +
                " p.pac_nomape as 'Nomb. Paciente', e.enf_codigo as 'Cod. Triaje'," +
                " e.enf_nomape as 'Nomb. Triaje', t.trj_fechora as 'Fecha' from" +
                " triaje t, enfermera e, paciente p WHERE (e.enf_codigo = t.trj_enfermera" +
                " AND t.trj_paciente = p.pac_codigo AND t.trj_activo = 1 AND e.enf_hospital ='"+ this.IDHospital +"') AND " +
                "(t.trj_codigo like '%"+parametro+ "%' OR e.enf_nomape like '%" + parametro + "%'" +
                " OR p.pac_nomape like '%" + parametro + "%'); ";

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
                idTriaje = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                btnAdd.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                btnBuscarTriaje.Enabled = true;
            }
            else
            {
                btnBuscarTriaje.Enabled = false;
            }
        }
    }
}
