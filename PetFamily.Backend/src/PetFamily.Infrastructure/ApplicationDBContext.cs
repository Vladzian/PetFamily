using Microsoft.EntityFrameworkCore;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Infrastructure
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql();
        }
    }
}
