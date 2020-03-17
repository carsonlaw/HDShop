using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppGoodCategory_AppGoodCategory_ParentCategoryId",
                table: "AppGoodCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppGoodCategory",
                table: "AppGoodCategory");

            migrationBuilder.RenameTable(
                name: "AppGoodCategory",
                newName: "HDGoodCategory");

            migrationBuilder.RenameIndex(
                name: "IX_AppGoodCategory_ParentCategoryId",
                table: "HDGoodCategory",
                newName: "IX_HDGoodCategory_ParentCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HDGoodCategory",
                table: "HDGoodCategory",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "HDGood",
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
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    ImageBaseUrl = table.Column<string>(maxLength: 100, nullable: false),
                    Sort = table.Column<int>(nullable: false),
                    OnSale = table.Column<bool>(nullable: false),
                    PriceCost = table.Column<decimal>(nullable: false),
                    PriceProduct = table.Column<decimal>(nullable: false),
                    PriceSale = table.Column<decimal>(nullable: false),
                    NumSales = table.Column<int>(nullable: false),
                    NumSalesReal = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    SaleStateValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDGood", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDGoodProperty",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TypeName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDGoodProperty", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDGoodCategoryMap",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    GoodId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDGoodCategoryMap", x => new { x.CategoryId, x.GoodId });
                    table.ForeignKey(
                        name: "FK_HDGoodCategoryMap_HDGoodCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "HDGoodCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HDGoodCategoryMap_HDGood_GoodId",
                        column: x => x.GoodId,
                        principalTable: "HDGood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HDGoodSku",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierId = table.Column<Guid>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    GoodId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDGoodSku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HDGoodSku_HDGood_GoodId",
                        column: x => x.GoodId,
                        principalTable: "HDGood",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HDGoodCategoryMap_GoodId",
                table: "HDGoodCategoryMap",
                column: "GoodId");

            migrationBuilder.CreateIndex(
                name: "IX_HDGoodSku_GoodId",
                table: "HDGoodSku",
                column: "GoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_HDGoodCategory_HDGoodCategory_ParentCategoryId",
                table: "HDGoodCategory",
                column: "ParentCategoryId",
                principalTable: "HDGoodCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HDGoodCategory_HDGoodCategory_ParentCategoryId",
                table: "HDGoodCategory");

            migrationBuilder.DropTable(
                name: "HDGoodCategoryMap");

            migrationBuilder.DropTable(
                name: "HDGoodProperty");

            migrationBuilder.DropTable(
                name: "HDGoodSku");

            migrationBuilder.DropTable(
                name: "HDGood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HDGoodCategory",
                table: "HDGoodCategory");

            migrationBuilder.RenameTable(
                name: "HDGoodCategory",
                newName: "AppGoodCategory");

            migrationBuilder.RenameIndex(
                name: "IX_HDGoodCategory_ParentCategoryId",
                table: "AppGoodCategory",
                newName: "IX_AppGoodCategory_ParentCategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppGoodCategory",
                table: "AppGoodCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppGoodCategory_AppGoodCategory_ParentCategoryId",
                table: "AppGoodCategory",
                column: "ParentCategoryId",
                principalTable: "AppGoodCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
