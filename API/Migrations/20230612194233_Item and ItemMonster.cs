using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ItemandItemMonster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id_Category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id_Category);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id_Item = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc_Item = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stats_Item = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HowFound_Item = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id_Item);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id_Weapon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_Weapon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Weapon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_Weapon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status_Weapon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Find_Weapon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Magic_Weapon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id_Weapon);
                });

            migrationBuilder.CreateTable(
                name: "Monsters",
                columns: table => new
                {
                    Id_Monster = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NO_Monster = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name_Monster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LV_Monster = table.Column<int>(type: "int", nullable: true),
                    HP_Monster = table.Column<int>(type: "int", nullable: true),
                    Img_Monster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strong_Monster = table.Column<int>(type: "int", nullable: true),
                    Immune_Monster = table.Column<int>(type: "int", nullable: true),
                    Weak_Monster = table.Column<int>(type: "int", nullable: true),
                    Absorb_Monster = table.Column<int>(type: "int", nullable: true),
                    EXP_Monster = table.Column<int>(type: "int", nullable: true),
                    Desc_Monster = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monsters", x => x.Id_Monster);
                    table.ForeignKey(
                        name: "FK_Monsters_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id_Category",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemMonster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    MonstersId_Monster = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMonster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemMonster_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id_Item",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemMonster_Monsters_MonstersId_Monster",
                        column: x => x.MonstersId_Monster,
                        principalTable: "Monsters",
                        principalColumn: "Id_Monster");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemMonster_ItemId",
                table: "ItemMonster",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemMonster_MonstersId_Monster",
                table: "ItemMonster",
                column: "MonstersId_Monster");

            migrationBuilder.CreateIndex(
                name: "IX_Monsters_CategoryId",
                table: "Monsters",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemMonster");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Monsters");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
