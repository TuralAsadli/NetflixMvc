using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IMovieService<VM> : IBaseService<VM> where VM : class
    {
        IEnumerable<object> GetAllWithInclude();

        IEnumerable<object> Search(string query);
        object GetWithInclude(int id);

        void AddView(int id);
    }
}
