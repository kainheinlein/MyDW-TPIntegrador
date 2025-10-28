using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class RegistroBE
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _usuario;

        public string usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        private string _detalle;

        public string detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }

        private DateTime _fecha;

        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
    }
}
