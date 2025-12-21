using LMS_WEB.Data;
using LMS_WEB.Models;
using LMS_WEB.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LMS_WEB.Repositories;

public class BorrowingRepository : IBorrowingRepository
{
    private readonly AppDbContext _dbContext;

    public BorrowingRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task AddAsync(Borrowing borrowing)
    {
        await _dbContext.Borrowings.AddAsync(borrowing);
    }

    public async Task ReturnBorrowingAsync(int borrowingId)
    {
        var borrowing = await _dbContext.Borrowings.FirstOrDefaultAsync(b => b.BorrowingId == borrowingId);

        if (borrowing == null)
            throw new InvalidOperationException("Borrowing not found.");

        if (borrowing.ReturnDate != null)
            return;

        borrowing.ReturnDate = DateTime.UtcNow;
        borrowing.IsOver = true;
    }

    public async Task<IEnumerable<Borrowing>> GetByCustomerAsync(int customerId)
    {
        return await _dbContext.Borrowings.Where(b => b.CustomerId == customerId).ToListAsync();
    }

    public async Task<Borrowing?> GetByIdAsync(int id)
    {
        return await _dbContext.Borrowings.FirstOrDefaultAsync(b => b.BorrowingId == id);
    }

    public async Task<Borrowing?> GetWithDetailsAsync(int id)
    {
        return await _dbContext.Borrowings
            .Include(b => b.Subscription)
            .Include(b => b.Customer)
            .Include(b => b.Books)
            .FirstOrDefaultAsync(b => b.BorrowingId == id);
    }
}
