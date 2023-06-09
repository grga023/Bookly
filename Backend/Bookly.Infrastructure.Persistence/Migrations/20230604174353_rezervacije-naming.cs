using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookly.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class rezervacijenaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Apartmani_ApartmanID",
                table: "Rezervacija");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacija_Kornisici_KorisnikID",
                table: "Rezervacija");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervacija",
                table: "Rezervacija");

            migrationBuilder.RenameTable(
                name: "Rezervacija",
                newName: "Rezervacije");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_KorisnikID",
                table: "Rezervacije",
                newName: "IX_Rezervacije_KorisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacija_ApartmanID",
                table: "Rezervacije",
                newName: "IX_Rezervacije_ApartmanID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervacije",
                table: "Rezervacije",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Apartmani_ApartmanID",
                table: "Rezervacije",
                column: "ApartmanID",
                principalTable: "Apartmani",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacije_Kornisici_KorisnikID",
                table: "Rezervacije",
                column: "KorisnikID",
                principalTable: "Kornisici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Apartmani_ApartmanID",
                table: "Rezervacije");

            migrationBuilder.DropForeignKey(
                name: "FK_Rezervacije_Kornisici_KorisnikID",
                table: "Rezervacije");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rezervacije",
                table: "Rezervacije");

            migrationBuilder.RenameTable(
                name: "Rezervacije",
                newName: "Rezervacija");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacije_KorisnikID",
                table: "Rezervacija",
                newName: "IX_Rezervacija_KorisnikID");

            migrationBuilder.RenameIndex(
                name: "IX_Rezervacije_ApartmanID",
                table: "Rezervacija",
                newName: "IX_Rezervacija_ApartmanID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rezervacija",
                table: "Rezervacija",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Apartmani_ApartmanID",
                table: "Rezervacija",
                column: "ApartmanID",
                principalTable: "Apartmani",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rezervacija_Kornisici_KorisnikID",
                table: "Rezervacija",
                column: "KorisnikID",
                principalTable: "Kornisici",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
