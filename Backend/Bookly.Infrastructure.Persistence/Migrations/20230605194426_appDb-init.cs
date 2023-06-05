using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookly.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class appDbinit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Apartmani");

            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApartmanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slike", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Slike_Apartmani_ApartmanID",
                        column: x => x.ApartmanID,
                        principalTable: "Apartmani",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slike_ApartmanID",
                table: "Slike",
                column: "ApartmanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slike");

            migrationBuilder.AddColumn<double>(
                name: "Cena",
                table: "Apartmani",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
