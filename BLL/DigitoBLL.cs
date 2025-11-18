using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using BE;

namespace BLL
{
    public class DigitoBLL
    {
        MP_DigVerificador mp_d = new MP_DigVerificador();

        public void VerificarIntegridadUsuarios(string currentusuarioDV, string usuarioDV, UsuarioBLL usuarioBLL, StringBuilder mensaje)
        {
            if(currentusuarioDV != usuarioDV)
            {
                mensaje.AppendLine("ALERTA: Se vulnero la integridad de tabla de datos de USUARIOS.");

                List<UsuarioBE> usuarios = usuarioBLL.Listar();
                List<UsuarioBE> usuarios_corruptos = new List<UsuarioBE>();
                List<string> errores = new List<string>();

                foreach(UsuarioBE usuario in usuarios)
                {
                    string dv = usuario.DVH;
                    string dvGenerado = usuarioBLL.getDV(usuario);

                    if(dvGenerado != dv)
                    {
                        usuarios_corruptos.Add(usuario);
                        errores.Add("Usuario con ID: " + usuario.id + " - Usuario: " + usuario.nombre + " - Tipo: " + usuario.tipoUs + " se ha modificado");
                    }
                }
                if(usuarios_corruptos.Count > 0)
                {
                    mensaje.AppendLine(string.Join(Environment.NewLine, errores));
                }
                else { errores.Add("No coincide el Digito Verificador de tabla USUARIOS, pero no se encuentran errores en registros en la tabla. Es posible que se haya eliminado registro de tabla"); }
            }
        }

        public void VerificarIntegridadBitacora(string currentbitacoraDV, string bitacoraDV, BitacoraBLL bitacoraBLL, StringBuilder mensaje)
        {
            if (currentbitacoraDV != bitacoraDV)
            {
                mensaje.AppendLine("ALERTA: Se vulnero la integridad de tabla de datos de BITACORA.");

                List<RegistroBE> registros = bitacoraBLL.ListarEventos();
                List<RegistroBE> registros_corruptos = new List<RegistroBE>();
                List<string> errores = new List<string>();

                foreach (RegistroBE registro in registros)
                {
                    string dv = registro.DVH;
                    string dvGenerado = bitacoraBLL.getDV(registro);

                    if (dvGenerado != dv)
                    {
                        registros_corruptos.Add(registro);
                        errores.Add("Registro con ID: " + registro.id + " - Usuario: " + registro.usuario + " - Detalle: " + registro.detalle + " - Fecha: " + registro.fecha.ToShortDateString() + " se ha modificado");
                    }
                }
                if (registros_corruptos.Count > 0)
                {
                    mensaje.AppendLine(string.Join(Environment.NewLine, errores));
                }
                else 
                { 
                    errores.Add("No coincide el Digito Verificador de tabla BITACORA, pero no se encuentran errores en registros en la tabla. Es posible que se haya eliminado registro de tabla");
                    mensaje.AppendLine(string.Join(Environment.NewLine, errores));
                }
            }
        }

        public void VerificarIntegridadProducto(string currentproductoDV, string productoDV, ProductoBLL productoBLL, StringBuilder mensaje)
        {
            if (currentproductoDV != productoDV)
            {
                mensaje.AppendLine("ALERTA: Se vulnero la integridad de tabla de datos de PRODUCTO.");

                List<ProductoBE> productos = productoBLL.ListarProductos();
                List<ProductoBE> productos_corruptos = new List<ProductoBE>();
                List<string> errores = new List<string>();

                foreach (ProductoBE p in productos)
                {
                    string dv = p.DVH;
                    string dvGenerado = productoBLL.getDV(p);

                    if (dvGenerado != dv)
                    {
                        productos_corruptos.Add(p);
                        errores.Add("Registro con ID: " + p.codigo + " se ha modificado");
                    }
                }
                if (productos_corruptos.Count > 0)
                {
                    mensaje.AppendLine(string.Join(Environment.NewLine, errores));
                }
                else
                {
                    errores.Add("No coincide el Digito Verificador de tabla PRODUCTO, pero no se encuentran errores en registros en la tabla. Es posible que se haya eliminado registro de tabla");
                    mensaje.AppendLine(string.Join(Environment.NewLine, errores));
                }
            }
        }

        public string VerificarDigito()
        {
            UsuarioBLL usuario = new UsuarioBLL();
            BitacoraBLL bitacora = new BitacoraBLL();
            ProductoBLL producto = new ProductoBLL();

            string currentusuarioDV = CalcularDigito(usuario.getTabla());
            string currentbitacoraDV = CalcularDigito(bitacora.getTabla());
            string currentproductoDV = CalcularDigito(producto.getTabla());

            string bitacoraDV = ObtenerDigito("Bitacora");
            string usuarioDV = ObtenerDigito("Usuario");
            string productoDV = ObtenerDigito("Producto");

            StringBuilder mensaje = new StringBuilder();

            VerificarIntegridadBitacora(currentbitacoraDV, bitacoraDV, bitacora, mensaje);
            VerificarIntegridadUsuarios(currentusuarioDV, usuarioDV, usuario, mensaje);
            VerificarIntegridadProducto(currentproductoDV, productoDV, producto, mensaje);

            return mensaje.ToString();
        }

        public string CalcularDigito(DataTable table)
        {
            StringBuilder sb = new StringBuilder();
            foreach(DataRow row in table.Rows)
            {
                for(int i=0; i<(row.ItemArray.Length - 1); i++)
                {
                    sb.Append(row.ItemArray[i]);
                }
            }
            return Encriptador.GetSHA256(sb.ToString());
        }

        public void ModificarDigito(string tabla, string digito)
        {
            try
            {
                mp_d.ModificarDigito(tabla, digito);
            }
            catch
            {
                throw new Exception("Error al modificar DIGITO VERIFICADOR.");
            }
        }

        public string ObtenerDigito(string tabla)
        {
            return mp_d.GetDGV(tabla);
        }
    }
}
