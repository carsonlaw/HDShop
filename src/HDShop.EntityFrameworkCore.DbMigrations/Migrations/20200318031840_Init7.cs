using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HDOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    UserId = table.Column<string>(maxLength: 20, nullable: false),
                    UserName = table.Column<string>(maxLength: 20, nullable: false),
                    PayPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PayTime = table.Column<DateTime>(nullable: false),
                    OrderStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDOrderLine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GoodSkuId = table.Column<Guid>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDOrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDOrderLine_HDGoodSku_GoodSkuId",
                        column: x => x.GoodSkuId,
                        principalTable: "HDGoodSku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HDOrderLine_HDOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "HDOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HDOrderLine_GoodSkuId",
                table: "HDOrderLine",
                column: "GoodSkuId");

            migrationBuilder.CreateIndex(
                name: "IX_HDOrderLine_OrderId",
                table: "HDOrderLine",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HDOrderLine");

            migrationBuilder.DropTable(
                name: "HDOrder");
        }
    }
}
