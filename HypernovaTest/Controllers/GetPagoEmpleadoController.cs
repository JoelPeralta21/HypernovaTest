using HypernovaTest.Context;
using HypernovaTest.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace HypernovaTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class GetPagoEmpleadoController : ControllerBase
	{
		private readonly AppDbContext db;
		public GetPagoEmpleadoController(AppDbContext db)
		{
			this.db = db;
		}


		
		[HttpGet("{id}")]
		//[Route("api/EmpleadosController/")]
		public IEnumerable<Empleado_Pago> Empleado_Pago(int id)
		{
			var param = new SqlParameter("@IdEmpleado",id);

			
			string prod = "declare @IdEmpleado int" + " exec [dbo].[USP_Nombre_Gasto]" + " @IdEmpleado= " + id;
			return db.Empleado_Pago.FromSqlRaw(prod).ToList();

		}
	}
}
