using Microsoft.EntityFrameworkCore.Migrations;

namespace Pas.Forms.Website.Migrations
{
    public partial class ResetForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Dbs_DbId",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "DbId",
                table: "Forms",
                newName: "DbTableId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_DbId",
                table: "Forms",
                newName: "IX_Forms_DbTableId");

            migrationBuilder.AddColumn<string>(
                name: "Fields",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_DbTables_DbTableId",
                table: "Forms",
                column: "DbTableId",
                principalTable: "DbTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forms_DbTables_DbTableId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Fields",
                table: "Forms");

            migrationBuilder.RenameColumn(
                name: "DbTableId",
                table: "Forms",
                newName: "DbId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_DbTableId",
                table: "Forms",
                newName: "IX_Forms_DbId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Dbs_DbId",
                table: "Forms",
                column: "DbId",
                principalTable: "Dbs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
