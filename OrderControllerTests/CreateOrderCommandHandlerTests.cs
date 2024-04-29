using FluentAssertions;
using Microsoft.EntityFrameworkCore;


namespace Tests

{
    public class CreateOrderCommandHandlerTests
    {
        private readonly Mock<IDbContext> _dbContextMock;

        public CreateOrderCommandHandlerTests()
        {
            _dbContextMock = new();
        }

        //[Fact]
        //public async Task Handle_Should_ReturnFailure_WhenNumberAlreadyExist()
        //{
        //    //Arrange
        //    _dbContextMock.Setup(x => x.Orders)
        //        .ReturnsDbSet(TestDataHelper.GetFakeOrderList());
        //    var command = new CreateOrderCommand
        //    {
        //        Number = "2",
        //        ContactName = "Vlad",
        //        Comment = "Tomorrow delivery",
        //        Amount = 100.00M
        //    };

        //    var handler = new CreateOrderCommandHandler(_dbContextMock.Object);
        //    //Act

        //    Result<Guid> result = await handler.Handle(command, default);

        //    //Assert
        //    result.IsFailure.Should().BeTrue();
        //    result.Error.Code.Should().Be(DomainErrors.Order.AlreadyExist(default).Code);
        //}

        //[Fact]
        //public async Task Handle_Should_ReturnSuccess_WhenNumberIsUnique()
        //{
        //    //Arrange
        //    _dbContextMock.Setup(x => x.Orders)
        //        .ReturnsDbSet(TestDataHelper.GetFakeOrderList());
        //    var command = new CreateOrderCommand
        //    {
        //        Number = "4",
        //        ContactName = "Vlad",
        //        Comment = "Tomorrow delivery",
        //        Amount = 100.00M
        //    };

        //    var handler = new CreateOrderCommandHandler(_dbContextMock.Object);
        //    //Act

        //    Result<Guid> result = await handler.Handle(command, default);

        //    //Assert
        //    result.IsSuccess.Should().BeTrue();
        //    result.Value.Should().NotBeEmpty();
        //}

        //[Fact]
        //public async Task Handle_Should_CallOnceAddToDb_WhenNumberIsUnique()
        //{
        //    //Arrange
        //    _dbContextMock.Setup(x => x.Orders)
        //        .ReturnsDbSet(TestDataHelper.GetFakeOrderList());
        //    var command = new CreateOrderCommand
        //    {
        //        Number = "4",
        //        ContactName = "Vlad",
        //        Comment = "Tomorrow delivery",
        //        Amount = 100.00M
        //    };

        //    var handler = new CreateOrderCommandHandler(_dbContextMock.Object);
        //    //Act

        //    Result<Guid> result = await handler.Handle(command, default);

        //    //Assert
        //    _dbContextMock.Verify(
        //        context => context.Orders.Add(It.Is<Order>(order => order.Id == result.Value)),
        //        Times.Once);
        //}
    }
}
