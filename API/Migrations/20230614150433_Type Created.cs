using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class TypeCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeWeaponId_TypeWeapon",
                table: "Weapons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypesWeapons",
                columns: table => new
                {
                    Id_TypeWeapon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_TypeWeapon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesWeapons", x => x.Id_TypeWeapon);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_TypesWeapons_TypeWeaponId_TypeWeapon",
                table: "Weapons");

            migrationBuilder.DropTable(
                name: "TypesWeapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_TypeWeaponId_TypeWeapon",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "TypeWeaponId_TypeWeapon",
                table: "Weapons");
        }
    }
}
