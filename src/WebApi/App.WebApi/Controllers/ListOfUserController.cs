using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Commands.ListOfUserController;
using Application.ApplicationCore.Features.Queries.ListOfUserController;
using Application.ApplicationCore.Wrappers;
using Application.WebApi.Dtos.ListDtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/v1/list")]
    [ApiController]
    //[Authorize]
    public class ListOfUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListOfUserController(IMediator mediator)
        {
            _mediator = mediator;
           
        }

        // GET: api/v1/list
        [HttpGet]
        public async Task<ServiceResponse<List<ListOfUser>>> GetAll()
        {
            return await _mediator.Send(new GetListAllQuery());
        }

        // GET api/v1/list/5
        [HttpGet("{id}")]
        public async Task<ServiceResponse<ListOfUser>> GetById(Guid id)
        {
            return await _mediator.Send(new GetListByIdQuery(id));
        }

        // POST api/v1/list
        [HttpPost]
        public async Task<ServiceResponse<ListOfUser>> Add([FromBody] CreateListDto dto)
        {
            var model = new CreateListCommand(dto.ListName, dto.Description, dto.UserId, dto.Items);
            return await _mediator.Send(model);
        }

        // POST api/v1/list
        [HttpPost]
        [Route("addItem")]
        public async Task<ListOfUser> AddItem(Guid id,[FromBody]AddItemDto entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var item = new Item()
            {
                Id = entity.Id,
                Quantity = entity.Quantity
            };
            var resp = await _mediator.Send(new AddItemCommand(id,item));
           
            return resp;
        }

        // POST api/v1/list
        [HttpPost]
        [Route("addBulkItems")]
        public async Task<ActionResult<Unit>> AddBulkItem(Guid id, [FromBody] Item[] items)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentNullException(nameof(items));
            }

            await _mediator.Send(new AddBulkItemCommand(id, items));

            return Ok();
        }

        // PUT api/v1/list/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateListDto dto)
        {
            if (id!=dto.Id)
            {
                return BadRequest("Id information is not confirmed!");
            }

            var list = new ListOfUser()
            {
                Id = dto.Id,
                ListName = dto.ListName,
                Description = dto.Description,
                UserId = dto.UserId,
                //Items = dto.Items
            };
            await _mediator.Send(new UpdateListCommand(id, list));
            return Ok();
        }

        // DELETE api/v1/list/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            
            await _mediator.Send(new DeleteListCommand(id));
            return NoContent();
        }

        // DELETE api/v1/list/1
        [HttpDelete]
        [Route("deleteItem")]
        public async Task<ActionResult<Unit>> DeleteItem(DeleteListDto dto)
        {
            await _mediator.Send(new DeleteItemFromListCommand(dto.Id,dto.ItemId));
            return NoContent();
        }

        // DELETE api/v1/list/1
        [HttpDelete]
        [Route("deleteBulkItems")]
        public async Task<ActionResult<Unit>> DeleteBulkItem(DeleteBulkItemDto dto)
        {
            await _mediator.Send(new DeleteBulkItemCommand(dto.Id, dto.ItemsId));
            return NoContent();
        }

    }
}
