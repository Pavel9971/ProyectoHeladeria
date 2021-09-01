using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoHeladeria
{
    public partial class FrmCompraProductos : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=ProyectoHeladeria;Persist Security Info=True;User ID=sa;Password=123");
        double Vuni = 0;
        double Vtot = 0;
        double cant = 0;
        double pago = 0;
        double cambio = 0;
        int idven=1;
        int cod=0;
        public FrmCompraProductos()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ced = Convert.ToInt32(txtbuscarcli.Text);
            SqlCommand command = new SqlCommand("SELECT * FROM TBL_CLIENTES WHERE CLI_CI='" + ced + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())

            {
                txtnomclo.Text = reader["CLI_NOMBRECOMPLETO"].ToString();
                txtcicli.Text = reader["CLI_CI"].ToString();
                txttelcli.Text = reader["CLI_NUMERO"].ToString();
                txtdircli.Text = reader["CLI_DIRECCION"].ToString();
                txtid.Text = reader["ID_CLIENTE"].ToString();


            }
            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string nomProd = txtbuscarpro.Text;
            SqlCommand command = new SqlCommand("SELECT * FROM TBL_PRODUCTO WHERE PRO_NOMBRE='" + nomProd + "'", connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())

            {
                txtnompro.Text = reader["PRO_NOMBRE"].ToString();
                txtcanpro.Text = reader["PRO_CANTIDAD"].ToString();
                txtprepro.Text = reader["PRO_COSTO"].ToString();
                txtidpro.Text = reader["ID_PRODUCTO"].ToString();


            }
            connection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cant = Convert.ToDouble(txtcantcomp.Text);
            Vuni = Convert.ToDouble(txtprepro.Text);
           
            Vtot = cant * Vuni;
          
            txttotal.Text = Vtot.ToString();
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pago = Convert.ToDouble(txtpago.Text);
            cambio = pago-Vtot ;
            txtcambio.Text = cambio.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtnompro.Text = dtgcomp.CurrentRow.Cells[2].Value.ToString();
            txtcantcomp.Text = dtgcomp.CurrentRow.Cells[3].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                
             
                string query = "INSERT INTO TBL_VENTA (ID_VENTA,ID_CLIENTE,ID_PRODUCTO,[VEN_CODIGO_VENTA],[VEN_CANTIDAD],[VEN_COSTO])" +
                    " values (@1,@2,@3,@4,@5,@6)";
                connection.Open();
               
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@1", TXTIDVENTA.Text);
                command.Parameters.AddWithValue("@2", txtid.Text);
                command.Parameters.AddWithValue("@3", txtidpro.Text);
                command.Parameters.AddWithValue("@4", txtcodigocompr.Text);
                command.Parameters.AddWithValue("@5", txtcantcomp.Text);
                command.Parameters.AddWithValue("@6", txttotal.Text);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Registro Agregado");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

            string codigo = txtcodigocompr.Text;
            SqlCommand command1 = new SqlCommand("SELECT * FROM TBL_VERCOMPRA WHERE CODIGO='" + codigo + "'", connection);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command1;
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            dtgcomp.DataSource = tabla;
            connection.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string codigo = txtbuscod.Text;
            SqlCommand command1 = new SqlCommand("SELECT * FROM TBL_VERCOMPRA WHERE CODIGO='" + codigo + "'", connection);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command1;
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            dtgcomp.DataSource = tabla;
            connection.Close();

        }
    }
}
