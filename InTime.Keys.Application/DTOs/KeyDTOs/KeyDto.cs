using InTime.Keys.Domain.Enumerations;

namespace InTime.Keys.Application.DTOs.KeyDTOs;

public record KeyDto(Guid Id, Guid AudienceId, string AudienceName, KeyStatus Status);

