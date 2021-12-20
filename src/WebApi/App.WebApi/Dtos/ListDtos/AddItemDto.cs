using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi.Dtos.ListDtos
{
    public class AddItemDto
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
