using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Api.Migrations
{
    /// <inheritdoc />
    public partial class newMigrationVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "Usuario",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Usuario",
                newName: "Nombre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuario",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Usuario",
                newName: "UserName");
        }
    }
}
