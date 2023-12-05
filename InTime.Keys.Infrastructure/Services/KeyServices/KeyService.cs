using InTime.Keys.Application.DTOs.BidDTOs;
using InTime.Keys.Application.DTOs.KeyDTOs;
using InTime.Keys.Application.Features.BIds.Queries;
using InTime.Keys.Application.Features.Keys.Queries;
using InTime.Keys.Application.Interfaces.Services.KeyServices;
using InTime.Keys.Domain.Enities;
using InTime.Keys.Domain.Enumerations;
using InTime.Keys.Infrastructure.Refit.Interfaces;
using InTime.Keys.Infrastructure.Refit.InTimeModels;
using InTime.Keys.Infrastructure.Refit.InTimeModels.Schedule;
using MediatR;

namespace InTime.Keys.Infrastructure.Services.KeyServices;

public class KeyService : IKeyGetService
{
    private readonly IMediator _mediator;
    private readonly IInTimeClient _client;

    public KeyService(IMediator mediator, IInTimeClient inTimeClient)
    {
        _mediator = mediator;
        _client = inTimeClient;
    }

    public async Task<List<KeyDto>> GetAllKeys()
    {
        var res = await _mediator.Send(new GetAllKeysQuery());

        return res;
    }

    //этот метод будет удалён после реализации авто-генерации заявок по рассписанию
    public async Task<List<TimeSlotKeyDto>> GetConcreteTimeSlotKeys(DateTime date, int timeSlot, int page, int size)
    {
        var bids = await _mediator.Send(new GetTimeSlotBidsWithPaginationQuery(date, timeSlot, page, size));

        var keys = await _mediator.Send(new GetKeysWithPaginationQuery(page, size));

        var res = new List<TimeSlotKeyDto>();

        foreach(var key in keys)
        {
            var strDate = $"{date.Year}-{date.Month}-{date.Day}";
            var schedule = await _client.GetSchedulesAsync("audience", key.AudienceId, strDate, strDate);

            var hasAudienceBId = bids.Any(e => e.AudienceId == key.AudienceId && e.LessonNumber == timeSlot);

            var dto = new TimeSlotKeyDto(key.Id, date, timeSlot, KeyStatus.Available, key.AudienceId, key.AudienceName);

            if(schedule.Any(e => e.Lessons is not null))
            {
                foreach (var sch in schedule)
                {
                    if(typeof(InTimeSchedule) != sch.GetType())
                        continue;

                    foreach(var lesson in sch.Lessons)
                    {
                        if (lesson.LessonNumber != timeSlot)
                            continue;

                        if (lesson.Type == "Empty" && !hasAudienceBId)
                        {
                            dto = new TimeSlotKeyDto(key.Id, date, timeSlot, KeyStatus.Available, key.AudienceId, key.AudienceName);
                        }
                        else if(lesson.Type == "LESSON")
                        {
                            dto = new TimeSlotKeyDto(key.Id, date, timeSlot, KeyStatus.InUse, key.AudienceId, key.AudienceName);
                        }
                    }
                }
            }
            if(hasAudienceBId)
            {
                var audienceBIds = bids.Where(e => e.AudienceId == key.AudienceId);

                if (audienceBIds.Any(e => e.BidStatus == BidStatus.Approved || e.BidStatus == BidStatus.GiveAway))
                    dto = new TimeSlotKeyDto(key.Id, date, timeSlot, KeyStatus.Booked, key.AudienceId, key.AudienceName);

                else if (audienceBIds.Any(e => e.BidStatus == BidStatus.KeyGiven))
                    dto = new TimeSlotKeyDto(key.Id, date, timeSlot, KeyStatus.InUse, key.AudienceId, key.AudienceName);

                else if (audienceBIds.Any())
                    dto = new TimeSlotKeyDto(key.Id, date, timeSlot, KeyStatus.Available, key.AudienceId, key.AudienceName);
            }

            res.Add(dto);
        }
        
        return res;
    }
}