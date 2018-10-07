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
    public partial class Medicos : Form
    {
        public Medicos()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        public String IDHospital = "";

        private void Usuarios_Load(object sender, EventArgs e)
        {
            String str = "Server=.;DataBase=sistema;Integrated Security=true;";
            conn = new SqlConnection(str);

            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT hos_codigo, hos_nombre FROM hospital WHERE hos_activo = 1;", conn);
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            conn.Open();
            String sp = "INSERT INTO medico (med_codigo, med_hospital, med_dni, med_nomape," +
                " med_fecnac, med_sueldo, med_espec, med_fecini, " +
                " med_direc) VALUES ("+
                "'" + generateID() + "' , " +
                "'" + cmbHospital.SelectedItem.ToString() + "' , " +
                "'" + txtDNI.Text + "' , " +
                "'" + txtNombres.Text + "' , " +
                "'" + txtFechaNac.Text + "' , " +
                "'" + txtSueldo.Text + "' , " +
                "'" + txtEspecialidad.Text + "' , " +
                "'" + txtFechaInicio.Text + "' , " +
                "'" + txtDireccion.Text +
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

        private void tableListado_SelectionChanged(object sender, EventArgs e)
        {
            if (tableListado.SelectedRows.Count > 0)
            {
                txtID.Text        = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                cmbHospital.SelectedItem  = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                txtDNI.Text       = tableListado.SelectedRows[0].Cells[2].Value.ToString();
                txtNombres.Text   = tableListado.SelectedRows[0].Cells[3].Value.ToString();
                txtFechaNac.Text  = tableListado.SelectedRows[0].Cells[4].Value.ToString();
                txtSueldo.Text    = tableListado.SelectedRows[0].Cells[5].Value.ToString().Replace(',','.');
                txtEspecialidad.Text  = tableListado.SelectedRows[0].Cells[6].Value.ToString();
                txtFechaInicio.Text     = tableListado.SelectedRows[0].Cells[7].Value.ToString();
                txtDireccion.Text = tableListado.SelectedRows[0].Cells[8].Value.ToString();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            conn.Open();

            String sql = "UPDATE medico SET "   +
                "med_dni='"       + txtDNI.Text      + "' ," +
                "med_hospital='"  + cmbHospital.SelectedItem.ToString() + "' ," +
                "med_nomape='"    + txtNombres.Text  + "' ," +
                "med_sueldo='"    + txtSueldo.Text   + "' ," +
                "med_espec='"     + txtEspecialidad.Text  + "' ," +
                "med_fecini='"    + txtFechaInicio.Text   + "' ," +
                "med_direc='"     + txtDireccion.Text + "' ," +
                "med_fecnac='"    + txtFechaNac.Text  + 
                "' WHERE med_codigo = '" + txtID.Text  + "';";

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
            //String sql = "DELETE medico WHERE med_codigo = '" + txtID.Text + "';";
            String sql = "UPDATE medico SET " +
                "med_activo = 0 WHERE med_codigo = '" + txtID.Text + "'";
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

        private void listarTabla () 
        {
            String sql = "SELECT * FROM medico WHERE med_hospital='"+ this.IDHospital + "';";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();
            table.Load(reader);
            tableListado.DataSource = table;
            tableListado.Refresh();
            conn.Close();
        }

        private String generateID()
        {
            String sql = "SELECT TOP 1 med_codigo FROM medico ORDER BY med_codigo DESC;";

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
