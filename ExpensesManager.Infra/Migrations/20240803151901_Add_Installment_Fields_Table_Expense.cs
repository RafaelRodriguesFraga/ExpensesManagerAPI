using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpensesManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Installment_Fields_Table_Expense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "purchase_date",
                table: "expenses",
                type: "timestamp",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<int>(
                name: "current_installment",
                table: "expenses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "intallment_price",
                table: "expenses",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "total_installments",
                table: "expenses",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "credit_card",
                columns: new[] { "id", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("146a4c2e-29e3-4d8b-a33d-01048d81bb5f"), new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9210), "Amex TGC" },
                    { new Guid("198bbd24-c87e-449d-af32-a6533d9a160e"), new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9200), "Inter Black" },
                    { new Guid("abcb4bb5-9955-4a5f-af6c-19c4185dc28e"), new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9220), "XP Visa Infinite" },
                    { new Guid("bbafbe9e-439c-4fba-aa54-5d86a13ec63a"), new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9170), "Inter Gold" },
                    { new Guid("c2a23e50-89eb-4ae1-b58f-c6889667b47d"), new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9240), "C6 Bank Standard" },
                    { new Guid("d26e8643-67e9-4ebd-b535-5283eab6996b"), new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9230), "BB Elo Mais" }
                });

            migrationBuilder.InsertData(
                table: "invoice_months",
                columns: new[] { "id", "code", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("05e2736f-d70d-48ff-9b82-77e07a9f202f"), 2, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9890), "Fevereiro" },
                    { new Guid("0bac5005-95ae-40b4-b7b0-a1e030e98705"), 10, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9950), "Outubro" },
                    { new Guid("4caa05c0-e965-452a-a567-4682533eb9c8"), 7, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9930), "Julho" },
                    { new Guid("60b63973-40ec-47b8-afa3-aa0faba522df"), 5, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9910), "Maio" },
                    { new Guid("701347ac-c63b-46f1-a28e-7b6ace293f84"), 8, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9930), "Agosto" },
                    { new Guid("719d1ca5-a742-4759-b076-1f4a50b6e3a3"), 11, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9960), "Novembro" },
                    { new Guid("77a5f79c-b979-4361-bfb1-c82cf2c8c29e"), 1, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9880), "Janeiro" },
                    { new Guid("830758d0-acb5-4066-8c73-d9bc805d86aa"), 3, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9900), "Marco" },
                    { new Guid("8f78f625-e55c-46b5-ba8c-32c05775a832"), 6, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9920), "Junho" },
                    { new Guid("99f51a2c-550f-4051-9ce0-148dd7a7d762"), 9, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9940), "Setembro" },
                    { new Guid("b4c198ef-7e46-4b7f-824f-e6daac67e678"), 12, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9960), "Dezembro" },
                    { new Guid("df265a81-89f7-4cb6-8b4c-21e8cb946989"), 4, new DateTime(2024, 8, 3, 12, 19, 0, 999, DateTimeKind.Local).AddTicks(9900), "Abril" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("146a4c2e-29e3-4d8b-a33d-01048d81bb5f"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("198bbd24-c87e-449d-af32-a6533d9a160e"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("abcb4bb5-9955-4a5f-af6c-19c4185dc28e"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("bbafbe9e-439c-4fba-aa54-5d86a13ec63a"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("c2a23e50-89eb-4ae1-b58f-c6889667b47d"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("d26e8643-67e9-4ebd-b535-5283eab6996b"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("05e2736f-d70d-48ff-9b82-77e07a9f202f"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("0bac5005-95ae-40b4-b7b0-a1e030e98705"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("4caa05c0-e965-452a-a567-4682533eb9c8"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("60b63973-40ec-47b8-afa3-aa0faba522df"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("701347ac-c63b-46f1-a28e-7b6ace293f84"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("719d1ca5-a742-4759-b076-1f4a50b6e3a3"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("77a5f79c-b979-4361-bfb1-c82cf2c8c29e"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("830758d0-acb5-4066-8c73-d9bc805d86aa"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("8f78f625-e55c-46b5-ba8c-32c05775a832"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("99f51a2c-550f-4051-9ce0-148dd7a7d762"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("b4c198ef-7e46-4b7f-824f-e6daac67e678"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("df265a81-89f7-4cb6-8b4c-21e8cb946989"));

            migrationBuilder.DropColumn(
                name: "current_installment",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "intallment_price",
                table: "expenses");

            migrationBuilder.DropColumn(
                name: "total_installments",
                table: "expenses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "purchase_date",
                table: "expenses",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp");

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
        }
    }
}
