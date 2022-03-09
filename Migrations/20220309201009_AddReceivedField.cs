using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission_7_Assignment.Migrations
{
    public partial class AddReceivedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PurchasedReceived",
                table: "Purchase",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchasedReceived",
                table: "Purchase");
        }
    }
}
