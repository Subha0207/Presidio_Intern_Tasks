using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaShopAPI.Migrations
{
    public partial class updatedDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Description", "ImageUrl", "InStock", "Name", "Price" },
                values: new object[] { 3, "A spicy pizza with Vegetables, and paneer.", "", true, "Veg Paneer Pizza", 150 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
