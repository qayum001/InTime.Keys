using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Common.DomainEvents;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.BIds.Events;

public class BidCreatedDomainEventHandler : INotificationHandler<BidCreatedDomainEvent>
{
    private readonly IUnitOfWork _unitOfWork;

    public BidCreatedDomainEventHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(BidCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var key = await _unitOfWork.Repository<Key>().GetById(notification.KeyId);

        if (key == null)
        {
            return;
        }

        key.SetStatus(Domain.Enumerations.KeyStatus.Booked);
    }
}