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
    public partial class FrmControlProducto : Form
    {
        DataClasses1DataContext cli = new DataClasses1DataContext();
        string ID = null;
        public FrmControlProducto()
        {
            InitializeComponent();
        }

        private void FrmControlProducto_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = new TBL_PRODUCTO
                {
                    
                    PRO_CODIGO = txtcodigo.Text,
                    PRO_NOMBRE = txtnom.Text,
                    PRO_CANTIDAD = Convert.ToInt32(txtcantidad.Text),
                    PRO_COSTO = Convert.ToDouble(txtcosto.Text),
                    PRO_ESTADO = 'A'


                };

                cli.TBL_PRODUCTO.InsertOnSubmit(query);
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
                var query = (from c in cli.TBL_PRODUCTO where c.ID_PRODUCTO == Convert.ToInt32(ID) select c).First();
                
                query.PRO_CODIGO = txtcodigo.Text;
                query.PRO_NOMBRE = txtnom.Text;
                query.PRO_CANTIDAD = Convert.ToInt32(txtcantidad.Text);
                query.PRO_COSTO = Convert.ToDouble(txtcosto.Text);
                query.PRO_ESTADO = 'A';
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
                var query = (from c in cli.TBL_PRODUCTO where c.ID_PRODUCTO == Convert.ToInt32(ID) select c).First();
                cli.TBL_PRODUCTO.DeleteOnSubmit(query);
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
            var query = from c in cli.TBL_PRODUCTO select c;
            DtgProducto.DataSource = query;
        }
        public void limpiar()
        {
          txtcodigo.Text = txtnom.Text = txtcantidad.Text = txtcosto.Text = "";
            ID = null;

        }

        private void DtgProducto_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (DtgProducto.SelectedRows.Count > 0)
            {
                if (DtgProducto.CurrentRow.Cells["ID_PRODUCTO"].Value.ToString() == "0")
                {
                    MessageBox.Show("No hay datos");
                }
                else
                {

                   
                    txtcodigo.Text = DtgProducto.CurrentRow.Cells["PRO_CODIGO"].Value.ToString();
                    txtnom.Text = DtgProducto.CurrentRow.Cells["PRO_NOMBRE"].Value.ToString();
                    txtcantidad.Text = DtgProducto.CurrentRow.Cells["PRO_CANTIDAD"].Value.ToString();
                    txtcosto.Text = DtgProducto.CurrentRow.Cells["PRO_COSTO"].Value.ToString();
                    ID = DtgProducto.CurrentRow.Cells["ID_PRODUCTO"].Value.ToString();
                }
            }
            else
            {

                MessageBox.Show("Seleccione una fila");
            }

        }

    }
}



