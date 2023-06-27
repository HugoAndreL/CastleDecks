using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ItemIdNulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMonster_Items_ItemId",
                table: "ItemMonster");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemMonster",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMonster_Items_ItemId",
                table: "ItemMonster",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id_Item");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMonster_Items_ItemId",
                table: "ItemMonster");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemMonster",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMonster_Items_ItemId",
                table: "ItemMonster",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id_Item",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
