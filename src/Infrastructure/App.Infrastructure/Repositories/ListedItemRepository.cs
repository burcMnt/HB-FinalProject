using Application.ApplicationCore.Entities.MongoDbEntities;
using Application.ApplicationCore.Interfaces.MongoDbRepository;
using Application.ApplicationCore.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Infrastructure.Repositories
{
    public class ListedItemRepository : IListedItemRepository
    {
        private readonly IListItemsMongoRepository _repository;

        public ListedItemRepository(IListItemsMongoRepository repository)
        {
            _repository = repository;
        }

        public async Task AddOrUpdateAsync(string id, int quantity)
        {
            ListItem current = await _repository.GetById(id);
            if (current != null)
            {
                current.ItemQuantity += quantity;
                await _repository.Update(current.ItemId, current);
            }
            else
            {
                await _repository.Add(new ListItem { ItemId = id, ItemQuantity = quantity });
            }
        }

        public async Task AddOrUpdateUserAsync(string userId, string itemId, int quantity)
        {
            UserListItem currentUser = await _repository.GetByUserId(userId);
            List<UserListItem> list = _repository.LoadRecords(userId).Result;


            if (currentUser == null)
            {
                throw new Exception("User not found !");
            }
            else if (currentUser != null)
            {
                var item = list.Find(x => x.ItemId == itemId);

                if (item != null)
                {
                    item.ItemQuantity += quantity;
                    await _repository.UpdateUser(item.ItemId, item);

                }
                else
                {
                    await _repository.AddUserList(new UserListItem { UserId = userId, ItemId = itemId, ItemQuantity = quantity });
                }

                //elektronik listesinin Id si
                //48f0322b-6201-44c1-bf3b-3a2235559337

                //if (currentUser.ItemId == itemId)
                //{
                //    currentUser.ItemQuantity += quantity;
                //    await _repository.UpdateUser(currentUser.UserId, currentUser);
                //}
                //else
                //{
                //    await _repository.AddUserList(new UserListItem { UserId = userId, ItemId = itemId, ItemQuantity = quantity });
                //}
            }


        }
    }
}
