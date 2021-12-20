using Application.ApplicationCore.Entities.MongoDbEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskWithHangfire.Data
{
    public interface IItemListFirstTen
    {
        Task<List<ListItem>> GetAllData();
        Task<List<UserListItem>> GetUserAllData();
        

    }
}
