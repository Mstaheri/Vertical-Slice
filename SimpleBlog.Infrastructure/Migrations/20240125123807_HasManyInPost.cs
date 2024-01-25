using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HasManyInPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IDPOST",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_IDPOST",
                table: "Comments",
                column: "IDPOST");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_IDPOST",
                table: "Comments",
                column: "IDPOST",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_IDPOST",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_IDPOST",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IDPOST",
                table: "Comments");
        }
    }
}
