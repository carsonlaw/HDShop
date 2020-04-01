using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class Init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_AppUser_CreatorId",
                table: "HDOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_AppUser_DeleterId",
                table: "HDOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_AppUser_LastModifierId",
                table: "HDOrder");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.AddForeignKey(
                name: "FK_HDDeliverAddress_AbpUsers_CreatorId",
                table: "HDDeliverAddress",
                column: "CreatorId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDDeliverAddress_AbpUsers_DeleterId",
                table: "HDDeliverAddress",
                column: "DeleterId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDDeliverAddress_AbpUsers_LastModifierId",
                table: "HDDeliverAddress",
                column: "LastModifierId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrder_AbpUsers_CreatorId",
                table: "HDOrder",
                column: "CreatorId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrder_AbpUsers_DeleterId",
                table: "HDOrder",
                column: "DeleterId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrder_AbpUsers_LastModifierId",
                table: "HDOrder",
                column: "LastModifierId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HDDeliverAddress_AbpUsers_CreatorId",
                table: "HDDeliverAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_HDDeliverAddress_AbpUsers_DeleterId",
                table: "HDDeliverAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_HDDeliverAddress_AbpUsers_LastModifierId",
                table: "HDDeliverAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_AbpUsers_CreatorId",
                table: "HDOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_AbpUsers_DeleterId",
                table: "HDOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_AbpUsers_LastModifierId",
                table: "HDOrder");

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

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
    }
}
