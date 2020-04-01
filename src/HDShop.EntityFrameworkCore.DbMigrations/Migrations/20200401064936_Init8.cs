using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class Init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HDOrderDeliverAddressMap_HDDeliverAddress_DeliverAddressId",
                table: "HDOrderDeliverAddressMap");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrderLine_HDGoodSku_GoodSkuId",
                table: "HDOrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrderLine_HDOrder_OrderId",
                table: "HDOrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HDOrderLine",
                table: "HDOrderLine");

            migrationBuilder.DropIndex(
                name: "IX_HDOrderLine_OrderId",
                table: "HDOrderLine");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HDOrderLine");

            migrationBuilder.DropColumn(
                name: "PriceTotal",
                table: "HDOrderLine");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "HDDeliverAddress");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "HDDeliverAddress");

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "HDOrderLine",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GoodSkuId",
                table: "HDOrderLine",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HDOrderLine",
                table: "HDOrderLine",
                columns: new[] { "OrderId", "GoodSkuId" });

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrderLine_HDGoodSku_GoodSkuId",
                table: "HDOrderLine",
                column: "GoodSkuId",
                principalTable: "HDGoodSku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrderLine_HDOrder_OrderId",
                table: "HDOrderLine",
                column: "OrderId",
                principalTable: "HDOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HDOrderLine_HDGoodSku_GoodSkuId",
                table: "HDOrderLine");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrderLine_HDOrder_OrderId",
                table: "HDOrderLine");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HDOrderLine",
                table: "HDOrderLine");

            migrationBuilder.AlterColumn<Guid>(
                name: "GoodSkuId",
                table: "HDOrderLine",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "OrderId",
                table: "HDOrderLine",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "HDOrderLine",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "PriceTotal",
                table: "HDOrderLine",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "HDDeliverAddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "HDDeliverAddress",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HDOrderLine",
                table: "HDOrderLine",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HDOrderLine_OrderId",
                table: "HDOrderLine",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrderDeliverAddressMap_HDDeliverAddress_DeliverAddressId",
                table: "HDOrderDeliverAddressMap",
                column: "DeliverAddressId",
                principalTable: "HDDeliverAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrderLine_HDGoodSku_GoodSkuId",
                table: "HDOrderLine",
                column: "GoodSkuId",
                principalTable: "HDGoodSku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrderLine_HDOrder_OrderId",
                table: "HDOrderLine",
                column: "OrderId",
                principalTable: "HDOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
