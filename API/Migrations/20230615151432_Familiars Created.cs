using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class FamiliarsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Familiars",
                columns: table => new
                {
                    Id_Familiar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Img_Familiar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Familiar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phrase_Familiar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiars", x => x.Id_Familiar);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Familiars");
        }
    }
}
