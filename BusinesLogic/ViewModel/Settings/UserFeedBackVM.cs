using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesLogic.ViewModel.Settings
{
    public class UserFeedBackVM
    {
        [Required]
        public string UserName { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required,DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Venue { get; set; }
        [Required, DataType(DataType.Text)]
        public string Message { get; set; }
    }
}
