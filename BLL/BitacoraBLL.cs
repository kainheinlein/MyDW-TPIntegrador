using BE;
using DAL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BitacoraBLL
    {
        MP_Bitacora BitacoraDAL = new MP_Bitacora();

        public void Registrar(UsuarioBE us, string accion)
        {
            RegistroBE reg = new RegistroBE()
            {
                usuario = us.nombre,
                detalle = accion,
                fecha = DateTime.Now,
            };
            BitacoraDAL.RegistrarEvento(reg);
        }

        public List<RegistroBE> Listar()
        {
            return BitacoraDAL.Listar();
        }
    }
}
