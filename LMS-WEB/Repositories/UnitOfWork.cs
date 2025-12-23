using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;

namespace LMS_WEB.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    private IAuthorRepository? _authorRepository;
    private ICustomerRepository? _customerRepository;
    private IBookRepository? _bookRepository;
    private IBorrowingRepository? _borrowingRepository;
    private ISubscriptionRepository? _subscriptionRepository;
    private IGenericRepository<Country>? _countryRepository;
    private IGenericRepository<City>? _cityRepository;
    private IGenericRepository<Nationality>? _nationalityRepository;
    private IGenericRepository<Publisher>? _publisherRepository;
    private IGenericRepository<Genre>? _genreRepository;

    public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_context);
    public ICustomerRepository Customers => _customerRepository ??= new CustomerRepository(_context);
    public IBookRepository Books => _bookRepository ??= new BookRepository(_context);
    public IBorrowingRepository Borrowings => _borrowingRepository ??= new BorrowingRepository(_context);
    public ISubscriptionRepository Subscriptions => _subscriptionRepository ??= new SubscriptionRepository(_context);
    public IGenericRepository<Country> Countries => _countryRepository ??= new CountryRepository(_context);
    public IGenericRepository<City> Cities => _cityRepository ??= new CityRepository(_context);
    public IGenericRepository<Nationality> Nationalities => _nationalityRepository ??= new NationalityRepository(_context);
    public IGenericRepository<Publisher> Publishers => _publisherRepository ??= new PublisherRepository(_context);
    public IGenericRepository<Genre> Genres => _genreRepository ??= new GenreRepository(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}

