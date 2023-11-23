using InTime.Keys.Domain.Enumerations;

namespace InTime.Keys.Application.DTOs.BidDTOs;

public record BidDto(Guid BidId,
                  DateTime Date,
                  int LessonNumber,
                  Guid KeyId,
                  Guid AudienceId,
                  string AudienceName,
                  BidStatus BidStatus);
