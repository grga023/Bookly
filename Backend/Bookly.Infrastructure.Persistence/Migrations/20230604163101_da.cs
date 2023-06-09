using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookly.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class da : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Cena",
                table: "Apartmani",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Drzava",
                table: "Apartmani",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mesto",
                table: "Apartmani",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Ocena",
                table: "Apartmani",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Apartmani",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Apartmani");

            migrationBuilder.DropColumn(
                name: "Drzava",
                table: "Apartmani");

            migrationBuilder.DropColumn(
                name: "Mesto",
                table: "Apartmani");

            migrationBuilder.DropColumn(
                name: "Ocena",
                table: "Apartmani");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Apartmani");
        }
    }
}
