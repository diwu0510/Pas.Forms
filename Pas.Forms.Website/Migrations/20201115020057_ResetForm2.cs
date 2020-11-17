using Microsoft.EntityFrameworkCore.Migrations;

namespace Pas.Forms.Website.Migrations
{
    public partial class ResetForm2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Forms_DbTableId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "IsMaster",
                table: "FormTables");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "FormTables");

            migrationBuilder.AddColumn<string>(
                name: "DbTableId",
                table: "FormTables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Forms_DbTableId",
                table: "Forms",
                column: "DbTableId");

            migrationBuilder.CreateIndex(
                name: "IX_FormTables_FormId",
                table: "FormTables",
                column: "FormId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "DbTableId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormTables_Forms_FormId",
                table: "FormTables");

            migrationBuilder.DropIndex(
                name: "IX_FormTables_FormId",
                table: "FormTables");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Forms_DbTableId",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "DbTableId",
                table: "FormTables");

            migrationBuilder.AddColumn<bool>(
                name: "IsMaster",
                table: "FormTables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "FormTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Forms_DbTableId",
                table: "Forms",
                column: "DbTableId");
        }
    }
}
