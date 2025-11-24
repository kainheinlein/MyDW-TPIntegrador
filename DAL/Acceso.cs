using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection _conexion;
        private readonly string cadenaSQL = @"Data Source=kainvm\SQLDEVELOPER;Initial Catalog=TP SOFTWARE;Integrated Security=True;";
        public SqlConnection conexion { get => _conexion; }

        private void AbrirConexion()
        {
           _conexion = new SqlConnection(cadenaSQL);
           _conexion.Open();
        }

        private void CerrarConexion()
        {
            _conexion.Close();
        }

        private SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaSQL);
        }

        public DataTable LeerTabla(string sp, SqlParameter[] datos)
        {
            try
            {
                AbrirConexion();
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = new SqlCommand();
                ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                ad.SelectCommand.CommandText = sp;
                if(datos != null)
                {
                    ad.SelectCommand.Parameters.AddRange(datos);
                }
                ad.SelectCommand.Connection = conexion;
                ad.Fill(dt);
                
                return dt;
            }
            catch(Exception ex) { throw ex; }
            finally { CerrarConexion(); }
        }

        public void Escribir(string sp, SqlParameter[] parametros)
        {
            SqlTransaction tr;
            AbrirConexion();
            tr = conexion.BeginTransaction();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.Connection = conexion;
                cmd.Parameters.AddRange(parametros);
                cmd.Transaction = tr;
                cmd.ExecuteNonQuery();
                tr.Commit();
            }
            catch (Exception e)
            {
                tr.Rollback();
                throw e;
            }
            finally { CerrarConexion(); }
        }

        public int Consulta(string sp, SqlParameter[] parametros)
        {
            int result;

            try
            {
                AbrirConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.Connection = conexion;
                cmd.Parameters.AddRange(parametros);
                cmd.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                return result = Convert.ToInt32(cmd.Parameters["@Result"].Value);
            }
            catch (Exception e) { throw e; }
            finally { CerrarConexion(); }
        }

        public SqlDataReader ExtraerDato(string sp, SqlParameter[] parametros)
        {
            try
            {
                AbrirConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.Connection = conexion;
                cmd.Parameters.AddRange(parametros);
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return dr;
            }
            catch (Exception e) { CerrarConexion(); throw e; }
        }

        public void GuardarCarritoXML(List<ItemCarritoBE> carrito, string rutaCompleta)
        {
            // La serialización convierte la lista de objetos en el formato XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<ItemCarritoBE>));

            // Escribe en la ruta física, asegurando que se cierre el archivo (using)
            using (TextWriter writer = new StreamWriter(rutaCompleta))
            {
                serializer.Serialize(writer, carrito);
            }
        }

        public XmlDocument LeerCarritoXML(string ruta)
        {
            XmlDocument documento = new XmlDocument();
            // Usamos XmlTextReader para manejar el archivo de forma eficiente
            // y evitar problemas con espacios en blanco.
            using (XmlTextReader reader = new XmlTextReader(ruta))
            {
                reader.WhitespaceHandling = WhitespaceHandling.None;
                documento.Load(reader);
                // El 'using' asegura que el 'reader' se cierre automáticamente
            }
            return documento;
        }

        public int DirectSQLResult(string query)
        {
            SqlCommand cmd = new SqlCommand(query, ObtenerConexion());
            if (cmd.Connection.State == ConnectionState.Closed)
            {
                cmd.Connection.Open();
            }
            return (int)cmd.ExecuteScalar();
        }
    }
}
