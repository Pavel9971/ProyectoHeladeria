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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmControlCliente frm =new FrmControlCliente();
            frm.Show();
        }

        private void pROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmControlProveedor frm = new FrmControlProveedor();
            frm.Show();

        }

        private void cATEGORIASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmControlCategoria frm = new FrmControlCategoria();
            frm.Show();
        }

        private void pRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmControlProducto frm = new FrmControlProducto();
            frm.Show();
        }
    }
}
