using BE;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DAL
{
    public class MP_Venta
    {
        Acceso acceso = new Acceso();

        public void GuardarCarrito(List<ItemCarritoBE>carrito, string ruta)
        {
            acceso.GuardarCarritoXML(carrito, ruta);
        }

        public List<ItemCarritoBE>CargarCarrito(string ruta)
        {
            XmlDocument carritoXML = new XmlDocument();
            List<ItemCarritoBE> carrito= new List<ItemCarritoBE>();
            carritoXML = acceso.LeerCarritoXML(ruta);
            XmlNode nodoRaiz = carritoXML.DocumentElement;

            foreach (XmlNode nodo in nodoRaiz.SelectNodes("ItemCarritoBE"))
            {
                // Mapeo manual de las propiedades (similar a tu ejemplo de profesor)
                ItemCarritoBE item = new ItemCarritoBE();

                // Convertimos el contenido de texto (Inner Text) a los tipos de datos de BE
                item.codigo = Convert.ToInt32(nodo["codigo"].InnerText);
                item.producto = nodo["producto"].InnerText;
                item.preUnitario = Convert.ToDecimal(nodo["preUnitario"].InnerText, CultureInfo.InvariantCulture);
                item.cantidad = Convert.ToInt32(nodo["cantidad"].InnerText); // 'stock' es la cantidad en el carrito
                item.subtotal = Convert.ToDecimal(nodo["subtotal"].InnerText, CultureInfo.InvariantCulture);
                carrito.Add(item);
            }
            return carrito;
        }
    }
}
