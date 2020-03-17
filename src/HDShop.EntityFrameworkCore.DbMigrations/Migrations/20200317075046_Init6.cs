using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class Init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrlsValue",
                table: "HDGood",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrlsValue",
                table: "HDGood");
        }
    }
}
