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
    public partial class Proveedores : Form
    {
        SqlConnection conn;

        public Proveedores()
        {
            InitializeComponent();
        }

        private void Proveedores_Load(object sender, EventArgs e)
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
            String sql = "SELECT * FROM proveedor WHERE prv_activo = 1;";
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
            String sp = "INSERT INTO proveedor (prv_codigo, prv_nombre, prv_ubicacion) VALUES (" +
                "'" + generateID() + "' , " +
                "'" + txtNombre.Text + "' , " +
                "'" + txtUbicacion.Text + "' );";
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

            String sql = "UPDATE proveedor SET " +
                "prv_nombre='" + txtNombre.Text + "' ," +
                "prv_ubicacion='" + txtUbicacion.Text + "' " +
                " WHERE prv_codigo = '" + txtID.Text + "';";

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            conn.Open();
            //String sql = "DELETE proveedor WHERE prv_codigo = '" + txtID.Text + "';";
            String sql = "UPDATE proveedor SET " +
                "prv_activo = 0 WHERE prv_codigo = '" + txtID.Text + "'";
            Console.WriteLine(sql);
            SqlCommand query = new SqlCommand(sql, conn);
            query.CommandType = CommandType.Text;

            try
            {
                int res = query.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("El elemento se ha eliminado correctamente!");
                    listarTabla();
                }
                else
                {
                    MessageBox.Show("No se ha encontrado el registro!");
                }
            }
            catch (Exception err)
            {
                //MessageBox.Show("Ocurrió un penoso error: " + err.ToString());
                MessageBox.Show("Ocurrió un penoso error: No se puede eliminar el proveedor" +
                    " porque otros registros dependen de él.");
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
                txtNombre.Text = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                txtUbicacion.Text = tableListado.SelectedRows[0].Cells[2].Value.ToString();

            }
        }

        private String generateID ()
        {
            String sql = "SELECT TOP 1 prv_codigo FROM proveedor ORDER BY prv_codigo DESC;";
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            String id = (String) reader.GetValue(0);
            String prefix = id.Substring(0, 1);
            int newID = Int32.Parse(id.Substring(1)) + 1;

            if (newID < 99)
            {
                id = prefix + "0" + newID;
            }else
            {
                id = prefix + newID;
            }
            reader.Close();
            return id;
        }
    }
}
