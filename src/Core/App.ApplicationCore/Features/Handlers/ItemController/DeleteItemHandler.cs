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
    public class DeleteItemHandler : IRequestHandler<DeleteItemCommand>
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItemHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var Item = await _itemRepository.GetByIdAsync(request.id);
            if (Item.Equals(null))
            {
                throw new Exception("Item was not found !");
            }

            await _itemRepository.DeleteAsync(Item);
            return Unit.Value;
        }
    }
}
