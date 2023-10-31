using MediatR;

namespace InTime.Keys.Domain.Common;

public class BaseEvent : INotification
{
    public DateTime OccuredDate { get; protected set; }
}