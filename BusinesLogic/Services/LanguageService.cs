using AutoMapper;
using BusinesLogic.ViewModel.Category;
using BusinesLogic.ViewModel.Language;
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
    public class LanguageService : ILanguageService<LanguageVM>
    {
        IBaseRepository<Language> _db;
        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;

        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;
        public LanguageService(IBaseRepository<Language> db)
        {
            configVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<LanguageVM, Language>()
                );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<LanguageWithId, Language>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Language, LanguageVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Language, LanguageWithId>()
                );
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);

            _db = db;
        }

        public void Create(LanguageVM item)
        {
            var Language = mapperVmToM.Map<Language>(item);
            _db.Create(Language);
        }

        public LanguageVM FindById(int id)
        {
            var res = _db.FindById(id);
            var languageVM = mapperIdMtoVM.Map<LanguageWithId>(res);
            return languageVM;
        }

        public IEnumerable<LanguageVM> GetAll()
        {
            var list = _db.GetAll();
            List<LanguageVM> LanguageList = new List<LanguageVM>();
            foreach (var item in list)
            {
                var language = mapperIdMtoVM.Map<LanguageVM>(item);
                LanguageList.Add(language);
            }

            return LanguageList;
        }

        public IEnumerable<LanguageVM> GetWithId()
        {
            var list = _db.GetAll();
            List<LanguageWithId> LanguageList = new List<LanguageWithId>();
            foreach (var item in list)
            {
                var language = mapperIdMtoVM.Map<LanguageWithId>(item);
                LanguageList.Add(language);
            }

            return LanguageList;
        }

        public void Remove(int id)
        {
            var res = _db.FindById(id);
            _db.Remove(res);
        }

        public void Update(int id, LanguageVM item)
        {
            var language = mapperVmToM.Map<Language>(item);
            language.Id = id;
            _db.Update(language);
        }
    }
}
