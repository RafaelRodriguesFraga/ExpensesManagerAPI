using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpensesManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Invoice_Month_Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("07e0314b-a148-414a-8d58-89e4c8feb0db"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("39541f54-fd2e-4670-8bb4-daa0295e19cc"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("85e5d4a8-c4b4-4356-9d27-d07c0c6a78a2"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("8d43d296-1896-44f4-8a32-998374fb7a63"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("ae8b9d29-3bfb-45ea-9c5b-c9c32ed24dc3"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("f4387472-57eb-4188-9d0d-76198051d94e"));

            migrationBuilder.CreateTable(
                name: "invoice_months",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    code = table.Column<int>(type: "integer", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_months", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "credit_card",
                columns: new[] { "id", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("223057d4-6dc5-4ee5-8ff3-363a61426402"), new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(10), "Inter Black" },
                    { new Guid("3c0896a6-9186-4fbd-a480-b294a0058feb"), new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(30), "Amex TGC" },
                    { new Guid("49dc3995-cdb5-4b71-b1c2-3bd25509b839"), new DateTime(2024, 7, 20, 22, 47, 17, 674, DateTimeKind.Local).AddTicks(9980), "Inter Gold" },
                    { new Guid("a9d8a2e4-699a-4019-b15e-f5ffa1e3a0a8"), new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(40), "XP Visa Infinite" },
                    { new Guid("ae7005a9-7df2-47bd-b148-4a54741ce3aa"), new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(50), "BB Elo Mais" },
                    { new Guid("e7073716-0d35-4c7e-a29e-adf1e8e31aec"), new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(60), "C6 Bank Standard" }
                });

            migrationBuilder.InsertData(
                table: "invoice_months",
                columns: new[] { "id", "code", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("1ed05727-390d-48ed-a20e-d64d827953bc"), 10, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3600), "Outubro" },
                    { new Guid("20624d88-1d16-41d4-a4d0-b923bc1a34af"), 2, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3540), "Fevereiro" },
                    { new Guid("2c92607c-e75d-4266-96a7-5a9e5af8a861"), 12, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3610), "Dezembro" },
                    { new Guid("373be07e-0a93-4548-8c9c-ca08e6297092"), 6, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3570), "Junho" },
                    { new Guid("3ecbd482-79d0-4c49-9362-8b1fa6f8dbc3"), 9, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3590), "Setembro" },
                    { new Guid("65be0841-36dc-4c6a-bd84-e237332da601"), 3, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3550), "Marco" },
                    { new Guid("6909d2ad-90b6-409f-b0b9-183d4bf249ca"), 8, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3580), "Agosto" },
                    { new Guid("6d642ac8-521d-4651-91d9-c1eb0f7954d3"), 1, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3530), "Janeio" },
                    { new Guid("7d82c60d-340c-483f-9f5a-1cc50d8d6196"), 4, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3550), "Abril" },
                    { new Guid("8f9e9e23-a570-493e-b9e2-204a0303758b"), 5, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3560), "Maio" },
                    { new Guid("d529e867-7e97-42c9-83c0-7f833247b671"), 7, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3580), "Julho" },
                    { new Guid("ebdb56f2-c91c-4145-972b-cb10b4036fd5"), 11, new DateTime(2024, 7, 20, 22, 47, 17, 675, DateTimeKind.Local).AddTicks(3610), "Novembro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_months");

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("223057d4-6dc5-4ee5-8ff3-363a61426402"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("3c0896a6-9186-4fbd-a480-b294a0058feb"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("49dc3995-cdb5-4b71-b1c2-3bd25509b839"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("a9d8a2e4-699a-4019-b15e-f5ffa1e3a0a8"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("ae7005a9-7df2-47bd-b148-4a54741ce3aa"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("e7073716-0d35-4c7e-a29e-adf1e8e31aec"));

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
    }
}
