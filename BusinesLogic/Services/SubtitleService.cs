using AutoMapper;
using BusinesLogic.ViewModel.Category;
using BusinesLogic.ViewModel.Language;
using BusinesLogic.ViewModel.Subtitle;
using DAL.GeneralClass;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Services
{

    public class SubtitleService : ISubtitleService<SubtitleVM>
    {
        IBaseRepository<Subtitle> _db;
        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;

        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;

        public SubtitleService(IBaseRepository<Subtitle> db)
        {
            configVmToM = new MapperConfiguration(cfg =>
                     cfg.CreateMap<SubtitleVM, Subtitle>()
                 );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SubtitleWithIdVM, Subtitle>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Subtitle, SubtitleVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Subtitle, SubtitleWithIdVM>()
                );
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);

            _db = db;
        }

        public void Create(SubtitleVM item)
        {
            var Subtitle = mapperVmToM.Map<Subtitle>(item);
            _db.Create(Subtitle);
        }

        public SubtitleVM FindById(int id)
        {
            var res = _db.FindById(id);
            var subtitleVM = mapperMtoVm.Map<SubtitleVM>(res);
            return subtitleVM;
        }

        public IEnumerable<SubtitleVM> GetAll()
        {
            var list = _db.GetAll();
            List<SubtitleVM> SubtitleList = new List<SubtitleVM>();
            foreach (var item in list)
            {
                var subtitle = mapperMtoVm.Map<SubtitleVM>(item);
                SubtitleList.Add(subtitle);
            }

            return SubtitleList;
        }

        public IEnumerable<SubtitleVM> GetWithId()
        {
            var list = _db.GetAll();
            List<SubtitleWithIdVM> SubtitleList = new List<SubtitleWithIdVM>();
            foreach (var item in list)
            {
                var subtitle = mapperIdMtoVM.Map<SubtitleWithIdVM>(item);
                SubtitleList.Add(subtitle);
            }

            return SubtitleList;
        }

        public void Remove(int id)
        {
            var res = _db.FindById(id);
            _db.Remove(res);
        }

        public void Update(int id, SubtitleVM item)
        {
            var subtitle = mapperVmToM.Map<Subtitle>(item);
            subtitle.Id = id;
            _db.Update(subtitle);
        }
    }
}
