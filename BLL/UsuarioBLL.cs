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
using System.Data;

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
            return user;
        }

        public DataTable getTabla()
        {
            DataTable data = usuarioMP.getTabla();
            return data;
        }

        public string getDV(UsuarioBE u)
        {
            return Encriptador.GetSHA256($"{u.id}|{u.nombre}|{u.contra}|{u.tipoUs}");
        }

        public List<UsuarioBE> Listar()
        {
            List<UsuarioBE> lista = new List<UsuarioBE>();
            lista = usuarioMP.ListarTodos();
            return lista;
        }

        public void ActualizarDVH()
        {
            List<UsuarioBE> list = new List<UsuarioBE>();
            list = Listar();
            foreach (UsuarioBE u in list)
            {
                u.DVH = getDV(u);
                usuarioMP.ModificarUsuario(u);
            }
        }

        public void ActualizarDVV()
        {
            DigitoBLL digitoBLL = new DigitoBLL();
            string nuevoDVV = digitoBLL.CalcularDigito(getTabla());
            digitoBLL.ModificarDigito("Usuario", nuevoDVV);
        }
    }
}
