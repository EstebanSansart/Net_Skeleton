using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Aplication.Repository;
public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    private readonly APIContext _context;
    public RoleRepository(APIContext context) : base(context)
    {
        _context = context;
    }
}