using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jewelry.Migrations
{
    /// <inheritdoc />
    public partial class itemdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemDetails",
                columns: table => new
                {
                    ItemMstID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CatMstId = table.Column<int>(type: "int", nullable: false),
                    prodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pairs = table.Column<int>(type: "int", nullable: false),
                    BrandMstID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CertifyMstID = table.Column<int>(type: "int", nullable: false),
                    GoldKrtMstID = table.Column<int>(type: "int", nullable: false),
                    Gold_Wt = table.Column<int>(type: "int", nullable: false),
                    Net_Gold = table.Column<int>(type: "int", nullable: false),
                    Wstg_Per = table.Column<int>(type: "int", nullable: false),
                    Wstg = table.Column<int>(type: "int", nullable: false),
                    Tot_Gross_Wt = table.Column<int>(type: "int", nullable: false),
                    Gold_Rate = table.Column<int>(type: "int", nullable: false),
                    Gold_Amt = table.Column<int>(type: "int", nullable: false),
                    Gold_Making = table.Column<int>(type: "int", nullable: false),
                    ProdMstID = table.Column<int>(type: "int", nullable: false),
                    Dim_Pcs = table.Column<int>(type: "int", nullable: false),
                    Stone_Wt = table.Column<int>(type: "int", nullable: false),
                    Stone_Making = table.Column<int>(type: "int", nullable: false),
                    Dim_Amt = table.Column<int>(type: "int", nullable: false),
                    imgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MRP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemDetails", x => x.ItemMstID);
                    table.ForeignKey(
                        name: "FK_itemDetails_CertifyMsts_CertifyMstID",
                        column: x => x.CertifyMstID,
                        principalTable: "CertifyMsts",
                        principalColumn: "CertifyMstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemDetails_brandMsts_BrandMstID",
                        column: x => x.BrandMstID,
                        principalTable: "brandMsts",
                        principalColumn: "BrandMstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemDetails_catMsts_CatMstId",
                        column: x => x.CatMstId,
                        principalTable: "catMsts",
                        principalColumn: "CatMstId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemDetails_goldKrtMsts_GoldKrtMstID",
                        column: x => x.GoldKrtMstID,
                        principalTable: "goldKrtMsts",
                        principalColumn: "GoldKrtMstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_itemDetails_prodMsts_ProdMstID",
                        column: x => x.ProdMstID,
                        principalTable: "prodMsts",
                        principalColumn: "ProdMstID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_itemDetails_BrandMstID",
                table: "itemDetails",
                column: "BrandMstID");

            migrationBuilder.CreateIndex(
                name: "IX_itemDetails_CatMstId",
                table: "itemDetails",
                column: "CatMstId");

            migrationBuilder.CreateIndex(
                name: "IX_itemDetails_CertifyMstID",
                table: "itemDetails",
                column: "CertifyMstID");

            migrationBuilder.CreateIndex(
                name: "IX_itemDetails_GoldKrtMstID",
                table: "itemDetails",
                column: "GoldKrtMstID");

            migrationBuilder.CreateIndex(
                name: "IX_itemDetails_ProdMstID",
                table: "itemDetails",
                column: "ProdMstID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemDetails");
        }
    }
}
