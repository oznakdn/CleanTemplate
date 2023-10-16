namespace Clean.Application.Results;

public class DataResult<TData> : IDataResult<TData>
{
    public TData Data { get; }

    public List<TData> Datas { get; } = new();

    public string Message { get; }

    public List<string> Messages { get; }

    public bool IsSuccessed { get; }


    public DataResult()
    {

    }

    public DataResult(TData data) : this()
    {
        Data = data;
    }
    public DataResult(TData data, string message) : this()
    {
        Data = data;
        Message = message;
    }

    public DataResult(TData data, string message, bool isSuccessed) : this()
    {
        Data = data;
        Message = message;
        IsSuccessed = isSuccessed;
    }

    public DataResult(List<TData> datas) : this()
    {
        Datas = datas;
    }

    public DataResult(List<TData> datas, string message) : this()
    {
        Datas = datas;
        Message = message;
    }

    public DataResult(List<TData> datas, string message, bool isSuccessed) : this()
    {
        Datas = datas;
        Message = message;
        IsSuccessed = isSuccessed;
    }

    public DataResult(string message) : this()
    {
        Message = message;
    }


    public DataResult(List<string> messages) : this()
    {
        Messages = messages;
    }

    public DataResult(bool isSuccessed) : this()
    {
        IsSuccessed = isSuccessed;
    }

    public DataResult(string message, bool isSuccessed) : this()
    {
        Message = message;
        IsSuccessed = isSuccessed;
    }


    public DataResult(List<string> messages, bool isSuccessed) : this()
    {
        Messages = messages;
        IsSuccessed = isSuccessed;
    }
}
