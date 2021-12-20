using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Entities.MongoDbEntities;
using Application.ApplicationCore.Interfaces.MongoDbRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Infrastructure.Repositories.MongoDb
{
    public class ListItemsMongoRepository : MongoRepository,IListItemsMongoRepository
    {
        public ListItemsMongoRepository(IMongoDbContext dbContext) :base(dbContext)
        {

        }
        //private readonly ApplicationDbContext _dbContext;

        //public ListItemsRepository(ApplicationDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        //public async Task<ListOfUser> AddListWithDetails(ListOfUser entity, List<ListOfUserItem> ListOfUserItems)
        //{
        //    foreach (var itemValue in ListOfUserItems)
        //    {
        //        var oneItem = await _dbContext.Items.FindAsync(itemValue.ItemId);
        //        if (oneItem == null)
        //        {
        //            oneItem.Id = itemValue.Id;
        //            oneItem.Name = itemValue.Item.Name;
        //            oneItem.Description = itemValue.Item.Description;
        //            oneItem.CategoryName = itemValue.Item.CategoryName;
        //            oneItem.Brand = itemValue.Item.Brand;
        //            oneItem.Price = itemValue.Item.Price;
        //            oneItem.DiscountedPrice = itemValue.Item.DiscountedPrice;
        //        }
        //        entity.Items.Add(itemValue);
        //    }
        //    await _dbContext.ListOfUsers.AddAsync(entity);
        //    await _dbContext.SaveChangesAsync();
        //    return entity;
        //    //throw new NotImplementedException();
        //}
    }
}
