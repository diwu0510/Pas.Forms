using Microsoft.EntityFrameworkCore.Migrations;

namespace Pas.Forms.Website.Migrations
{
    public partial class ResetForm5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Forms_DbTableId",
                table: "Forms");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_DbTableId",
                table: "Forms",
                column: "DbTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables");

            migrationBuilder.DropIndex(
                name: "IX_Forms_DbTableId",
                table: "Forms");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Forms_DbTableId",
                table: "Forms",
                column: "DbTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "DbTableId");
        }
    }
}
