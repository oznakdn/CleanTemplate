using Clean.Domain.Contracts.Results;

namespace Clean.Domain.Results;

public class Result : IResult
{
    public string Message { get; }

    public List<string> Messages { get; } = new();

    public bool IsSuccessed { get; }

    public Result()
    {
        
    }

    public Result(string message):this()
    {
        Message = message;
    }

    public Result(List<string> messages) : this()
    {
        Messages = messages;
    }

    public Result(bool isSuccessed) : this()
    {
        IsSuccessed = isSuccessed;
    }

    public Result(string message, bool isSuccessed) : this()
    {
        Message = message;
        IsSuccessed = isSuccessed;
    }

    
    public Result(List<string> messages, bool isSuccessed) : this()
    {
        Messages = messages;
        IsSuccessed = isSuccessed;
    }
}
