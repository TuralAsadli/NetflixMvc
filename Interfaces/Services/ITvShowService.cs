using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ITvShowService<VM> : IBaseService<VM> where VM : class
    {
        IEnumerable<object> GetAllWithInclude();

        IEnumerable<object> Search(string query);
        object GetWithInclude(int id);
        
    }
}
