using DAL.Entities.User;
using Interfaces.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    internal class SubscripeRepository : ISubscribeRepository<Subscribe>
    {
        public void Create(Subscribe item)
        {
            throw new NotImplementedException();
        }

        public Subscribe FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subscribe> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subscribe> GetAll(Func<Subscribe, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subscribe> GetWithInclude(params string[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Subscribe> Include(IQueryable<Subscribe> queryable, params string[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Remove(Subscribe item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Subscribe item)
        {
            throw new NotImplementedException();
        }
    }
}
