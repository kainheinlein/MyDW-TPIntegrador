using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ItemCarritoBE
    {
		private int _codigo;

		public int codigo
		{
			get { return _codigo; }
			set { _codigo = value; }
		}

		private string _producto;

		public string producto
		{
			get { return _producto; }
			set { _producto = value; }
		}

        private decimal _preUnitario;

        public decimal preUnitario
		{
			get { return _preUnitario; }
			set { _preUnitario = value; }
		}

        private int _cantidad;

		public int cantidad
		{
			get { return _cantidad; }
			set { _cantidad = value; }
		}

		private decimal _subtotal;

		public decimal subtotal
		{
			get { return _subtotal; }
			set { _subtotal = value; }
		}

		public ItemCarritoBE() { }
	}
}
