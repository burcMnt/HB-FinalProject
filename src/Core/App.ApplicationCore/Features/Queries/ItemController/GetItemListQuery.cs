using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System.Collections.Generic;

namespace Application.ApplicationCore.Features.Queries.ItemController
{
    public record GetItemListQuery() :IRequest<ServiceResponse<List<Item>>>;
    
}
