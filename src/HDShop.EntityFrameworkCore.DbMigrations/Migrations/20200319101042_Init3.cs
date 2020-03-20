using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SaleStates_GoodId1",
                table: "HDGood",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HDGood_HDGood_SaleStates_GoodId1",
                table: "HDGood");

            migrationBuilder.DropIndex(
                name: "IX_HDGood_SaleStates_GoodId1",
                table: "HDGood");

            migrationBuilder.DropColumn(
                name: "SaleStates_GoodId1",
                table: "HDGood");
        }
    }
}
