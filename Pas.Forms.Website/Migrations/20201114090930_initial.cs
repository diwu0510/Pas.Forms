using Microsoft.EntityFrameworkCore.Migrations;

namespace Pas.Forms.Website.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dbs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConnectionString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsValid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbTables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbConnectionId = table.Column<int>(type: "int", nullable: false),
                    DbId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbTables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbTables_Dbs_DbId",
                        column: x => x.DbId,
                        principalTable: "Dbs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DbFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertIgnore = table.Column<bool>(type: "bit", nullable: false),
                    UpdateIgnore = table.Column<bool>(type: "bit", nullable: false),
                    IsForeignKey = table.Column<bool>(type: "bit", nullable: false),
                    ForeignTable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForeignTableKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DbTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbFields_DbTables_DbTableId",
                        column: x => x.DbTableId,
                        principalTable: "DbTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbFields_DbTableId",
                table: "DbFields",
                column: "DbTableId");

            migrationBuilder.CreateIndex(
                name: "IX_DbTables_DbId",
                table: "DbTables",
                column: "DbId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbFields");

            migrationBuilder.DropTable(
                name: "DbTables");

            migrationBuilder.DropTable(
                name: "Dbs");
        }
    }
}
