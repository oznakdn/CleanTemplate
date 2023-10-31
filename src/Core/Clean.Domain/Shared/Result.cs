using Clean.Domain.Contracts.Abstracts;

namespace Clean.Domain.Shared;

public class Result:AbstractResult
{
   
    protected Result() { }


    #region Success

    public static Result Ok()
    {
        return new Result
        {
            IsSuccessed = true,
            IsFailed = false,
            Errors = Enumerable.Empty<string>(),
            Message = string.Empty
        };
    }

    public static Result Ok(string message)
    {
        return new Result
        {
            IsSuccessed = true,
            IsFailed = false,
            Message = message,
            Errors = Enumerable.Empty<string>(),
        };
    }


    #endregion


    #region Fail

    public static Result Fail()
    {
        return new Result
        {
            IsSuccessed = false,
            IsFailed = true,
            Errors = Enumerable.Empty<string>(),
            Message = string.Empty
        };
    }

    public static Result Fail(string message)
    {
        return new Result
        {
            IsSuccessed = false,
            IsFailed = true,
            Message = message,
            Errors = Enumerable.Empty<string>(),
        };
    }

    public static Result Fail(List<string> errors)
    {
        return new Result
        {
            IsSuccessed = false,
            IsFailed = true,
            Errors = errors,
            Message = string.Empty,
        };
    }

    #endregion
 

}
