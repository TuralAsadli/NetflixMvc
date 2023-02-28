using DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Settings
{
    public class Setting : BaseItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
