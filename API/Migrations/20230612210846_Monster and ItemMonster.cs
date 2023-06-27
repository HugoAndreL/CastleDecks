using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class MonsterandItemMonster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMonster_Monsters_MonstersId_Monster",
                table: "ItemMonster");

            migrationBuilder.RenameColumn(
                name: "MonstersId_Monster",
                table: "ItemMonster",
                newName: "MonstersId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemMonster_MonstersId_Monster",
                table: "ItemMonster",
                newName: "IX_ItemMonster_MonstersId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMonster_Monsters_MonstersId",
                table: "ItemMonster",
                column: "MonstersId",
                principalTable: "Monsters",
                principalColumn: "Id_Monster");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMonster_Monsters_MonstersId",
                table: "ItemMonster");

            migrationBuilder.RenameColumn(
                name: "MonstersId",
                table: "ItemMonster",
                newName: "MonstersId_Monster");

            migrationBuilder.RenameIndex(
                name: "IX_ItemMonster_MonstersId",
                table: "ItemMonster",
                newName: "IX_ItemMonster_MonstersId_Monster");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMonster_Monsters_MonstersId_Monster",
                table: "ItemMonster",
                column: "MonstersId_Monster",
                principalTable: "Monsters",
                principalColumn: "Id_Monster");
        }
    }
}
