using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guerron_Elizabeth_EXAMENPROGRESO.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Altura",
                table: "EGuerron",
                newName: "Sueldo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sueldo",
                table: "EGuerron",
                newName: "Altura");
        }
    }
}
