namespace Clean.Shared;

public class Result : IResult
{
    public string Message { get; private set; }
    public string Error { get; private set; }
    public IEnumerable<string> Errors { get; private set; }
    public bool IsSuccess { get; set; }

    protected Result() { }

    public static IResult Fail(string? error = null, IEnumerable<string?> errors = null)
    {
        return new Result
        {
            Error = error ?? string.Empty,
            Errors = errors ?? Enumerable.Empty<string?>(),
            IsSuccess = false
        };
    }

    public static IResult Success(string message = null)
    {
        return new Result
        {
            Message = message ?? string.Empty,
            IsSuccess = true
        };
    }
}

public class Result<T> : IResult<T>
where T : class
{
    public T Value { get; private set; }
    public IEnumerable<T> Values { get; private set; }
    public string Message { get; private set; }
    public string Error { get; private set; }
    public IEnumerable<string> Errors { get; private set; }
    public bool IsSuccess { get; private set; }

    protected Result(){}

    public static IResult<T> Fail(string error = null, IEnumerable<string> errors = null)
    {
        return new Result<T>
        {
            Error = error ?? string.Empty,
            Errors = errors ?? Enumerable.Empty<string?>(),
            Value = default,
            Values = Enumerable.Empty<T>(),
            IsSuccess = false
        };
    }

    public static IResult<T> Success(string message = null, T? value = null, IEnumerable<T?> values = null)
    {
        return new Result<T>
        {
            Message = message ?? string.Empty,
            Error = default,
            Errors = Enumerable.Empty<string>(),
            Value = value ?? default,
            Values = values ?? Enumerable.Empty<T>(),
            IsSuccess = true
        };
    }
}
