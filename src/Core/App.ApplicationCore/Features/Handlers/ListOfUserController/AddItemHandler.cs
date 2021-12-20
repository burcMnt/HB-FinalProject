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
    public class AddItemHandler : IRequestHandler<AddItemCommand, ListOfUser>
    {
        private readonly IListOfUserRepository _listOfUserRepository;
        private readonly IListedItemRepository _listedItemRepository;

        public AddItemHandler(IListOfUserRepository listOfUserRepository, IListedItemRepository listedItemRepository)
        {
            _listOfUserRepository = listOfUserRepository;
            _listedItemRepository = listedItemRepository;
        }
        public async Task<ListOfUser> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            var userList = await _listOfUserRepository.GetByIdAsync(request.Id);
            if (userList == null)
            {
                throw new Exception("List was not found!");
            }

            if (userList.Items == null)
            {
                userList.Items = new List<ListOfUserItem>();
                userList.Items.Add(new ListOfUserItem { ItemId = request.Item.Id, ItemQuantity = request.Item.Quantity });
            }
            else
            {
                var deneme = userList.Items.FirstOrDefault(x => x.ItemId == request.Item.Id);

                if (deneme != null)
                {
                    deneme.ItemQuantity += request.Item.Quantity;
                }
                else
                {
                    var Luser = new ListOfUserItem() { ItemId = request.Item.Id, ItemQuantity = request.Item.Quantity };
                    userList.Items.Add(Luser);
                }

                await _listOfUserRepository.UpdateAsync(userList);
                //await _listOfUserRepository.AddAsync(userList);
            }

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
