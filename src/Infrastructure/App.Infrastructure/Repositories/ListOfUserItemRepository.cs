using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Repositories
{
    public class ListOfUserItemRepository :GenericRepository<ListOfUserItem>, IListOfUserItemRepository
    {
        public ListOfUserItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
