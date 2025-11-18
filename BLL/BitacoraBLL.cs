using BE;
using DAL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace BLL
{
    public class BitacoraBLL
    {
        MP_Bitacora BitacoraDAL = new MP_Bitacora();

        public void Registrar(string us, string accion)
        {
            RegistroBE reg = new RegistroBE()
            {
                usuario = us,
                detalle = accion,
                fecha = DateTime.Now,
            };
            reg.id = BitacoraDAL.GetLastID() + 1;
            reg.DVH = getDV(reg);
            BitacoraDAL.RegistrarEvento(reg);
            ActualizarDVV();
        }

        public List<RegistroBE> ListarEventos()
        {
            return BitacoraDAL.ListarEventos();
        }

        public DataTable getTabla()
        {
            DataTable data = BitacoraDAL.getTabla();
            return data;
        }

        public void ActualizarDVV()
        {
            DigitoBLL digitoBLL = new DigitoBLL();
            string nuevoDVV = digitoBLL.CalcularDigito(getTabla());
            digitoBLL.ModificarDigito("Bitacora", nuevoDVV);
        }

        public void ActualizarDVH()
        {
            List<RegistroBE> list = new List<RegistroBE>();
            list = ListarEventos();
            foreach(RegistroBE reg in list)
            {
                reg.DVH = getDV(reg);
                BitacoraDAL.ModificarRegistro(reg);
            }
        }

        public string getDV(RegistroBE r)
        {
            string fechaStr = r.fecha.ToString("yyyy-MM-dd HH:mm:ss");
            string strtotal = $"{r.usuario}|{r.detalle}|{fechaStr}";
            return Encriptador.GetSHA256(strtotal);
        }
    }
}
