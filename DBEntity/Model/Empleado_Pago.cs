using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity.Model
{
	
	class Empleado_Pago
	{
		public int IdEmpleado { get; set; }
		public string NombreCompleto { get; set; }
		public string Posicion { get; set; }
		public string Departamento { get; set; }
		public string Supervisor { get; set; }
		public int IdPago { get; set; }
		public string Fecha { get; set; }
		public int NumeroCuenta { get; set; }
		public string Descripcion { get; set; }
		public double Total { get; set; }
		public string AprobadoPor { get; set; }
		public string Concepto { get; set; }
	}
}
