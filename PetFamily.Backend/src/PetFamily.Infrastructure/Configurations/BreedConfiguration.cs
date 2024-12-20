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
    public class BreedConfiguration : IEntityTypeConfiguration<Breed>
    {
        public void Configure(EntityTypeBuilder<Breed> builder)
        {
            builder.ToTable(nameof(Breed));
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .HasConversion(
                    id => id.Value,
                    value => BreedId.Create(value));
            builder.Property(v => v.Name)
                .HasMaxLength(Constants.MAX_FULLNAME_LENGHT)
                .IsRequired();             
        }
    }
}
