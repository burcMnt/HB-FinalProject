using Application.ApplicationCore.Entities;
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
    public class DeleteBulkItemHandler : IRequestHandler<DeleteBulkItemCommand>
    {
        private readonly IListOfUserRepository _listOfUserRepository;
        private readonly IListOfUserItemRepository _listOfUserItemRepository;

        public DeleteBulkItemHandler(IListOfUserRepository listOfUserRepository, IListOfUserItemRepository listOfUserItemRepository)
        {
            _listOfUserRepository = listOfUserRepository;
            _listOfUserItemRepository = listOfUserItemRepository;
        }
        public async Task<Unit> Handle(DeleteBulkItemCommand request, CancellationToken cancellationToken)
        {
            var userList = await _listOfUserRepository.GetByIdAsync(request.Id);
            if (userList == null)
            {
                throw new Exception("List was not found!");
            }

            var listUser = new List<ListOfUserItem>();

            if (userList.Items != null)
            {
                for (int i = 0; i < request.ItemsId.Length; i++)
                {
                    var lister = userList.Items.Find(x => x.ItemId == request.ItemsId[i]);
                    if (lister != null)
                    {
                        listUser.Add(lister);
                        userList.Items.Remove(lister);
                    }
                }
            }
            else
            {
                throw new Exception("Item was not found! Please try again.");

            }
            await _listOfUserRepository.UpdateAsync(userList);
            await _listOfUserItemRepository.DeleteListAsync(listUser);
            return Unit.Value;
        }
    }
}
