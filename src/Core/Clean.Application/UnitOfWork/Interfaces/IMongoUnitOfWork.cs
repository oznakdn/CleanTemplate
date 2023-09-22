namespace Clean.Application.UnitOfWork.Interfaces;

public interface IMongoUnitOfWork
{
    IMapper Mapper { get; }
    IMongoCustomerRepository Customer { get; }
}
