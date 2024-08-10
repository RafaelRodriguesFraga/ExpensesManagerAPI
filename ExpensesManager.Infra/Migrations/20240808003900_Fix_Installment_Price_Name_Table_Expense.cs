using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpensesManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Fix_Installment_Price_Name_Table_Expense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "intallment_price",
                table: "expenses",
                newName: "installment_price");

            migrationBuilder.InsertData(
                table: "credit_card",
                columns: new[] { "id", "created_at", "name" },
                values: new object[,]
                {
                    { new Guid("173b36c3-f538-445e-938e-dafe8a812d33"), new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3110), "C6 Bank Standard" },
                    { new Guid("473b5651-ae1f-4017-bced-bd342a8dcc09"), new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3090), "Amex TGC" },
                    { new Guid("a62bc917-5a79-4d41-b01c-0cc4bd97b5c9"), new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3090), "XP Visa Infinite" },
                    { new Guid("c4cad1f1-f678-4ee4-a034-e767a78331d2"), new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3040), "Inter Gold" },
                    { new Guid("d6f19267-bef9-4f44-86cf-0937c65871b6"), new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3080), "Inter Black" },
                    { new Guid("fdb8a5cc-2670-4c77-92f4-433c9c6080e3"), new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3100), "BB Elo Mais" }
                });

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("0325e053-cbcc-492b-b268-f7bcbd0fbacc"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3790));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("253c382a-d5d4-4a0f-97d1-7bc582795caf"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3820));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("3176f263-02e6-40ae-a0d8-8bb770c5d581"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3830));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("42caa6f7-8fee-479a-ad6b-89fc85f89e6b"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("4605c82b-4ef1-40a1-baaa-4646c4bb4dff"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("498732b2-31ae-410b-9ce0-c436d31be794"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("58a0cfe2-0a5e-42cd-a2a7-1515831b068b"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("ac9fa14b-38c4-4c4c-a614-162093942e36"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("cf143b5b-d705-4e46-b88c-8c5aa59fc9bc"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3770));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("eec7fa31-e1d7-49a8-a179-23900b7ff6af"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3810));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("f0509c30-2311-4209-a57f-b512b3b51d93"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("f4371cca-b3e9-49d6-aacf-c1b99bb63caa"),
                column: "created_at",
                value: new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3760));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("173b36c3-f538-445e-938e-dafe8a812d33"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("473b5651-ae1f-4017-bced-bd342a8dcc09"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("a62bc917-5a79-4d41-b01c-0cc4bd97b5c9"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("c4cad1f1-f678-4ee4-a034-e767a78331d2"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("d6f19267-bef9-4f44-86cf-0937c65871b6"));

            migrationBuilder.DeleteData(
                table: "credit_card",
                keyColumn: "id",
                keyValue: new Guid("fdb8a5cc-2670-4c77-92f4-433c9c6080e3"));

            migrationBuilder.RenameColumn(
                name: "installment_price",
                table: "expenses",
                newName: "intallment_price");

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

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("0325e053-cbcc-492b-b268-f7bcbd0fbacc"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("253c382a-d5d4-4a0f-97d1-7bc582795caf"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1360));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("3176f263-02e6-40ae-a0d8-8bb770c5d581"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1370));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("42caa6f7-8fee-479a-ad6b-89fc85f89e6b"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("4605c82b-4ef1-40a1-baaa-4646c4bb4dff"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1340));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("498732b2-31ae-410b-9ce0-c436d31be794"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("58a0cfe2-0a5e-42cd-a2a7-1515831b068b"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("ac9fa14b-38c4-4c4c-a614-162093942e36"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("cf143b5b-d705-4e46-b88c-8c5aa59fc9bc"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1310));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("eec7fa31-e1d7-49a8-a179-23900b7ff6af"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("f0509c30-2311-4209-a57f-b512b3b51d93"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "invoice_months",
                keyColumn: "id",
                keyValue: new Guid("f4371cca-b3e9-49d6-aacf-c1b99bb63caa"),
                column: "created_at",
                value: new DateTime(2024, 8, 3, 12, 31, 21, 636, DateTimeKind.Local).AddTicks(1300));
        }
    }
}
