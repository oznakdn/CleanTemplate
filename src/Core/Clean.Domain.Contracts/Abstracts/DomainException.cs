namespace Clean.Domain.Contracts.Abstracts;

public abstract class DomainException : Exception
{
    protected DomainException(string message):base(message) 
    { 
    }
   
}
