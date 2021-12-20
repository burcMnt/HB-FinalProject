using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Commands.ItemController;
using Application.ApplicationCore.Interfaces.Repository;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.ItemController
{
    public class CreateItemHandler : IRequestHandler<CreateItemCommand, ServiceResponse<Item>>
    {
        private readonly IItemRepository _itemRepository;

        public CreateItemHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ServiceResponse<Item>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
           var item = new Item() { Name = request.Name, CategoryName = request.CategoryName, Brand = request.Brand,Description = request.Description, Price = request.Price,DiscountedPrice=CalculateDiscount(request.Price) };
            await _itemRepository.AddAsync(item);
            return new ServiceResponse<Item>(item);

        }
        private decimal CalculateDiscount(decimal price)
        {
            decimal result = 0;
            if (price >= 0m)
            {
                decimal discount = (price * 15) / 100;
                result = price - discount;
            }
            return result;
        }
    }
}
