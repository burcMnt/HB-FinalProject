using Application.ApplicationCore.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Commands.ItemController
{
    public record UpdateItemCommand(Guid id, Item item) : IRequest;

}
