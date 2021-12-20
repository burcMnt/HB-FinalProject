using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Queries.UserController
{
    public record GetUserByIdQuery(Guid Id):IRequest<ServiceResponse<User>>;
   
}
