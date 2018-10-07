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
    public partial class ListaMedicos : Form
    {
        public ListaMedicos()
        {
            InitializeComponent();
            btnAdd.DialogResult = DialogResult.OK;
        }

        SqlConnection conn;
        public String idMedico = "";
        public String IDHospital = "";

        private void ListaMedicos_Load(object sender, EventArgs e)
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
            String sql = "SELECT med_codigo as 'Código', med_nomape as 'Nomb. Médico'," +
                " med_dni as 'DNI', med_fecnac as 'Fecha Nacimiento', med_hospital as 'Hospital' FROM medico " +
                "WHERE med_hospital ='"+ this.IDHospital + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();
            conn.Close();
        }

        private void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            String parametro = txtSearch.Text;

            conn.Open();
            /*SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BuscarMedico";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Parametro";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = parametro;

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@Hospital";
            param2.SqlDbType = SqlDbType.Char;
            param2.Value = parametro;

            cmd.Parameters.Add(param);
            cmd.Parameters.Add(param2);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();*/

            String sql = "SELECT med_codigo as 'Código', med_nomape as 'Nomb. Médico'," +
                " med_dni as 'DNI', med_fecnac as 'Fecha Nacimiento', med_hospital as 'Hospital' FROM medico WHERE" +
                " (med_nomape like '%"+parametro+"%' or med_dni like '%"+parametro+"%'" +
                " or med_codigo like '%"+parametro+"%') AND med_hospital = '"+this.IDHospital+"';";
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
                idMedico = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                btnAdd.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                btnBuscarMedico.Enabled = true;
            }
            else
            {
                btnBuscarMedico.Enabled = false;
            }
        }
    }
}
