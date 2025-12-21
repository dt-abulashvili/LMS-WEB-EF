using LMS_WEB.Models;

namespace LMS_WEB.Repositories.Interfaces;

public interface IBorrowingRepository
{
    Task<Borrowing?> GetByIdAsync(int id);

    Task<IEnumerable<Borrowing>> GetByCustomerAsync(int customerId);

    Task<Borrowing?> GetWithDetailsAsync(int id);
    // Books + Customer + Subscription

    Task AddAsync(Borrowing borrowing);

    Task ReturnBorrowingAsync(int borrowingId);
}

