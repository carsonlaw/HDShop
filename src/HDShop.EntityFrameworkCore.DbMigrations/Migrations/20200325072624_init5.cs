using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HDShop.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayTime",
                table: "HDOrder");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HDOrder");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "HDOrder");

            migrationBuilder.RenameColumn(
                name: "PayPrice",
                table: "HDOrder",
                newName: "PayOrder_PayPrice");

            migrationBuilder.AlterColumn<decimal>(
                name: "PayOrder_PayPrice",
                table: "HDOrder",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<string>(
                name: "DeliverOrder_Code",
                table: "HDOrder",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliverOrder_CreationTime",
                table: "HDOrder",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliverOrder_DeliverCompanyId",
                table: "HDOrder",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PayOrder_Code",
                table: "HDOrder",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayOrder_CreationTime",
                table: "HDOrder",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HDGood",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "HDGood",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "SubName",
                table: "HDGood",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "HDDeliverAddress",
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
                    Name = table.Column<string>(maxLength: 10, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDDeliverAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDDeliverCompany",
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
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDDeliverCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDPayCompany",
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
                    Code = table.Column<string>(maxLength: 20, nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDPayCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HDOrderDeliverAddressMap",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    DeliverAddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HDOrderDeliverAddressMap", x => new { x.DeliverAddressId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_HDOrderDeliverAddressMap_HDDeliverAddress_DeliverAddressId",
                        column: x => x.DeliverAddressId,
                        principalTable: "HDDeliverAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HDOrderDeliverAddressMap_HDOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "HDOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HDOrder_DeliverOrder_DeliverCompanyId",
                table: "HDOrder",
                column: "DeliverOrder_DeliverCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_HDOrderDeliverAddressMap_OrderId",
                table: "HDOrderDeliverAddressMap",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_HDOrder_HDDeliverCompany_DeliverOrder_DeliverCompanyId",
                table: "HDOrder",
                column: "DeliverOrder_DeliverCompanyId",
                principalTable: "HDDeliverCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HDOrder_HDDeliverCompany_DeliverOrder_DeliverCompanyId",
                table: "HDOrder");

            migrationBuilder.DropTable(
                name: "HDDeliverCompany");

            migrationBuilder.DropTable(
                name: "HDOrderDeliverAddressMap");

            migrationBuilder.DropTable(
                name: "HDPayCompany");

            migrationBuilder.DropTable(
                name: "HDDeliverAddress");

            migrationBuilder.DropIndex(
                name: "IX_HDOrder_DeliverOrder_DeliverCompanyId",
                table: "HDOrder");

            migrationBuilder.DropColumn(
                name: "DeliverOrder_Code",
                table: "HDOrder");

            migrationBuilder.DropColumn(
                name: "DeliverOrder_CreationTime",
                table: "HDOrder");

            migrationBuilder.DropColumn(
                name: "DeliverOrder_DeliverCompanyId",
                table: "HDOrder");

            migrationBuilder.DropColumn(
                name: "PayOrder_Code",
                table: "HDOrder");

            migrationBuilder.DropColumn(
                name: "PayOrder_CreationTime",
                table: "HDOrder");

            migrationBuilder.DropColumn(
                name: "SubName",
                table: "HDGood");

            migrationBuilder.RenameColumn(
                name: "PayOrder_PayPrice",
                table: "HDOrder",
                newName: "PayPrice");

            migrationBuilder.AlterColumn<decimal>(
                name: "PayPrice",
                table: "HDOrder",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PayTime",
                table: "HDOrder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HDOrder",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "HDOrder",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "HDGood",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "HDGood",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);
        }
    }
}
