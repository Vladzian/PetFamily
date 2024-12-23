﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PetFamily.Infrastructure;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PetFamily.Domain.Species.Breed", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<Guid>("SpeciesId")
                        .HasColumnType("uuid")
                        .HasColumnName("species_id");

                    b.HasKey("Id")
                        .HasName("pk_breed");

                    b.HasIndex("SpeciesId")
                        .HasDatabaseName("ix_breed_species_id");

                    b.ToTable("Breed", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Species.Species", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_species");

                    b.ToTable("Species", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteer.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid?>("BreedId")
                        .HasColumnType("uuid")
                        .HasColumnName("breed_id");

                    b.Property<string>("ByName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("by_name");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("color");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date")
                        .HasColumnName("creation_date");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("description");

                    b.Property<float>("Height")
                        .HasColumnType("real")
                        .HasColumnName("height");

                    b.Property<bool>("IsNeutered")
                        .HasColumnType("boolean")
                        .HasColumnName("is_neutered");

                    b.Property<bool>("IsVaccinated")
                        .HasColumnType("boolean")
                        .HasColumnName("is_vaccinated");

                    b.Property<string>("OwnerPhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("owner_phone_number");

                    b.Property<string>("PetHealthInfo")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("pet_health_info");

                    b.Property<int>("PetHelpStatus")
                        .HasColumnType("integer")
                        .HasColumnName("help_status");

                    b.Property<Guid?>("SpecieId")
                        .HasColumnType("uuid")
                        .HasColumnName("specie_id");

                    b.Property<float>("Weight")
                        .HasColumnType("real")
                        .HasColumnName("weight");

                    b.Property<Guid?>("volunteer_id")
                        .HasColumnType("uuid")
                        .HasColumnName("volunteer_id");

                    b.HasKey("Id")
                        .HasName("pk_pet");

                    b.HasIndex("volunteer_id")
                        .HasDatabaseName("ix_pet_volunteer_id");

                    b.ToTable("Pet", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteer.Volunteer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<byte>("Experience")
                        .HasColumnType("smallint")
                        .HasColumnName("experience");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("full_name");

                    b.Property<string>("GeneralDescription")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("character varying(512)")
                        .HasColumnName("general_description");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character")
                        .HasColumnName("phone_number");

                    b.HasKey("Id")
                        .HasName("pk_volunteer");

                    b.ToTable("Volunteer", (string)null);
                });

            modelBuilder.Entity("PetFamily.Domain.Species.Breed", b =>
                {
                    b.HasOne("PetFamily.Domain.Species.Species", "Species")
                        .WithMany("Breeds")
                        .HasForeignKey("SpeciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_breed_species_species_id");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteer.Pet", b =>
                {
                    b.HasOne("PetFamily.Domain.Volunteer.Volunteer", null)
                        .WithMany("Pets")
                        .HasForeignKey("volunteer_id")
                        .HasConstraintName("fk_pet_volunteer_volunteer_id");

                    b.OwnsOne("PetFamily.Domain.Shared.Address", "PetAddress", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("PetId");

                            b1.ToTable("Pet");

                            b1.ToJson("PetAddress");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pet_pet_id");
                        });

                    b.OwnsOne("PetFamily.Domain.Volunteer.Requisites", "RequisitesForHelp", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid");

                            b1.HasKey("PetId")
                                .HasName("pk_pet");

                            b1.ToTable("Pet");

                            b1.ToJson("RequisitesForHelp");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pet_pet_pet_id");

                            b1.OwnsMany("PetFamily.Domain.Volunteer.HelpRequisite", "RequisitesForHelp", b2 =>
                                {
                                    b2.Property<Guid>("RequisitesPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("RequisitesPetId", "Id")
                                        .HasName("pk_pet");

                                    b2.ToTable("Pet");

                                    b2.WithOwner()
                                        .HasForeignKey("RequisitesPetId")
                                        .HasConstraintName("fk_pet_pet_requisites_pet_id");
                                });

                            b1.Navigation("RequisitesForHelp");
                        });

                    b.OwnsOne("PetFamily.Domain.Volunteer.PetPhotos", "Photos", b1 =>
                        {
                            b1.Property<Guid>("PetId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("PetId");

                            b1.ToTable("Pet");

                            b1.ToJson("Photos");

                            b1.WithOwner()
                                .HasForeignKey("PetId")
                                .HasConstraintName("fk_pet_pet_id");

                            b1.OwnsMany("PetFamily.Domain.Volunteer.PetPhoto", "ListPhotos", b2 =>
                                {
                                    b2.Property<Guid>("PetPhotosPetId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<bool>("IsMain")
                                        .HasColumnType("boolean");

                                    b2.Property<string>("Path")
                                        .IsRequired()
                                        .HasMaxLength(255)
                                        .HasColumnType("character varying(255)");

                                    b2.HasKey("PetPhotosPetId", "Id")
                                        .HasName("pk_pet");

                                    b2.ToTable("Pet");

                                    b2.WithOwner()
                                        .HasForeignKey("PetPhotosPetId")
                                        .HasConstraintName("fk_pet_pet_pet_photos_pet_id");
                                });

                            b1.Navigation("ListPhotos");
                        });

                    b.Navigation("PetAddress")
                        .IsRequired();

                    b.Navigation("Photos")
                        .IsRequired();

                    b.Navigation("RequisitesForHelp")
                        .IsRequired();
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteer.Volunteer", b =>
                {
                    b.OwnsOne("PetFamily.Domain.Volunteer.SocialMedias", "VolunteerSocialMedias", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("Volunteer");

                            b1.ToJson("VolunteerSocialMedias");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteer_volunteer_id");

                            b1.OwnsMany("PetFamily.Domain.Volunteer.SocialMedia", "ListSocialMedia", b2 =>
                                {
                                    b2.Property<Guid>("SocialMediasVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Link")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(150)
                                        .HasColumnType("character varying(150)");

                                    b2.HasKey("SocialMediasVolunteerId", "Id")
                                        .HasName("pk_volunteer");

                                    b2.ToTable("Volunteer");

                                    b2.WithOwner()
                                        .HasForeignKey("SocialMediasVolunteerId")
                                        .HasConstraintName("fk_volunteer_volunteer_social_medias_volunteer_id");
                                });

                            b1.Navigation("ListSocialMedia");
                        });

                    b.OwnsOne("PetFamily.Domain.Volunteer.Requisites", "RequisitesForHelp", b1 =>
                        {
                            b1.Property<Guid>("VolunteerId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.HasKey("VolunteerId");

                            b1.ToTable("Volunteer");

                            b1.ToJson("RequisitesForHelp");

                            b1.WithOwner()
                                .HasForeignKey("VolunteerId")
                                .HasConstraintName("fk_volunteer_volunteer_id");

                            b1.OwnsMany("PetFamily.Domain.Volunteer.HelpRequisite", "RequisitesForHelp", b2 =>
                                {
                                    b2.Property<Guid>("RequisitesVolunteerId")
                                        .HasColumnType("uuid");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasColumnType("text");

                                    b2.HasKey("RequisitesVolunteerId", "Id")
                                        .HasName("pk_volunteer");

                                    b2.ToTable("Volunteer");

                                    b2.WithOwner()
                                        .HasForeignKey("RequisitesVolunteerId")
                                        .HasConstraintName("fk_volunteer_volunteer_requisites_volunteer_id");
                                });

                            b1.Navigation("RequisitesForHelp");
                        });

                    b.Navigation("RequisitesForHelp")
                        .IsRequired();

                    b.Navigation("VolunteerSocialMedias")
                        .IsRequired();
                });

            modelBuilder.Entity("PetFamily.Domain.Species.Species", b =>
                {
                    b.Navigation("Breeds");
                });

            modelBuilder.Entity("PetFamily.Domain.Volunteer.Volunteer", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
