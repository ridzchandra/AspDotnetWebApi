using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PokemonReview.Migrations
{
    /// <inheritdoc />
    public partial class initial_migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pokemon", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reviewer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviewer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Gym = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_owner_country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CategoryPokemon",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "integer", nullable: false),
                    PokemonsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPokemon", x => new { x.CategoriesId, x.PokemonsId });
                    table.ForeignKey(
                        name: "FK_CategoryPokemon_category_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryPokemon_pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    ReviewerId = table.Column<int>(type: "integer", nullable: true),
                    PokemonId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.Id);
                    table.ForeignKey(
                        name: "FK_review_pokemon_PokemonId",
                        column: x => x.PokemonId,
                        principalTable: "pokemon",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_review_reviewer_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "reviewer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OwnerPokemon",
                columns: table => new
                {
                    OwnersId = table.Column<int>(type: "integer", nullable: false),
                    PokemonsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerPokemon", x => new { x.OwnersId, x.PokemonsId });
                    table.ForeignKey(
                        name: "FK_OwnerPokemon_owner_OwnersId",
                        column: x => x.OwnersId,
                        principalTable: "owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OwnerPokemon_pokemon_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "pokemon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryPokemon_PokemonsId",
                table: "CategoryPokemon",
                column: "PokemonsId");

            migrationBuilder.CreateIndex(
                name: "IX_owner_CountryId",
                table: "owner",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnerPokemon_PokemonsId",
                table: "OwnerPokemon",
                column: "PokemonsId");

            migrationBuilder.CreateIndex(
                name: "IX_review_PokemonId",
                table: "review",
                column: "PokemonId");

            migrationBuilder.CreateIndex(
                name: "IX_review_ReviewerId",
                table: "review",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryPokemon");

            migrationBuilder.DropTable(
                name: "OwnerPokemon");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "owner");

            migrationBuilder.DropTable(
                name: "pokemon");

            migrationBuilder.DropTable(
                name: "reviewer");

            migrationBuilder.DropTable(
                name: "country");
        }
    }
}
