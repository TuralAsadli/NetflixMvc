using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ISeriaService<VM> : IBaseService<VM> where VM : class
    {
        public void AddView(int id);
        
    }
}
