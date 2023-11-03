namespace InTime.Keys.Application.DTOs.Building;

public record AudienceDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public AudienceDto(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
