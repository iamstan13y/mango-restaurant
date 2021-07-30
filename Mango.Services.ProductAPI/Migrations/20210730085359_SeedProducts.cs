using Microsoft.EntityFrameworkCore.Migrations;

namespace Mango.Services.ProductAPI.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryName", "Description", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Appetizer", "Shit", "https://thegnatbug.blob.core.windows.net/mango/1.jpg", "Samosa", 15.0 },
                    { 2, "Appetizer", "Shit", "https://thegnatbug.blob.core.windows.net/mango/3.jpg", "Cup Cake", 18.0 },
                    { 3, "Appetizer", "Shit", "https://thegnatbug.blob.core.windows.net/mango/2.jpg", "Shawarma", 22.0 },
                    { 4, "Appetizer", "Shit", "https://thegnatbug.blob.core.windows.net/mango/4.jpg", "Pizza", 16.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);
        }
    }
}
