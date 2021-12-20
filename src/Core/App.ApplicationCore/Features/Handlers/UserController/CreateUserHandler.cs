using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Commands.UserController;
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
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ServiceResponse<User>>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ServiceResponse<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.Name,
                Surname = request.Surname,
                Gsm = request.Gsm,
                Email = request.Email,
                Address = request.Address
            };

            await _userRepository.AddAsync(user);
            return new ServiceResponse<User>(user);
        }
    }
}
