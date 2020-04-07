using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class Init13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HDOrderDeliverAddressMap_OrderId",
                table: "HDOrderDeliverAddressMap");

            migrationBuilder.CreateIndex(
                name: "IX_HDOrderDeliverAddressMap_OrderId",
                table: "HDOrderDeliverAddressMap",
                column: "OrderId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HDOrderDeliverAddressMap_OrderId",
                table: "HDOrderDeliverAddressMap");

            migrationBuilder.CreateIndex(
                name: "IX_HDOrderDeliverAddressMap_OrderId",
                table: "HDOrderDeliverAddressMap",
                column: "OrderId");
        }
    }
}
