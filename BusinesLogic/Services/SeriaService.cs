using AutoMapper;
using BusinesLogic.Utilites;
using BusinesLogic.ViewModel.TvShow;
using BusinesLogic.ViewModel.TvShow.Season;
using BusinesLogic.ViewModel.TvShow.Seria;
using DAL.Movies;
using DAL.Repository;
using DAL.TvShows;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Services
{
    public class SeriaService : ISeriaService<SeriaVM>
    {
        IWebHostEnvironment _env;
        IBaseRepository<Series> _db;
        IBaseRepository<Season> _seasons;


        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;

        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;

        public SeriaService(IWebHostEnvironment env, IBaseRepository<Series> db, IBaseRepository<Season> seasons)
        {
            configVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SeriaVM, Series>()
                );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SeriaWithIdVM, Series>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Series, SeriaVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Series, SeriaWithIdVM>()
                );
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);

            _env = env;
            _db = db;
            _seasons = seasons;
        }

        public void Create(SeriaVM item)
        {
            var seria = mapperVmToM.Map<Series>(item);

            var season = _seasons.FindById(item.SeasonId);

            string imgName = item.HoverImgFile.ChangeImgFileName();
            item.HoverImgFile.CreateImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", imgName));
            seria.HoverImgName = imgName;

            string videoName = item.VideoFile.ChangeVideoFileName();
            item.VideoFile.CreateVideoFile(Path.Combine(_env.WebRootPath, "videos", "tvshows", videoName));
            seria.VideoName = videoName;

            seria.Duration = VideoFileExtenion.GetVideoDuration(Path.Combine(_env.WebRootPath, "videos", "tvshows", videoName)).ConvertTimeSpan();

            if (season.Series == null)
            {
                season.Series = new List<Series>();
                season.Series.Add(seria);
            }
            else
            {
                season.Series.Add(seria);
            }
            _seasons.Update(season);
        }

        public SeriaVM FindById(int id)
        {
            var res = _db.FindById(id);
            var seria = mapperMtoVm.Map<SeriaVM>(res);
            return seria;
        }

        public IEnumerable<SeriaVM> GetAll()
        {
            var list = _db.GetAll();
            List<SeriaVM> series = new();
            foreach (var item in list)
            {
                var seria = mapperMtoVm.Map<SeriaVM>(item);
                series.Add(seria);
            }
            return series;
        }

        public IEnumerable<SeriaVM> GetWithId()
        {
            var list = _db.GetWithInclude("Seasons");
            List<SeriaWithIdVM> series = new();
            foreach (var item in list)
            {
                var seria = mapperIdMtoVM.Map<SeriaWithIdVM>(item);
                series.Add(seria);
            }
            return series;
        }

        public void Remove(int id)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return;
            }

            ImgFileExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", res.HoverImgName));
            VideoFileExtenion.DeleteVideoFile(Path.Combine(_env.WebRootPath, "videos", "tvshows", res.VideoName));
            _db.Remove(res);
        }

        public void Update(int id, SeriaVM item)
        {
            var res = _db.FindById(id);
            if (res == null)
            {
                return;
            }

            var seria = mapperVmToM.Map<Series>(item);

            seria.Id = id;

            ImgFileExtention.DeleteImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", res.HoverImgName));
            VideoFileExtenion.DeleteVideoFile(Path.Combine(_env.WebRootPath, "videos", "tvshows", res.VideoName));

            string imgName = item.HoverImgFile.ChangeImgFileName();
            item.HoverImgFile.CreateImgFile(Path.Combine(_env.WebRootPath, "images", "hoverImg", imgName));
            seria.HoverImgName = imgName;

            string videoName = item.VideoFile.ChangeVideoFileName();
            item.VideoFile.CreateVideoFile(Path.Combine(_env.WebRootPath, "videos", "tvshows", videoName));
            seria.VideoName = videoName;

            seria.Duration = VideoFileExtenion.GetVideoDuration(Path.Combine(_env.WebRootPath, "videos", "tvshows", videoName)).ConvertTimeSpan();

            _db.Update(seria);
        }

        public void AddView(int id)
        {
            var seria = _db.FindById(id);
            seria.Views += 1;
            _db.Update(seria);
        }
    }
}
