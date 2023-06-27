using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class TypeWeaponandWeapon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_TypesWeapons_TypeWeaponId_TypeWeapon",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_TypeWeaponId_TypeWeapon",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "TypeWeaponId_TypeWeapon",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "TypeWeaponId",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_TypeWeaponId",
                table: "Weapons",
                column: "TypeWeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_TypesWeapons_TypeWeaponId",
                table: "Weapons",
                column: "TypeWeaponId",
                principalTable: "TypesWeapons",
                principalColumn: "Id_TypeWeapon",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_TypesWeapons_TypeWeaponId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_TypeWeaponId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "TypeWeaponId",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "TypeWeaponId_TypeWeapon",
                table: "Weapons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_TypeWeaponId_TypeWeapon",
                table: "Weapons",
                column: "TypeWeaponId_TypeWeapon");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_TypesWeapons_TypeWeaponId_TypeWeapon",
                table: "Weapons",
                column: "TypeWeaponId_TypeWeapon",
                principalTable: "TypesWeapons",
                principalColumn: "Id_TypeWeapon");
        }
    }
}
