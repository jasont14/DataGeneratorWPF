using Microsoft.EntityFrameworkCore.Migrations;

namespace DataGeneratorWPF.Migrations
{
    public partial class AddOrderCustomerID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Customer",
                table: "Orders",
                newName: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Orders",
                newName: "Customer");
        }
    }
}
