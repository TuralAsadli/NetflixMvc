using BusinesLogic.ViewModel.Settings;
using DAL.Entities.Settings;
using Interfaces.Repository.BaseRepository;
using Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.Services
{
    public class UserFeedbackService : IUserFeedbackService<UserFeedBackVM>
    {
        IBaseRepository<UserFeedback> _db;

        public UserFeedbackService(IBaseRepository<UserFeedback> db)
        {
            _db = db;
        }

        public void Create(UserFeedBackVM item)
        {
            UserFeedback message = new UserFeedback()
            {
                UserName = item.UserName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                Message = item.Message,
                Venue = item.Venue,
            };
            _db.Create(message);
        }

        public UserFeedBackVM FindById(int id)
        {
            var item = _db.FindById(id);
            FeedBackWithId feedback = new FeedBackWithId()
            {
                Id = id,
                UserName = item.UserName,
                Email = item.Email,
                PhoneNumber = item.PhoneNumber,
                Message = item.Message,
                Venue = item.Venue,
            };

            return feedback;
        }

        public IEnumerable<UserFeedBackVM> GetAll()
        {
            List<UserFeedBackVM> list = new List<UserFeedBackVM>();
            foreach (var item in _db.GetAll())
            {
                UserFeedBackVM message = new UserFeedBackVM()
                {
                    UserName = item.UserName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Message = item.Message,
                    Venue = item.Venue,
                };
                list.Add(message);
            }
            return list;
        }

        public IEnumerable<UserFeedBackVM> GetWithId()
        {
            List<FeedBackWithId> list = new List<FeedBackWithId>();
            foreach (var item in _db.GetAll())
            {
                FeedBackWithId message = new FeedBackWithId()
                {
                    Id=item.Id,
                    UserName = item.UserName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Message = item.Message,
                    Venue = item.Venue,
                };
                list.Add(message);
            }
            return list;
        }

        public void Remove(int id)
        {
            _db.Remove(_db.FindById(id));
        }

        public void Update(int id, UserFeedBackVM item)
        {
            var setting = _db.FindById(id);
            setting.UserName = item.UserName;
            setting.Email = item.Email;
            setting.PhoneNumber = item.PhoneNumber;
            setting.Message = item.Message;
            setting.Venue = item.Venue;
            _db.Update(setting);
        }
    }
}
