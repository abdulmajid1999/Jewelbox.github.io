using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jewelry.Migrations
{
    /// <inheritdoc />
    public partial class itemgoldcartprod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "goldKrtMsts",
                columns: table => new
                {
                    GoldKrtMstID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gold_Crt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goldKrtMsts", x => x.GoldKrtMstID);
                });

            migrationBuilder.CreateTable(
                name: "prodMsts",
                columns: table => new
                {
                    ProdMstID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prod_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_prodMsts", x => x.ProdMstID);
                });

            migrationBuilder.CreateTable(
                name: "itemMsts",
                columns: table => new
                {
                    ItemMstID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pairs = table.Column<int>(type: "int", nullable: false),
                    BrandMstID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CatMstId = table.Column<int>(type: "int", nullable: false),
                    Prod_Quality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertifyMstID = table.Column<int>(type: "int", nullable: false),
                    ProdMstID = table.Column<int>(type: "int", nullable: false),
                    GoldKrtMstID = table.Column<int>(type: "int", nullable: false),
                    Gold_Wt = table.Column<int>(type: "int", nullable: false),
                    Stone_Wt = table.Column<int>(type: "int", nullable: false),
                    Net_Gold = table.Column<int>(type: "int", nullable: false),
                    Wstg_Per = table.Column<int>(type: "int", nullable: false),
                    Wstg = table.Column<int>(type: "int", nullable: false),
                    Tot_Gross_Wt = table.Column<int>(type: "int", nullable: false),
                    Gold_Rate = table.Column<int>(type: "int", nullable: false),
                    Gold_Amt = table.Column<int>(type: "int", nullable: false),
                    Gold_Making = table.Column<int>(type: "int", nullable: false),
                    Stone_Making = table.Column<int>(type: "int", nullable: false),
                    Other_Making = table.Column<int>(type: "int", nullable: false),
                    Tot_Making = table.Column<int>(type: "int", nullable: false),
                    MRP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemMsts", x => x.ItemMstID);
                    table.ForeignKey(
                        name: "FK_itemMsts_CertifyMsts_CertifyMstID",
                        column: x => x.CertifyMstID,
                        principalTable: "CertifyMsts",
                        principalColumn: "CertifyMstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemMsts_brandMsts_BrandMstID",
                        column: x => x.BrandMstID,
                        principalTable: "brandMsts",
                        principalColumn: "BrandMstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemMsts_catMsts_CatMstId",
                        column: x => x.CatMstId,
                        principalTable: "catMsts",
                        principalColumn: "CatMstId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemMsts_goldKrtMsts_GoldKrtMstID",
                        column: x => x.GoldKrtMstID,
                        principalTable: "goldKrtMsts",
                        principalColumn: "GoldKrtMstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemMsts_prodMsts_ProdMstID",
                        column: x => x.ProdMstID,
                        principalTable: "prodMsts",
                        principalColumn: "ProdMstID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_itemMsts_BrandMstID",
                table: "itemMsts",
                column: "BrandMstID");

            migrationBuilder.CreateIndex(
                name: "IX_itemMsts_CatMstId",
                table: "itemMsts",
                column: "CatMstId");

            migrationBuilder.CreateIndex(
                name: "IX_itemMsts_CertifyMstID",
                table: "itemMsts",
                column: "CertifyMstID");

            migrationBuilder.CreateIndex(
                name: "IX_itemMsts_GoldKrtMstID",
                table: "itemMsts",
                column: "GoldKrtMstID");

            migrationBuilder.CreateIndex(
                name: "IX_itemMsts_ProdMstID",
                table: "itemMsts",
                column: "ProdMstID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemMsts");

            migrationBuilder.DropTable(
                name: "goldKrtMsts");

            migrationBuilder.DropTable(
                name: "prodMsts");
        }
    }
}
