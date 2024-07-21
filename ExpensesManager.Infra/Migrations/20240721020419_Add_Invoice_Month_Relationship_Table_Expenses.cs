using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpensesManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Invoice_Month_Relationship_Table_Expenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("1ed05727-390d-48ed-a20e-d64d827953bc"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("20624d88-1d16-41d4-a4d0-b923bc1a34af"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("2c92607c-e75d-4266-96a7-5a9e5af8a861"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("373be07e-0a93-4548-8c9c-ca08e6297092"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("3ecbd482-79d0-4c49-9362-8b1fa6f8dbc3"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("65be0841-36dc-4c6a-bd84-e237332da601"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("6909d2ad-90b6-409f-b0b9-183d4bf249ca"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("6d642ac8-521d-4651-91d9-c1eb0f7954d3"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("7d82c60d-340c-483f-9f5a-1cc50d8d6196"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("8f9e9e23-a570-493e-b9e2-204a0303758b"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("d529e867-7e97-42c9-83c0-7f833247b671"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("ebdb56f2-c91c-4145-972b-cb10b4036fd5"));

            migrationBuilder.DropColumn(
                name: "invoice_month",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "paid",
                table: "expenses");

            migrationBuilder.AddColumn<Guid>(
                name: "invoice_month_id",
                table: "expenses",
                type: "uuid",
                maxLength: 10,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "credit_card",
                columns: new[] { "id", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("427d534e-6f68-46e9-aadc-655853e50691"), new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(2540), "Inter Black" },
                    { new Guid("4e23155c-6275-4c44-b34f-b63f638d40a6"), new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(2570), "BB Elo Mais" },
                    { new Guid("82e8d759-4932-4f4c-9c5f-56d8f10f381b"), new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(2580), "C6 Bank Standard" },
                    { new Guid("c3ba3e4f-6928-4652-99f5-6a6b208ffb42"), new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(2550), "Amex TGC" },
                    { new Guid("c5432896-1184-4921-a161-f6ec4486aaec"), new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(2520), "Inter Gold" },
                    { new Guid("e8fbde5b-2084-449f-8ea3-2e31a522e765"), new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(2560), "XP Visa Infinite" }
                });

            migrationBuilder.InsertData(
                table: "invoice_months",
                columns: new[] { "id", "code", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("1afac8dd-1436-4c40-8b5a-627b478537d1"), 5, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3240), "Maio" },
                    { new Guid("3931991f-1962-445d-98d9-17f9733876fa"), 2, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3210), "Fevereiro" },
                    { new Guid("3f37999e-8808-4d91-883a-5b53b7460d65"), 10, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3270), "Outubro" },
                    { new Guid("5e43043e-6260-486b-9433-0cb4aadf3854"), 4, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3230), "Abril" },
                    { new Guid("99164a93-c21c-45c7-9c18-a354f0c48bdc"), 12, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3290), "Dezembro" },
                    { new Guid("9b0a31f4-ff93-4e73-84ab-c1907b52415b"), 7, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3250), "Julho" },
                    { new Guid("acedef82-d5ce-4bdf-b956-13b7c695bbd1"), 3, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3220), "Marco" },
                    { new Guid("af790125-d828-4d12-a404-7cabb826035e"), 8, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3260), "Agosto" },
                    { new Guid("bfbbddc0-4b42-49d6-8cf8-8bc11ff7da90"), 11, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3280), "Novembro" },
                    { new Guid("c9b5f349-2e84-4078-9186-f76da1315f63"), 1, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3200), "Janeio" },
                    { new Guid("f4942526-e38e-41fd-a965-18e87503a13f"), 9, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3270), "Setembro" },
                    { new Guid("fe2c6c70-5b43-466b-9296-f80a49c10f2a"), 6, new DateTime(2024, 7, 20, 23, 4, 18, 932, DateTimeKind.Local).AddTicks(3240), "Junho" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_expenses_invoice_month_id",
                table: "expenses",
                column: "invoice_month_id");

            migrationBuilder.AddForeignKey(
                name: "invoice_month_id",
                table: "expenses",
                column: "invoice_month_id",
                principalTable: "invoice_months",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "invoice_month_id",
                table: "expenses");

            migrationBuilder.DropIndex(
                name: "IX_expenses_invoice_month_id",
                table: "expenses");

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("427d534e-6f68-46e9-aadc-655853e50691"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("4e23155c-6275-4c44-b34f-b63f638d40a6"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("82e8d759-4932-4f4c-9c5f-56d8f10f381b"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("c3ba3e4f-6928-4652-99f5-6a6b208ffb42"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("c5432896-1184-4921-a161-f6ec4486aaec"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("e8fbde5b-2084-449f-8ea3-2e31a522e765"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("1afac8dd-1436-4c40-8b5a-627b478537d1"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("3931991f-1962-445d-98d9-17f9733876fa"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("3f37999e-8808-4d91-883a-5b53b7460d65"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("5e43043e-6260-486b-9433-0cb4aadf3854"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("99164a93-c21c-45c7-9c18-a354f0c48bdc"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("9b0a31f4-ff93-4e73-84ab-c1907b52415b"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("acedef82-d5ce-4bdf-b956-13b7c695bbd1"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("af790125-d828-4d12-a404-7cabb826035e"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("bfbbddc0-4b42-49d6-8cf8-8bc11ff7da90"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("c9b5f349-2e84-4078-9186-f76da1315f63"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("f4942526-e38e-41fd-a965-18e87503a13f"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("fe2c6c70-5b43-466b-9296-f80a49c10f2a"));

            migrationBuilder.DropColumn(
                name: "invoice_month_id",
                table: "expenses");

            migrationBuilder.AddColumn<string>(
                name: "invoice_month",
                table: "expenses",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "paid",
                table: "expenses",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
    }
}
