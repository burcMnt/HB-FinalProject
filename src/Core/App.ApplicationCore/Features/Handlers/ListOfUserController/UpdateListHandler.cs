using Application.ApplicationCore.Features.Commands.ListOfUserController;
using Application.ApplicationCore.Features.Commands.UserController;
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
    public class UpdateListHandler : IRequestHandler<UpdateListCommand>
    {
        private readonly IListOfUserRepository _listOfUserRepository;
        private readonly IListedItemRepository _listedItemRepository;

        public UpdateListHandler(IListOfUserRepository listOfUserRepository, IListedItemRepository listedItemRepository)
        {
            _listOfUserRepository = listOfUserRepository;
            _listedItemRepository = listedItemRepository;
        }

        
        public async Task<Unit> Handle(UpdateListCommand request, CancellationToken cancellationToken)
        {
            var list = await _listOfUserRepository.GetByIdAsync(request.Id);
            if (list.Equals(null))
            {
                throw new Exception("List of user was not found !");
            }
            list.ListName = request.List.ListName;
            list.Description = request.List.Description;
            list.UserId = request.List.UserId;

            //list.Items = request.List.Items;
            await _listOfUserRepository.UpdateAsync(list);

            //for MongoDb
            foreach (var item in list.Items)
            {
                await _listedItemRepository.AddOrUpdateUserAsync(list.UserId.ToString(), item.ItemId.ToString(), item.ItemQuantity);
            }
            return Unit.Value;
        }
    }
}
