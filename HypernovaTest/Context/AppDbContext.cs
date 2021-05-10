using HypernovaTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HypernovaTest.Context
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}
		
		public DbSet<Empleados> Empleados { get; set; }
		public DbSet<Pagos> Pagos { get; set; }

		public DbSet<Empleado_Pago> Empleado_Pago { get; set; }


	}
}
