using Application.ApplicationCore.Entities.MongoDbEntities;
using Application.ApplicationCore.Interfaces.MongoDbRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TaskWithHangfire.Data.Query
{
    public class GetUserTopTenItemsHandler : IRequestHandler<GetUserTopTenItemsQuery, List<UserListItem>>
    {
        private readonly IListItemsMongoRepository _mongoRepository;

        public GetUserTopTenItemsHandler(IListItemsMongoRepository mongoRepository)
        {
            _mongoRepository = mongoRepository;
        }
        public async Task<List<UserListItem>> Handle(GetUserTopTenItemsQuery request, CancellationToken cancellationToken)
        {
            var userItems= await _mongoRepository.GetUserFirstTen();

            return new List<UserListItem>(userItems);
        }
    }
}
