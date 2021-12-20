using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Interfaces.Repository;

namespace Application.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
