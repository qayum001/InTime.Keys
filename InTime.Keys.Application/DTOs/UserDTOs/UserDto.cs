namespace InTime.Keys.Application.DTOs.UserDTOs;

public record UserDto
{
    public Guid Id { get; }
    public UserDto(Guid id)
    {
        Id = id;
    }
}
