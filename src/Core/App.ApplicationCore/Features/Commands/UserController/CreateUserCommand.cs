using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Commands.UserController
{
    public record CreateUserCommand(string Name, string Surname, string Email, string Gsm, string Address) : IRequest<ServiceResponse<User>>;

}
