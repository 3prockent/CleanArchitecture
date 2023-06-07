using AC.WebAPI.Controllers;
using CA.Application.Interfaces;
using CA.Application.Orders.Commands;
using CA.Application.Orders.Queries;
using CA.Domain.Entities;
using CA.Domain.Errors;
using CA.Domain.Shared;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Fact]
        public async Task Handle_Should_ReturnSuccess_WhenRequestSuccess()
        {
            //Arrange

            var controller = new OrderController(_mediatorMock.Object);

            _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllOrdersQuery>()
                , It.IsAny<CancellationToken>())).ReturnsAsync(TestDataHelper.GetFakeOrderList());

            //Act

            IActionResult result = await controller.GetAll();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
        }
    }
    
}
