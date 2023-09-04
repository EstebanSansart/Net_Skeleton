using Domain.Interfaces;
using Persistence;

namespace Aplication.UnitOfWork;
public class UnitOfWork //: IUnitOfWork
{
    private readonly APIContext _context;
    public UnitOfWork(APIContext context)
    {
        _context = context;
    }
}