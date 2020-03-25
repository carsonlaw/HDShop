using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HDOrder_CreatorId",
                table: "HDOrder",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HDOrder_DeleterId",
                table: "HDOrder",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_HDOrder_LastModifierId",
                table: "HDOrder",
                column: "LastModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrder_AppUser_CreatorId",
                table: "HDOrder",
                column: "CreatorId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrder_AppUser_DeleterId",
                table: "HDOrder",
                column: "DeleterId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrder_AppUser_LastModifierId",
                table: "HDOrder",
                column: "LastModifierId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_AppUser_CreatorId",
                table: "HDOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_AppUser_DeleterId",
                table: "HDOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_AppUser_LastModifierId",
                table: "HDOrder");

            migrationBuilder.DropIndex(
                name: "IX_HDOrder_CreatorId",
                table: "HDOrder");

            migrationBuilder.DropIndex(
                name: "IX_HDOrder_DeleterId",
                table: "HDOrder");

            migrationBuilder.DropIndex(
                name: "IX_HDOrder_LastModifierId",
                table: "HDOrder");
        }
    }
}
