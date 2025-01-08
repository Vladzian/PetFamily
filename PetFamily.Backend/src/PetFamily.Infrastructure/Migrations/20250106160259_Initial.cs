using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    experience = table.Column<byte>(type: "smallint", nullable: false),
                    general_description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    requisites_for_help = table.Column<string>(type: "jsonb", nullable: false),
                    social_medias = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_volunteer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Breed",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    species_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_breed", x => x.id);
                    table.ForeignKey(
                        name: "fk_breed_species_species_id",
                        column: x => x.species_id,
                        principalTable: "Species",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    creation_date = table.Column<DateTime>(type: "date", nullable: false),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    by_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    color = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "date", nullable: false),
                    description = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true, defaultValue: ""),
                    height = table.Column<float>(type: "real", nullable: false),
                    help_status = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_neutered = table.Column<bool>(type: "boolean", nullable: false),
                    is_vaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    owner_phone_number = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true),
                    pet_health_info = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    weight = table.Column<float>(type: "real", nullable: false),
                    breed_id = table.Column<Guid>(type: "uuid", nullable: true),
                    specie_id = table.Column<Guid>(type: "uuid", nullable: true),
                    address = table.Column<string>(type: "jsonb", nullable: false),
                    photos = table.Column<string>(type: "jsonb", nullable: false),
                    requisites_for_help = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pet", x => x.id);
                    table.ForeignKey(
                        name: "fk_pet_volunteer_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "Volunteer",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_breed_species_id",
                table: "Breed",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "ix_pet_volunteer_id",
                table: "Pet",
                column: "volunteer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breed");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropTable(
                name: "Volunteer");
        }
    }
}
