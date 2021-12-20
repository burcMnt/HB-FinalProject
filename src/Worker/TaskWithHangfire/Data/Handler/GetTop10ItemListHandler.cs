using Application.ApplicationCore.Entities.MongoDbEntities;
using Application.ApplicationCore.Interfaces.MongoDbRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TaskWithHangfire.Data.Query;

namespace TaskWithHangfire.Data.Handler
{
    public class GetTop10ItemListHandler : IRequestHandler<GetTop10ItemListQuery, List<ListItem>>
    {
        private readonly IListItemsMongoRepository _mongoRepository;

        public GetTop10ItemListHandler(IListItemsMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        public async Task<List<ListItem>> Handle(GetTop10ItemListQuery request, CancellationToken cancellationToken)
        {
            var firstTenItems = await _mongoRepository.GetFirstTen();
            
            return new List<ListItem>(firstTenItems);
        }
    }
}
