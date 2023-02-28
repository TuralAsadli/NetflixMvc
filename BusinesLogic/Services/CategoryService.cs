
using AutoMapper;
using BusinesLogic.ViewModel.Category;
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
    public class CategoryService : ICategoryService<CategoryVM>
    {
        MapperConfiguration configVmToM;
        MapperConfiguration configIdVmToM;
        MapperConfiguration configMtoVm;
        MapperConfiguration configIdMtoVm;
        IBaseRepository<Category> _db;
        Mapper mapperVmToM;
        Mapper mapperIdVmToM;
        Mapper mapperMtoVm;
        Mapper mapperIdMtoVM;
        public CategoryService(IBaseRepository<Category> db)
        {
            configVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<CategoryVM, Category>()
                );
            configIdVmToM = new MapperConfiguration(cfg =>
                    cfg.CreateMap<CategoryWithId, Category>()
                );
            configMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Category, CategoryVM>()
                );
            configIdMtoVm = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Category,CategoryWithId>()
                );
            mapperVmToM = new Mapper(configVmToM);
            mapperIdVmToM = new Mapper(configIdVmToM);
            mapperMtoVm = new Mapper(configMtoVm);
            mapperIdMtoVM = new Mapper(configIdMtoVm);
            _db = db;
        }

        public void Remove(int id)
        {
            var res = _db.FindById(id);
            _db.Remove(res);
        }

        public void Create(CategoryVM item)
        {
            var category = mapperVmToM.Map<Category>(item);
            _db.Create(category);
        }

        public CategoryVM FindById(int id)
        {
            var res = _db.FindById(id);
            var categoryVM = mapperMtoVm.Map<CategoryVM>(res);
            return categoryVM;
        }

        public IEnumerable<CategoryVM> GetAll()
        {
            var list = _db.GetAll();
            List<CategoryVM> categoryList = new List<CategoryVM>();
            foreach (var item in list)
            {
                var categories = mapperMtoVm.Map<CategoryVM>(item);
                categoryList.Add(categories);
            }
            
            return categoryList;
        }

        public IEnumerable<CategoryVM> GetWithId()
        {
            var list = _db.GetAll();
            List<CategoryWithId> categoryList = new List<CategoryWithId>();
            foreach (var item in list)
            {
                var categories = mapperIdMtoVM.Map<CategoryWithId>(item);
                categoryList.Add(categories);
            }

            return categoryList;
        }

        public void Update(int id, CategoryVM item)
        {
            var category = mapperVmToM.Map<Category>(item);
            category.Id = id;
            _db.Update(category);
        }
    }
}
