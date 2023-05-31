using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbruzaCosmicProducts_Backend.Migrations
{
    /// <inheritdoc />
    public partial class updateorderhistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistory_Product_productId",
                table: "OrderHistory");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistory_productId",
                table: "OrderHistory");

            migrationBuilder.DropColumn(
                name: "productId",
                table: "OrderHistory");

            migrationBuilder.RenameColumn(
                name: "zipcode",
                table: "OrderHistory",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "total",
                table: "OrderHistory",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "state",
                table: "OrderHistory",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "OrderHistory",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "OrderHistory",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "OrderHistory",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "OrderHistory",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "country",
                table: "OrderHistory",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "OrderHistory",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "cardNumber",
                table: "OrderHistory",
                newName: "CardNumber");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "OrderHistory",
                newName: "Address");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "OrderHistory",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "OrderHistory",
                newName: "zipcode");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "OrderHistory",
                newName: "total");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "OrderHistory",
                newName: "state");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "OrderHistory",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OrderHistory",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "OrderHistory",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "OrderHistory",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "OrderHistory",
                newName: "country");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "OrderHistory",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "OrderHistory",
                newName: "cardNumber");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "OrderHistory",
                newName: "address");

            migrationBuilder.AlterColumn<int>(
                name: "total",
                table: "OrderHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "productId",
                table: "OrderHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistory_productId",
                table: "OrderHistory",
                column: "productId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistory_Product_productId",
                table: "OrderHistory",
                column: "productId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
