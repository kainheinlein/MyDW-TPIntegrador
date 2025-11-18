using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class MP_Usuario
    {
        private readonly Acceso conexDB = new Acceso();
        public UsuarioBE Login (UsuarioBE us)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter("@nombre", us.nombre);
            parametros[1] = new SqlParameter("@password", us.contra);
            SqlDataReader dr = conexDB.ExtraerDato("SP_OBTENER_USUARIO", parametros);
            if (dr.Read())
            {
                us.id = Convert.ToInt32(dr["id"].ToString());
                us.nombre = dr["nombre"].ToString();
                us.contra = dr["password"].ToString();
                us.tipoUs = dr["tipousuario"].ToString();
                us.DVH = dr["DVH"].ToString();
                dr.Close();
                return us;
            }
            else return null;
        }

        public List<UsuarioBE> ListarTodos()
        {
            List<UsuarioBE> us = new List<UsuarioBE>();
            DataTable dt = new DataTable();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Usuario");
            dt = conexDB.LeerTabla("SP_LISTAR_TABLA", param);
            foreach (DataRow dr in dt.Rows)
            {
                UsuarioBE u = new UsuarioBE();
                u.id = Convert.ToInt32(dr["id"]);
                u.nombre = dr["nombre"].ToString();
                u.contra = dr["password"].ToString();
                u.tipoUs = dr["tipousuario"].ToString();
                u.DVH = dr["DVH"].ToString();
                us.Add(u);
            }
            return us;
        }

        public DataTable getTabla()
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tabla", "Usuario");
            DataTable dt = conexDB.LeerTabla("SP_LISTAR_TABLA", param);
            return dt;
        }

        public void ModificarUsuario(UsuarioBE usuario)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter(@"id", usuario.id);
            param[1] = new SqlParameter(@"nombre", usuario.nombre);
            param[2] = new SqlParameter(@"password", usuario.contra);
            param[3] = new SqlParameter(@"tipousuario", usuario.tipoUs);
            param[4] = new SqlParameter(@"DVH", usuario.DVH);
            conexDB.Escribir("SP_ACTUALIZAR_USUARIO", param);
        }
    }
}
