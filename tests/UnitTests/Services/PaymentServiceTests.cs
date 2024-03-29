using Moq;
using Xunit;
using Application.Interfaces;
using Application.UseCases;
using Domain.Request;
using Domain.Response;
using Domain.Base;
using Domain.Entities;

namespace UnitTests.Application.UseCases
{
    public class PaymentServiceTests
    {
        private readonly Mock<IMessageQueueService> _messageQueueServiceMock;
        private readonly PaymentService _paymentService;

        public PaymentServiceTests()
        {
            _messageQueueServiceMock = new Mock<IMessageQueueService>();
            _paymentService = new PaymentService(_messageQueueServiceMock.Object);
        }

        [Fact]
        public async Task ProcessPayment_ShouldReturnPendingPaymentResponseAsync()
        {
            // Arrange
            var paymentRequest = new PaymentRequest { OrderId = Guid.NewGuid(), PaymentId = Guid.NewGuid() };

            // Act
            var result = await _paymentService.RequestPayment(paymentRequest);

            // Assert
            Assert.Equal(paymentRequest.OrderId, result.OrderId);
            Assert.Equal(paymentRequest.PaymentId, result.Id);
            Assert.Equal(PaymentStatus.Pending, result.Status);
            _messageQueueServiceMock.Verify(m => m.PublishMessage(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetPayment_ShouldReturnApprovedPaymentResponse()
        {
            // Arrange
            var paymentId = Guid.NewGuid();

            // Act
            var result = _paymentService.GetPayment(paymentId);

            // Assert
            Assert.Equal(paymentId, result.Id);
            Assert.Equal(PaymentStatus.Approved, result.Status);
        }
    }
}