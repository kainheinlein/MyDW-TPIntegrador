using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_Bitacora
    {
        private readonly Acceso acceso = new Acceso();

        public void RegistrarEvento(RegistroBE reg)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter(@"usuario",reg.usuario);
            param[1] = new SqlParameter(@"detalle", reg.detalle);
            param[2] = new SqlParameter(@"fecha", reg.fecha);
            param[3] = new SqlParameter(@"DVH", reg.DVH);
            acceso.Escribir("SP_RegistrarBitacora", param);
        }

        public List<RegistroBE> ListarEventos()
        {
            List<RegistroBE>Registros = new List<RegistroBE>();

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Bitacora");
            DataTable dt = new DataTable();
            dt = acceso.LeerTabla("SP_LISTAR_TABLA",param);
            foreach (DataRow dr in dt.Rows)
            {
                RegistroBE reg = new RegistroBE();
                reg.id = Convert.ToInt32(dr["id"]);
                reg.usuario = dr["usuario"].ToString();
                reg.fecha = Convert.ToDateTime(dr["fecha"]);
                reg.detalle = dr["detalle"].ToString();
                reg.DVH = dr["DVH"].ToString();
                Registros.Add(reg);
            }
            return Registros;
        }

        public DataTable getTabla()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Bitacora");
            DataTable dt = new DataTable();
            dt = acceso.LeerTabla("SP_LISTAR_TABLA", param);
            return dt;
        }

        public int GetLastID()
        {
            int ultimoID = acceso.DirectSQLResult("SELECT ISNULL(MAX(id), 0) AS MaxId FROM Bitacora;\r\n");
            return ultimoID;
        }

        public void ModificarRegistro(RegistroBE reg)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter(@"id", reg.id);
            param[1] = new SqlParameter(@"usuario", reg.usuario);
            param[2] = new SqlParameter(@"detalle", reg.detalle);
            param[3] = new SqlParameter(@"fecha", reg.fecha);
            param[4] = new SqlParameter(@"DVH", reg.DVH);
            acceso.Escribir("SP_ACTUALIZAR_REGISTRO", param);
        }
    }
}
