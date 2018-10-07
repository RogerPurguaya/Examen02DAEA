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
    public partial class Triajes : Form
    {
        public Triajes()
        {
            InitializeComponent();
        }

        public String idPaciente;
        public String IDHospital = "";

        ListaPacientes listaPac;
        ListaEnfermeras listaEnf;
        SqlConnection conn;

        private void Triajes_Load(object sender, EventArgs e)
        {
            String str = "Server=.;DataBase=sistema;Integrated Security=true;";
            conn = new SqlConnection(str);
            cmbEstado.SelectedIndex = 0;
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

        private void btnListaEnfermeras_Click(object sender, EventArgs e)
        {
            listaEnf = new ListaEnfermeras();
            listaEnf.IDHospital = this.IDHospital;
            DialogResult res = listaEnf.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtEnfermera.Text = listaEnf.idEnfermera;
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            conn.Open();
            listarTabla();
        }

        private void listarTabla()
        {
            String sql = "SELECT t.trj_codigo, t.trj_paciente, t.trj_enfermera, t.trj_peso, " +
                "t.trj_presion, t.trj_talla, t.trj_temp, t.trj_fechora, t.trj_estado " +
                "FROM triaje t " +
                " WHERE t.trj_activo = 1";
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
            String sp = "INSERT INTO triaje (trj_codigo, trj_paciente, trj_enfermera, " +
                "trj_peso, trj_presion, trj_talla, trj_temp, trj_fechora, trj_estado) VALUES (" +
                "'" + generateID() + "' , " +
                "'" + txtPaciente.Text + "' , " +
                "'" + txtEnfermera.Text + "' , " +
                "'" + txtPeso.Text + "' , " +
                "'" + txtPresion.Text + "' , " +
                "'" + txtTalla.Text + "' , " +
                "'" + txtTemperatura.Text + "' , " +
                "'" + txtFecha.Text + "' , " +
                "'" + cmbEstado.SelectedItem.ToString() + "' );";

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

             String sql = "UPDATE triaje SET " +
                 "trj_paciente='" + txtPaciente.Text + "' ," +
                 "trj_enfermera='" + txtEnfermera.Text + "' ," +
                 "trj_peso='" + txtPeso.Text + "' ," +
                 "trj_presion='" + txtPresion.Text + "' ," +
                 "trj_talla='" + txtTalla.Text + "' ," +
                 "trj_temp='" + txtTemperatura.Text + "' ," +
                 "trj_fechora='" + txtFecha.Text + "' ," +
                 "trj_estado='" + cmbEstado.SelectedItem.ToString() + "'" +
                 " WHERE trj_codigo = '" + txtID.Text + "';";

            Console.WriteLine("la consulta: " + sql);
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
            //String sql = "DELETE triaje WHERE id = '" + txtID.Text + "';";
            String sql = "UPDATE triaje SET " +
                "trj_activo = 0 WHERE trj_codigo = '" + txtID.Text + "'";
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
                txtPaciente.Text = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                txtEnfermera.Text = tableListado.SelectedRows[0].Cells[2].Value.ToString();
                txtPeso.Text = tableListado.SelectedRows[0].Cells[3].Value.ToString().Replace(",",".");
                txtPresion.Text = tableListado.SelectedRows[0].Cells[4].Value.ToString().Replace(",", "."); ;
                txtTalla.Text = tableListado.SelectedRows[0].Cells[5].Value.ToString().Replace(",", "."); ;
                txtTemperatura.Text = tableListado.SelectedRows[0].Cells[6].Value.ToString().Replace(",", "."); ;
                txtFecha.Text = tableListado.SelectedRows[0].Cells[7].Value.ToString();
                cmbEstado.SelectedItem = tableListado.SelectedRows[0].Cells[8].Value.ToString();

            }
        }

        private String generateID()
        {
            String sql = "SELECT TOP 1 trj_codigo FROM triaje ORDER BY trj_codigo DESC;";

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
                return "T001";
            }
        }

        
    }
}
