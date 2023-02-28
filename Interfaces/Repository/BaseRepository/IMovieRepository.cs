using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository.BaseRepository
{
    public interface IMovieRepository<T> : IBaseRepository<T> where T : class
    {

        T GetWithIdInclude(int id,params string[] includeProperties);
        

    }
}
