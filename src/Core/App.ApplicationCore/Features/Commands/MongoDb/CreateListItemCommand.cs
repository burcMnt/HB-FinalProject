using Application.ApplicationCore.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Commands.MongoDb
{
    public record CreateListItemCommand(string ListName, string Description, Guid UserId,int Quantity, List<ListOfUserItem> Items) : IRequest<ListOfUser>;

}