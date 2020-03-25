using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ExtraProperties = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HDDeliverAddress_CreatorId",
                table: "HDDeliverAddress",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HDDeliverAddress_DeleterId",
                table: "HDDeliverAddress",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_HDDeliverAddress_LastModifierId",
                table: "HDDeliverAddress",
                column: "LastModifierId");

            migrationBuilder.AddForeignKey(
                name: "FK_HDDeliverAddress_AppUser_CreatorId",
                table: "HDDeliverAddress",
                column: "CreatorId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDDeliverAddress_AppUser_DeleterId",
                table: "HDDeliverAddress",
                column: "DeleterId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDDeliverAddress_AppUser_LastModifierId",
                table: "HDDeliverAddress",
                column: "LastModifierId",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HDDeliverAddress_AppUser_CreatorId",
                table: "HDDeliverAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_HDDeliverAddress_AppUser_DeleterId",
                table: "HDDeliverAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_HDDeliverAddress_AppUser_LastModifierId",
                table: "HDDeliverAddress");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_HDDeliverAddress_CreatorId",
                table: "HDDeliverAddress");

            migrationBuilder.DropIndex(
                name: "IX_HDDeliverAddress_DeleterId",
                table: "HDDeliverAddress");

            migrationBuilder.DropIndex(
                name: "IX_HDDeliverAddress_LastModifierId",
                table: "HDDeliverAddress");
        }
    }
}
