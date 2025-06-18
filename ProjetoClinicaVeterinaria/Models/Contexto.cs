using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Models
{
	public class Contexto : DbContext
	{
		public Contexto(DbContextOptions<Contexto>options)  : base(options)
		{
		}

		public DbSet<Cliente> Cliente { get; set; }
	}
}