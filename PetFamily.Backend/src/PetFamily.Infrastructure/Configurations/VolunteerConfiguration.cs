using CSharpFunctionalExtensions;
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
    public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
    {
        public void Configure(EntityTypeBuilder<Volunteer> builder)
        {
            builder.ToTable(nameof(Volunteer));
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .HasConversion(
                    id => id.Value,
                    value => VolunteerId.Create(value));
            builder.Property(v => v.FullName)
                .IsRequired()
                .HasMaxLength(Constants.MAX_FULLNAME_LENGHT);
            
            builder.Property(v => v.Email)
                .IsRequired()
                .HasMaxLength(Constants.MAX_EMAIL_LENGHT);
            
            builder.Property(v => v.GeneralDescription)
                .IsRequired()
                .HasMaxLength(Constants.MAX_DESCRIPTION_LENGHT);
            
            builder.Property(v => v.PhoneNumber)
                .HasColumnType("character")
                .HasMaxLength(Constants.MAX_PHONENUMBER_LENGHT);
            builder.Property(v => v.Experience)
                .HasColumnType("smallint");

            builder.HasMany(v => v.Pets)
                .WithOne()
                .HasForeignKey("volunteer_id");

            builder.OwnsMany(v => v.SocialMedias, sm =>
            {
                sm.ToJson();
            });

            builder.OwnsMany(v => v.RequisitesForHelp, rh =>
            { 
                rh.ToJson();
            });
        }
    }
}
