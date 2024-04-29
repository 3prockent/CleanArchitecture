using Microsoft.AspNetCore.Mvc;

namespace Tests
{
    public class OrderControllerTests
    {
        private readonly Mock<IDbContext> _dbContextMock;
        private readonly Mock<IMediator> _mediatorMock;

        public OrderControllerTests()
        {
            _dbContextMock = new();
            _mediatorMock = new();
        }

        //[Fact]
        //public async Task Handle_Should_ReturnSuccess_WhenRequestSuccess()
        //{
        //    //Arrange

        //    var controller = new OrderController(_mediatorMock.Object);

        //    _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllOrdersQuery>()
        //        , It.IsAny<CancellationToken>())).ReturnsAsync(TestDataHelper.GetFakeOrderList());

        //    //Act

        //    IActionResult result = await controller.GetAll(default);

        //    //Assert
        //    result.Should().BeOfType<OkObjectResult>();
        //}
    }
    
}
