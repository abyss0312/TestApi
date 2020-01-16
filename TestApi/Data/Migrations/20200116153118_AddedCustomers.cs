using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Data.Migrations
{
    public partial class AddedCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PhoneNumber",
                table: "Customers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
