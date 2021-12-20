using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Interfaces.Repository;

namespace Application.Infrastructure.Repositories
{
    public class ItemRepository :GenericRepository<Item>,IItemRepository
    {
        public ItemRepository(ApplicationDbContext dbContext):base(dbContext)
        {

        }
    }
}
