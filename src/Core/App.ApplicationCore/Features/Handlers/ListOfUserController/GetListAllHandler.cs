using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Queries.ListOfUserController;
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
    public class GetListAllHandler : IRequestHandler<GetListAllQuery, ServiceResponse<List<ListOfUser>>>
    {
        private readonly IListOfUserRepository _listOfUserRepository;

        public GetListAllHandler(IListOfUserRepository listOfUserRepository)
        {
            _listOfUserRepository = listOfUserRepository;
        }
        public async Task<ServiceResponse<List<ListOfUser>>> Handle(GetListAllQuery request, CancellationToken cancellationToken)
        {
            var lists = await _listOfUserRepository.GetAllAsync();
            return new ServiceResponse<List<ListOfUser>>(lists);
        }
    }
}
