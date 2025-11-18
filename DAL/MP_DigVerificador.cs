using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_DigVerificador
    {
        Acceso acceso = new Acceso();

        public string GetDGV(string tabla)
        {
            string digito = "";

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter(@"tabla", tabla);

            DataTable dt = new DataTable();
            dt = acceso.LeerTabla("SP_OBTENER_DGV", param);
            foreach (DataRow dr in dt.Rows)
            {
                digito = dr["DVV"].ToString();                
            }

            return digito;
        }

        public void ModificarDigito(string tabla, string digito)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter(@"tabla", tabla);
            param[1] = new SqlParameter(@"digito", digito);
            acceso.Escribir("SP_ACTUALIZAR_DGV", param);
        }
    }
}
