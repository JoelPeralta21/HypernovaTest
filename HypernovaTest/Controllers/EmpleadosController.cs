using HypernovaTest.Context;
using HypernovaTest.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HypernovaTest.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmpleadosController : ControllerBase
	{
		private readonly AppDbContext db;
		public EmpleadosController(AppDbContext db)
		{
			this.db = db;
		}
		// GET: api/<EmpleadosController>
		[HttpGet]

		public IEnumerable<Empleados> Get()
		{
			return db.Empleados.ToList();
		}


		// GET api/<EmpleadosController>/
		[HttpGet("{id}")]
		public Empleados Get(int id)
		{
			var empleados = db.Empleados.FirstOrDefault(x => x.IdEmpleado == id);
			return empleados;
		}

		// POST api/<EmpleadosController>
		[HttpPost]
		public ActionResult Post([FromBody] Empleados empleados)
		{
			try
			{
				db.Empleados.Add(empleados);
				db.SaveChanges();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest();//se devuelve el estado 400, server no interpreta la solicitud
			}
		}

		// PUT api/<EmpleadosController>/5
		[HttpPut("{id}")]
		public ActionResult Put(int id, [FromBody] Empleados empleados)
		{

			if (empleados.IdEmpleado == id)
			{
				db.Entry(empleados).State = EntityState.Modified;
				db.SaveChanges();
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}

		// DELETE api/<EmpleadosController>/5
		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			var empleado = db.Empleados.FirstOrDefault(x => x.IdEmpleado == id);

				if (empleado != null)
				{
					db.Empleados.Remove(empleado);
					db.SaveChanges();
					return Ok();
				}
				else
				{
					return BadRequest();
				}
		}


	}

}
