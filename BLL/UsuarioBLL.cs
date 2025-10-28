using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using Microsoft.Win32;

namespace BLL
{
    public class UsuarioBLL
    {
        private static string patron = @"^[A-Za-z0-9\s]+$";
        MP_Usuario usuarioMP = new MP_Usuario();

        public UsuarioBE Login (string us,string con)
        {
            UsuarioBE user = new UsuarioBE();

            if (Regex.IsMatch(us, patron) && Regex.IsMatch(con, patron))
            {
                user.nombre = us;
                user.contra = Encriptador.GetSHA256(con);
                user = usuarioMP.Login(user);
            }
            else user = null;

            if (user != null)
            {
                //bitacora.Registrar(user, "Login");
            }
            return user;
        }
    }
}
