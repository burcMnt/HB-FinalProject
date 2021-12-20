using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Queries.ItemController;
using Application.ApplicationCore.Interfaces.Repository;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.ItemController
{
    public class GetItemListHandler : IRequestHandler<GetItemListQuery, ServiceResponse<List<Item>>>
    {
        private readonly IItemRepository _itemRepository;

        public GetItemListHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ServiceResponse<List<Item>>> Handle(GetItemListQuery request, CancellationToken cancellationToken)
        {
            var items = await _itemRepository.GetAllAsync();
            return new ServiceResponse<List<Item>>(items);
        }
    }
}
