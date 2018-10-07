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
    public partial class Consultorios : Form
    {
        public Consultorios()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        public String IDHospital = "";

        private void Consultorios_Load(object sender, EventArgs e)
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

        private void btnListar_Click(object sender, EventArgs e)
        {
            conn.Open();
            listarTabla();
        }

        private void listarTabla()
        {
            String sql = "SELECT cto_codigo as 'Código', cto_hospital as 'Hospital', cto_piso as 'Piso'," +
                " cto_numero as 'Número'" +
                "FROM consultorio WHERE " +
                " cto_activo = 1 AND cto_hospital ='"+this.IDHospital+"';";
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
            String sp = "INSERT INTO consultorio (cto_codigo, cto_hospital, cto_piso, " +
                "cto_numero) VALUES (" +
                "'" + generateID() + "' , " +
                "'" + cmbHospital.SelectedItem.ToString() + "' , " +
                "'" + txtPiso.Text + "' , " +
                "'" + txtNumero.Text + "' );";

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

            String sql = "UPDATE consultorio SET " +
                "cto_piso='" + txtPiso.Text + "' ," +
                "cto_numero='" + txtNumero.Text + "' ," +
                "cto_hospital='" + cmbHospital.SelectedItem.ToString() + "'" +
                " WHERE cto_codigo = '" + txtID.Text + "';";

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
            //String sql = "DELETE consultorio WHERE id = '" + txtID.Text + "';";
            String sql = "UPDATE consultorio SET " +
                "cto_activo = 0 WHERE cto_codigo = '" + txtID.Text + "'";
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
            String sql = "SELECT TOP 1 cto_codigo FROM consultorio ORDER BY cto_codigo DESC;";

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
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

        private void tableListado_SelectionChanged(object sender, EventArgs e)
        {
            if (tableListado.SelectedRows.Count > 0)
            {
                txtID.Text = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                cmbHospital.SelectedItem = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                txtPiso.Text = tableListado.SelectedRows[0].Cells[2].Value.ToString();
                txtNumero.Text = tableListado.SelectedRows[0].Cells[3].Value.ToString();
            }
        }
    }
}

