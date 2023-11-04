using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_24BM.Migrations
{
    /// <inheritdoc />
    public partial class _31123 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NombreFoto",
                table: "Curriculums",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CURP",
                table: "Curriculums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CURP",
                table: "Curriculums");

            migrationBuilder.AlterColumn<string>(
                name: "NombreFoto",
                table: "Curriculums",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
