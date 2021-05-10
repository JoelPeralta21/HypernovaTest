using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HypernovaTest.Entities
{
	public class Empleados
	{
		[Key]
		public int IdEmpleado { get; set; }
		public string NombreCompleto { get; set; }
		public string Posicion { get; set; }
		public string Departamento { get; set; }
		public string Supervisor { get; set; }

	}
}
