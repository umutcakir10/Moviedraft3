using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moviegram.Migrations
{
    /// <inheritdoc />
    public partial class Addinglikefunctionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoviePostLike",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MoviePostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePostLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviePostLike_MoviePosts_MoviePostId",
                        column: x => x.MoviePostId,
                        principalTable: "MoviePosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePostLike_MoviePostId",
                table: "MoviePostLike",
                column: "MoviePostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviePostLike");
        }
    }
}
