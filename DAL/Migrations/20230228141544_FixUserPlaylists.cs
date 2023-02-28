using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixUserPlaylists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePlaylists_AspNetUsers_UserId1",
                table: "MoviePlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_TvShowPlaylist_AspNetUsers_UserId1",
                table: "TvShowPlaylist");

            migrationBuilder.DropIndex(
                name: "IX_TvShowPlaylist_UserId1",
                table: "TvShowPlaylist");

            migrationBuilder.DropIndex(
                name: "IX_MoviePlaylists_UserId1",
                table: "MoviePlaylists");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TvShowPlaylist");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MoviePlaylists");

            migrationBuilder.AddColumn<int>(
                name: "MoviePlaylistId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TvShowPlaylistId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MoviePlaylistId",
                table: "AspNetUsers",
                column: "MoviePlaylistId",
                unique: true,
                filter: "[MoviePlaylistId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_TvShowPlaylistId",
                table: "AspNetUsers",
                column: "TvShowPlaylistId",
                unique: true,
                filter: "[TvShowPlaylistId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_MoviePlaylists_MoviePlaylistId",
                table: "AspNetUsers",
                column: "MoviePlaylistId",
                principalTable: "MoviePlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_TvShowPlaylist_TvShowPlaylistId",
                table: "AspNetUsers",
                column: "TvShowPlaylistId",
                principalTable: "TvShowPlaylist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MoviePlaylists_MoviePlaylistId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TvShowPlaylist_TvShowPlaylistId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MoviePlaylistId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_TvShowPlaylistId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MoviePlaylistId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TvShowPlaylistId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "TvShowPlaylist",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "MoviePlaylists",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TvShowPlaylist_UserId1",
                table: "TvShowPlaylist",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlaylists_UserId1",
                table: "MoviePlaylists",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePlaylists_AspNetUsers_UserId1",
                table: "MoviePlaylists",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TvShowPlaylist_AspNetUsers_UserId1",
                table: "TvShowPlaylist",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
