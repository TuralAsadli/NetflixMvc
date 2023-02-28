using AutoMapper;
using BusinesLogic.ViewModel.Actor;
using BusinesLogic.ViewModel.Category;
using DAL.GeneralClass;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;


namespace BusinesLogic.Services
{
    
    public class ActorService : IActorService<ActorVM>
    {
        IBaseRepository<Actor> _db;
        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;

        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;
        public ActorService(IBaseRepository<Actor> db)
        {
            configVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ActorVM, Actor>()
                );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ActorWithIdVM, Actor>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Actor, ActorVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Actor, ActorWithIdVM>()
                );
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);
            _db = db;
        }

        public void Create(ActorVM item)
        {
            var actor = mapperVmToM.Map<Actor>(item);

            _db.Create(actor);
        }

        public ActorVM FindById(int id)
        {
            var res = _db.FindById(id);
            var actorVM = mapperMtoVm.Map<ActorVM>(res);
            return actorVM;
        }

        public IEnumerable<ActorVM> GetAll()
        {
            var list = _db.GetAll();
            List<ActorVM> actorList = new List<ActorVM>();
            foreach (var item in list)
            {
                var actor = mapperMtoVm.Map<ActorVM>(item);
                actorList.Add(actor);
            }

            return actorList;
        }

        public void Remove(int id)
        {
            var res = _db.FindById(id);
            _db.Remove(res);
        }

        public void Update(int id, ActorVM item)
        {
            Actor actor = new Actor()
            {
                Id = id,
                ActorName = item.ActorName,
                ActorSurname = item.ActorSurname,
            };

            _db.Update(actor);
        }

        public IEnumerable<ActorVM> GetWithId()
        {
            var list = _db.GetAll();
            List<ActorWithIdVM> actorList = new List<ActorWithIdVM>();
            foreach (var item in list)
            {
                var actor = mapperIdMtoVM.Map<ActorWithIdVM>(item);
                actorList.Add(actor);
            }

            return actorList;
        }

        
    }
}
