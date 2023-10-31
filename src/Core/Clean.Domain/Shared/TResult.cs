using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Shared;

public sealed class TResult<T>:AbstractResult
    where T : class
{
    public T Value { get; private set; }
    public IEnumerable<T> Values { get; private set; }

    private TResult() { }


    #region Success

    public static TResult<T> Ok()
    {
        return new TResult<T>()
        {
            IsSuccessed = true,
            IsFailed = false,
            Value = null,
            Errors = Enumerable.Empty<string>(),
            Message = string.Empty,
            Values = Enumerable.Empty<T>()
        };
    }

    public static TResult<T> Ok(string message)
    {
        return new TResult<T>()
        {
            IsSuccessed = true,
            IsFailed = false,
            Message = message,
            Value = null,
            Errors = Enumerable.Empty<string>(),
            Values = Enumerable.Empty<T>()
        };
    }


    public static TResult<T> Ok(T value)
    {
        return new TResult<T>()
        {
            IsSuccessed = true,
            IsFailed = false,
            Value = value,
            Errors = Enumerable.Empty<string>(),
            Message = string.Empty,
            Values = Enumerable.Empty<T>()
        };
    }

    public static TResult<T> Ok(T value, string message)
    {
        return new TResult<T>()
        {
            IsSuccessed = true,
            IsFailed = false,
            Value = value,
            Message = message,
            Errors = Enumerable.Empty<string>(),
            Values = Enumerable.Empty<T>()
        };
    }

    public static TResult<T> Ok(IEnumerable<T> values)
    {
        return new TResult<T>()
        {
            IsSuccessed = true,
            IsFailed = false,
            Values = values,
            Value = null,
            Errors = Enumerable.Empty<string>(),
            Message = string.Empty
        };
    }

    public static TResult<T> Ok(IEnumerable<T> values, string message)
    {
        return new TResult<T>()
        {
            IsSuccessed = true,
            IsFailed = false,
            Message = message,
            Values = values,
            Value = null,
            Errors = Enumerable.Empty<string>()
        };
    }


    #endregion


    #region Fail
    public static TResult<T> Fail()
    {
        return new TResult<T>
        {
            IsSuccessed = false,
            IsFailed = true,
            Errors = Enumerable.Empty<string>(),
            Message = string.Empty,
            Values = Enumerable.Empty<T>(),
            Value = null
        };
    }

    public static TResult<T> Fail(string message)
    {
        return new TResult<T>
        {
            IsSuccessed = false,
            IsFailed = true,
            Message = message,
            Errors = Enumerable.Empty<string>(),
            Values = Enumerable.Empty<T>(),
            Value = null
        };
    }

    public static TResult<T> Fail(List<string> errors)
    {
        return new TResult<T>
        {
            IsSuccessed = false,
            IsFailed = true,
            Errors = errors,
            Message = string.Empty,
            Values = Enumerable.Empty<T>(),
            Value = null
        };
    }

    #endregion



}
