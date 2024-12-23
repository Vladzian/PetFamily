using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Infrastructure.Configurations
{
    public class SpeciesConfiguration : IEntityTypeConfiguration<Species>
    {
        public void Configure(EntityTypeBuilder<Species> builder)
        {
            builder.ToTable(nameof(Species));
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .HasConversion(
                    id => id.Value,
                    value => SpeciesId.Create(value));

            builder.Property(v => v.Name)
                   .HasMaxLength(Constants.MAX_FULLNAME_LENGHT)
                   .IsRequired();

            builder.HasMany(s => s.Breeds)
                   .WithOne(e => e.Species)
                   .HasForeignKey(b => b.SpeciesId)
                   .IsRequired(true);
            
        }

    }
}
