using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SDA_WEB_API.Migrations
{
    /// <inheritdoc />
    public partial class ConnectPublisherToVideoGames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Studio",
                table: "VideoGames");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "VideoGames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoGames_Publishers_PublisherId",
                table: "VideoGames",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoGames_Publishers_PublisherId",
                table: "VideoGames");

            migrationBuilder.DropIndex(
                name: "IX_VideoGames_PublisherId",
                table: "VideoGames");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "VideoGames");

            migrationBuilder.AddColumn<string>(
                name: "Studio",
                table: "VideoGames",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
