using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ISettingsService<VM> : IBaseService<VM> where VM : class
    {
        
    }
}
