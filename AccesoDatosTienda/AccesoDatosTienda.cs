using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesTienda;

namespace AccesoDatosTienda
{
    public class AccesoDatosTienda
    {
        Conexion con;
        public AccesoDatosTienda()
        {
            con = new Conexion("localhost", "root", "", "Tienda", 3306);
        }
        public void GuardarProductos(Productos productos)
        {
            string consulta = string.Format("insert into producto values({0},'{1}','{2}',{3})",
                productos.Idproducto, productos.Nombre, productos.Descripcion, productos.Precio);
            con.EjecutarConsulta(consulta);
        }
        public List<Productos> GetProductos(string dato)
        {
            var ListProductos = new List<Productos>();
            var ds = new DataSet();

            string consulta = string.Format("select * from producto where nombre like '%{0}%'", dato);
            ds = con.ObtenerDatos(consulta, "Tienda");

            var dt = new DataTable();
            dt = ds.Tables[0];

            foreach (DataRow row in dt.Rows)
            {
                var Usuario = new Productos
                {
                    Idproducto = Convert.ToInt32(row["idproducto"]),
                    Nombre = row["nombre"].ToString(),
                    Descripcion = row["descripcion"].ToString(),
                    Precio = Convert.ToInt32(row["precio"]),
                };
                ListProductos.Add(Usuario);
            }
            return ListProductos;
        }
    }
}
