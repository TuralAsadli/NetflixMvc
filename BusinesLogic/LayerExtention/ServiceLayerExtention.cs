using BusinesLogic.Services;
using BusinesLogic.Services.ManytoManyServices;
using BusinesLogic.ViewModel.Actor;
using BusinesLogic.ViewModel.AudioLanguage;
using BusinesLogic.ViewModel.Category;
using BusinesLogic.ViewModel.Language;
using BusinesLogic.ViewModel.Movie;
using BusinesLogic.ViewModel.Settings;
using BusinesLogic.ViewModel.Subscribe;
using BusinesLogic.ViewModel.Subtitle;
using BusinesLogic.ViewModel.TvShow;
using BusinesLogic.ViewModel.TvShow.Season;
using BusinesLogic.ViewModel.TvShow.Seria;
using DAL.Entities.User;
using DAL.Movies;
using DAL.Repository;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Interfaces.Services.ManyToManyServices;
using Microsoft.Extensions.DependencyInjection;

namespace BusinesLogic.LayerExtention
{
    public static class ServiceLayerExtention
    {
        public static IServiceCollection AddServiceLayerExtention(this IServiceCollection services)
        {
            services.AddScoped<IActorService<ActorVM>, ActorService>();
            services.AddScoped<ICategoryService<CategoryVM>, CategoryService>();
            services.AddScoped<ILanguageService<LanguageVM>, LanguageService>();
            services.AddScoped<ISubtitleService<SubtitleVM>, SubtitleService>();
            services.AddScoped<IAudioLanguageService<AudioLanguageVM>, AudioLanguageService>();
            services.AddScoped<IMovieService<MovieVM>,MovieService>();
            services.AddScoped<ISubscribeService<SubscribeVM>, SubscribeService>();

            services.AddScoped<ITvShowService<TvShowVM>, TvShowService>();
            services.AddScoped<ISeasonService<SeasonVM>, SeasonService>();
            services.AddScoped<ISeriaService<SeriaVM>, SeriaService>();

            services.AddScoped<ISettingsService<SettingVM>, SettingsService>();
            services.AddScoped<IUserFeedbackService<UserFeedBackVM>, UserFeedbackService>();

            services.AddScoped<IBaseManyToManyService<MovieCategory>, MovieCategoryService>();
            services.AddScoped<IBaseManyToManyService<MovieLanguage>, MovieLanguageService>();
            services.AddScoped<IBaseManyToManyService<MovieSubtitle>, MovieSubtitleService>();
            services.AddScoped<IBaseManyToManyService<MovieAudioLanguage>, MovieAudioService>();
            services.AddScoped<IBaseManyToManyService<MovieActor>, MovieActorService>();
            
            

            return services;
        }
    }
}
