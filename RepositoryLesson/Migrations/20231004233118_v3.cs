﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLesson.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PurchaseStatus",
                table: "ShopListProductMapping",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseStatus",
                table: "ShopListProductMapping");
        }
    }
}
