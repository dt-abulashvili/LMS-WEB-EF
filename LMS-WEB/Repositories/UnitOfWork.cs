using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;

namespace LMS_WEB.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    private IAuthorRepository? _authorRepository;
    private ICustomerRepository? _customerRepository;
    private IBookRepository? _bookRepository;
    private IBorrowingRepository? _borrowingRepository;
    private ISubscriptionRepository? _subscriptionRepository;
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_context);
    public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_context);
    public IBookRepository Books => _bookRepository ??= new BookRepository(_context);
    public IBorrowingRepository Borrowings => _borrowingRepository ??= new BorrowingRepository(_context);
    public ISubscriptionRepository Subscriptions => _subscriptionRepository ??= new SubscriptionRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}

