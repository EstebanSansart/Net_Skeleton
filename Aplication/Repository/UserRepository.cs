using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Aplication.Repository;
public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly APIContext _context;
    public UserRepository(APIContext context) : base(context)
    {
        _context = context;
    }
    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Username.ToLower()==username.ToLower());
    }
}
