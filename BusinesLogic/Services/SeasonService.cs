using AutoMapper;
using BusinesLogic.Utilites;
using BusinesLogic.ViewModel.TvShow;
using BusinesLogic.ViewModel.TvShow.Season;
using DAL.GeneralClass;
using DAL.TvShows;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Services
{
    
    public class SeasonService : ISeasonService<SeasonVM>
    {
        IWebHostEnvironment _env;
        IBaseRepository<Season> _db;
        ITvShowRepository<TvShow> _tvShowRepository;

        
        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;

        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;

        public SeasonService(IWebHostEnvironment env, IBaseRepository<Season> db, ITvShowRepository<TvShow> tvShowRepository)
        {
            configVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SeasonVM, Season>()
                );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SeasonWithIdVM, Season>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Season, SeasonVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Season, SeasonWithIdVM>()
                );
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);

            _env = env;
            _db = db;
            _tvShowRepository = tvShowRepository;
        }

        public void Create(SeasonVM item)
        {
            var Season = mapperVmToM.Map<Season>(item);

            var tvshow = _tvShowRepository.FindById(item.TvshowId);

            string VideoName = item.TrailerVideoFile.ChangeVideoFileName();
            item.TrailerVideoFile.CreateVideoFile(Path.Combine(_env.WebRootPath, "videos", "trailers", VideoName));
            Season.TrailerVideo = VideoName;

            if (tvshow.Seasons == null)
            {
                tvshow.Seasons = new List<Season>();
                tvshow.Seasons.Add(Season);
            }
            else
            {
                tvshow.Seasons.Add(Season);
            }
            _tvShowRepository.Update(tvshow);
            //_db.Create(Season);
        }

        public SeasonVM FindById(int id)
        {
            var res = _db.FindById(id);
            var season = mapperMtoVm.Map<SeasonVM>(res);
            return season;
        }

        public IEnumerable<SeasonVM> GetAll()
        {
            var list = _db.GetAll();
            List<SeasonVM> seasons = new();
            foreach (var item in list)
            {
                var season = mapperMtoVm.Map<SeasonVM>(item);
                seasons.Add(season);
            }
            return seasons;
        }

        public IEnumerable<SeasonVM> GetWithId()
        {
            var list = _db.GetWithInclude("TvShow");
            List<SeasonWithIdVM> seasons = new();
            foreach (var item in list)
            {
                var season = mapperIdMtoVM.Map<SeasonWithIdVM>(item);
                seasons.Add(season);
            }
            return seasons;
        }

        public void Remove(int id)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return;
            }

            ImgFileExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "videos", "trailers", res.TrailerVideo));

            _db.Remove(res);
        }

        public void Update(int id, SeasonVM item)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return;
            }

            var season = mapperVmToM.Map<Season>(item);

            season.Id = id;

            VideoFileExtenion.DeleteVideoFile(Path.Combine(_env.WebRootPath, "videos", "trailers", res.TrailerVideo));
            string imgName = item.TrailerVideoFile.ChangeVideoFileName();
            item.TrailerVideoFile.CreateVideoFile(Path.Combine(_env.WebRootPath, "videos", "trailers", imgName));
            season.TrailerVideo = imgName;




            _db.Update(season);
        }
    }
}
