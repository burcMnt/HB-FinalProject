using Application.ApplicationCore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Entities
{
    public class ListOfUser : BaseEntity
    {
        public string ListName { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int ItemQuantity { get; set; }
        public List<ListOfUserItem> Items { get; set; }
       // public List<Item> UserItems { get; set; }

    }
}
