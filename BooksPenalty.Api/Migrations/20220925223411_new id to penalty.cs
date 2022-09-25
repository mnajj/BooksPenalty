using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BooksPenalty.Api.Migrations
{
    public partial class newidtopenalty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookPenalties",
                table: "BookPenalties");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("16c82f36-7912-4c6b-9775-98d6c2c98e18"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("bbecf46b-c1eb-46b0-9e8d-b9a283688ba3"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "BookPenalties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookPenalties",
                table: "BookPenalties",
                columns: new[] { "Id", "BookId", "CustomerId" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Name", "Pages" },
                values: new object[] { new Guid("76c52493-126f-48b7-969c-7cf0c9a2ea49"), "Herman Melville", "Moby-Dick", 558 });

            migrationBuilder.InsertData(
                table: "Customers",
                column: "Id",
                value: new Guid("8c16588d-80c5-4c63-86bd-4a47de61e783"));

            migrationBuilder.CreateIndex(
                name: "IX_BookPenalties_BookId",
                table: "BookPenalties",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookPenalties",
                table: "BookPenalties");

            migrationBuilder.DropIndex(
                name: "IX_BookPenalties_BookId",
                table: "BookPenalties");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("76c52493-126f-48b7-969c-7cf0c9a2ea49"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("8c16588d-80c5-4c63-86bd-4a47de61e783"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookPenalties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookPenalties",
                table: "BookPenalties",
                columns: new[] { "BookId", "CustomerId" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Name", "Pages" },
                values: new object[] { new Guid("16c82f36-7912-4c6b-9775-98d6c2c98e18"), "Herman Melville", "Moby-Dick", 558 });

            migrationBuilder.InsertData(
                table: "Customers",
                column: "Id",
                value: new Guid("bbecf46b-c1eb-46b0-9e8d-b9a283688ba3"));
        }
    }
}
