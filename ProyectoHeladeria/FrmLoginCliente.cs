using CapaDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHeladeria
{
    public partial class FrmLoginCliente : Form
    {
        public FrmLoginCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validar_Usuario(txtusuario.Text, txtclave.Text))
            {
                FrmCompraProductos frm = new FrmCompraProductos();
                FrmLoginCliente fr = new FrmLoginCliente();


                frm.Show();
                this.Hide();

            }

        }
        private bool validar_Usuario(string user, string clave)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            var q = from p in context.TBL_CLIENTES
                    where p.CLI_CI == txtusuario.Text
                    && p.CLI_CI == txtclave.Text
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

        private void button2_Click(object sender, EventArgs e)
        {
            FrmInicio frm = new FrmInicio();
            FrmLoginCliente fr = new FrmLoginCliente();


            frm.Show();
            this.Hide();

        }
    }
}
