using DAL.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Settings
{
    public class UserFeedback : BaseItem
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Venue { get; set; }
        public string Message { get; set; }
    }
}
