using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetManager.Migrations
{
    public partial class AccountCodeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountMoveLines_AccountMove_MoveId",
                table: "AccountMoveLines");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Code",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountMove",
                table: "AccountMove");

            migrationBuilder.RenameTable(
                name: "AccountMove",
                newName: "AccountMoves");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountMoves",
                table: "AccountMoves",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Code",
                table: "Accounts",
                column: "Code",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountMoveLines_AccountMoves_MoveId",
                table: "AccountMoveLines",
                column: "MoveId",
                principalTable: "AccountMoves",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountMoveLines_AccountMoves_MoveId",
                table: "AccountMoveLines");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_Code",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountMoves",
                table: "AccountMoves");

            migrationBuilder.RenameTable(
                name: "AccountMoves",
                newName: "AccountMove");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountMove",
                table: "AccountMove",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_Code",
                table: "Accounts",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountMoveLines_AccountMove_MoveId",
                table: "AccountMoveLines",
                column: "MoveId",
                principalTable: "AccountMove",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
