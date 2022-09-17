using System.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatosTienda
{
    public class Conexion
    {
        private MySqlConnection _conn;
        public Conexion(string servidor, string usuario, string password, string basedatos, uint puerto)
        {
            MySqlConnectionStringBuilder CadenaConexion = new MySqlConnectionStringBuilder();
            CadenaConexion.Server = servidor;
            CadenaConexion.UserID = usuario;
            CadenaConexion.Password = password;
            CadenaConexion.Database = basedatos;
            CadenaConexion.Port = puerto;

            _conn = new MySqlConnection(CadenaConexion.ToString());
        }

        public void EjecutarConsulta(string consulta)
        {
            _conn.Open();
            var command = new MySqlCommand(consulta, _conn);
            command.ExecuteNonQuery();
            _conn.Close();
        }

        public DataSet ObtenerDatos(string consulta, string tabla)
        {
            var ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(consulta, _conn);
            da.Fill(ds, tabla);
            return ds;
        }
    }
}
