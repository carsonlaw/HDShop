using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HDGood_HDGood_SaleStates_GoodId1",
                table: "HDGood");

            migrationBuilder.DropIndex(
                name: "IX_HDGood_SaleStates_GoodId1",
                table: "HDGood");

            migrationBuilder.DropColumn(
                name: "Sort",
                table: "HDGoodPropertyMap");

            migrationBuilder.DropColumn(
                name: "SaleStates_GoodId1",
                table: "HDGood");

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "HDGoodProperty",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sort",
                table: "HDGoodProperty");

            migrationBuilder.AddColumn<int>(
                name: "Sort",
                table: "HDGoodPropertyMap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "SaleStates_GoodId1",
                table: "HDGood",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HDGood_SaleStates_GoodId1",
                table: "HDGood",
                column: "SaleStates_GoodId1");

            migrationBuilder.AddForeignKey(
                name: "FK_HDGood_HDGood_SaleStates_GoodId1",
                table: "HDGood",
                column: "SaleStates_GoodId1",
                principalTable: "HDGood",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
