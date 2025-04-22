using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleAppDevart.Migrations
{
    /// <inheritdoc />
    public partial class AddDati : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TST_PEOPLE_TB_TST_GRUPO_NAME",
                schema: "DOTNET",
                table: "TB_TST_PEOPLE");

            migrationBuilder.InsertData(
                schema: "DOTNET",
                table: "TB_TST_GRUPO",
                columns: new[] { "NAME", "DESCRIPTION", "STATUS" },
                values: new object[,]
                {
                    { "Grupo1", "Descrizione Grupo1", "A" },
                    { "Grupo2", "Descrizione Grupo2", "A" },
                    { "Grupo3", "Descrizione Grupo3", "A" },
                    { "Grupo4", "Descrizione Grupo4", "A" }
                });

            migrationBuilder.InsertData(
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                columns: new[] { "NAME", "GRUPONAME", "STATUS" },
                values: new object[,]
                {
                    { "User1-1", "Grupo1", "A" },
                    { "User2-1", "Grupo1", "A" },
                    { "User3-1", "Grupo1", "I" },
                    { "User4-1", "Grupo1", "A" },
                    { "User5-2", "Grupo2", "A" },
                    { "User6-2", "Grupo2", "A" },
                    { "User7-2", "Grupo2", "I" },
                    { "User8-1", "Grupo1", "A" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_TST_PEOPLE_GRUPONAME",
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                column: "GRUPONAME");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TST_PEOPLE_TB_TST_GRUPO_GRUPONAME",
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                column: "GRUPONAME",
                principalSchema: "DOTNET",
                principalTable: "TB_TST_GRUPO",
                principalColumn: "NAME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_TST_PEOPLE_TB_TST_GRUPO_GRUPONAME",
                schema: "DOTNET",
                table: "TB_TST_PEOPLE");

            migrationBuilder.DropIndex(
                name: "IX_TB_TST_PEOPLE_GRUPONAME",
                schema: "DOTNET",
                table: "TB_TST_PEOPLE");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_GRUPO",
                keyColumn: "NAME",
                keyValue: "Grupo3");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_GRUPO",
                keyColumn: "NAME",
                keyValue: "Grupo4");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                keyColumn: "NAME",
                keyValue: "User1-1");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                keyColumn: "NAME",
                keyValue: "User2-1");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                keyColumn: "NAME",
                keyValue: "User3-1");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                keyColumn: "NAME",
                keyValue: "User4-1");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                keyColumn: "NAME",
                keyValue: "User5-2");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                keyColumn: "NAME",
                keyValue: "User6-2");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                keyColumn: "NAME",
                keyValue: "User7-2");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                keyColumn: "NAME",
                keyValue: "User8-1");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_GRUPO",
                keyColumn: "NAME",
                keyValue: "Grupo1");

            migrationBuilder.DeleteData(
                schema: "DOTNET",
                table: "TB_TST_GRUPO",
                keyColumn: "NAME",
                keyValue: "Grupo2");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_TST_PEOPLE_TB_TST_GRUPO_NAME",
                schema: "DOTNET",
                table: "TB_TST_PEOPLE",
                column: "NAME",
                principalSchema: "DOTNET",
                principalTable: "TB_TST_GRUPO",
                principalColumn: "NAME");
        }
    }
}
