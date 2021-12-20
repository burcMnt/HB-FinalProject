using Application.ApplicationCore.Entities.MongoDbEntities;
using MediatR;
using System.Collections.Generic;

namespace TaskWithHangfire.Data.Query
{
    public record GetUserTopTenItemsQuery() : IRequest<List<UserListItem>>;


}
