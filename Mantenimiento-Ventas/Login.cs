using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mantenimiento_Ventas
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        String user = "admin";
        String password = "1234";

      

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            String usuario = txtUser.Text;
            String contra = txtPassword.Text;

            if (usuario.Equals(user) && contra.Equals(password))
            {
                Mantenimientos man = new Mantenimientos();
                txtPassword.Clear();
                txtUser.Clear();
                man.Show();
            }
            else
            {
                MessageBox.Show("El usuario o conraseña son incorrectos.");
                txtPassword.Clear();
                txtUser.Clear();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
