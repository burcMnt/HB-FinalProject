using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;

namespace Application.ApplicationCore.Features.Queries.ItemController
{
    public record GetItemByIdQuery(Guid Id) :IRequest<ServiceResponse<Item>>;
    
}
