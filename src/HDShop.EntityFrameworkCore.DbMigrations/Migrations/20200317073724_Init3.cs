using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppGoodCategory",
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
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    GoodDescription = table.Column<string>(maxLength: 8000, nullable: false),
                    ParentCategoryId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppGoodCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppGoodCategory_AppGoodCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "AppGoodCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppGoodCategory_ParentCategoryId",
                table: "AppGoodCategory",
                column: "ParentCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppGoodCategory");
        }
    }
}
