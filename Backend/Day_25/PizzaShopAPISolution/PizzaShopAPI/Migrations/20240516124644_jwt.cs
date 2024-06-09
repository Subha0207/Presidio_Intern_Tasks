using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaShopAPI.Migrations
{
    public partial class jwt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "PhoneNumber", "UserName" },
                values: new object[] { 1, "Coimbatore", 123456789, "Subha" });
        }
    }
}
