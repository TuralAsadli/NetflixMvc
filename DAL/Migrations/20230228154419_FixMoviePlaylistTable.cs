using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixMoviePlaylistTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_MoviePlaylists_MoviePlaylistId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_TvShowPlaylist_TvShowPlaylistId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MovieMoviePlaylist");

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

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TvShowPlaylist",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MoviePlaylistId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MoviePlaylists",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "MovieUser",
                columns: table => new
                {
                    MoviesId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUser", x => new { x.MoviesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_MovieUser_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUser_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TvShowPlaylist_UserId",
                table: "TvShowPlaylist",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MoviePlaylistId",
                table: "Movies",
                column: "MoviePlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlaylists_UserId",
                table: "MoviePlaylists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieUser_UsersId",
                table: "MovieUser",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePlaylists_AspNetUsers_UserId",
                table: "MoviePlaylists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviePlaylists_MoviePlaylistId",
                table: "Movies",
                column: "MoviePlaylistId",
                principalTable: "MoviePlaylists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TvShowPlaylist_AspNetUsers_UserId",
                table: "TvShowPlaylist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePlaylists_AspNetUsers_UserId",
                table: "MoviePlaylists");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviePlaylists_MoviePlaylistId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_TvShowPlaylist_AspNetUsers_UserId",
                table: "TvShowPlaylist");

            migrationBuilder.DropTable(
                name: "MovieUser");

            migrationBuilder.DropIndex(
                name: "IX_TvShowPlaylist_UserId",
                table: "TvShowPlaylist");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MoviePlaylistId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_MoviePlaylists_UserId",
                table: "MoviePlaylists");

            migrationBuilder.DropColumn(
                name: "MoviePlaylistId",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "TvShowPlaylist",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MoviePlaylists",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

            migrationBuilder.CreateTable(
                name: "MovieMoviePlaylist",
                columns: table => new
                {
                    MoviePlaylistsId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMoviePlaylist", x => new { x.MoviePlaylistsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieMoviePlaylist_MoviePlaylists_MoviePlaylistsId",
                        column: x => x.MoviePlaylistsId,
                        principalTable: "MoviePlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMoviePlaylist_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MovieMoviePlaylist_MoviesId",
                table: "MovieMoviePlaylist",
                column: "MoviesId");

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
    }
}
