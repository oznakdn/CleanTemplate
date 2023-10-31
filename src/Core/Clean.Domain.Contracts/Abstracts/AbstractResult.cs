using Clean.Domain.Contracts.Interfaces;

namespace Clean.Domain.Contracts.Abstracts;

public abstract class AbstractResult : IResult
{
    public string Message { get; protected set; }

    public IEnumerable<string> Errors { get; protected set; }

    public bool IsFailed { get; protected set; }

    public bool IsSuccessed { get; protected set; }

}
