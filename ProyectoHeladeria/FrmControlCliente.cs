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

    public partial class FrmControlCliente : Form
    {
        DataClasses1DataContext cli = new DataClasses1DataContext();
        private string ID_CLIENTE = null;
        public FrmControlCliente()
        {
            InitializeComponent();
        }

        private void FrmControlCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        public void CargarClientes() {
            var query = from c in cli.TBL_CLIENTES select c;
            DtgCliente.DataSource = query;
        }


        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try {
                var query = new TBL_CLIENTES
                {

                    CLI_NOMBRECOMPLETO = txtnombre.Text,
                    CLI_CI = txtcedula.Text,
                    CLI_DIRECCION = txtdireccion.Text,
                    CLI_NUMERO = txttelefono.Text,
                    CLI_ESTADO = 'A'


                };
                cli.TBL_CLIENTES.InsertOnSubmit(query);
                cli.SubmitChanges();
                MessageBox.Show("Datos guardados");
                CargarClientes();
                limpiar();
            }
            catch (Exception) {
                MessageBox.Show("Datos no guardados");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ID_CLIENTE == null)
            {
                MessageBox.Show("Seleccione un campo para actualizar");
            }
            else
            {
                var query = (from c in cli.TBL_CLIENTES where c.ID_CLIENTE == Convert.ToInt32(ID_CLIENTE) select c).First();
                query.CLI_NOMBRECOMPLETO = txtnombre.Text;
                query.CLI_CI = txtcedula.Text;
                query.CLI_DIRECCION = txtdireccion.Text;
                query.CLI_NUMERO = txttelefono.Text;
                cli.SubmitChanges();
                MessageBox.Show("Datos actualizados");
                CargarClientes();
                limpiar();
            }
            
   }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(ID_CLIENTE == null)
            {
                MessageBox.Show("Seleccione un campo para eliminar");
            }
            else
            {
                var query = (from c in cli.TBL_CLIENTES where c.ID_CLIENTE == Convert.ToInt32(ID_CLIENTE) select c).First();
                cli.TBL_CLIENTES.DeleteOnSubmit(query);
                cli.SubmitChanges();
                MessageBox.Show("Registro Eliminado");
                CargarClientes();
                limpiar();

            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void limpiar()
        {
            txtnombre.Text = txtcedula.Text = txttelefono.Text = txtdireccion.Text = "";
            ID_CLIENTE = null;

        }

        private void DtgCliente_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgCliente.SelectedRows.Count > 0)
            {
                if (DtgCliente.CurrentRow.Cells["ID_CLIENTE"].Value.ToString() == "0")
                {
                    MessageBox.Show("No hay datos");
                }
                else
                {

                    txtnombre.Text = DtgCliente.CurrentRow.Cells["CLI_NOMBRECOMPLETO"].Value.ToString();
                    txtcedula.Text = DtgCliente.CurrentRow.Cells["CLI_CI"].Value.ToString();
                    txttelefono.Text = DtgCliente.CurrentRow.Cells["CLI_NUMERO"].Value.ToString();
                    txtdireccion.Text = DtgCliente.CurrentRow.Cells["CLI_DIRECCION"].Value.ToString();
                    ID_CLIENTE = DtgCliente.CurrentRow.Cells["ID_CLIENTE"].Value.ToString();
                }
            }
            else
            {

                MessageBox.Show("Seleccione una fila");
            }


        }

      
    }
}
