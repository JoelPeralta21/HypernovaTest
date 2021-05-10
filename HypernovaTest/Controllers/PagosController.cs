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
	public class PagosController : ControllerBase
	{
		private readonly AppDbContext db;
		public PagosController(AppDbContext db)
		{
			this.db = db;
		}
		// GET: api/<EmpleadosController>
		[HttpGet]
		public IEnumerable<Pagos> Get()
		{
			return db.Pagos.ToList();
		}


		// GET api/<EmpleadosController>/
		[HttpGet("{id}")]
		public Pagos Get(int id)
		{
			var pagos = db.Pagos.FirstOrDefault(x => x.IdPago == id);
			return pagos;
		}

		// POST api/<EmpleadosController>
		[HttpPost]
		public ActionResult Post([FromBody] Pagos pagos)
		{
			try
			{
				db.Pagos.Add(pagos);
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
		public ActionResult Put(int id, [FromBody] Pagos pagos)
		{

			if (pagos.IdPago == id)
			{
				db.Entry(pagos).State = EntityState.Modified;
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
			var pagos = db.Pagos.FirstOrDefault(x => x.IdPago == id);

			if (pagos != null)
			{
				db.Pagos.Remove(pagos);
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

