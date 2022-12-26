using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UoWDemo.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    POBox = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    Apartment = table.Column<string>(type: "TEXT", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CreatedAt", "FirstName", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3512), "Jordan", "Davila", new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3615) },
                    { 2, new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3617), "Giovanni", "Krueger", new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3618) },
                    { 3, new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3620), "Marjorie", "Nolan", new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3621) }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Apartment", "City", "Country", "CreatedAt", "POBox", "PersonId", "Street", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "3", "Lisboa", "Portuguese", new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3738), "1900-349", 1, "Yango Avenida, Quadra 25", new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3740) },
                    { 2, "54", "Faro", "Portuguese", new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3742), "1900-123", 2, "Braga Rua, Quadra 01", new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3744) },
                    { 3, "", "Albufeira", "Portuguese", new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3746), "1900-73", 3, "Moraes Alameda, Casa 2", new DateTime(2022, 12, 12, 11, 44, 22, 538, DateTimeKind.Local).AddTicks(3747) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PersonId",
                table: "Addresses",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
