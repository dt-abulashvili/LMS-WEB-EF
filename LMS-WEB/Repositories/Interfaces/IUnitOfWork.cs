namespace LMS_WEB.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAuthorRepository Authors { get; }
    ICustomerRepository Customers { get; }

    Task<int> SaveChangesAsync();
}

