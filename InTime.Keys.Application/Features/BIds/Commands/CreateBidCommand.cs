using InTime.Keys.Application.Interfaces.Repositories;
using InTime.Keys.Domain.Enities;
using MediatR;

namespace InTime.Keys.Application.Features.BIds.Commands;

public record CreateBidCommand : IRequest
{
    public Guid UserId { get; }
    public Guid KeyId { get; }
    public int TimeSlot { get; }
    public DateTime Date { get; }

    public CreateBidCommand(Guid userId, Guid keyId, int timeSlot, DateTime date)
    {
        UserId = userId;
        KeyId = keyId;
        TimeSlot = timeSlot;
        Date = date;
    }
}

public class CreateBidCommandHandler : IRequestHandler<CreateBidCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBidCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateBidCommand request, CancellationToken cancellationToken)
    {
        var key = await _unitOfWork.Repository<Key>().GetById(request.KeyId);
        //TODO: добавить получение юзера через контекст, и если получаем null то создаём нового и сохраняем.
        //возможно нам хватит id от юзера чтобы понимать кто создал заявку
        //var user = new User(request.User.Id);

        var timeSlot = TimeSlot.Create(request.TimeSlot, request.Date);

        var bid = Bid.Create(request.UserId, timeSlot, key);

        await _unitOfWork.Repository<Bid>().AddAsync(bid);
        await _unitOfWork.Repository<TimeSlot>().AddAsync(timeSlot);

        await _unitOfWork.Save(cancellationToken);
    }
}
