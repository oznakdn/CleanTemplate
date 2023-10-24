namespace Clean.Domain.Shared;

public class Result
{
    public Result(string message, bool isFailed, bool isSuccessed)
    {
        Message = message;
        IsFailed = isFailed;
        IsSuccessed = isSuccessed;
    }

    public Result()
    {

    }

    public string Message { get;}
    public bool IsFailed { get;}
    public bool IsSuccessed { get;}

}
