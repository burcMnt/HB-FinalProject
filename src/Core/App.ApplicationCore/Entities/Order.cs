using Application.ApplicationCore.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Entities
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public decimal TotalPrice { get; set; } = 0;
        public User User { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        
    }
}
