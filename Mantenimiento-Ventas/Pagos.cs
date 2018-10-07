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
    public partial class Pagos : Form
    {
        public Pagos()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        ListaPacientes listaPac;
        public String IDHospital = "";

        private void Pagos_Load(object sender, EventArgs e)
        {
            String str = "Server=.;DataBase=sistema;Integrated Security=true;";
            conn = new SqlConnection(str);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT tpg_codigo, tpg_tipo FROM tipo_pago;", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            int codigo;
            while (reader.Read())
            {
                codigo = (int)reader.GetValue(0);
                cmbTipo.Items.Add(codigo);
            }
            cmbTipo.SelectedIndex = 0;
            conn.Close();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            conn.Open();
            listarTabla();
        }

        private void listarTabla()
        {

            String sql = "SELECT pgo_codigo, pgo_paciente, pgo_tipo, pgo_monto, " +
                "pgo_fecha FROM pago WHERE " +
                " pgo_activo = 1;";
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
            String sp = "INSERT INTO pago (pgo_codigo, pgo_paciente, pgo_tipo, " +
                "pgo_monto, pgo_fecha) VALUES (" +
                "'" + generateID() + "' , " +
                "'" + txtPaciente.Text + "' , " +
                "'" + cmbTipo.SelectedItem.ToString() + "' , " +
                "'" + txtMonto.Text + "' , " +
                "'" + txtFecha.Text + "' );";

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

            String sql = "UPDATE pago SET " +
                "pgo_paciente='" + txtPaciente.Text + "' ," +
                "pgo_tipo='" + cmbTipo.SelectedItem.ToString() + "' ," +
                "pgo_monto='" + txtMonto.Text + "' ," +
                "pgo_fecha='" + txtFecha.Text + "' " +
                " WHERE pgo_codigo = '" + txtID.Text + "';";

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
            //String sql = "DELETE pago WHERE id = '" + txtID.Text + "';";
            String sql = "UPDATE pago SET " +
                "pgo_activo = 0 WHERE pgo_codigo = '" + txtID.Text + "'";
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

        private String generateID()
        {
            String sql = "SELECT TOP 1 pgo_codigo FROM pago ORDER BY pgo_codigo DESC;";

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
                return "P001";
            }
        }

        private void btnListaPacientes_Click(object sender, EventArgs e)
        {
            listaPac = new ListaPacientes();
            listaPac.IDHospital = this.IDHospital;
            DialogResult res = listaPac.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtPaciente.Text = listaPac.idPaciente;
            }
        }

        private void tableListado_SelectionChanged(object sender, EventArgs e)
        {
            if (tableListado.SelectedRows.Count > 0)
            {
                txtID.Text = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                txtPaciente.Text = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                cmbTipo.SelectedItem = tableListado.SelectedRows[0].Cells[2].Value.ToString();
                txtMonto.Text = tableListado.SelectedRows[0].Cells[3].Value.ToString().Replace(",", "."); ;
                txtFecha.Text = tableListado.SelectedRows[0].Cells[4].Value.ToString();
            }
        }
    }
}
