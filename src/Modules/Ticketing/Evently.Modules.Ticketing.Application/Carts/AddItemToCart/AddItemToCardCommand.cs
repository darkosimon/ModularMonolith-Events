﻿
using Evently.Common.Application.Messaging;
using Evently.Common.Domain;
using Evently.Modules.Events.PublicApi;
using Evently.Modules.Ticketing.Domain.Customers;
using Evently.Modules.Ticketing.Domain.Events;
using FluentValidation;
using MediatR;

namespace Evently.Modules.Ticketing.Application.Carts.AddItemToCart;
public sealed record AddItemToCardCommand(Guid CustomerId, Guid TicketTypeId, decimal Quantity) : ICommand;

internal sealed class AddItemToCardCommandValidator : AbstractValidator<AddItemToCardCommand>
{
    public AddItemToCardCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.TicketTypeId).NotEmpty();
        RuleFor(c => c.Quantity).GreaterThan(decimal.Zero);
    }
}

internal sealed class AddItemToCardCommandHandler(
    CartService cartService,
    //IUsersApi usersApi,
    ICustomerRepository customerRepository,
    IEventsApi eventsApi) : ICommandHandler<AddItemToCardCommand>
{
    public async Task<Result> Handle(AddItemToCardCommand request, CancellationToken cancellationToken)
    {
        //1) Get Customer
        Customer? customer = await customerRepository.GetAsync(request.CustomerId, cancellationToken);

        if (customer is null)
        {
            return Result.Failure(CustomerErrors.NotFound(request.CustomerId));
        }

        //2) Get TicketTpe
        TicketTypeResponse? ticketType = await eventsApi.GetTicketTypeAsync(request.TicketTypeId, cancellationToken);

        if (ticketType is null)
        {
            return Result.Failure(TicketTypeErrors.NotFound(request.TicketTypeId));
        }

        //3) Add item to cart
        var cartItem = new CartItem
        {
            TicketTypeId = ticketType.Id,
            Price = ticketType.Price,
            Quantity = request.Quantity,
            Currency = ticketType.Currency,
        };

        await cartService.AddItemAsync(customer.Id, cartItem, cancellationToken);

        return Result.Success();
    }
}
