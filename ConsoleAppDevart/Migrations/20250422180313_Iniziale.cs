using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleAppDevart.Migrations
{
    /// <inheritdoc />
    public partial class Iniziale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DOTNET");

            migrationBuilder.CreateTable(
                name: "TB_TST_GRUPO",
                schema: "DOTNET",
                columns: table => new
                {
                    NAME = table.Column<string>(type: "varchar2(30)", unicode: false, maxLength: 30, nullable: false),
                    DESCRIPTION = table.Column<string>(type: "varchar2(300)", unicode: false, maxLength: 300, nullable: false),
                    STATUS = table.Column<string>(type: "varchar2(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TST_GRUPO", x => x.NAME);
                });

            migrationBuilder.CreateTable(
                name: "TB_TST_PEOPLE",
                schema: "DOTNET",
                columns: table => new
                {
                    NAME = table.Column<string>(type: "varchar2(30)", unicode: false, maxLength: 30, nullable: false),
                    STATUS = table.Column<string>(type: "varchar2(1)", maxLength: 1, nullable: false),
                    GRUPONAME = table.Column<string>(type: "varchar2(30)", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TST_PEOPLE", x => x.NAME);
                    table.ForeignKey(
                        name: "FK_TB_TST_PEOPLE_TB_TST_GRUPO_NAME",
                        column: x => x.NAME,
                        principalSchema: "DOTNET",
                        principalTable: "TB_TST_GRUPO",
                        principalColumn: "NAME");
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_TST_PEOPLE",
                schema: "DOTNET");

            migrationBuilder.DropTable(
                name: "TB_TST_GRUPO",
                schema: "DOTNET");
        }
    }
}
