using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Queries.ListOfUserController;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.ListOfUserController
{
    public class GetListByIdHandler : IRequestHandler<GetListByIdQuery, ServiceResponse<ListOfUser>>
    {
        private readonly IMediator _mediator;

        public GetListByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<ServiceResponse<ListOfUser>> Handle(GetListByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetListAllQuery());
            var output= result.Value.FirstOrDefault(x => x.Id == request.Id);
            return new ServiceResponse<ListOfUser>(output);
        }
    }
}
