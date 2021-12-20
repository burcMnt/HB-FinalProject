using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Interfaces.Repository;

namespace Application.Infrastructure.Repositories
{
    public class OrderRepository :GenericRepository<Order>,IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
