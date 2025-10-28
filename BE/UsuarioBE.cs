using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE
    {
		private int _id;

		public int id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _nombre;

		public string nombre
		{
			get { return _nombre; }
			set { _nombre = value; }
		}

		private string _contra;

		public string contra
		{
			get { return _contra; }
			set { _contra = value; }
		}

		private string _tipoUs;

		public string tipoUs
		{
			get { return _tipoUs; }
			set { _tipoUs = value; }
		}
		public UsuarioBE() { }

		public UsuarioBE CrearUsuario(int id, string nom, string contra, string tipo)
		{
			this.id = id;
			this.nombre = nom;
			this.contra = contra;
			this.tipoUs = tipo;
			return this;
		}
    }
}
