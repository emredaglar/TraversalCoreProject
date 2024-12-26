using Microsoft.EntityFrameworkCore;
using TraversalApiProject.DAL.Entities;

namespace TraversalApiProject.DAL.Context
{
	public class Context:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DD\\SQLEXPRESS01;database=TraversalApiDb;integrated security=true;TrustServerCertificate=True;");
		}
		public DbSet<Visitor> Visitors { get; set; }
	}
}
