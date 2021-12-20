using Application.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Interfaces.Repository
{
    public interface IOrderRepository : IAsyncGenericRepository<Order>
    {
    }
}
