namespace Clean.Shared;

public interface IResult
{
    string Message { get;}
    string Error { get;}
    IEnumerable<string> Errors { get;}
    bool IsSuccess { get;}
}

public interface IResult<T> : IResult
    where T : class
{
    T Value { get;}
    IEnumerable<T> Values { get; }
}
