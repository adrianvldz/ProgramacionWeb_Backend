using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_24BM.Migrations
{
    /// <inheritdoc />
    public partial class exampl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Apellido",
                table: "Curriculums",
                newName: "Apellidos");

            migrationBuilder.AddColumn<string>(
                name: "DatosLaboral",
                table: "Curriculums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatosLaboral",
                table: "Curriculums");

            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "Curriculums",
                newName: "Apellido");
        }
    }
}
