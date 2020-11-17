using Microsoft.EntityFrameworkCore.Migrations;

namespace Pas.Forms.Website.Migrations
{
    public partial class RenameDbConnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbTables_Dbs_DbId",
                table: "DbTables");

            migrationBuilder.DropColumn(
                name: "DbConnectionId",
                table: "DbTables");

            migrationBuilder.AlterColumn<int>(
                name: "DbId",
                table: "DbTables",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ForeignTable",
                table: "DbFields",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DbTables_Dbs_DbId",
                table: "DbTables",
                column: "DbId",
                principalTable: "Dbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DbTables_Dbs_DbId",
                table: "DbTables");

            migrationBuilder.AlterColumn<int>(
                name: "DbId",
                table: "DbTables",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DbConnectionId",
                table: "DbTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ForeignTable",
                table: "DbFields",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DbTables_Dbs_DbId",
                table: "DbTables",
                column: "DbId",
                principalTable: "Dbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
