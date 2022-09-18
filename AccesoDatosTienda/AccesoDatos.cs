using EntidadesTienda;
using System;
using System.Collections.Generic;
using System.Data;

namespace AccesoDatosTienda
{
    public class AccesoDatos
    {
        Conexion con;
        public AccesoDatos()
        {
            con = new Conexion("localhost", "root", "", "tienda", 3306);
        }
        public void GuardarProductos(Productos productos)
        {
            string consulta = string.Format("insert into producto values({0},'{1}','{2}',{3})",
                productos.Idproducto, productos.Nombre, productos.Descripcion, productos.Precio);
            con.EjecutarConsulta(consulta);
        }
        public void EliminarProducto(int idproducto)
        {
            string consulta = string.Format("Delete from producto where idproducto = {0}", idproducto);
            con.EjecutarConsulta(consulta);
        }
        public List<Productos> GetProductos(string dato)
        {
            var ListProductos = new List<Productos>();
            var ds = new DataSet();

            string consulta = string.Format("select * from producto where nombre like '%{0}%'", dato);
            ds = con.ObtenerDatos(consulta, "producto");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var Producto = new Productos
                {
                    Idproducto = Convert.ToInt32(row["idproducto"]),
                    Nombre = row["nombre"].ToString(),
                    Descripcion = row["descripcion"].ToString(),
                    Precio = Convert.ToInt32(row["precio"]),
                };
                ListProductos.Add(Producto);
            }
            return ListProductos;
        }
    }
}
