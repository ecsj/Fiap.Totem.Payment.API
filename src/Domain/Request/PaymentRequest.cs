
using Domain.Entities;

namespace Domain.Request;

public class PaymentRequest
{
    public Guid OrderId { get; set; }
    public Guid PaymentId { get; set; }
    public decimal Amount { get; set; }
    public string? Currency { get; set; }
    public PaymentStatus Status { get; set; }
    public DateTime PaymentDate { get; set; }
}

public class PaymentWebook
{
    public Guid PaymentId { get; set; }
    public PaymentStatus Status { get; set; }
    public Guid OrderId { get; set; }
}