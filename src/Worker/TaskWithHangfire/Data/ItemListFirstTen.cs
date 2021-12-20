using Application.ApplicationCore.Entities.MongoDbEntities;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskWithHangfire.Data.Query;

namespace TaskWithHangfire.Data
{
    public class ItemListFirstTen : IItemListFirstTen
    {
        private readonly IMediator _mediator;

        public ItemListFirstTen(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<List<ListItem>> GetAllData()
        {
           return  _mediator.Send(new GetTop10ItemListQuery());
        }
        public Task<List<UserListItem>> GetUserAllData()
        {
            return _mediator.Send(new GetUserTopTenItemsQuery());
        }
    }
}

