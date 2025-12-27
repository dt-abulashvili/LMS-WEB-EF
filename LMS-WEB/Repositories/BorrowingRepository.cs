using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories;

internal class BorrowingRepository : GenericRepository<Borrowing>, IBorrowingRepository
{
    private readonly AppDbContext _dbContext;

    public BorrowingRepository(AppDbContext context) : base(context)
    {
        _dbContext = context;
    }

    public async Task ReturnBorrowingAsync(int borrowingId)
    {
        var borrowing = await _dbContext.Borrowings.FirstOrDefaultAsync(b => b.BorrowingId == borrowingId);

        if (borrowing == null)
            throw new InvalidOperationException("Borrowing not found.");

        if (borrowing.IsOver)
            return;

        borrowing.ReturnDate = DateTime.UtcNow;
        borrowing.IsOver = true;
    }

    public async Task<IEnumerable<Borrowing>> GetByCustomerAsync(int customerId)
    {
        return await _dbContext.Borrowings.Where(b => b.CustomerId == customerId).ToListAsync();
    }

    public async Task<Borrowing?> GetBooksFromBorrowing(int id)
    {
        return await _dbContext.Borrowings
            .Include(b => b.Books)
                .ThenInclude(b => b.Author)
            .Include(b => b.Books)
                .ThenInclude(b => b.Genre)
            .Include(b => b.Books)
                .ThenInclude(b => b.Publisher)
            .FirstOrDefaultAsync(b => b.BorrowingId == id);
    }

    public async Task<IEnumerable<Borrowing>> FilterAsync(int? customerId, BorrowingStatus? status)
    {
        var now = DateTime.UtcNow;

        var query = _dbContext.Borrowings.AsQueryable();

        if (customerId.HasValue)
            query = query.Where(c => c.CustomerId == customerId);

        if (status.HasValue)
        {
            query = status.Value switch
            {
                BorrowingStatus.Active =>
                    query.Where(b =>
                        !b.IsOver &&
                        (!b.DueDate.HasValue || b.DueDate >= now)),

                BorrowingStatus.Expired =>
                    query.Where(b =>
                        !b.IsOver &&
                        b.DueDate.HasValue &&
                        b.DueDate < now),

                BorrowingStatus.Completed =>
                    query.Where(b => b.IsOver),

                _ => query
            };
        }

        return await query
            .Include(b => b.Customer)
            .Include(b => b.Books)
            .ToListAsync();
    }

}
