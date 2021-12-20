using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Queries.ItemController;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.ItemController
{
    public class GetItemByIdHandler : IRequestHandler<GetItemByIdQuery, ServiceResponse<Item>>
    {
        private readonly IMediator _mediator;

        public GetItemByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ServiceResponse<Item>> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetItemListQuery());
            var output = result.Value.FirstOrDefault(x => x.Id == request.Id);
            return new ServiceResponse<Item>(output);
        }
    }
}
