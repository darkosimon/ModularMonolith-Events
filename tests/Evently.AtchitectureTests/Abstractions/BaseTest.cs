#pragma warning disable CA1515

namespace Evently.AtchitectureTests.Abstractions;

public abstract class BaseTest
{
    protected const string UserNamespace = "Evently.Modules.Users";
    protected const string UserIntegrationEventsNamespace = "Evently.Modules.Users.IntegrationEvents";

    protected const string EventsNamespace = "Evently.Modules.Events";
    protected const string EventsIntegrationEventsNamespace = "Evently.Modules.Events.IntegrationEvents";

    protected const string TicketingNamespace = "Evently.Modules.Ticketing";
    protected const string TicketingIntegrationEventsNamespace = "Evently.Modules.Ticketing.IntegrationEvents";

    protected const string AttendanceNamespace = "Evently.Modules.Attendance";
    protected const string AttendanceIntegrationEventsNamespace = "Evently.Modules.Attendance.IntegrationEvents";
}
