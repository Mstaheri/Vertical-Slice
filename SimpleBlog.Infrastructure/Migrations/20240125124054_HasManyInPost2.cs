using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleBlog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HasManyInPost2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_IDPOST",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "IDPOST",
                table: "Comments",
                newName: "IdPost");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_IDPOST",
                table: "Comments",
                newName: "IX_Comments_IdPost");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                columns: new[] { "Id", "IdPost" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_IdPost",
                table: "Comments",
                column: "IdPost",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Posts_IdPost",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "IdPost",
                table: "Comments",
                newName: "IDPOST");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_IdPost",
                table: "Comments",
                newName: "IX_Comments_IDPOST");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Posts_IDPOST",
                table: "Comments",
                column: "IDPOST",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
