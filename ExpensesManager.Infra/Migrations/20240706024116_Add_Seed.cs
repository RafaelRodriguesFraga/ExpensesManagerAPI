using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpensesManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "credit_card",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credit_card", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "credit_card",
                columns: new[] { "id", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("07e0314b-a148-414a-8d58-89e4c8feb0db"), new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2530), "Amex TGC" },
                    { new Guid("39541f54-fd2e-4670-8bb4-daa0295e19cc"), new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2540), "BB Elo Mais" },
                    { new Guid("85e5d4a8-c4b4-4356-9d27-d07c0c6a78a2"), new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2520), "Inter Black" },
                    { new Guid("8d43d296-1896-44f4-8a32-998374fb7a63"), new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2530), "XP Visa Infinite" },
                    { new Guid("ae8b9d29-3bfb-45ea-9c5b-c9c32ed24dc3"), new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2470), "Inter Gold" },
                    { new Guid("f4387472-57eb-4188-9d0d-76198051d94e"), new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2550), "C6 Bank Standard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "credit_card");
        }
    }
}
