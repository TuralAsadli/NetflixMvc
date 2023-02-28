using DAL.Entities.Settings;
using DAL.Entities.User;
using DAL.GeneralClass;
using DAL.Movies;
using DAL.TvShows;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Subtitle> Subtitles { get; set; }
        public DbSet<AudioLanguage> AudioLanguages { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieLanguage> MovieLanguages { get; set; }
        public DbSet<MovieSubtitle> MovieSubtitles { get; set; }
        public DbSet<MovieAudioLanguage> MovieAudioLanguages { get; set; }


        ///
        public DbSet<User> Users { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<WachedMovies> WachedMovies { get; set; }
        public DbSet<MoviePlaylist> MoviePlaylists { get; set; }


        ///
        public DbSet<TvShow> TvShows { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Series> Series { get; set; }

        ///
        public DbSet<Setting> Settings { get; set; }
        public DbSet<UserFeedback> UserFeedbacks { get; set; }
    }
}
