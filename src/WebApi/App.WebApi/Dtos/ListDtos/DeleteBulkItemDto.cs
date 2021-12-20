using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.WebApi.Dtos.ListDtos
{
    public class DeleteBulkItemDto
    {
        public Guid Id { get; set; }
        public Guid[] ItemsId { get; set; }
    }
}
