﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbruzaCosmicProducts_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addtypeproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Product",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Product");
        }
    }
}
