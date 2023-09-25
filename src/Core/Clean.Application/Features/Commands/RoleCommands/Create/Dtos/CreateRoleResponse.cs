namespace Clean.Application.Features.Commands.RoleCommands.Create.Dtos;

public class CreateRoleResponse
{
    public bool Success { get; set; } = true;
    public List<string>? Errors { get; set; }
    public string? Message { get; set; }
}
