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
    public class AddBulkItemHandler : IRequestHandler<AddBulkItemCommand, ListOfUser>
    {
        private readonly IListOfUserRepository _listOfUserRepository;
        private readonly IListOfUserItemRepository _listOfUserItemRepository;
        private readonly IListedItemRepository _listedItemRepository;

        public AddBulkItemHandler(IListOfUserRepository listOfUserRepository, IListOfUserItemRepository listOfUserItemRepository,
            IListedItemRepository listedItemRepository)
        {
            _listOfUserRepository = listOfUserRepository;
            _listOfUserItemRepository = listOfUserItemRepository;
            _listedItemRepository = listedItemRepository;
        }

        public async Task<ListOfUser> Handle(AddBulkItemCommand request, CancellationToken cancellationToken)
        {
            var userList = await _listOfUserRepository.GetByIdAsync(request.Id);
            if (userList == null)
            {
                throw new Exception("List was not found!");
            }

            if (userList.Items == null)
            {
                userList.Items = new List<ListOfUserItem>();
                for (int i = 0; i < request.Items.Length; i++)
                {
                    userList.Items.Add(
                        new ListOfUserItem
                        {
                            ItemId = request.Items[i].Id,
                            ItemQuantity = request.Items[i].Quantity
                        });
                }
            }
            else
            {

                for (int i = 0; i < request.Items.Length; i++)
                {
                    var liste = userList.Items.FirstOrDefault(x => x.ItemId == request.Items[i].Id);
                    if (liste != null)
                    {
                        userList.ItemQuantity += request.Items[i].Quantity;
                    }
                    else
                    {
                        var newItem = new ListOfUserItem
                        {
                            ItemId = request.Items[i].Id,
                            ItemQuantity = request.Items[i].Quantity
                        };
                        userList.Items.Add(newItem);
                    }
                }

            }

            await _listOfUserItemRepository.AddListAsync(userList.Items);
            //await _listOfUserRepository.AddListAsync(userList);
            await _listOfUserRepository.UpdateAsync(userList);

            //for MongoDb
            foreach (var item in userList.Items)
            {

                await _listedItemRepository.AddOrUpdateUserAsync(userList.UserId.ToString(), item.ItemId.ToString(), item.ItemQuantity);
                await _listedItemRepository.AddOrUpdateAsync(item.ItemId.ToString(), item.ItemQuantity);
            }
            return userList;
        }
    }
}
