using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Api.Migrations
{
    /// <inheritdoc />
    public partial class AfterCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquiler_Coche_CocheId",
                table: "Alquiler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coche",
                table: "Coche");

            migrationBuilder.RenameTable(
                name: "Coche",
                newName: "Coches");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coches",
                table: "Coches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alquiler_Coches_CocheId",
                table: "Alquiler",
                column: "CocheId",
                principalTable: "Coches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alquiler_Coches_CocheId",
                table: "Alquiler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coches",
                table: "Coches");

            migrationBuilder.RenameTable(
                name: "Coches",
                newName: "Coche");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coche",
                table: "Coche",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alquiler_Coche_CocheId",
                table: "Alquiler",
                column: "CocheId",
                principalTable: "Coche",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
