using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.Language
{
    public class LanguageVM
    {
        [Required(ErrorMessage = "Pls write name of Language"), MaxLength(25, ErrorMessage = "Very long name of Language")]
        public string LanguageName { get; set; }
    }
}
