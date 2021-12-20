using Application.ApplicationCore.Entities.MongoDbEntities;
using Application.ApplicationCore.Interfaces.MongoDbRepository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Repositories.MongoDb
{
    public class MongoRepository : IMongoRepository
    {
        private IMongoCollection<ListItem> _ItemList;
        private IMongoCollection<UserListItem> _UserItemList;

        public MongoRepository(IMongoDbContext dbContext)
        {
            _ItemList = dbContext.db.GetCollection<ListItem>("ItemsList");
            _UserItemList = dbContext.db.GetCollection<UserListItem>("_UserItemList");
        }
        public async Task Add(ListItem entity)
        {
            await _ItemList.InsertOneAsync(entity);
        }
        public async Task AddUserList(UserListItem entity)
        {
            await _UserItemList.InsertOneAsync(entity);
        }

        public async Task<List<ListItem>> GetAll() =>
      
            (await _ItemList.FindAsync(entity => true)).ToList();


        public async Task<ListItem> GetById(string listId) =>
            (await _ItemList.FindAsync(entity => entity.ItemId==listId)).FirstOrDefault();

        public async Task<UserListItem> GetByUserId(string userlistId) =>
            (await _UserItemList.FindAsync(entity => entity.UserId == userlistId)).FirstOrDefault();

        public Task<List<UserListItem>> GetUserFirstTen()
        {
            // var userList = _UserItemList.Find(x => x.UserId !=null ).SortByDescending(x=>x.ItemQuantity).Limit(10).ToList();

            var userList = _UserItemList.AsQueryable<UserListItem>().OrderByDescending(x => x.ItemQuantity).Take(10).ToList();
            return Task.FromResult(userList);
          
        }

        public Task<List<ListItem>> GetFirstTen()
        {
           //var list= _ItemList.Find(x => true).SortByDescending(x=>x.ItemQuantity).Limit(10).ToList();

           var list= _ItemList.AsQueryable<ListItem>().OrderByDescending(x => x.ItemQuantity).Take(10).ToList();
            return Task.FromResult(list);
        }

        public async Task Remove(ListItem entity) =>
            await _ItemList.DeleteOneAsync(x => x.ItemId.Equals(entity.ItemId));
      

        public async Task Remove(string listId)=>
            await _ItemList.DeleteOneAsync(x => x.ItemId.Equals(listId));

        public async Task Update(string listId, ListItem entity) =>
            await _ItemList.ReplaceOneAsync(x => x.ItemId.Equals(listId), entity);

        public async Task UpdateUser(string userId, UserListItem entity) =>
            await _UserItemList.ReplaceOneAsync(x => x.ItemId == userId, entity);

        public async Task<List<UserListItem>> LoadRecords(string id)
        {
            var filter = Builders<UserListItem>.Filter.Eq("UserId", id);

            List<UserListItem> filteredUser = await _UserItemList.Find(filter).ToListAsync();
            return filteredUser;
        }
    }
}
