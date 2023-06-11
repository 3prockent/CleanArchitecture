using CA.Application.Interfaces;
using CA.Application.Orders.Commands;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace Tests

{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IDbContext> _dbContextMock;

        public CreateOrderCommandHandlerTests()
        {
            _dbContextMock = new();
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_WhenNumberAlreadyExist()
        {
            //Arrange
            _dbContextMock.Setup(x => x.Orders)
                .ReturnsDbSet(TestDataHelper.GetFakeOrderList());
            var command = new CreateOrderCommand
            {
                Number = "2",
                ContactName = "Vlad",
                Comment = "Tomorrow delivery",
                Amount = 100.00M
            };

            var handler = new CreateOrderCommandHandler(_dbContextMock.Object);
            //Act

            Result<Guid> result = await handler.Handle(command, default);

            //Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Code.Should().Be(DomainErrors.Order.AlreadyExist(default).Code);
        }

        [Fact]
        public async Task Handle_Should_ReturnSuccess_WhenNumberIsUnique()
        {
            //Arrange
            _dbContextMock.Setup(x => x.Orders)
                .ReturnsDbSet(TestDataHelper.GetFakeOrderList());
            var command = new CreateOrderCommand
            {
                Number = "4",
                ContactName = "Vlad",
                Comment = "Tomorrow delivery",
                Amount = 100.00M
            };

            var handler = new CreateOrderCommandHandler(_dbContextMock.Object);
            //Act

            Result<Guid> result = await handler.Handle(command, default);

            //Assert
            result.IsSuccess.Should().BeTrue();
            result.Value.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Handle_Should_CallOnceAddToDb_WhenNumberIsUnique()
        {
            //Arrange
            _dbContextMock.Setup(x => x.Orders)
                .ReturnsDbSet(TestDataHelper.GetFakeOrderList());
            var command = new CreateOrderCommand
            {
                Number = "4",
                ContactName = "Vlad",
                Comment = "Tomorrow delivery",
                Amount = 100.00M
            };

            var handler = new CreateOrderCommandHandler(_dbContextMock.Object);
            //Act

            Result<Guid> result = await handler.Handle(command, default);

            //Assert
            _dbContextMock.Verify(
                x => x.Orders.Add(It.Is<Order>(o => o.Id == result.Value)),
                Times.Once);
        }


    }



    internal static class TestDataHelper
    {
        public static List<Order> GetFakeOrderList()
        {
            return new List<Order>()
            {
                new Order
                {
                        Number = "2",
                        ContactName = "Vlad",
                        Comment = "123 delivery",
                        Amount = 100.00M
                },
                new Order
                {
                    Number = "3",
                    ContactName = "Alex",
                    Comment = "222 delivery",
                    Amount = 200.00M
                }
            };
        }
    }

}