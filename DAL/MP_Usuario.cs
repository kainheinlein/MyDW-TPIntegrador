using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MP_Usuario
    {
        Acceso conexDB = new Acceso();
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
                dr.Close();
                return us;
            }
            else return null;
        }
    }
}
