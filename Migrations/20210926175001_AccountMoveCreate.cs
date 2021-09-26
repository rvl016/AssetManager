using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AssetManager.Migrations
{
    public partial class AccountMoveCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoveId",
                table: "AccountMoveLines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccountMove",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Reference = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    DatePosted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountMove", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountMoveLines_MoveId",
                table: "AccountMoveLines",
                column: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountMoveLines_AccountMove_MoveId",
                table: "AccountMoveLines",
                column: "MoveId",
                principalTable: "AccountMove",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountMoveLines_AccountMove_MoveId",
                table: "AccountMoveLines");

            migrationBuilder.DropTable(
                name: "AccountMove");

            migrationBuilder.DropIndex(
                name: "IX_AccountMoveLines_MoveId",
                table: "AccountMoveLines");

            migrationBuilder.DropColumn(
                name: "MoveId",
                table: "AccountMoveLines");
        }
    }
}
