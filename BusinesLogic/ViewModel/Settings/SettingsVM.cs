using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.Settings
{
    public class SettingVM
    {
        
        public int? Id { get; set; }
        [Required]
        public string Key { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
