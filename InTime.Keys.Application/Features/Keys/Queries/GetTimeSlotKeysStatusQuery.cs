using MediatR;

namespace InTime.Keys.Application.Features.Keys.Queries;

public class GetTimeSlotKeysStatusQuery : IRequest
{
    //этот запрос должен возвращать список ключей на конкретный таймслот,
    //но для того чтобы эта логика работала нормально нужно реализовать автоматическое
    //создание заявок по расписанию
}
