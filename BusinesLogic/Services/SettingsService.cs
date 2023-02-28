
using BusinesLogic.ViewModel.Settings;
using DAL.Entities.Settings;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;

namespace BusinesLogic.Services
{
    public class SettingsService : ISettingsService<SettingVM>
    {
        IBaseRepository<Setting> _db;

        public SettingsService(IBaseRepository<Setting> db)
        {
            _db = db;
        }

        public void Create(SettingVM item)
        {
            Setting setting = new Setting()
            {
                Key = item.Key,
                Value = item.Value,
            };
            _db.Create(setting);
        }

        public SettingVM FindById(int id)
        {
            var setting = _db.FindById(id);
            SettingVM settingVM= new SettingVM()
            {
                Id = id,
                Key = setting.Key,
                Value = setting.Value
            };

            return settingVM;
        }

        public IEnumerable<SettingVM> GetAll()
        {
            List<SettingVM> list = new List<SettingVM>();
            foreach (var item in _db.GetAll())
            {
                SettingVM setting = new SettingVM
                {
                    Id = item.Id,
                    Key = item.Key,
                    Value = item.Value
                };
                list.Add(setting);
            }
            return list;
        }

        public IEnumerable<SettingVM> GetWithId()
        {
            List<SettingVM> list = new List<SettingVM>();
            foreach (var item in _db.GetAll())
            {
                SettingVM setting = new SettingVM
                {
                    Id = item.Id,
                    Key = item.Key,
                    Value = item.Value
                };
                list.Add(setting);
            }
            return list;
        }

        public void Remove(int id)
        {
            _db.Remove(_db.FindById(id));
        }

        public void Update(int id, SettingVM item)
        {
            var setting = _db.FindById(id);
            setting.Key = item.Key;
            setting.Value = item.Value;
            _db.Update(setting);
        }
    }
}
