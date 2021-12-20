using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Commands.MongoDb;
using Application.ApplicationCore.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.MongoDb
{
    public class CreateListItemHandler : IRequestHandler<CreateListItemCommand, ListOfUser>
    {
        private readonly IListOfUserRepository _listOfUserRepository;

        public CreateListItemHandler(IListOfUserRepository listOfUserRepository)
        {
            _listOfUserRepository = listOfUserRepository;
        }
        public Task<ListOfUser> Handle(CreateListItemCommand request, CancellationToken cancellationToken)
        {
            var listOfUser = new ListOfUser
            {
                ListName = request.ListName,
                Description = request.Description,
                UserId = request.UserId,
            };

            if (listOfUser == null)
            {
                throw new Exception("Entity can not be null");

            }
            return Task.FromResult(listOfUser);
        }
    }
} 