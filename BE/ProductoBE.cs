using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
	public class ProductoBE
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

		private decimal _precio;

		public decimal precio
		{
			get { return _precio; }
			set { _precio = value; }
		}

		private int _stock;

		public int stock
		{
			get { return _stock; }
			set { _stock = value; }
		}

		private string _DVH;
		public string DVH
		{
			get { return _DVH; }
			set { _DVH = value; }
		}
	}
}
