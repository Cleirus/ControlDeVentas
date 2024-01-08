using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlDeVentas
{
    public partial class Form1 : Form
    {
        //Inicializar arreglo de producto
        static string[] productos = {"Charola", "Vaso", "Cuchara", "Tenedor", "Servilletas"};

        //Objeto de la clase ArrayList
        ArrayList aProducto = new ArrayList(productos);

        //Objeto de Ventas
        Venta objV = new Venta();

        //Sumar total
        double total;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarFecha();
            MostrarHora();
            LlenarProducto();
            lblNeto.Text = "0.00";
            LimpiarCampos();
        }
        private void btmRegistrar_Click(object sender, EventArgs e)
        {
            objV.Producto = cobProductos.Text;
            objV.Cantidad = int.Parse(txtCantidad.Text);
            ListViewItem fila = new ListViewItem(objV.Producto);
            fila.SubItems.Add(objV.Cantidad.ToString());
            fila.SubItems.Add(objV.AsignarPrecio().ToString());
            fila.SubItems.Add(objV.CalcularSubtotal().ToString());
            fila.SubItems.Add(objV.CalcularDescuento().ToString());
            fila.SubItems.Add(objV.CalcularNeto().ToString());

            //Muestra la fila
            lvRegistro.Items.Add(fila);

            //Muestra el total
            total += objV.CalcularNeto();
            lblNeto.Text = total.ToString();

            LimpiarCampos();

        }
        private void cobProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            objV.Producto = cobProductos.Text;
            lblPrecio.Text = objV.AsignarPrecio().ToString("C");
        }
        private void MostrarFecha() 
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }
        private void MostrarHora()
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void LimpiarCampos() 
        {
            txtCliente.Clear();
            cobProductos.Text = "Selecciona un producto";
            txtCantidad.Clear();
            lblPrecio.Text = "0.00";
            txtCliente.Focus();
        }

        private void LlenarProducto()
        {
            foreach (var s in productos) 
            { 
                cobProductos.Items.Add(s);
            }
        }

        private void btmCancelar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Deseas salir...?", "Ventas",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            }
            else 
            {
                LimpiarCampos();
            }
        }

        

    }
}
