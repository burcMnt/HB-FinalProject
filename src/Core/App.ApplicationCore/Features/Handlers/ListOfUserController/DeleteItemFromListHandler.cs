using Application.ApplicationCore.Features.Commands.ItemController;
using Application.ApplicationCore.Features.Commands.ListOfUserController;
using Application.ApplicationCore.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.ListOfUserController
{
    public class DeleteItemFromListHandler : IRequestHandler<DeleteItemFromListCommand>
    {
        private readonly IListOfUserRepository _listOfUserRepository;
        private readonly IItemRepository _itemRepository;

        public DeleteItemFromListHandler(IListOfUserRepository listOfUserRepository, IItemRepository itemRepository)
        {
            _listOfUserRepository = listOfUserRepository;
            _itemRepository = itemRepository;
        }
        public async Task<Unit> Handle(DeleteItemFromListCommand request, CancellationToken cancellationToken)
        {
            var userList = await _listOfUserRepository.GetByIdAsync(request.Id);
            if (userList == null)
            {
                throw new Exception("List was not found!");
            }
            var item = userList.Items.FirstOrDefault(x => x.ItemId == request.ItemId);
            if (item!=null)
            {
                foreach (var w in userList.Items)
                {
                    if (item.ItemId==w.ItemId)
                    {
                        userList.Items.Remove(w);
                    }
                }
            }
            else
            {
                throw new Exception("Item was not found! Please try again.");
            }
            await _listOfUserRepository.UpdateAsync(userList);
            return Unit.Value;
        }
    }
}
