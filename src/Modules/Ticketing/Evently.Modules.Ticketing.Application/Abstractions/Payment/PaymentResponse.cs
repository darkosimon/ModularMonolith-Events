
namespace Evently.Modules.Ticketing.Application.Abstractions.Payment;
public sealed record PaymentResponse(Guid TransactionId, decimal Amount, string Currency);
