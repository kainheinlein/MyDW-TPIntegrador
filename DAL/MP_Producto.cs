using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_Producto
    {
        private readonly Acceso conexDB = new Acceso();
        public List<ProductoBE> ListarProductos()
        {
            Acceso acceso = new Acceso();
            List<ProductoBE> listaProductos = new List<ProductoBE>();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Producto");
            DataTable dt = new DataTable();
            dt = acceso.LeerTabla("SP_LISTAR_TABLA", param);
            foreach (DataRow dr in dt.Rows)
            {
                ProductoBE prod = new ProductoBE();
                prod.codigo = Convert.ToInt32(dr["Codigo"]);
                prod.producto = dr["Producto"].ToString();
                prod.precio = Convert.ToDecimal(dr["Precio"]);
                prod.stock = Convert.ToInt32(dr["Stock"]);
                prod.DVH = dr["DVH"].ToString();
                listaProductos.Add(prod);
            }
            return listaProductos;
        }

        public DataTable getTabla()
        {
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Producto");
            dt = conexDB.LeerTabla("SP_LISTAR_TABLA", param);
            return dt;
        }
    }
}
