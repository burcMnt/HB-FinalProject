using Application.ApplicationCore.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Commands.ListOfUserController
{
   public record UpdateListCommand(Guid Id,ListOfUser List) :IRequest;
   
}
