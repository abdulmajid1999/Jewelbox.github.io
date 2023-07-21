using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jewelry.Migrations
{
    /// <inheritdoc />
    public partial class stone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stoneMsts",
                columns: table => new
                {
                    StoneMstId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemMstID = table.Column<int>(type: "int", nullable: false),
                    StoneQltyMstID = table.Column<int>(type: "int", nullable: false),
                    Stone_Gm = table.Column<int>(type: "int", nullable: false),
                    Stone_Pcs = table.Column<int>(type: "int", nullable: false),
                    Stone_Crt = table.Column<int>(type: "int", nullable: false),
                    Stone_Rate = table.Column<int>(type: "int", nullable: false),
                    Stone_Amt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stoneMsts", x => x.StoneMstId);
                    table.ForeignKey(
                        name: "FK_stoneMsts_itemMsts_ItemMstID",
                        column: x => x.ItemMstID,
                        principalTable: "itemMsts",
                        principalColumn: "ItemMstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stoneMsts_stoneQltyMsts_StoneQltyMstID",
                        column: x => x.StoneQltyMstID,
                        principalTable: "stoneQltyMsts",
                        principalColumn: "StoneQltyMstID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stoneMsts_ItemMstID",
                table: "stoneMsts",
                column: "ItemMstID");

            migrationBuilder.CreateIndex(
                name: "IX_stoneMsts_StoneQltyMstID",
                table: "stoneMsts",
                column: "StoneQltyMstID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stoneMsts");
        }
    }
}
