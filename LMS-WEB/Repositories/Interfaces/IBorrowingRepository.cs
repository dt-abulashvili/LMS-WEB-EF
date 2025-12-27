using LMS_WEB.Models;

namespace LMS_WEB.Repositories.Interfaces;

public interface IBorrowingRepository : IGenericRepository<Borrowing>
{
    Task<IEnumerable<Borrowing>> FilterAsync(int? customerId, BorrowingStatus? status);
    Task<Borrowing?> GetBooksFromBorrowing(int id);
    Task ReturnBorrowingAsync(int borrowingId);
}

