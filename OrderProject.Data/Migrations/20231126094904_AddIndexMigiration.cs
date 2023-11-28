using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdersProject.Data.Migrations
{
    public partial class AddIndexMigiration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "Index_UserOrder",
                table: "UserOrders",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_Order",
                table: "Orders",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_UserOrder",
                table: "UserOrders");

            migrationBuilder.DropIndex(
                name: "Index_Order",
                table: "Orders");
        }
    }
}
