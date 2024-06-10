using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpensesManager.Infra.Migrations
{
    /// <inheritdoc />
    public partial class Change_Columns_To_Snake_Case : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenses_people_PersonId",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_people_users_UserId",
                table: "people");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_Email",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "users",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "people",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "people",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "people",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "people",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_people_UserId",
                table: "people",
                newName: "IX_people_user_id");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "expenses",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Paid",
                table: "expenses",
                newName: "paid");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "expenses",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "expenses",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PurchaseDate",
                table: "expenses",
                newName: "purchase_date");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "expenses",
                newName: "person_id");

            migrationBuilder.RenameColumn(
                name: "IsInstallment",
                table: "expenses",
                newName: "is_installment");

            migrationBuilder.RenameColumn(
                name: "InvoiceMonth",
                table: "expenses",
                newName: "invoice_month");

            migrationBuilder.RenameColumn(
                name: "CreditCardName",
                table: "expenses",
                newName: "credit_card_name");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "expenses",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_PersonId",
                table: "expenses",
                newName: "IX_expenses_person_id");

            migrationBuilder.AddPrimaryKey(
                name: "id",
                table: "users",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "person_id",
                table: "expenses",
                column: "person_id",
                principalTable: "people",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "user_id",
                table: "people",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "person_id",
                table: "expenses");

            migrationBuilder.DropForeignKey(
                name: "user_id",
                table: "people");

            migrationBuilder.DropPrimaryKey(
                name: "id",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "users",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "people",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "people",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "people",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "people",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_people_user_id",
                table: "people",
                newName: "IX_people_UserId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "expenses",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "paid",
                table: "expenses",
                newName: "Paid");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "expenses",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "expenses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "purchase_date",
                table: "expenses",
                newName: "PurchaseDate");

            migrationBuilder.RenameColumn(
                name: "person_id",
                table: "expenses",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "is_installment",
                table: "expenses",
                newName: "IsInstallment");

            migrationBuilder.RenameColumn(
                name: "invoice_month",
                table: "expenses",
                newName: "InvoiceMonth");

            migrationBuilder.RenameColumn(
                name: "credit_card_name",
                table: "expenses",
                newName: "CreditCardName");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "expenses",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_expenses_person_id",
                table: "expenses",
                newName: "IX_expenses_PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_expenses_people_PersonId",
                table: "expenses",
                column: "PersonId",
                principalTable: "people",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_people_users_UserId",
                table: "people",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
