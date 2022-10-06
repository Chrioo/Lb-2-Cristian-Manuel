using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_2_Cristian_Menjivar_y_Manuel_humberto
{
    public partial class Form1 : Form
    {
        List<Producto> Productos = new List<Producto>();

        public Form1()
        {
            InitializeComponent();
        }

        public void LimpiarObjeto()
        {
            txtMarca.Clear();
            txtIdproducto.Clear();
            txtDescripcion.Clear();
            cbCategoria.Text = "";
            txtTalla.Clear();
            txtCantidad.Clear();
            txtCompra.Clear();
        }
        void idProducto()
        {
            int id = 0;
            txtIdproducto.Text = id.ToString();
            id++;
        }

        public void Registrar()
        {
            Producto Pdt = new Producto();
            double pVenta;
            Pdt.idProductos = int.Parse(txtIdproducto.Text);
            Pdt.Marca = txtMarca.Text;
            Pdt.descripcion = txtDescripcion.Text;
            Pdt.Categoria = cbCategoria.Text;
            Pdt.cantidad= int.Parse(txtCantidad.Text);
            Pdt.Talla = int.Parse(txtTalla.Text);
            Pdt.PrecioCompra = Convert.ToDouble(txtCompra.Text);
            pVenta = double.Parse(txtCompra.Text) + double.Parse(txtCompra.Text) * 0.13;
            Pdt.PrecioVenta = pVenta;
            Productos.Add(Pdt);
            LimpiarObjeto();

        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo números enteros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se aceptan letras ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se aceptan letras ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 45 || e.KeyChar >= 58 && e.KeyChar <= 255 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se aceptan números ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 45 || e.KeyChar >= 58 && e.KeyChar <= 255 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                MessageBox.Show("Solo se aceptan números ", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        public void Buscar()
        {
            try
            {
                if (txtIdproducto.Text != null)
                {
                    foreach (Producto p in Productos)
                    {
                        if (p.idProductos == Convert.ToInt64(txtIdproducto.Text))
                        {
                            DialogResult respuesta = MessageBox.Show("Editaras el registro?", "Editar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (respuesta == DialogResult.Yes)
                            {
                                cbCategoria.Text = p.Categoria;
                                txtCompra.Text = p.PrecioCompra.ToString();
                                txtMarca.Text = p.Marca;
                                txtCantidad.Text = p.cantidad.ToString();
                                txtTalla.Text = p.Talla.ToString();
                                txtDescripcion.Text = p.descripcion;
                                btnGuardar.Enabled = true;
                                btnBuscar.Enabled = false;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El campo nombre esta vacio!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error en la busqueda");
            }
        }

        public void Editar()

        {
            try
            {
                foreach (Producto p in Productos)
                {
                    if (p.idProductos == Convert.ToInt64( txtIdproducto.Text))
                    {
                        p.PrecioCompra = double.Parse(txtCompra.Text);
                        p.cantidad = int.Parse(txtCantidad.Text);
                        p.Marca = txtMarca.Text;
                        p.Talla = int.Parse(txtTalla.Text);
                        p.descripcion = txtDescripcion.Text;
                        p.Categoria = cbCategoria.Text;
                        LimpiarObjeto();
                        Mostrar();
                        btnBuscar.Enabled = true;
                        btnGuardar.Enabled = false;
                        break;
                    }

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar los cambios!!");

            }
        }

        public void Mostrar()
        {
            string Datos = "";
            foreach (Producto pt in Productos)
            {
                Datos = Datos + " --------  " + pt.idProductos + "-------  " + pt.Marca + "--------  " + pt.descripcion + " --------- " + pt.Categoria + "---------  " + pt.Talla  + " --------- " + pt.PrecioCompra + " ----------- " + pt.PrecioVenta + "--------------"+pt.cantidad +" \n ";

            }
            rtbInventario.Text = Datos;
        }
        public void Filtrar()
        {

            string datos = "";
            string categoria;
            categoria = cbFiltrar.Text;
            var consulta = from cate in Productos
                           where cate.Categoria.Equals(categoria)
                           select cate;
       
                foreach (Producto c in consulta)
                {
                    datos = datos + " --------  " + c.idProductos + "-------  " + c.Marca + "--------  " + c.descripcion + " --------- " + c.Categoria + "---------  " + c.Talla + " --------- " + c.PrecioCompra + " ----------- " + c.PrecioVenta + "---------" + c.cantidad + " \n ";
                }
                 rtbFiltro.Text = datos;

        }

        public void FiltrarMarca()
        {

            string datos1 = "";
            string Marca;
            Marca = txtFilMarca.Text;
            var consulta = from cate in Productos
                           where cate.Marca.Equals(Marca)
                           select cate;

            foreach (Producto c in consulta)
            {
                datos1 = datos1 + " --------  " + c.idProductos + "-------  " + c.Marca + "--------  " + c.descripcion + " --------- " + c.Categoria + "---------  " + c.Talla + " --------- " + c.PrecioCompra + " ----------- " + c.PrecioVenta + "---------" + c.cantidad + " \n ";
            }
            rtbMarca.Text = datos1;

        }



        public void Eliminar()
        {
            try
            {
                if (txtIdproducto.Text != "")
                {
                    foreach (Producto p in Productos)
                    {
                        if (p.idProductos == Convert.ToInt64 (txtIdproducto.Text))
                        {
                            DialogResult respuesta = MessageBox.Show("Esta seguro de eliminar el registro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (respuesta == DialogResult.Yes)
                            {
                                Productos.Remove(p);
                                LimpiarObjeto();
                                Mostrar();
                            }

                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Campo nombre esta vacio!!");

                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al elminar registro");
            }
        }

            public void ValidarID()
            {

            }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            Registrar();
            Mostrar();
            idProducto();
            LimpiarObjeto();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Filtrar();
            Mostrar();
            
        }



        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Editar();
            Mostrar();
        }

        private void btnFiltarMarca_Click(object sender, EventArgs e)
        {
            FiltrarMarca();
            Mostrar();
        }
    }
}
