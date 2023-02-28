using AutoMapper;
using BusinesLogic.Utilites;
using BusinesLogic.ViewModel.Movie;
using DAL.GeneralClass;
using DAL.Movies;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Interfaces.Services.ManyToManyServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BusinesLogic.Services
{
    public class MovieService : IMovieService<MovieVM>
    {
        IWebHostEnvironment _env;
        IMovieRepository<Movie> _db;

        IBaseManyToManyService<MovieCategory> _movieCategories;
        IBaseManyToManyService<MovieLanguage> _movieLanguage;
        IBaseManyToManyService<MovieSubtitle> _movieSubtitle;
        IBaseManyToManyService<MovieAudioLanguage> _movieAudioLanguages;
        IBaseManyToManyService<MovieActor> _movieActor;
        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;

        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;

        public MovieService(IMovieRepository<Movie> db, IBaseManyToManyService<MovieCategory> movieCategories, IBaseManyToManyService<MovieLanguage> movieLanguage, IBaseManyToManyService<MovieSubtitle> movieSubtitle, IBaseManyToManyService<MovieAudioLanguage> movieAudioLanguages, IBaseManyToManyService<MovieActor> movieActor, IWebHostEnvironment env)
        {
            configVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<MovieVM, Movie>()
                );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<MovieWithIdVM, Movie>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Movie, MovieVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Movie, MovieWithIdVM>()
                );
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);
            _db = db;
            _movieCategories = movieCategories;
            _movieLanguage = movieLanguage;
            _movieSubtitle = movieSubtitle;
            _movieAudioLanguages = movieAudioLanguages;
            _movieActor = movieActor;
            _env = env;
        }

        public void Create(MovieVM item)
        {
            var movie = mapperVmToM.Map<Movie>(item);
            movie.Rating = item.Raiting;

            string imgName = item.ImgFile.ChangeImgFileName();
            item.ImgFile.CreateImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", imgName));
            movie.MovieImgName = imgName;

            string videoName = item.VideoFile.ChangeVideoFileName();
            item.VideoFile.CreateVideoFile(Path.Combine(_env.WebRootPath, "videos", "movies", videoName));
            movie.MovieVideoName = videoName;

            string trailerName = item.TrailerFile.ChangeVideoFileName();
            item.VideoFile.CreateVideoFile(Path.Combine(_env.WebRootPath, "videos", "trailers", trailerName));
            movie.MovieTrailerName = trailerName;

            movie.Duration = VideoFileExtenion.GetVideoDuration(Path.Combine(_env.WebRootPath, "videos", "movies", videoName)).ConvertTimeSpan();
            
            if (movie.Rating == null)
            {
                movie.Rating = "Unheard";
            }

            _db.Create(movie);

            foreach (var categoriesId in item.MovieCategoriesId)
            {
                _movieCategories.Create(new MovieCategory { CategoryId = categoriesId, Movie = movie });
            }

            foreach (var languageId in item.MovieLanguagesId)
            {
                _movieLanguage.Create(new MovieLanguage { LanguageId = languageId, Movie = movie });
            }

            foreach (var subtitleId in item.MovieSubtitlesId)
            {
                _movieSubtitle.Create(new MovieSubtitle { SubtitleId = subtitleId, Movie = movie });
            }
            foreach (var actorId in item.MovieActorsId)
            {
                _movieActor.Create(new MovieActor { ActorId = actorId, Movie = movie });
            }
            foreach (var audioId in item.MovieAudioLanguagesId)
            {
                _movieAudioLanguages.Create(new MovieAudioLanguage { AudioLanguageId = audioId, Movie = movie });
            }



        }


        public MovieVM FindById(int id)
        {
            var res = _db.FindById(id);
            var movie = mapperMtoVm.Map<MovieVM>(res);


            return movie;
        }

        public IEnumerable<MovieVM> GetAll()
        {
            var list = _db.GetAll();
            List<MovieVM> movies = new();
            foreach (var item in list)
            {
                var movie = mapperMtoVm.Map<MovieVM>(item);
                movies.Add(movie);
            }
            return movies;
        }

        public IEnumerable<object> GetAllWithInclude()
        {
            var res = _db.GetWithInclude("MovieCategories.Category", "MovieLanguages.Language", "MovieSubtitles.Subtitle", "MovieAudioLanguages.AudioLanguage", "MovieActors.Actor");
            
            return res;
        }

        public IEnumerable<MovieVM> GetWithId()
        {
            var list = _db.GetAll();
            List<MovieWithIdVM> movies = new();
            foreach (var item in list)
            {
                var movie = mapperIdMtoVM.Map<MovieWithIdVM>(item);
                movies.Add(movie);
            }
            return movies;
        }

        public IEnumerable<object> Search(string query)
        {
            var movies = (List<Movie>)GetAllWithInclude();
            return movies.Where(item => item.MovieName.Contains(query)).ToList(); ;
        } 

        public object GetWithInclude(int id)
        {
            var res = _db.GetWithIdInclude(id, "MovieCategories.Category", "MovieLanguages.Language", "MovieSubtitles.Subtitle", "MovieAudioLanguages.AudioLanguage", "MovieActors.Actor");

            return res;
        }

        public void Remove(int id)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return;
            }

            ImgFileExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "images","hoverImg", res.MovieImgName));
            VideoFileExtenion.DeleteVideoFile(Path.Combine(_env.WebRootPath, "videos", "movies", res.MovieVideoName));
            VideoFileExtenion.DeleteVideoFile(Path.Combine(_env.WebRootPath, "videos", "trailers", res.MovieTrailerName));

            _db.Remove(res);
        }

        public void Update(int id, MovieVM item)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return;
            }
            res.ReliseDate = item.ReliseDate;
            res.Desc = item.Desc;
            res.MovieName = item.MovieName;

            ImgFileExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", res.MovieImgName));
            string imgName = item.ImgFile.ChangeImgFileName();
            item.ImgFile.CreateImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", imgName));
            res.MovieImgName = imgName;

            VideoFileExtenion.DeleteVideoFile(Path.Combine(_env.WebRootPath, "videos", "movies", res.MovieVideoName));
            string videoName = item.VideoFile.ChangeImgFileName();
            item.VideoFile.CreateVideoFile(Path.Combine(_env.WebRootPath, "videos", "movies", videoName));
            res.MovieVideoName = videoName;

            VideoFileExtenion.DeleteVideoFile(Path.Combine(_env.WebRootPath, "videos", "trailers", res.MovieTrailerName));
            string trailerName = item.TrailerFile.ChangeImgFileName();
            item.TrailerFile.CreateVideoFile(Path.Combine(_env.WebRootPath, "videos", "trailers", trailerName));
            res.MovieTrailerName = trailerName;

            res.Rating = item.Raiting;

            res.Duration = VideoFileExtenion.GetVideoDuration(Path.Combine(_env.WebRootPath, "videos", "movies", videoName)).ConvertTimeSpan();


            _db.Update(res);

            var categories = _movieCategories.GetByMovie(res.Id);
            var audios = _movieAudioLanguages.GetByMovie(res.Id);
            var actors = _movieActor.GetByMovie(res.Id);
            var languages = _movieLanguage.GetByMovie(res.Id);
            var subtitles = _movieSubtitle.GetByMovie(res.Id);

            foreach (var category in categories)
            {
                _movieCategories.Remove(category);
            }
            foreach (var audio in audios)
            {
                _movieAudioLanguages.Remove(audio);
            }
            foreach (var actor in actors)
            {
                _movieActor.Remove(actor);
            }
            foreach (var language in languages)
            {
                _movieLanguage.Remove(language);
            }
            foreach (var subtitle in subtitles)
            {
                _movieSubtitle.Remove(subtitle);
            }


            foreach (var categoriesId in item.MovieCategoriesId)
            {
                _movieCategories.Create(new MovieCategory { CategoryId = categoriesId, Movie = res });
            }
            

            foreach (var languageId in item.MovieLanguagesId)
            {
                _movieLanguage.Create(new MovieLanguage { LanguageId = languageId, Movie = res });
            }
            

            foreach (var subtitleId in item.MovieSubtitlesId)
            {
                _movieSubtitle.Create(new MovieSubtitle { SubtitleId = subtitleId, Movie = res });
            }
            


            foreach (var actorId in item.MovieActorsId)
            {
                _movieActor.Create(new MovieActor { ActorId = actorId, Movie = res });
            }
           


            foreach (var audioId in item.MovieAudioLanguagesId)
            {
                _movieAudioLanguages.Create(new MovieAudioLanguage { AudioLanguageId = audioId, Movie = res });
            }
            

        }

        public void AddView(int id)
        {
            var movie = _db.FindById(id);
            movie.Views += 1;
            _db.Update(movie);
        }
    }
}
