using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository.BaseRepository
{
    public interface ITvShowRepository<T> : IBaseRepository<T> where T : class
    {
        T GetWithIdInclude(int id, params string[] includeProperties);
        
    }
}
