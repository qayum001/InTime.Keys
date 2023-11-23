using InTime.Keys.Domain.Enumerations;

namespace InTime.Keys.Application.DTOs.KeyDTOs;

public record TimeSlotKeyDto(Guid KeyId, DateTime Date, int TimeSlot, KeyStatus KeyStatus, Guid AudienceId, string AudeinceName);

