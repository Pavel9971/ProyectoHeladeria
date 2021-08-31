using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;

namespace ProyectoHeladeria
{
    public partial class FrmLogin : Form
    {
       

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }






        private void button1_Click(object sender, EventArgs e)
        {
            if (validar_Usuario(txtusuario.Text, txtclave.Text))
            {
                FrmPrincipal frm = new FrmPrincipal();
                FrmLogin fr = new FrmLogin();


                frm.Show();
                this.Hide();

            }


        }
        private bool validar_Usuario(string user, string clave)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            var q = from p in context.TBL_USUARIO
                    where p.USU_USUARIO == txtusuario.Text
                    && p.USU_CLAVE == txtclave.Text
                    select p;


            if (q.Any())
            {

                MessageBox.Show("Bienvenido al Sistema");
                return true;

            }
            else
            {
                MessageBox.Show("Usuario o Clave Incorrectos");
                txtclave.Text = "";
                txtusuario.Text = "";
                return false;
            }


        }
    }
}
