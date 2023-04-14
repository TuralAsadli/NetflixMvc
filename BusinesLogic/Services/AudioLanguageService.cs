using AutoMapper;
using BusinesLogic.ViewModel.AudioLanguage;
using BusinesLogic.ViewModel.Category;
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
    internal class AudioLanguageService : IAudioLanguageService<AudioLanguageVM>
    {
        IBaseRepository<AudioLanguage> _db;
        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;

        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;

        public AudioLanguageService(IBaseRepository<AudioLanguage> db)
        {
            configVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AudioLanguageVM, AudioLanguage>()
                );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AudioWithId, AudioLanguage>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AudioLanguage, AudioLanguageVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<AudioLanguage, AudioWithId>());
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);
            _db = db;
        }

        public void Create(AudioLanguageVM item)
        {
            var Audio = mapperVmToM.Map<AudioLanguage>(item);
            _db.Create(Audio);
        }

        public AudioLanguageVM FindById(int id)
        {
            var res = _db.FindById(id);
            var audioVM = mapperMtoVm.Map<AudioLanguageVM>(res);
            return audioVM;
        }

        public IEnumerable<AudioLanguageVM> GetAll()
        {
            var list = _db.GetAll();
            List<AudioLanguageVM> audioList = new List<AudioLanguageVM>();
            foreach (var item in list)
            {
                var audio = mapperIdMtoVM.Map<AudioLanguageVM>(item);
                audioList.Add(audio);
            }

            return audioList;
        }

        public IEnumerable<AudioLanguageVM> GetWithId()
        {
            var list = _db.GetAll();
            List<AudioWithId> AudioList = new List<AudioWithId>();
            foreach (var item in list)
            {
                var subtitle = mapperIdMtoVM.Map<AudioWithId>(item);
                AudioList.Add(subtitle);
            }

            return AudioList;
        }

        public void Remove(int id)
        {
            var res = _db.FindById(id);
            _db.Remove(res);
        }

        public void Update(int id, AudioLanguageVM item)
        {
            var subtitle = mapperVmToM.Map<AudioLanguage>(item);
            subtitle.Id = id;
            _db.Update(subtitle);
        }
    }
}
