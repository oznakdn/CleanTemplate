namespace Clean.Domain.Shared;

public class TResult<T>:Result
{

    public TResult(string message, T value) : base(message,false,true)
    {
        Value = value;
    }

    public TResult(T value)
    {
        Value = value;
    }

    public T Value { get;}

}
