using Application.ApplicationCore.Entities;
using Application.ApplicationCore.Features.Handlers.ItemController;
using Application.ApplicationCore.Interfaces.Repository;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Application.Items
{
    public class DeleteItemHandlerTest
    {
        private readonly Mock<IItemRepository> _mockItemRepository;
        private readonly Mock<Item> _mockItem;
        List<Item> itemList = new List<Item>();
     
        public DeleteItemHandlerTest()
        {
            _mockItemRepository = new Mock<IItemRepository>();
            _mockItem = new Mock<Item>();
        }

        [Fact]
        public async void Handle_ShouldDeleteReturnResponseWhenGivenId()
        {
            int count=itemList.Count;
            _mockItemRepository
       .Setup(repo => repo.DeleteAsync(It.IsAny<Item>())).Callback((Guid Id) =>
            {
                var Item = itemList.FirstOrDefault(x => x.Id.Equals(Id));
                itemList.Remove(Item);
            });

            var handler = new DeleteItemHandler(_mockItemRepository.Object);
            Assert.True(count > itemList.Count);
       }
    }
}
