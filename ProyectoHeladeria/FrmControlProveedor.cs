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
    public partial class FrmControlProveedor : Form
    {
        DataClasses1DataContext cli = new DataClasses1DataContext();
        string ID = null;
        public FrmControlProveedor()
        {
            InitializeComponent();
        }

        private void FrmControlProveedor_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = new TBL_PROOVEDORES
                {

                    PROV_NOMBRE = txtnombre.Text,
                    PROV_RUC = txtruc.Text,
                    PROV_DIRECCION = txtdireccion.Text,
                    PROV_NUMERO = txttelefono.Text,
                    PROV_ESTADO = 'A'


                };
                cli.TBL_PROOVEDORES.InsertOnSubmit(query);
                cli.SubmitChanges();
                MessageBox.Show("Datos guardados");
                CargarDatos();
                limpiar();
            }
            catch (Exception)
            {
                MessageBox.Show("Datos no guardados");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                MessageBox.Show("Seleccione un campo para actualizar");
            }
            else
            {
                var query = (from c in cli.TBL_PROOVEDORES where c.ID_PROOVEDOR == Convert.ToInt32(ID) select c).First();
                query.PROV_NOMBRE = txtnombre.Text;
                query.PROV_RUC = txtruc.Text;
                query.PROV_DIRECCION = txtdireccion.Text;
                query.PROV_NUMERO = txttelefono.Text;
                cli.SubmitChanges();
                MessageBox.Show("Datos actualizados");
                CargarDatos();
                limpiar();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ID == null)
            {
                MessageBox.Show("Seleccione un campo para eliminar");
            }
            else
            {
                var query = (from c in cli.TBL_PROOVEDORES where c.ID_PROOVEDOR == Convert.ToInt32(ID) select c).First();
                cli.TBL_PROOVEDORES.DeleteOnSubmit(query);
                cli.SubmitChanges();
                MessageBox.Show("Registro Eliminado");
                CargarDatos();
                limpiar();

            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        public void CargarDatos()
        {
            var query = from c in cli.TBL_PROOVEDORES select c;
            dtgProveedor.DataSource = query;
        }
        public void limpiar()
        {
            txtnombre.Text = txtruc.Text = txttelefono.Text = txtdireccion.Text = "";
            ID = null;

        }

        private void dtgProveedor_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtgProveedor.SelectedRows.Count > 0)
            {
                if (dtgProveedor.CurrentRow.Cells["ID_PROOVEDOR"].Value.ToString() == "0")
                {
                    MessageBox.Show("No hay datos");
                }
                else
                {

                    txtnombre.Text = dtgProveedor.CurrentRow.Cells["PROV_NOMBRE"].Value.ToString();
                    txtruc.Text = dtgProveedor.CurrentRow.Cells["PROV_RUC"].Value.ToString();
                    txttelefono.Text = dtgProveedor.CurrentRow.Cells["PROV_NUMERO"].Value.ToString();
                    txtdireccion.Text = dtgProveedor.CurrentRow.Cells["PROV_DIRECCION"].Value.ToString();
                    ID = dtgProveedor.CurrentRow.Cells["ID_PROOVEDOR"].Value.ToString();
                }
            }
            else
            {

                MessageBox.Show("Seleccione una fila");
            }


        }

    }
    
}
