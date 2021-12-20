using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Commands.UserController;
using Application.ApplicationCore.Features.Queries.UserController;
using Application.ApplicationCore.Wrappers;
using Application.WebApi.Dtos.UserDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/v1/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/v1/user
        [HttpGet]
        public async Task<ServiceResponse<List<User>>> GetAll()
        {
            return await _mediator.Send(new GetUserListQuery());
        }

        // GET api/v1/user/5
        [HttpGet("{id}")]
        public async Task<ServiceResponse<User>> GetById(Guid id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        // POST api/v1/user
        [HttpPost]
        public async Task<ServiceResponse<User>> Add([FromBody] CreateUserDto dto)
        {
            var model = new CreateUserCommand(dto.Name, dto.Surname, dto.Email, dto.Gsm, dto.Address);
            return await _mediator.Send(model);

        }

        // PUT api/v1/user/2
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Id information is not confirmed!");
            }
            var user = new User()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Gsm = dto.Gsm,
                Email = dto.Email,
                Address = dto.Address
            };
            await _mediator.Send(new UpdateUserCommand(id, user));
            return Ok();
        }

        // DELETE api/v1/user/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var dto = new DeleteUserDto()
            {
                Id = id
            };
            await _mediator.Send(new DeleteUserCommand(dto.Id));
            return NoContent();
        }
    }
}
