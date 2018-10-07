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
    public partial class Hospitales : Form
    {
        public Hospitales()
        {
            InitializeComponent();
        }

        SqlConnection conn;

        private void Hospitales_Load(object sender, EventArgs e)
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
            String sql = "SELECT * FROM hospital";
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
            String sp = "INSERT INTO hospital ( hos_nombre, hos_direc, hos_fono, hos_ambul, hos_admin" +
                ") VALUES (" +
                "'" + txtNombre.Text + "' , " +
                "'" + txtDireccion.Text + "' , " +
                "'" + txtTelefono.Text + "' , " +
                "'" + txtAmbulancia.Text + "' , " +
                "'" + txtAdmin.Text +
                "'" + ");";

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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            conn.Open();

            String sql = "UPDATE hospital SET " +
                "hos_nombre='" + txtNombre.Text + "' ," +
                "hos_admin='" + txtAdmin.Text + "' ," +
                "hos_ambul='" + txtAmbulancia.Text + "' ," +
                "hos_fono='" + txtTelefono.Text + "' ," +
                "hos_direc='" + txtDireccion.Text + "' " +
                " WHERE hos_codigo = '" + txtID.Text + "';";

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
            String sql = "DELETE hospital WHERE hos_codigo = '" + txtID.Text + "';";

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
                txtNombre.Text = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                txtDireccion.Text = tableListado.SelectedRows[0].Cells[2].Value.ToString();
                txtTelefono.Text = tableListado.SelectedRows[0].Cells[3].Value.ToString();
                txtAmbulancia.Text = tableListado.SelectedRows[0].Cells[4].Value.ToString();
                txtAdmin.Text = tableListado.SelectedRows[0].Cells[5].Value.ToString();
            }
        }
    }
}
