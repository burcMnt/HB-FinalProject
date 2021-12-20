using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Wrappers;
using MediatR;

namespace Application.ApplicationCore.Features.Commands.ItemController
{
    public record CreateItemCommand(string Name,string Description,string CategoryName,string Brand,decimal Price,decimal DiscountedPrice) :IRequest<ServiceResponse<Item>>;
    
}
