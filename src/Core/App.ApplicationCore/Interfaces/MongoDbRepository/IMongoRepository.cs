using Application.ApplicationCore.Common;
using Application.ApplicationCore.Entities.MongoDbEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Interfaces.MongoDbRepository
{
    public interface IMongoRepository
    {
        Task<ListItem> GetById(string itemId);
        Task<UserListItem> GetByUserId(string userId);
        Task<List<ListItem>> GetAll();
        Task<List<UserListItem>> GetUserFirstTen();
        Task<List<ListItem>> GetFirstTen();
        Task Add(ListItem entity);
        Task AddUserList(UserListItem entity);
        Task Update(string itemId, ListItem entity);
        Task UpdateUser(string userId, UserListItem entity);
        Task Remove(ListItem entity);
        Task Remove(string itemId);

        Task<List<UserListItem>> LoadRecords(string id);
    }
}
