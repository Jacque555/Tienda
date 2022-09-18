using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesTienda;
using ManejadorTienda;


namespace PresentacionTienda
{
    public partial class FrmTienda : Form
    {
        private ProductosManejador _productosManejador;
        private string _bandera;
        public FrmTienda()
        {
            InitializeComponent();
            _productosManejador = new ProductosManejador();
        }
        private void EliminarProducto()
        {
            var idproducto = dtvTienda.CurrentRow.Cells["idproducto"].Value.ToString();
            _productosManejador.EliminarUsuarios(Convert.ToInt32(idproducto));
        }
        private void GuardarProducto()
        {
            Productos productos = new Productos();
            productos.Idproducto = Convert.ToInt32(txtIdproducto.Text);
            productos.Nombre = txtNombre.Text;
            productos.Descripcion = txtDescripcion.Text;
            productos.Precio = Convert.ToInt32(txtPrecio.Text);
            _productosManejador.GuardarProducto(productos);
        }
        private void LlenarProducto(string dato)
        {
            dtvTienda.DataSource = _productosManejador.GetProductos(dato);
        }
        private void ControlarBotones(bool nuevo, bool guardar,
            bool cancelar, bool eliminar, bool salir)
        {
            btnNuevo.Enabled = nuevo;
            btnGuardar.Enabled = guardar;
            btnCancelar.Enabled = cancelar;
            btnEliminar.Enabled = eliminar;
            btnSalir.Enabled = salir;
        }
        private void LimpiarCuadros()
        {
            txtIdproducto.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
        }
        private void ControlarCuadros(bool control)
        {
            txtIdproducto.Enabled = control;
            txtNombre.Enabled = control;
            txtDescripcion.Enabled = control;
            txtPrecio.Enabled = control;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ControlarBotones(false, true, true, false, false);
            ControlarCuadros(true);
            _bandera = "guardar";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlarBotones(true, false, false, true, true);
                if (_bandera == "guardar")
                {
                    GuardarProducto();
                    LimpiarCuadros();
                    MessageBox.Show("Se guardo correctamente");
                }
                else
                {
                    //ModificarUsuario();
                    LlenarProducto("");
                    MessageBox.Show("Se actualizo correctamente");
                }
                ControlarCuadros(false);
                LlenarProducto("");
            }
            catch (Exception)
            {
                MessageBox.Show("Verificar datos");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ControlarBotones(true, false, false, true, true);
            LimpiarCuadros();
            ControlarCuadros(false);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtvTienda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _bandera = "actualizar";
                ControlarCuadros(true);
                ControlarBotones(false, true, true, false, false);
                txtIdproducto.Text = dtvTienda.CurrentRow.Cells["idproducto"].Value.ToString();
                txtNombre.Text = dtvTienda.CurrentRow.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = dtvTienda.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrecio.Text = dtvTienda.CurrentRow.Cells["precio"].Value.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar actualizar");
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            LlenarProducto(txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Deseas eliminar este registro?", "Eliminar Usuario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    EliminarProducto();
                    LlenarProducto("");
                    MessageBox.Show("Se elimino correctamente");
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al intentar eliminar");

                }
            }
        }
    }
}
