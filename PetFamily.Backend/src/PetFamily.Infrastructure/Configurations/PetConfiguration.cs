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
            builder.ToTable(nameof(Pet));
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasConversion(
                id => id.Value,
                value => PetId.Create(value));

            builder.Property(p => p.SpecieId).HasColumnName("specie_id");
            builder.Property(p => p.BreedId).HasColumnName("breed_id");

            builder.Property(p => p.ByName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_FULLNAME_LENGHT);

            builder.Property(p => p.Description)
                .HasMaxLength(Constants.MAX_DESCRIPTION_LENGHT);

            builder.Property(p => p.DateOfBirth)
                .HasColumnType("date");
            
            builder.Property(p => p.CreationDate)
                .HasColumnType("date");

            builder.Property(p => p.Color)
                .HasMaxLength(Constants.MAX_COLOR_LENGHT);

            builder.Property(p => p.PetHealthInfo)
                .HasMaxLength(Constants.MAX_DESCRIPTION_LENGHT);

            builder.Property(p => p.Weight);
            builder.Property(p => p.Height);
            builder.Property(p => p.IsNeutered);
            builder.Property(p => p.IsVaccinated);

            builder.Property(p => p.PetHelpStatus)
                   .IsRequired()
                   .HasColumnName("help_status"); 


            builder.OwnsOne(p => p.PetAddress, pa =>
            {
                pa.ToJson();  
            });

            builder.OwnsOne(p => p.Photos, ph =>
            {
                ph.ToJson();
                ph.OwnsMany(ph => ph.ListPhotos, lPh => 
                {
                    lPh.Property(l => l.Path)
                        .IsRequired()
                        .HasMaxLength(PetPhoto.MAX_PATH_LENGHT);
                    lPh.Property(l => l.IsMain);
                });
            });

            builder.Property(p => p.OwnerPhoneNumber)
                .HasMaxLength(Constants.MAX_PHONENUMBER_LENGHT);
           
            builder.OwnsOne(p => p.RequisitesForHelp, r =>
            {
                r.ToJson();
                r.OwnsMany(r => r.RequisitesForHelp, rh => 
                {
                    rh.Property(rh => rh.Name);
                    rh.Property(rh => rh.Description);
                });
            });

        }
    }
}
