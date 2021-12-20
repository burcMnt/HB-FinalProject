using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Queries.UserController;
using Application.ApplicationCore.Interfaces.Repository;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.UserController
{
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, ServiceResponse<List<User>>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserListHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ServiceResponse<List<User>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return new ServiceResponse<List<User>>(users);
        }
    }
}
