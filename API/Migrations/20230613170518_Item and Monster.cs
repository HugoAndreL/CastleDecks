using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ItemandMonster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMonster_Items_ItemId",
                table: "ItemMonster");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMonster_Monsters_MonstersId",
                table: "ItemMonster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemMonster",
                table: "ItemMonster");

            migrationBuilder.DropIndex(
                name: "IX_ItemMonster_ItemId",
                table: "ItemMonster");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ItemMonster");

            migrationBuilder.AlterColumn<int>(
                name: "MonstersId",
                table: "ItemMonster",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemMonster",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemMonster",
                table: "ItemMonster",
                columns: new[] { "ItemId", "MonstersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMonster_Items_ItemId",
                table: "ItemMonster",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id_Item",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMonster_Monsters_MonstersId",
                table: "ItemMonster",
                column: "MonstersId",
                principalTable: "Monsters",
                principalColumn: "Id_Monster",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemMonster_Items_ItemId",
                table: "ItemMonster");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemMonster_Monsters_MonstersId",
                table: "ItemMonster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemMonster",
                table: "ItemMonster");

            migrationBuilder.AlterColumn<int>(
                name: "MonstersId",
                table: "ItemMonster",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ItemId",
                table: "ItemMonster",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ItemMonster",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemMonster",
                table: "ItemMonster",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMonster_ItemId",
                table: "ItemMonster",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMonster_Items_ItemId",
                table: "ItemMonster",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id_Item");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemMonster_Monsters_MonstersId",
                table: "ItemMonster",
                column: "MonstersId",
                principalTable: "Monsters",
                principalColumn: "Id_Monster");
        }
    }
}
