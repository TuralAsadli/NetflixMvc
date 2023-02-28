using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.Category
{
    public class CategoryVM
    {
        [Required(ErrorMessage = "Pls write name of Category"), MaxLength(25, ErrorMessage = "Very long name of Category")]
        public string CategoryName { get; set; }
    }
}
