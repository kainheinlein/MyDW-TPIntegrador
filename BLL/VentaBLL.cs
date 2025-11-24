using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VentaBLL
    {
        MP_Venta ventaMP = new MP_Venta();
        public void GuardarCarrito(List<ItemCarritoBE>carrito, string ruta)
        {
            ventaMP.GuardarCarrito(carrito, ruta);
        }

        public List<ItemCarritoBE>CargarCarrito(string ruta)
        {
            return ventaMP.CargarCarrito(ruta);
        }
    }
}
