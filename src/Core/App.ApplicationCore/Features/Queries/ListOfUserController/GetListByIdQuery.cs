using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Queries.ListOfUserController
{
    public record GetListByIdQuery(Guid Id) : IRequest<ServiceResponse<ListOfUser>>;
}
