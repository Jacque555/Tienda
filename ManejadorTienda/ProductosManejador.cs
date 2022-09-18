using EntidadesTienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatosTienda;


namespace ManejadorTienda
{
    public class ProductosManejador
    {
        private AccesoDatos _accesoDatos = new AccesoDatos();
        public List<Productos> GetProductos(string dato)
        {
            var listProductos = _accesoDatos.GetProductos(dato);
            return listProductos;
        }
        public void GuardarProducto(Productos productos)
        {
            _accesoDatos.GuardarProductos(productos);
        }
        public void EliminarUsuarios(int idproducto)
        {
            _accesoDatos.EliminarProducto(idproducto);
        }

    }
}
