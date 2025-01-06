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

            builder.ComplexProperty(v => v.FullName, fullNameBuilder =>
            {
                fullNameBuilder.Property(fn => fn.Value)
                                .IsRequired()
                                .HasMaxLength(Constants.MAX_FULLNAME_LENGHT)
                                .HasColumnName("full_name");
            });
                

            builder.ComplexProperty(v => v.Info, infoBuilder =>
            {
                infoBuilder.Property(e => e.Email)
                            .IsRequired()
                            .HasMaxLength(VolunteerInfo.EMAIL_MAX_LENGHT)
                            .HasColumnName("email");

                infoBuilder.Property(e => e.GeneralDescription)
                            .IsRequired()
                            .HasMaxLength(VolunteerInfo.DESC_MAX_LENGHT)
                            .HasColumnName("general_description");

                infoBuilder.Property(e => e.PhoneNumber)
                            .IsRequired()
                            .HasMaxLength(VolunteerInfo.PHONE_MAX_LENGHT)
                            .HasColumnName("phone_number");

                infoBuilder.Property(e => e.Experience)
                            .IsRequired()
                            .HasColumnName("experience");
            });

            builder.HasMany(v => v.Pets)
                .WithOne()
                .HasForeignKey("volunteer_id");

            builder.OwnsOne(v => v.SocialMedias, vsm =>
            {
                vsm.ToJson("social_medias");                
                vsm.OwnsMany(vsm => vsm.ListSocialMedia, lsm => 
                {
                    lsm.Property(sm => sm.Name)
                        .IsRequired(false)
                        .HasMaxLength(SocialMedia.MAX_NAME_LENGHT);

                    lsm.Property(sm => sm.Link)
                        .IsRequired(false);
                });
            });

            builder.OwnsOne(p => p.RequisitesForHelp, r =>
            {
                r.ToJson("requisites_for_help");
                r.OwnsMany(r => r.RequisitesForHelp, rh =>
                {
                    rh.Property(rh => rh.Name).IsRequired(false);
                    rh.Property(rh => rh.Description).IsRequired(false);
                });
            });
        }
    }
}
