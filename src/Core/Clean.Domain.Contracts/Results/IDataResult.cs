namespace Clean.Domain.Contracts.Results;

public interface IDataResult<TData> : IResult
{
    TData Data { get; }
    List<TData> Datas { get; }
}
