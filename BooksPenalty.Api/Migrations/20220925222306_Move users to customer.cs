using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksPenalty.Api.Migrations
{
    public partial class Moveuserstocustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPenalties_Users_UserId",
                table: "BookPenalties");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b00baa00-7df7-41ea-83bf-e90568c85738"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("dacf51ff-bf8f-43d1-9429-2b679bc52939"));

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "BookPenalties",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_BookPenalties_UserId",
                table: "BookPenalties",
                newName: "IX_BookPenalties_CustomerId");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Name", "Pages" },
                values: new object[] { new Guid("16c82f36-7912-4c6b-9775-98d6c2c98e18"), "Herman Melville", "Moby-Dick", 558 });

            migrationBuilder.InsertData(
                table: "Customers",
                column: "Id",
                value: new Guid("bbecf46b-c1eb-46b0-9e8d-b9a283688ba3"));

            migrationBuilder.AddForeignKey(
                name: "FK_BookPenalties_Customers_CustomerId",
                table: "BookPenalties",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookPenalties_Customers_CustomerId",
                table: "BookPenalties");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("16c82f36-7912-4c6b-9775-98d6c2c98e18"));

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "BookPenalties",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BookPenalties_CustomerId",
                table: "BookPenalties",
                newName: "IX_BookPenalties_UserId");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Name", "Pages" },
                values: new object[] { new Guid("b00baa00-7df7-41ea-83bf-e90568c85738"), "Herman Melville", "Moby-Dick", 558 });

            migrationBuilder.InsertData(
                table: "Users",
                column: "Id",
                value: new Guid("dacf51ff-bf8f-43d1-9429-2b679bc52939"));

            migrationBuilder.AddForeignKey(
                name: "FK_BookPenalties_Users_UserId",
                table: "BookPenalties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
