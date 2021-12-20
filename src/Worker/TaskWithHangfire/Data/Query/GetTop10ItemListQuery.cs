using Application.ApplicationCore.Entities.MongoDbEntities;
using MediatR;
using System.Collections.Generic;

namespace TaskWithHangfire.Data.Query
{
    public record GetTop10ItemListQuery :IRequest<List<ListItem>>;

}
