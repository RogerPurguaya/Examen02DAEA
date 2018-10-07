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
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        ListaMedicos listaMed;
        ListaConsultorios listaCon;
        ListaTriajes listaTri;
        public String IDHospital = "";

        private void Consultas_Load(object sender, EventArgs e)
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
            String sql = "SELECT c.cta_codigo, c.cta_consultorio, c.cta_triaje, c.cta_medico, " +
                "c.cta_fecha, c.cta_desdiag " +
                "FROM consulta c, consultorio co " +
                " WHERE c.cta_activo = 1 AND c.cta_consultorio = co.cto_codigo AND co.cto_hospital ='"+this.IDHospital+"';";
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
            String sp = "INSERT INTO consulta (cta_codigo, cta_consultorio, cta_triaje, " +
                "cta_medico, cta_fecha, cta_desdiag) VALUES (" +
                "'" + generateID() + "' , " +
                "'" + txtConsultorio.Text + "' , " +
                "'" + txtTriaje.Text + "' , " +
                "'" + txtMedico.Text + "' , " +
                "'" + txtFecha.Text + "' , " +
                "'" + txtDescripcion.Text + "' );";

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

            String sql = "UPDATE consulta SET " +
                "cta_consultorio='" + txtConsultorio.Text + "' ," +
                "cta_triaje='" + txtTriaje.Text + "' ," +
                "cta_medico='" + txtMedico.Text + "' ," +
                "cta_fecha='" + txtFecha.Text + "' ," +
                "cta_desdiag='" + txtDescripcion.Text + "'" +
                " WHERE cta_codigo = '" + txtID.Text + "';";

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
            //String sql = "DELETE consulta WHERE id = '" + txtID.Text + "';";
            String sql = "UPDATE consulta SET " +
                "cta_activo = 0 WHERE cta_codigo = '" + txtID.Text + "'";
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

        private void btnListaMedicos_Click(object sender, EventArgs e)
        {
            listaMed = new ListaMedicos();
            listaMed.IDHospital = this.IDHospital;
            DialogResult res = listaMed.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtMedico.Text = listaMed.idMedico;
            }
        }

        private void btnListaConsultorios_Click(object sender, EventArgs e)
        {
            listaCon = new ListaConsultorios();
            listaCon.IDHospital = this.IDHospital;
            DialogResult res = listaCon.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtConsultorio.Text = listaCon.idConsultorio;
            }
        }

        private void btnListaTriajes_Click(object sender, EventArgs e)
        {
            listaTri = new ListaTriajes();
            listaTri.IDHospital = this.IDHospital;
            DialogResult res = listaTri.ShowDialog();
            if (res == DialogResult.OK)
            {
                txtTriaje.Text = listaTri.idTriaje;
            }
        }

        private void tableListado_SelectionChanged(object sender, EventArgs e)
        {
            if (tableListado.SelectedRows.Count > 0)
            {
                txtID.Text = tableListado.SelectedRows[0].Cells[0].Value.ToString();
                txtConsultorio.Text = tableListado.SelectedRows[0].Cells[1].Value.ToString();
                txtTriaje.Text = tableListado.SelectedRows[0].Cells[2].Value.ToString();
                txtMedico.Text = tableListado.SelectedRows[0].Cells[3].Value.ToString().Replace(",", ".");
                txtFecha.Text = tableListado.SelectedRows[0].Cells[4].Value.ToString().Replace(",", "."); ;
                txtDescripcion.Text = tableListado.SelectedRows[0].Cells[5].Value.ToString().Replace(",", "."); 

            }
        }

        private String generateID()
        {
            String sql = "SELECT TOP 1 cta_codigo FROM consulta ORDER BY cta_codigo DESC;";

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
                return "C001";
            }
        }
    }
}
