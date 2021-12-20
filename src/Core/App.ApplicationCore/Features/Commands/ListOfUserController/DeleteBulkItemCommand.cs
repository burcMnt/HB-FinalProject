using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Commands.ListOfUserController
{
   public record DeleteBulkItemCommand(Guid Id, Guid[] ItemsId) : IRequest;
    
}
