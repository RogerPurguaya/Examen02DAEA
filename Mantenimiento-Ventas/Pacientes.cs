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
    public partial class Pacientes : Form
    {
        public Pacientes()
        {
            InitializeComponent();
        }

        public String IDHospital = "";
        SqlConnection conn;

        private void btnListar_Click(object sender, EventArgs e)
        {
            conn.Open();
            listarTabla();
        }

        private void Pacientes_Load(object sender, EventArgs e)
        {
            String str = "Server=.;DataBase=sistema;Integrated Security=true;";
            conn = new SqlConnection(str);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT hos_codigo, hos_nombre FROM hospital;", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            String codigo = "";
            while (reader.Read())
            {
                codigo = (String)reader.GetValue(0);
                cmbHospital.Items.Add(codigo);
            }
            cmbHospital.SelectedItem = this.IDHospital;
            conn.Close();

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            conn.Open();
            String sp = "INSERT INTO paciente (pac_codigo, pac_hospital, pac_dni," +
                " pac_nomape, pac_fecnac, pac_direc, pac_fono" +
                ") VALUES (" +
                "'" + generateID() + "' , " +
                "'" + cmbHospital.SelectedItem.ToString() + "' , " +
                "'" + txtDNI.Text + "' , " +
                "'" + txtNombre.Text + "' , " +
                "'" + txtFechaNac.Text + "' , " +
                "'" + txtDireccion.Text + "' , " +
                "'" + txtTelefono.Text + "');";

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

            String sql = "UPDATE paciente SET " +
                "pac_dni='" + txtDNI.Text + "' ," +
                "pac_hospital='" + cmbHospital.SelectedItem.ToString() + "' ," +
                "pac_nomape='" + txtNombre.Text + "' ," +
                "pac_fono='" + txtTelefono.Text + "' ," +
                "pac_direc='" + txtDireccion.Text + "' ," +
                "pac_fecnac='" + txtFechaNac.Text +
                "' WHERE pac_codigo = '" + txtID.Text + "';";

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
            //String sql = "DELETE paciente WHERE pac_codigo = '" + txtID.Text + "';";
            String sql = "UPDATE paciente SET " +
                "pac_activo = 0 WHERE pac_codigo = '" + txtID.Text + "'";
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

        private void listarTabla()
        {
            String sql = "SELECT * FROM paciente WHERE " +
                " pac_hospital ='"+this.IDHospital+"';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();
            conn.Close();
        }

        private void tableListado_SelectionChanged(object sender, EventArgs e)
        {
            if (tableListado.SelectedRows.Count > 0)
            {
                txtID.Text = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                cmbHospital.SelectedItem = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                txtDNI.Text = tableListado.SelectedRows[0].Cells[2].Value.ToString();
                txtNombre.Text = tableListado.SelectedRows[0].Cells[3].Value.ToString();
                txtFechaNac.Text = tableListado.SelectedRows[0].Cells[4].Value.ToString();
                txtDireccion.Text = tableListado.SelectedRows[0].Cells[5].Value.ToString();
                txtTelefono.Text = tableListado.SelectedRows[0].Cells[6].Value.ToString();
            }
        }

        private String generateID()
        {
            String sql = "SELECT TOP 1 pac_codigo FROM paciente ORDER BY pac_codigo DESC;";

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
    }
}
