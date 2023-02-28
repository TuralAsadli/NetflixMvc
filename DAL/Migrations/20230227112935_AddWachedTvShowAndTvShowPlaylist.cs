using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddWachedTvShowAndTvShowPlaylist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TvShowPlaylist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlaylistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowPlaylist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvShowPlaylist_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WachedTvShows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TvShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WachedTvShows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WachedTvShows_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TvShowTvShowPlaylist",
                columns: table => new
                {
                    TvShowPlaylistsId = table.Column<int>(type: "int", nullable: false),
                    TvShowsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvShowTvShowPlaylist", x => new { x.TvShowPlaylistsId, x.TvShowsId });
                    table.ForeignKey(
                        name: "FK_TvShowTvShowPlaylist_TvShowPlaylist_TvShowPlaylistsId",
                        column: x => x.TvShowPlaylistsId,
                        principalTable: "TvShowPlaylist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TvShowTvShowPlaylist_TvShows_TvShowsId",
                        column: x => x.TvShowsId,
                        principalTable: "TvShows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TvShowPlaylist_UserId1",
                table: "TvShowPlaylist",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_TvShowTvShowPlaylist_TvShowsId",
                table: "TvShowTvShowPlaylist",
                column: "TvShowsId");

            migrationBuilder.CreateIndex(
                name: "IX_WachedTvShows_UserId1",
                table: "WachedTvShows",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TvShowTvShowPlaylist");

            migrationBuilder.DropTable(
                name: "WachedTvShows");

            migrationBuilder.DropTable(
                name: "TvShowPlaylist");
        }
    }
}
