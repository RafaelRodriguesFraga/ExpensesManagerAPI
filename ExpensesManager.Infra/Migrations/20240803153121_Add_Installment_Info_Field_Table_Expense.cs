using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpensesManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Add_Installment_Info_Field_Table_Expense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "installment_info",
                table: "expenses",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "credit_card",
                columns: new[] { "id", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("0b86cf26-5b64-4993-b5c7-34fa2ad10e50"), new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(640), "Amex TGC" },
                    { new Guid("6417b0e1-9e86-40ac-9d12-978c5f7db2e1"), new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(630), "Inter Black" },
                    { new Guid("785def09-3d00-423c-a934-5a2c1525fb63"), new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(600), "Inter Gold" },
                    { new Guid("9c62eebf-125a-47f6-babc-17e56c88aef8"), new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(660), "C6 Bank Standard" },
                    { new Guid("acec67d8-1cc3-4ad2-8a12-6392d57aa685"), new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(650), "XP Visa Infinite" },
                    { new Guid("d7a0e997-bfca-439b-bc05-c0d87bdde42d"), new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(650), "BB Elo Mais" }
                });

            migrationBuilder.InsertData(
                table: "invoice_months",
                columns: new[] { "id", "code", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("0325e053-cbcc-492b-b268-f7bcbd0fbacc"), 5, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1330), "Maio" },
                    { new Guid("253c382a-d5d4-4a0f-97d1-7bc582795caf"), 9, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1360), "Setembro" },
                    { new Guid("3176f263-02e6-40ae-a0d8-8bb770c5d581"), 10, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1370), "Outubro" },
                    { new Guid("42caa6f7-8fee-479a-ad6b-89fc85f89e6b"), 7, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1340), "Julho" },
                    { new Guid("4605c82b-4ef1-40a1-baaa-4646c4bb4dff"), 6, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1340), "Junho" },
                    { new Guid("498732b2-31ae-410b-9ce0-c436d31be794"), 4, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1320), "Abril" },
                    { new Guid("58a0cfe2-0a5e-42cd-a2a7-1515831b068b"), 3, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1310), "Marco" },
                    { new Guid("ac9fa14b-38c4-4c4c-a614-162093942e36"), 12, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1380), "Dezembro" },
                    { new Guid("cf143b5b-d705-4e46-b88c-8c5aa59fc9bc"), 2, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1310), "Fevereiro" },
                    { new Guid("eec7fa31-e1d7-49a8-a179-23900b7ff6af"), 8, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1350), "Agosto" },
                    { new Guid("f0509c30-2311-4209-a57f-b512b3b51d93"), 11, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1380), "Novembro" },
                    { new Guid("f4371cca-b3e9-49d6-aacf-c1b99bb63caa"), 1, new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1300), "Janeiro" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("0b86cf26-5b64-4993-b5c7-34fa2ad10e50"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("6417b0e1-9e86-40ac-9d12-978c5f7db2e1"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("785def09-3d00-423c-a934-5a2c1525fb63"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("9c62eebf-125a-47f6-babc-17e56c88aef8"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("acec67d8-1cc3-4ad2-8a12-6392d57aa685"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("d7a0e997-bfca-439b-bc05-c0d87bdde42d"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("0325e053-cbcc-492b-b268-f7bcbd0fbacc"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("253c382a-d5d4-4a0f-97d1-7bc582795caf"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("3176f263-02e6-40ae-a0d8-8bb770c5d581"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("42caa6f7-8fee-479a-ad6b-89fc85f89e6b"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("4605c82b-4ef1-40a1-baaa-4646c4bb4dff"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("498732b2-31ae-410b-9ce0-c436d31be794"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("58a0cfe2-0a5e-42cd-a2a7-1515831b068b"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("ac9fa14b-38c4-4c4c-a614-162093942e36"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("cf143b5b-d705-4e46-b88c-8c5aa59fc9bc"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("eec7fa31-e1d7-49a8-a179-23900b7ff6af"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("f0509c30-2311-4209-a57f-b512b3b51d93"));

            migrationBuilder.DeleteData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("f4371cca-b3e9-49d6-aacf-c1b99bb63caa"));

            migrationBuilder.DropColumn(
                name: "installment_info",
                table: "expenses");

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
    }
}
