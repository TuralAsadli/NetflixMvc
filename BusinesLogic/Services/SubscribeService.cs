using AutoMapper;
using BusinesLogic.ViewModel.Language;
using BusinesLogic.ViewModel.Subscribe;
using DAL.Entities.User;
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

    public class SubscribeService : ISubscribeService<SubscribeVM>
    {
        IBaseRepository<Subscribe> _db;
        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;

        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;

        public SubscribeService(IBaseRepository<Subscribe> db)
        {
            configVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SubscribeVM, Subscribe>()
                );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SubscribeWithIdVM, Subscribe>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Subscribe, SubscribeVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Subscribe, SubscribeWithIdVM>()
                );
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);
            _db = db;
        }

        public void Create(SubscribeVM item)
        {
            var Language = mapperVmToM.Map<Subscribe>(item);
            _db.Create(Language);
        }

        public SubscribeVM FindById(int id)
        {
            var res = _db.FindById(id);
            var languageVM = mapperIdMtoVM.Map<SubscribeWithIdVM>(res);
            return languageVM;
        }

        public IEnumerable<SubscribeVM> GetAll()
        {
            var list = _db.GetAll();
            List<SubscribeVM> SubscribeList = new List<SubscribeVM>();
            foreach (var item in list)
            {
                var subscribe = mapperIdMtoVM.Map<SubscribeVM>(item);
                SubscribeList.Add(subscribe);
            }

            return SubscribeList;
        }

        public IEnumerable<SubscribeVM> GetWithId()
        {
            var list = _db.GetAll();
            List<SubscribeWithIdVM> SubscribeList = new List<SubscribeWithIdVM>();
            foreach (var item in list)
            {
                var subscribe = mapperIdMtoVM.Map<SubscribeWithIdVM>(item);
                SubscribeList.Add(subscribe);
            }

            return SubscribeList;
        }

        public void Remove(int id)
        {
            var res = _db.FindById(id);
            _db.Remove(res);
        }

        public void Update(int id, SubscribeVM item)
        {
            var subscribe = mapperVmToM.Map<Subscribe>(item);
            subscribe.Id = id;
            _db.Update(subscribe);

        }
    }
}
