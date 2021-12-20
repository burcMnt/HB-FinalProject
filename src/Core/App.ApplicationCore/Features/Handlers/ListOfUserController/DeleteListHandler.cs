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
    public class DeleteListHandler : IRequestHandler<DeleteListCommand>
    {
        private readonly IListOfUserRepository _listOfUserRepository;

        public DeleteListHandler(IListOfUserRepository listOfUserRepository)
        {
            _listOfUserRepository = listOfUserRepository;
        }
        public async Task<Unit> Handle(DeleteListCommand request, CancellationToken cancellationToken)
        {
            var list = await _listOfUserRepository.GetByIdAsync(request.Id);
            if (list.Equals(null))
            {
                throw new Exception("List of user was not found!");
            }
            await _listOfUserRepository.DeleteAsync(list);
            return Unit.Value;
        }
    }
}
