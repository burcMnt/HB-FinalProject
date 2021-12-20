using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Interfaces.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Infrastructure.Repositories
{
    public class ListOfUserRepository : GenericRepository<ListOfUser>, IListOfUserRepository
    {
        public ListOfUserRepository(ApplicationDbContext dbContext):base(dbContext)
        {

        }

   
    }
}
