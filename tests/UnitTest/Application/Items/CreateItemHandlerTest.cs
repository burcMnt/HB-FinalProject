using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Commands.ItemController;
using Application.ApplicationCore.Features.Handlers.ItemController;
using Application.ApplicationCore.Interfaces.Repository;
using Application.ApplicationCore.Wrappers;
using Moq;
using Shouldly;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Items
{
    public class CreateItemHandlerTest
    {
        private readonly Mock<IItemRepository> _mockItemRepository;
        private readonly Mock<Item> _mockItem;
        public CreateItemHandlerTest()
        {
            _mockItemRepository = new Mock<IItemRepository>();
            _mockItem=new Mock<Item>();
        }

        List<Item> itemList = new List<Item>();

        [Fact]
        public async void HandleShouldReturnCreatedItem()
        {
            _mockItemRepository.Setup(repo => repo.AddAsync(It.IsAny<Item>()))
                .ReturnsAsync(new Item());
            CreateItemCommand request = new CreateItemCommand("a", "b", "c", "a", 100.00m, 95.00m);

            var handler = new CreateItemHandler(_mockItemRepository.Object);

            Task< ServiceResponse<Item>> result = handler.Handle(request, CancellationToken.None) ;
            itemList = await _mockItemRepository.Object.GetAllAsync();

            result.ShouldNotBeNull();
            itemList.Count.ShouldBe(1);
        }
    }
}
