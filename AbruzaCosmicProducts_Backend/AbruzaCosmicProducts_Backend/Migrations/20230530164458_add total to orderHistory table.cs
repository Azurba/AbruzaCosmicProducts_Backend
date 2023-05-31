using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbruzaCosmicProducts_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addtotaltoorderHistorytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "total",
                table: "OrderHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total",
                table: "OrderHistory");
        }
    }
}
