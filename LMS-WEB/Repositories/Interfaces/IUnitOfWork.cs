using LMS_WEB.Models;

namespace LMS_WEB.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        IBorrowingRepository Borrowings { get; }
        IGenericRepository<City> Cities { get; }
        IGenericRepository<Country> Countries { get; }
        ICustomerRepository Customers { get; }
        IGenericRepository<Genre> Genres { get; }
        IGenericRepository<Nationality> Nationalities { get; }
        IGenericRepository<Publisher> Publishers { get; }
        ISubscriptionRepository Subscriptions { get; }

        void Dispose();
        Task<int> SaveChangesAsync();
    }
}