using Application.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Interfaces.Repository
{
     public interface IListedItemRepository
    {
        public Task AddOrUpdateAsync(string id, int quantity);
        public Task AddOrUpdateUserAsync(string userId,string itemId, int quantity);
    }
}
