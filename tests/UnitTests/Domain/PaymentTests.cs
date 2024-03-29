using Domain.Entities;
using Xunit;

namespace UnitTests;
 public class PaymentTests
{
    [Fact]
    public void NewPayment_AmountConstructor_ShouldSetProperties()
    {
        // Arrange
        decimal amount = 100.50m;

        // Act
        var payment = new Payment(amount);
        payment.Id = 1;

        // Assert
        Assert.Equal(amount, payment.Amount);
        Assert.Equal("BRL", payment.Currency);
        Assert.Equal(PaymentStatus.Pending, payment.Status);
        Assert.NotEqual(default(DateTime), payment.PaymentDate);
        Assert.Equal(0, payment.OrderId);
        Assert.Null(payment.QrCode);
        Assert.Equal(1, payment.Id);
    }

    [Fact]
    public void ChangeStatus_ShouldUpdateStatus()
    {
        // Arrange
        var payment = new Payment();
        var newStatus = PaymentStatus.Refunded;

        // Act
        payment.ChangeStatus(newStatus);

        // Assert
        Assert.Equal(newStatus, payment.Status);
    }

    [Fact]
    public void ChangeQrCode_ShouldUpdateQrCode()
    {
        // Arrange
        var payment = new Payment();
        var newQrCode = "ABC123";

        // Act
        payment.ChangeQrCode(newQrCode);

        // Assert
        Assert.Equal(newQrCode, payment.QrCode);
    }
}