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
    public partial class Medicinas : Form
    {
        public Medicinas()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        ListaProveedores listaPro;

        private void Medicinas_Load(object sender, EventArgs e)
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
            String sql = "SELECT mdc_codigo, mdc_proveedor, mdc_nomcom, mdc_nomgen, " +
                "mdc_presentacion, mdc_cantidad, mdc_precio FROM medicina " +
                " WHERE mdc_activo = 1";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();
            conn.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            conn.Open();
            String sp = "INSERT INTO medicina (mdc_codigo, mdc_proveedor, mdc_nomcom, " +
                "mdc_nomgen, mdc_presentacion, mdc_cantidad, mdc_precio) VALUES (" +
                "'" + generateID() + "' , " +
                "'" + txtProveedor.Text + "' , " +
                "'" + txtComercial.Text + "' , " +
                "'" + txtGenerico.Text + "' , " +
                "'" + txtPresentacion.Text + "' , " +
                "'" + txtCantidad.Text + "' , " +
                "'" + txtPrecio.Text + "' );";

            Console.WriteLine(sp);

            SqlCommand cmd = new SqlCommand(sp, conn);
            cmd.CommandType = CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Se ha registrado correctamente: ");
                listarTabla();
            }
            catch (Exception err)
            {
                MessageBox.Show("Ocurrió un penoso error: " + err.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            conn.Open();

            String sql = "UPDATE medicina SET " +
                "mdc_proveedor='" + txtProveedor.Text + "' ," +
                "mdc_nomcom='" + txtComercial.Text + "' ," +
                "mdc_nomgen='" + txtGenerico.Text + "' ," +
                "mdc_presentacion='" + txtPresentacion.Text + "' ," +
                "mdc_cantidad='" + txtCantidad.Text + "' ," +
                "mdc_precio='" + txtPrecio.Text + "'" +
                " WHERE mdc_codigo = '" + txtID.Text + "';";

            Console.WriteLine(sql);
            SqlCommand query = new SqlCommand(sql, conn);
            query.CommandType = CommandType.Text;

            try
            {
                int res = query.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("El elemento se ha modificado correctamente!");
                    listarTabla();
                }
                else
                {
                    MessageBox.Show("NO se ha afectado ningún registro!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Ocurrió un penoso error: " + err.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnEiminar_Click(object sender, EventArgs e)
        {
            conn.Open();
            //String sql = "DELETE medicina WHERE id = '" + txtID.Text + "';";
            String sql = "UPDATE medicina SET " +
                "mdc_activo = 0 WHERE mdc_codigo = '" + txtID.Text + "'";
            Console.WriteLine(sql);
            SqlCommand query = new SqlCommand(sql, conn);
            query.CommandType = CommandType.Text;

            try
            {
                int res = query.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("El elemento se ha dado de baja correctamente!");
                    listarTabla();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el registro!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Ocurrió un penoso error: " + err.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void tableListado_SelectionChanged(object sender, EventArgs e)
        {
            if (tableListado.SelectedRows.Count > 0)
            {
                txtID.Text = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                txtProveedor.Text = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                txtComercial.Text = tableListado.SelectedRows[0].Cells[2].Value.ToString();
                txtGenerico.Text = tableListado.SelectedRows[0].Cells[3].Value.ToString();
                txtPresentacion.Text = tableListado.SelectedRows[0].Cells[4].Value.ToString();
                txtCantidad.Text = tableListado.SelectedRows[0].Cells[5].Value.ToString();
                txtPrecio.Text = tableListado.SelectedRows[0].Cells[6].Value.ToString().Replace(",", "."); ;
            }
        }

        private void btnListaProveedores_Click(object sender, EventArgs e)
        {
            listaPro = new ListaProveedores();
            DialogResult res = listaPro.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtProveedor.Text = listaPro.idProveedor;
            }
        }


        private String generateID()
        {
            String sql = "SELECT TOP 1 mdc_codigo FROM medicina ORDER BY mdc_codigo DESC;";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            try
            {
                String id = (String)reader.GetValue(0);
                String prefix = id.Substring(0, 1);
                int newID = Int32.Parse(id.Substring(1)) + 1;

                if (newID < 99)
                {
                    id = prefix + "0" + newID;
                }
                else
                {
                    id = prefix + newID;
                }
                reader.Close();
                return id;
            }
            catch (Exception)
            {
                reader.Close();
                return "M001";
            }
        }
    }
}
