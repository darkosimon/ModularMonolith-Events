
namespace Evently.Modules.Ticketing.Application.Abstractions.Payment;
public interface IPaymentService
{
    Task<PaymentResponse> ChargeAsync(decimal amount, string currency);

    Task RefundAsync(Guid transactionId, decimal amount);
}
