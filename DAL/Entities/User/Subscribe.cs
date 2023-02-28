using DAL.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.User
{
    public class Subscribe : BaseItem
    {
        public string SubscribeName { get; set; }

        public decimal Price { get; set; }


        
        public int Duration { get; set; }

        public int MaxUser { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
