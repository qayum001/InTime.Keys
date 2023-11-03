using InTime.Keys.Domain.Common;
using InTime.Keys.Domain.Common.Interfaces;

namespace InTime.Keys.Application.Dispatcher;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    public Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents)
    {
        return Task.CompletedTask;
    }
}
