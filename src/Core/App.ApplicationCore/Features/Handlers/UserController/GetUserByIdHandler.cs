using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Queries.UserController;
using Application.ApplicationCore.Interfaces.Repository;
using Application.ApplicationCore.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ApplicationCore.Features.Handlers.UserController
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ServiceResponse<User>>
    {
        private readonly IMediator _mediator;

        public GetUserByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ServiceResponse<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetUserListQuery());
            var output = result.Value.FirstOrDefault(x => x.Id.Equals(request.Id));
            return new ServiceResponse<User>(output);
        }
    }
}
