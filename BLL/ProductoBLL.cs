using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductoBLL
    {
        MP_Producto productoDAL = new MP_Producto();

        public List<ProductoBE> ListarProductos()
        {
            return productoDAL.ListarProductos();
        }

        public DataTable getTabla()
        {
            DataTable data = productoDAL.getTabla();
            return data;
        }

        public string getDV(ProductoBE u)
        {
            return Encriptador.GetSHA256($"{u.codigo}|{u.producto}|{u.precio}|{u.stock}");
        }
    }
}
