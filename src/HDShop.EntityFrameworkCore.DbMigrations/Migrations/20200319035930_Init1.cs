using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaleState_IsRecommand",
                table: "HDGood",
                newName: "SaleStates_IsRecommand");

            migrationBuilder.RenameColumn(
                name: "SaleState_IsNew",
                table: "HDGood",
                newName: "SaleStates_IsNew");

            migrationBuilder.RenameColumn(
                name: "SaleState_IsHot",
                table: "HDGood",
                newName: "SaleStates_IsHot");

            migrationBuilder.RenameColumn(
                name: "SaleState_IsDiscount",
                table: "HDGood",
                newName: "SaleStates_IsDiscount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SaleStates_IsRecommand",
                table: "HDGood",
                newName: "SaleState_IsRecommand");

            migrationBuilder.RenameColumn(
                name: "SaleStates_IsNew",
                table: "HDGood",
                newName: "SaleState_IsNew");

            migrationBuilder.RenameColumn(
                name: "SaleStates_IsHot",
                table: "HDGood",
                newName: "SaleState_IsHot");

            migrationBuilder.RenameColumn(
                name: "SaleStates_IsDiscount",
                table: "HDGood",
                newName: "SaleState_IsDiscount");
        }
    }
}
