using Clean.Domain.Customers;
using Gleeman.Repository.EFCore.Interfaces.Command.Create;
using Gleeman.Repository.EFCore.Interfaces.Command.Delete;
using Gleeman.Repository.EFCore.Interfaces.Command.Update;

namespace Clean.Domain.Repositories.Commands;

public interface ICustomerCommand : 
    IEFCreateAsyncRepository<Customer>,
    IEFCreateSyncRepository<Customer>,
    IEFUpdateAsyncRepository<Customer>,
    IEFUpdateSyncRepository<Customer>,
    IEFDeleteAsyncRepository<Customer>,
    IEFDeleteSyncRepository<Customer>
{
}
