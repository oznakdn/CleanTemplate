namespace Clean.Domain.Contracts.Interfaces;

public interface IResult
{
    public string Message { get;}
    public IEnumerable<string> Errors { get;}
    public bool IsFailed { get;}
    public bool IsSuccessed { get;}
}
