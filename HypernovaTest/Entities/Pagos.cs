using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaTest.Entities
{
	public class Pagos
	{
		[Key]
		public int IdPago { get; set; }
		public int IdEmpleado { get; set; }
		public string Fecha { get; set; }
		public int NumeroCuenta { get; set; }
		public string Descripcion { get; set; }
		public double Total { get; set; }
		public string AprobadoPor { get; set; }
		public string Concepto { get; set; }
	}
}
