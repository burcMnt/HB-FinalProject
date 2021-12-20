using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Commands.ListOfUserController;
using Application.ApplicationCore.Interfaces.Repository;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.ListOfUserController
{
    public class CreateListHandler : IRequestHandler<CreateListCommand, ServiceResponse<ListOfUser>>
    {
        private readonly IListOfUserRepository _listOfUserRepository;
        private readonly IListedItemRepository _listedItemRepository;

        public CreateListHandler(IListOfUserRepository listOfUserRepository, IListedItemRepository listedItemRepository)
        {
            _listOfUserRepository = listOfUserRepository;
            _listedItemRepository = listedItemRepository;
        }
        public async Task<ServiceResponse<ListOfUser>> Handle(CreateListCommand request, CancellationToken cancellationToken)
        {
            var list = new ListOfUser()
            {
                ListName = request.ListName,
                Description = request.Description,
                UserId = request.UserId,
                Items = new List<ListOfUserItem>(request.Items.Select(x => new ListOfUserItem() { ItemId = x.Id, ItemQuantity=x.Quantity }).ToList())

            };
            await _listOfUserRepository.AddAsync(list);

            //for MongoDb
            foreach (var item in list.Items)
            {
                await _listedItemRepository.AddOrUpdateAsync(item.ItemId.ToString(), item.ItemQuantity);
            }

            return new ServiceResponse<ListOfUser>(list);
        }
    }
}
