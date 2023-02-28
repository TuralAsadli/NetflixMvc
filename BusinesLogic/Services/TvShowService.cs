using AutoMapper;
using BusinesLogic.Utilites;
using BusinesLogic.ViewModel.Actor;
using BusinesLogic.ViewModel.Language;
using BusinesLogic.ViewModel.Movie;
using BusinesLogic.ViewModel.Subtitle;
using BusinesLogic.ViewModel.TvShow;
using BusinesLogic.ViewModel.TvShow.Season;
using DAL.GeneralClass;
using DAL.Movies;
using DAL.Repository;
using DAL.TvShows;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Interfaces.Services.ManyToManyServices;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Services
{
    public class TvShowService : ITvShowService<TvShowVM>
    {
        IWebHostEnvironment _env;
        ITvShowRepository<TvShow> _db;

        IBaseRepository<Category> _categories;
        IBaseRepository<Language> _language;
        IBaseRepository<Subtitle> _subtitle;
        IBaseRepository<AudioLanguage> _audioLanguages;
        IBaseRepository<Actor> _actors;
        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;

        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;

        public TvShowService(ITvShowRepository<TvShow> db, IWebHostEnvironment env, IBaseRepository<Category> categories, IBaseRepository<Language> language, IBaseRepository<Subtitle> subtitle, IBaseRepository<AudioLanguage> audioLanguages, IBaseRepository<Actor> actors)
        {
            configVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<TvShowVM, TvShow>()
                );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<TvShowWithIdVM, TvShow>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<TvShow, TvShowVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<TvShow, TvShowWithIdVM>()
                );
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);

            _db = db;
            _env = env;
            _db = db;
            _env = env;
            _categories = categories;
            _language = language;
            _subtitle = subtitle;
            _audioLanguages = audioLanguages;
            _actors = actors;
        }

        public IEnumerable<object> Search(string query)
        {
            
            return _db.GetWithInclude().Where(item => item.TvShowName.Contains(query)).ToList();
        }
        public void Create(TvShowVM item)
        {
            var TvShow = mapperVmToM.Map<TvShow>(item);

            string imgName = item.ImgFile.ChangeImgFileName();
            item.ImgFile.CreateImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", imgName));
            TvShow.HoverImgName = imgName;

            if (TvShow.rating == null)
            {
                TvShow.rating = "Unheard";
            }

            foreach (var categoriesId in item.CategoriesIds)
            {
                if (TvShow.Categories == null)
                {
                    TvShow.Categories = new List<Category>();
                    TvShow.Categories.Add(_categories.FindById(categoriesId));
                }
                else
                {
                    TvShow.Categories.Add(_categories.FindById(categoriesId));
                }
                
            }
            foreach (var languageId in item.LanguagesIds)
            {
                if (TvShow.Languages == null)
                {
                    TvShow.Languages = new List<Language>();
                    TvShow.Languages.Add(_language.FindById(languageId));
                }
                else
                {
                    TvShow.Languages.Add(_language.FindById(languageId));
                }
            }
            foreach (var subtitleId in item.SubtitleIds)
            {
                if (TvShow.Subtitle == null)
                {
                    TvShow.Subtitle = new List<Subtitle>();
                    TvShow.Subtitle.Add(_subtitle.FindById(subtitleId));
                }
                else
                {
                    TvShow.Subtitle.Add(_subtitle.FindById(subtitleId));
                }
            }
            foreach (var actorId in item.ActorsIds)
            {
                if (TvShow.Actors == null)
                {
                    TvShow.Actors = new List<Actor>();
                    TvShow.Actors.Add(_actors.FindById(actorId));
                }
                else
                {
                    TvShow.Actors.Add(_actors.FindById(actorId));
                }
            }
            foreach (var audioId in item.AudioLanguagesIds)
            {
                if (TvShow.AudioLanguages == null)
                {
                    TvShow.AudioLanguages = new List<AudioLanguage>();
                    TvShow.AudioLanguages.Add(_audioLanguages.FindById(audioId));
                }
                else
                {
                    TvShow.AudioLanguages.Add(_audioLanguages.FindById(audioId));
                }
            }

            _db.Create(TvShow);
        }

        public TvShowVM FindById(int id)
        {
            var res = _db.FindById(id);
            var TvShow = mapperMtoVm.Map<TvShowVM>(res);
            return TvShow;
        }

        public IEnumerable<TvShowVM> GetAll()
        {
            var list = _db.GetAll();
            List<TvShowVM> tvshows = new();
            foreach (var item in list)
            {
                var twshow = mapperMtoVm.Map<TvShowVM>(item);
                tvshows.Add(twshow);
            }
            return tvshows;
        }

        public IEnumerable<object> GetAllWithInclude()
        {
            var res = _db.GetWithInclude("Categories", "Languages", "Subtitle", "AudioLanguages", "Actors", "Seasons.Series");

            return res;
        }

        public IEnumerable<TvShowVM> GetWithId()
        {
            var list = _db.GetAll();
            List<TvShowWithIdVM> tvshows = new();
            foreach (var item in list)
            {
                var tvshow = mapperIdMtoVM.Map<TvShowWithIdVM>(item);
                tvshows.Add(tvshow);
            }
            return tvshows;
        }

        public object GetWithInclude(int id)
        {
            var res = _db.GetWithIdInclude(id, "Categories", "Languages", "Subtitle", "AudioLanguages", "Actors", "Seasons.Series");

            return res;
        }

        public void Remove(int id)
        {
            var res = _db.GetWithIdInclude(id, "Languages", "Subtitle", "AudioLanguages", "Categories", "Actors", "Seasons");
            if (res == null)
            {
                return;
            }

            ImgFileExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", res.HoverImgName));
            
            _db.Remove(res);
        }

        public void Update(int id, TvShowVM item)
        {
            var res  = _db.FindById(id);
            if (res == null)
            {
                return;
            }

            res.Desc = item.Desc;
            res.ReliseTime = item.ReliseTime;
            res.TvShowName = item.TvShowName;
            res.rating = item.rating;
            if (res.rating == null)
            {
                res.rating = "Unheard";
            }

            ImgFileExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", res.HoverImgName));
            string imgName = item.ImgFile.ChangeImgFileName();
            item.ImgFile.CreateImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", imgName));
            res.HoverImgName = imgName;

            res.Categories.Clear();
            res.Actors.Clear();
            res.Subtitle.Clear();
            res.AudioLanguages.Clear();
            res.Languages.Clear();

            foreach (var categoriesId in item.CategoriesIds)
            {
                if (res.Categories == null)
                {
                    res.Categories = new List<Category>();
                    res.Categories.Add(_categories.FindById(categoriesId));
                }
                else
                {
                    res.Categories.Add(_categories.FindById(categoriesId));
                }

            }
            foreach (var languageId in item.LanguagesIds)
            {
                if (res.Languages == null)
                {
                    res.Languages = new List<Language>();
                    res.Languages.Add(_language.FindById(languageId));
                }
                else
                {
                    res.Languages.Add(_language.FindById(languageId));
                }
            }
            foreach (var subtitleId in item.SubtitleIds)
            {
                if (res.Subtitle == null)
                {
                    res.Subtitle = new List<Subtitle>();
                    res.Subtitle.Add(_subtitle.FindById(subtitleId));
                }
                else
                {
                    res.Subtitle.Add(_subtitle.FindById(subtitleId));
                }
            }
            foreach (var actorId in item.ActorsIds)
            {
                if (res.Actors == null)
                {
                    res.Actors = new List<Actor>();
                    res.Actors.Add(_actors.FindById(actorId));
                }
                else
                {
                    res.Actors.Add(_actors.FindById(actorId));
                }
            }
            foreach (var audioId in item.AudioLanguagesIds)
            {
                if (res.AudioLanguages == null)
                {
                    res.AudioLanguages = new List<AudioLanguage>();
                    res.AudioLanguages.Add(_audioLanguages.FindById(audioId));
                }
                else
                {
                    res.AudioLanguages.Add(_audioLanguages.FindById(audioId));
                }
            }


            _db.Update(res);
        }

        
    }
}
