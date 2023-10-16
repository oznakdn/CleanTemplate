namespace Clean.Application.Results;

public interface IResult
{
    string Message { get; }
    List<string> Messages { get; }
    bool IsSuccessed { get; }
}
