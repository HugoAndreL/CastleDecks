using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class SpellandFamiliar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpellId",
                table: "Familiars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Familiars_SpellId",
                table: "Familiars",
                column: "SpellId",
                unique: true,
                filter: "[SpellId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Familiars_Spells_SpellId",
                table: "Familiars",
                column: "SpellId",
                principalTable: "Spells",
                principalColumn: "Id_Spell");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Familiars_Spells_SpellId",
                table: "Familiars");

            migrationBuilder.DropIndex(
                name: "IX_Familiars_SpellId",
                table: "Familiars");

            migrationBuilder.DropColumn(
                name: "SpellId",
                table: "Familiars");
        }
    }
}
