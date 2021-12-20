using Application.ApplicationCore.Entities;
using System;
using System.Collections.Generic;

namespace Application.WebApi.Dtos.ListDtos
{
    public class CreateListDto
    {
        public string ListName { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public int ItemQuantity { get; set; }
        public List<Item> Items { get; set; }
    }
}
