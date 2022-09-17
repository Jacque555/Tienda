namespace EntidadesTienda
{
    public class Productos
    {
        private int _idproducto;
        private string _Nombre;
        private string _Descripcion;
        private int _Precio;

        public int Idproducto { get => _idproducto; set => _idproducto = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public int Precio { get => _Precio; set => _Precio = value; }
    }
}
