using Clean.Domain.Repositories.Commands;
using Clean.Persistence.Repositories.Commands;

namespace Clean.Application.UnitOfWork.Commands;

public class CommandUnitOfWork : ICommandUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public CommandUnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        basketItemCommand = basketItemCommand ?? new BasketItemCommand(_context);
    }

    public CommandUnitOfWork()
    {

    }

    public IBasketItemCommand basketItemCommand { get; }



}
