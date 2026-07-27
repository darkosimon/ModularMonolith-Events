using Evently.Common.Application.Messaging;
using Evently.Modules.Ticketing.Application.Abstractions.Payment;
using Evently.Modules.Ticketing.Domain.Payments;

namespace Evently.Modules.Ticketing.Application.Payments.RefundPayment;
internal sealed class PaymentPartiallyRefundedDomainEventHandler(IPaymentService paymentService)
    : IDomainEventHandler<PaymentPartiallyRefundedDomainEvent>
{
    public async Task Handle(PaymentPartiallyRefundedDomainEvent domainEvent, CancellationToken cancellationToken)
    {
        await paymentService.RefundAsync(domainEvent.TransactionId, domainEvent.RefundAmount);
    }
}
