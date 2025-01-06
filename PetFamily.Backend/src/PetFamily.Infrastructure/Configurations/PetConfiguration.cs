using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;

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

            builder.ComplexProperty(p => p.Specie, specieBuilder =>
            {
                specieBuilder.Property(s => s.SpecieId)
                            .IsRequired(false)
                            .HasColumnType("uuid")
                            .HasColumnName("specie_id");

                specieBuilder.Property(s => s.BreedId)
                            .IsRequired(false)
                            .HasColumnType("uuid")
                            .HasColumnName("breed_id");
            });


            builder.ComplexProperty(p => p.ByName, byNameBuilder =>
            {
                byNameBuilder.Property(fn => fn.Value)
                             .IsRequired()
                             .HasMaxLength(Constants.MAX_FULLNAME_LENGHT)
                             .HasColumnName("by_name");
            });

            builder.Property(p => p.CreationDate)
               .HasColumnType("date")
               .HasColumnName("creation_date");

            builder.ComplexProperty(p => p.Info, infoBuilder =>
            {
                infoBuilder.Property(i => i.Description)
                        .IsRequired(false)
                        .HasDefaultValue("")
                        .HasMaxLength(PetInfo.DESC_MAX_LENGHT)
                        .HasColumnName("description");

                infoBuilder.Property(i => i.DateOfBirth)
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                infoBuilder.Property(i => i.Color)
                        .IsRequired(false)
                        .HasMaxLength(PetInfo.MAX_COLOR_LENGHT)
                        .HasColumnName("color");

                infoBuilder.Property(i => i.PetHealthInfo)
                        .IsRequired(false)
                        .HasMaxLength(PetInfo.DESC_MAX_LENGHT)
                        .HasColumnName("pet_health_info");

                infoBuilder.Property(i => i.Weight)             
                        .HasColumnName("weight");

                infoBuilder.Property(i => i.Height)                    
                        .HasColumnName("height");

                infoBuilder.Property(i => i.IsNeutered)                        
                        .HasColumnName("is_neutered");

                infoBuilder.Property(i => i.IsVaccinated)                        
                        .HasColumnName("is_vaccinated");

                infoBuilder.Property(i => i.HelpStatus)
                        .HasDefaultValue(HelpStatus.NeedsHelp)
                        .HasColumnName("help_status");

                infoBuilder.Property(p => p.OwnerPhoneNumber)
                        .IsRequired(false)
                        .HasMaxLength(PetInfo.PHONE_MAX_LENGHT)
                        .HasColumnName("owner_phone_number");
            });

            builder.OwnsOne(p => p.Address, pa =>
            {
                pa.ToJson("address");
            });

            builder.OwnsOne(p => p.Photos, ph =>
            {
                ph.ToJson("photos");
                ph.OwnsMany(ph => ph.ListPhotos, lPh =>
                {
                    lPh.Property(l => l.Path)
                        .IsRequired()
                        .HasMaxLength(PetPhoto.MAX_PATH_LENGHT);
                    lPh.Property(l => l.IsMain);
                });
            });

            builder.OwnsOne(p => p.RequisitesForHelp, r =>
            {
                r.ToJson("requisites_for_help");
                r.OwnsMany(r => r.RequisitesForHelp, rh =>
                {
                    rh.Property(rh => rh.Name);
                    rh.Property(rh => rh.Description);
                });
            });

        }
    }
}
