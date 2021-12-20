using Application.ApplicationCore.Features.Commands.UserController;
using Application.ApplicationCore.Interfaces.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.UserController
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user.Equals(null))
            {
                throw new Exception("User was not found!");
            }
            user.Name = request.User.Name;
            user.Surname = request.User.Surname;
            user.Gsm = request.User.Gsm;
            user.Email = request.User.Email;
            user.Address = request.User.Address;
            await _userRepository.UpdateAsync(user);
            return Unit.Value;
        }
    }
}
