namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IRoleRepository Roles { get; }
    Task<int> SavaAsync();
}