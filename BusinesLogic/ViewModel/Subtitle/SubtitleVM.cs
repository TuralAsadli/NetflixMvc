using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.Subtitle
{
    public class SubtitleVM
    {
        [Required(ErrorMessage = "Pls write name of Subtitle"), MaxLength(25, ErrorMessage = "Very long name of Subtitle")]
        public string SubtitleName { get; set; }
    }
}
