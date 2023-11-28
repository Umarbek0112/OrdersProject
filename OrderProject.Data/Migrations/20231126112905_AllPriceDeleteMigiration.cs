using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersProject.Data.Migrations
{
    public partial class AllPriceDeleteMigiration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllPrice",
                table: "UserOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AllPrice",
                table: "UserOrders",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
