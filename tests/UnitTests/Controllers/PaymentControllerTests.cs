using API.Controllers;
using Application.Interfaces;
using Domain.Entities;
using Domain.Request;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTests.Controllers
{
    public class PaymentControllerTests
    {
        [Fact]
        public async Task ProcessPayment_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var paymentServiceMock = new Mock<IPaymentService>();
            var controller = new PaymentController(paymentServiceMock.Object);

            var paymentRequest = new PaymentRequest
            {
                Amount = 1,
                Currency = "BRL",
                OrderId = Guid.NewGuid(),
                PaymentDate = DateTime.Now,
                PaymentId = Guid.NewGuid(),
                Status = PaymentStatus.Approved,
            };

            // Act
            var result = await controller.ProcessPayment(paymentRequest) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void ReceivePaymentStatus_ValidId_ReturnsOkResult()
        {
            // Arrange
            var paymentServiceMock = new Mock<IPaymentService>();
            var controller = new PaymentController(paymentServiceMock.Object);

            var paymentId = Guid.NewGuid();

            paymentServiceMock.Setup(service => service.GetPayment(paymentId))
                .Returns(new PaymentResponse()
                {
                    Id = paymentId,
                    QrCode = "4c0d190f-993e-4364-bfb3-739ac58cb28d",
                    Status = PaymentStatus.Approved
                });

            // Act
            var result = controller.ReceivePaymentStatus(paymentId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
