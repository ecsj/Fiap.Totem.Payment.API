using Domain.Request;
using Domain.Response;

namespace Application.Interfaces;

public interface IPaymentService
{
    Task<PaymentResponse> RequestPayment(PaymentRequest order);
    PaymentResponse GetPayment(Guid id);
    bool ProcessPayment(PaymentWebook request);
}
