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
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmLogin frm = new FrmLogin();
            FrmInicio fr = new FrmInicio();

            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmLoginCliente frm = new FrmLoginCliente();
            FrmInicio fr = new FrmInicio();

            frm.Show();
            this.Hide();
        }
    }
}
