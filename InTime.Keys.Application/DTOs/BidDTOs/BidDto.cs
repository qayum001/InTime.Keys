using InTime.Keys.Domain.Enumerations;
using System.Globalization;

namespace InTime.Keys.Application.DTOs.BidDTOs;

public record BidDto
{
    public Guid BidId { get; }
    public DateTime Date { get; }
    public int LessonNunber { get; }
    public Guid KeyId { get; }
    public Guid AudienceId { get; }
    public string AudienceName { get; } = string.Empty;
    public BidStatus BidStatus { get; }

    public BidDto(Guid bidId,
                  DateTime date,
                  int lessonNumber,
                  Guid keyId,
                  Guid audienceId,
                  string audienceName,
                  BidStatus bidStatus)
    {
        BidId = bidId;
        Date = date;
        LessonNunber = lessonNumber;
        KeyId = keyId;
        AudienceId = audienceId;
        AudienceName = audienceName;
        BidStatus = bidStatus;
    }
}
