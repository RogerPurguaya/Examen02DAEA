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
    public partial class Enfermeras : Form
    {
        public Enfermeras()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        public String Cod_hospital = "";

        private void Productos_Load(object sender, EventArgs e)
        {
 
            String str = "Server=.;DataBase=sistema;Integrated Security=true;";
            conn = new SqlConnection(str);

            conn.Open();
            
            SqlCommand cmd = new SqlCommand("SELECT hos_codigo, hos_nombre FROM hospital WHERE hos_activo = 1;", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            String codigo = "";
            while (reader.Read())
            {
                codigo = (String) reader.GetValue(0);
                cmbHospital.Items.Add(codigo);
            }
            cmbHospital.SelectedItem = this.Cod_hospital;
            conn.Close();
        }


        private void btnListar_Click(object sender, EventArgs e)
        {
            conn.Open();
            listarTabla();
        }

        private void listarTabla()
        {
            
            String sql = "SELECT enf_codigo, enf_dni, enf_nomape, enf_fecnac, " +
                "enf_fecini, enf_direc, enf_sueldo, enf_hospital ,enf_activo " +
                "FROM enfermera WHERE " +
                " enf_hospital = '"+ this.Cod_hospital +"' AND enf_activo = 1;";
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
            String sp = "INSERT INTO enfermera (enf_codigo, enf_hospital, enf_dni, " +
                "enf_nomape, enf_fecnac, enf_sueldo, enf_direc, enf_fecini) VALUES (" +
                "'" + generateID() + "' , " +
                "'" + cmbHospital.SelectedItem.ToString() + "' , " +
                "'" + txtDNI.Text + "' , " +
                "'" + txtNombre.Text + "' , " +
                "'" + txtFecNac.Text + "' , " +
                "'" + txtSueldo.Text + "' , " +
                "'" + txtDireccion.Text + "' , " +
                "'" + txtFecInicio.Text + "' );";

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

            String sql = "UPDATE enfermera SET " +
                "enf_dni='" + txtDNI.Text + "' ," +
                "enf_nomape='" + txtNombre.Text + "' ," +
                "enf_fecnac='" + txtFecNac.Text + "' ," +
                "enf_sueldo='" + txtSueldo.Text + "' ," +
                "enf_direc='" + txtDireccion.Text + "' ," +
                "enf_fecini='" + txtFecInicio.Text + "' ," +
                "enf_hospital='" + cmbHospital.SelectedItem.ToString() + "'" +
                " WHERE enf_codigo = '" + txtID.Text + "';";

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

        private void tableListado_SelectionChanged(object sender, EventArgs e)
        {
            if (tableListado.SelectedRows.Count > 0)
            {
                txtID.Text      = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                txtDNI.Text     = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                txtNombre.Text  = tableListado.SelectedRows[0].Cells[2].Value.ToString();
                txtFecNac.Text  = tableListado.SelectedRows[0].Cells[3].Value.ToString();
                txtFecInicio.Text = tableListado.SelectedRows[0].Cells[4].Value.ToString();
                txtDireccion.Text = tableListado.SelectedRows[0].Cells[5].Value.ToString();
                txtSueldo.Text  = tableListado.SelectedRows[0].Cells[6].Value.ToString().Replace(",", "."); ;
                cmbHospital.SelectedItem = tableListado.SelectedRows[0].Cells[7].Value.ToString();

            }
        }

        private void btnEiminar_Click(object sender, EventArgs e)
        {
            conn.Open();
            //String sql = "DELETE enfermera WHERE id = '" + txtID.Text + "';";
            String sql = "UPDATE enfermera SET " +
                "enf_activo = 0 WHERE enf_codigo = '" + txtID.Text + "'";
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
            String sql = "SELECT TOP 1 enf_codigo FROM enfermera ORDER BY enf_codigo DESC;";

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
                return "E001";
            }
        }
    }
}
