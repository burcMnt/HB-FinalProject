using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Commands.ListOfUserController
{
    public record CreateListCommand(string ListName, string Description, Guid UserId, List<Item> Items) : IRequest<ServiceResponse<ListOfUser>>;

}
