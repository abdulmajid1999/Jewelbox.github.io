using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jewelry.Migrations
{
    /// <inheritdoc />
    public partial class dimdimqltydimsubqlty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dimQltyMsts",
                columns: table => new
                {
                    DimQltyMstID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimQlty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dimQltyMsts", x => x.DimQltyMstID);
                });

            migrationBuilder.CreateTable(
                name: "dimQltySubMsts",
                columns: table => new
                {
                    DimQltySubMstID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DimQlty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dimQltySubMsts", x => x.DimQltySubMstID);
                });

            migrationBuilder.CreateTable(
                name: "dimMsts",
                columns: table => new
                {
                    DimMstId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemMstID = table.Column<int>(type: "int", nullable: false),
                    DimQltyMstID = table.Column<int>(type: "int", nullable: false),
                    DimQltySubMstID = table.Column<int>(type: "int", nullable: false),
                    Dim_Crt = table.Column<int>(type: "int", nullable: false),
                    Dim_Pcs = table.Column<int>(type: "int", nullable: false),
                    Dim_Gm = table.Column<int>(type: "int", nullable: false),
                    Dim_Size = table.Column<int>(type: "int", nullable: false),
                    Dim_Rate = table.Column<int>(type: "int", nullable: false),
                    Dim_Amt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dimMsts", x => x.DimMstId);
                    table.ForeignKey(
                        name: "FK_dimMsts_dimQltyMsts_DimQltyMstID",
                        column: x => x.DimQltyMstID,
                        principalTable: "dimQltyMsts",
                        principalColumn: "DimQltyMstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dimMsts_dimQltySubMsts_DimQltySubMstID",
                        column: x => x.DimQltySubMstID,
                        principalTable: "dimQltySubMsts",
                        principalColumn: "DimQltySubMstID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dimMsts_itemMsts_ItemMstID",
                        column: x => x.ItemMstID,
                        principalTable: "itemMsts",
                        principalColumn: "ItemMstID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dimMsts_DimQltyMstID",
                table: "dimMsts",
                column: "DimQltyMstID");

            migrationBuilder.CreateIndex(
                name: "IX_dimMsts_DimQltySubMstID",
                table: "dimMsts",
                column: "DimQltySubMstID");

            migrationBuilder.CreateIndex(
                name: "IX_dimMsts_ItemMstID",
                table: "dimMsts",
                column: "ItemMstID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dimMsts");

            migrationBuilder.DropTable(
                name: "dimQltyMsts");

            migrationBuilder.DropTable(
                name: "dimQltySubMsts");
        }
    }
}
