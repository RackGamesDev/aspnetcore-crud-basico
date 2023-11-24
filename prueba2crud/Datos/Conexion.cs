using System.Data.SqlClient;
using System.Linq.Expressions;

namespace prueba2crud.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        public Conexion(){
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }
        public string getCadenaSQL(){
            return cadenaSQL;
        }
    }
}
//script para conexiones hecho desde 0