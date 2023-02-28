using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services.ManyToManyServices
{
    public interface IBaseManyToManyService<T>
    {
        void Create(T entity);

        IEnumerable<T> GetByMovie(int id);
        void Remove(T entity);
    }
}
