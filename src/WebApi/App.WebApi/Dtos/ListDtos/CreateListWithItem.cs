using Application.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi.Dtos.ListDtos
{
    public class CreateListWithItem
    {
        public string ListName { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public List<Item> Items { get; set; }
    }
}
