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
    public partial class ListaProveedores : Form
    {
        public ListaProveedores()
        {
            InitializeComponent();
            btnAdd.DialogResult = DialogResult.OK;
        }

        SqlConnection conn;
        public String idProveedor;

        private void ListaProveedores_Load(object sender, EventArgs e)
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
            String sql = "SELECT prv_codigo as 'Código', prv_nombre as 'Nombre', prv_ubicacion as 'Ubicación'" +
                " FROM proveedor WHERE prv_activo = 1;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();
            conn.Close();
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            String parametro = txtSearch.Text;

            conn.Open();
            String sql = "SELECT prv_codigo as 'Código', prv_nombre as 'Nombre', prv_ubicacion as 'Ubicación'" +
                " FROM proveedor WHERE " +
                "prv_codigo like '%" + parametro + "%' OR prv_nombre like '%" + parametro + "%'" +
                " OR prv_ubicacion like '%" + parametro + "%'; ";

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
                idProveedor = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                btnAdd.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!txtSearch.Text.Equals(""))
            {
                btnBuscarProveedor.Enabled = true;
            }
            else
            {
                btnBuscarProveedor.Enabled = false;
            }
        }
    }
}
