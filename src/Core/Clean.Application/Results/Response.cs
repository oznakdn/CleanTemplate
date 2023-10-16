namespace Clean.Application.Results;

public class Response
{
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new();
    public bool Successed { get; set; } = true;
}
