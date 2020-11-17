using Microsoft.EntityFrameworkCore.Migrations;

namespace Pas.Forms.Website.Migrations
{
    public partial class ResetForm4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables");

            migrationBuilder.DropColumn(
                name: "DbTable",
                table: "FormTables");

            migrationBuilder.AddColumn<int>(
                name: "DbTableId",
                table: "FormTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FormTables_DbTableId",
                table: "FormTables",
                column: "DbTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormTables_DbTables_DbTableId",
                table: "FormTables",
                column: "DbTableId",
                principalTable: "DbTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "DbTableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormTables_DbTables_DbTableId",
                table: "FormTables");

            migrationBuilder.DropForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables");

            migrationBuilder.DropIndex(
                name: "IX_FormTables_DbTableId",
                table: "FormTables");

            migrationBuilder.DropColumn(
                name: "DbTableId",
                table: "FormTables");

            migrationBuilder.AddColumn<string>(
                name: "DbTable",
                table: "FormTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "DbTableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
