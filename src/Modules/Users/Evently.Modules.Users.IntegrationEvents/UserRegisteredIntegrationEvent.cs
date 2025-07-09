using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Common.Application.EventBus;

namespace Evently.Modules.Users.IntegrationEvents;

public sealed class UserRegisteredIntegrationEvent : IntegrationEvent
{
    public UserRegisteredIntegrationEvent(
        Guid id,
        DateTime occurredOnUtc,
        Guid userID,
        string email,
        string firstName,
        string lastName) : base(id, occurredOnUtc)
    {
        UserID = userID;
        Email = email;
        FirstName = firstName;
        LastName = lastName;
    }

    public Guid UserID { get; init; }
    
    public string Email { get; init; }

    public string FirstName { get; init; }

    public string LastName { get; init; }

}
