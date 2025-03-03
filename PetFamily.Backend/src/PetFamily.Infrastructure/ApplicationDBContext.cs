using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Infrastructure
{
    public class ApplicationDBContext(IConfiguration configuration) : DbContext
    {   
        private const string CS_POSTGRES_DB = nameof(CS_POSTGRES_DB);
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Species> Species{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(CS_POSTGRES_DB));
            optionsBuilder.UseSnakeCaseNamingConvention();
            
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
        }

        private static ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}