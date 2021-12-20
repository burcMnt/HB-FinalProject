using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Commands.ItemController;
using Application.ApplicationCore.Features.Queries.ItemController;
using Application.ApplicationCore.Wrappers;
using Application.WebApi.Dtos.ItemDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.WebApi.Controllers
{
    [Route("api/v1/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ServiceResponse<List<Item>>> GetAll()
        {
            return await _mediator.Send(new GetItemListQuery());
        }

        [HttpGet("{id}")]
        public async Task<ServiceResponse<Item>> GetById(Guid id)
        {
            return await _mediator.Send(new GetItemByIdQuery(id));
        }

        [HttpPost]
        public async Task<ServiceResponse<Item>> Add([FromBody] CreateItemDto dto)
        {
            var model = new CreateItemCommand(dto.Name, dto.Description, dto.CategoryName, dto.Brand, dto.Price, dto.DiscountedPrice);
            return await _mediator.Send(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var dto = new DeleteItemDto()
            {
                Id = id
            };
            await _mediator.Send(new DeleteItemCommand(dto.Id));
            return NoContent();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateItemDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest("Id information is not confirmed");
            }

            var item = new Item()
            {
                Id = dto.Id,
                Name = dto.Name,
                CategoryName = dto.CategoryName,
                Description = dto.Description,
                Brand = dto.Brand,
                Price = dto.Price,
                DiscountedPrice = dto.DiscountedPrice
            };
           await _mediator.Send(new UpdateItemCommand(id,item));
          return  Ok();
        }
    }
}
