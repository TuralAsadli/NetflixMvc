using DAL.DAL;
using DAL.Entities.Settings;
using DAL.Entities.User;
using DAL.GeneralClass;
using DAL.Movies;
using DAL.Repository;
using DAL.TvShows;
using DAL.Utilites;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DAL.Extention
{
    public static class DataLayerExtention
    {
        public static IServiceCollection AddDataLayerExtention(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBaseRepository<Actor>, BaseRepository<Actor>>();
            services.AddScoped<IBaseRepository<Category>, BaseRepository<Category>>();
            services.AddScoped<IBaseRepository<Language>, BaseRepository<Language>>();
            services.AddScoped<IBaseRepository<Subtitle>, BaseRepository<Subtitle>>();
            services.AddScoped<IBaseRepository<AudioLanguage>, BaseRepository<AudioLanguage>>();

            services.AddScoped<IMovieRepository<Movie>, MovieRepository>();
            
            services.AddScoped<IBaseRepository<Subscribe>, BaseRepository<Subscribe>>();

            services.AddScoped<ISubscribeRepository<Subscribe>, SubscripeRepository>();
            services.AddScoped<ITvShowRepository<TvShow>, TvshowRepository>();
            services.AddScoped<IBaseRepository<Season>, BaseRepository<Season>>();
            services.AddScoped<IBaseRepository<Series>, BaseRepository<Series>>();

            services.AddScoped<IBaseRepository<Setting>, BaseRepository<Setting>>();
            services.AddScoped<IBaseRepository<UserFeedback>, BaseRepository<UserFeedback>>();

            services.AddScoped<IBaseRepository<MovieActor>, BaseRepository<MovieActor>>();
            services.AddScoped<IBaseRepository<MovieCategory>, BaseRepository<MovieCategory>>();
            services.AddScoped<IBaseRepository<MovieAudioLanguage>, BaseRepository<MovieAudioLanguage>>();
            services.AddScoped<IBaseRepository<MovieSubtitle>, BaseRepository<MovieSubtitle>>();
            services.AddScoped<IBaseRepository<MovieLanguage>, BaseRepository<MovieLanguage>>();

            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();


            return services;
        }

    }
}
