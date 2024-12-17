using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Infrastructure.Configurations
{
    internal class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable(nameof(PetConfiguration));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasConversion(
                id => id.Value,
                value => EntityId<PetId>.Create(value));

            builder.Property(p => p.ByName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_FULLNAME_LENGHT);

            builder.Property(p => p.Description)
                .HasMaxLength(Constants.MAX_DESCRIPTION_LENGHT);

            builder.Property(p => p.DateOfBirth)
                .HasColumnType("date");

            
        }
    }
}
