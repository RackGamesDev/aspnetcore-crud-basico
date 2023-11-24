using prueba2crud.Models;
using System.Data.SqlClient;
using System.Data;

namespace prueba2crud.Datos
{
    public class ContactoDatos//en esta clase se hacen como funciones los procedures del archivo.sql
    {
        public List<ContactoModel> Listar(){//devuelve todas las entrys
            var oLista = new List<ContactoModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL())){
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);//nombre del procedure de la base de datos (mirar archivo.sql)
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader()){
                    while (dr.Read()){
                        oLista.Add(new ContactoModel(){//cada propiedad de la tabla
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public ContactoModel Obtener(int IdContacto){//devuelve 1 entry
            var oContacto = new ContactoModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);//nombre del procedure
                cmd.Parameters.AddWithValue("IdContacto",  IdContacto);//clave primaria
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read()){//cada propiedad de la tabla
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return oContacto;
        }
        public bool Guardar(ContactoModel ocontacto){//agregar un entry
            bool rpta;
            try{
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);//nombre del procedure
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);//claves
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch(Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Editar(ContactoModel ocontacto){//editar un entry
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);//nombre del procedure
                    cmd.Parameters.AddWithValue("IdContacto", ocontacto.IdContacto);//claves
                    cmd.Parameters.AddWithValue("Nombre", ocontacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", ocontacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", ocontacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar(int IdContacto){//eliminar un entry
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);//nombre del procedure
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);//clave
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
