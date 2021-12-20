using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Commands.ItemController;
using Application.ApplicationCore.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.ItemController
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand>
    {
        private readonly IItemRepository _itemRepository;

        public UpdateItemHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var item = await _itemRepository.GetByIdAsync(request.id);
            if (item.Equals(null))
            {
                throw new Exception("Item was not found !");
            }
            item.Name = request.item.Name;
            item.CategoryName = request.item.CategoryName;
            item.Description = request.item.Description;
            item.Brand = request.item.Brand;
            item.Price = request.item.Price;
            item.DiscountedPrice = request.item.DiscountedPrice;
            await _itemRepository.UpdateAsync(item);
            return Unit.Value;
        }
    }
}
