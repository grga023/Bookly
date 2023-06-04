using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookly.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class dodanerezervacije : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezervacija",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApartmanID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KorisnikID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatumDolaska = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumOdlaska = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Apartmani_ApartmanID",
                        column: x => x.ApartmanID,
                        principalTable: "Apartmani",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervacija_Kornisici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Kornisici",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_ApartmanID",
                table: "Rezervacija",
                column: "ApartmanID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacija_KorisnikID",
                table: "Rezervacija",
                column: "KorisnikID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacija");
        }
    }
}
