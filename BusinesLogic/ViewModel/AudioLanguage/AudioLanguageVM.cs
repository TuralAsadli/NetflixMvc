using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.AudioLanguage
{
    public class AudioLanguageVM
    {
        [Required(ErrorMessage = "Pls write name of AudioLanguage"), MaxLength(25, ErrorMessage = "Very long name of AudioLanguage")]
        public string AudioName { get; set; }
    }
}
