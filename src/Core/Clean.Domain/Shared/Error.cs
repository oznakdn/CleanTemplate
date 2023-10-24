namespace Clean.Domain.Shared;

public class Error:Result
{
    public Error(string message) : base(message,true,false)
    {
        
    }
}
