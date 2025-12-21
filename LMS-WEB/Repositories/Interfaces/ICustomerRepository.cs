using LMS_WEB.Models;

namespace LMS_WEB.Repositories.Interfaces;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer?> GetByIdAsync(int id);

    Task<Customer?> GetWithBorrowingsAsync(int id);
    Task<Customer?> GetWithSubscriptionsAsync(int id);

    Task AddAsync(Customer customer);
    Task UpdateAsync(Customer customer);
    Task SoftDeleteAsync(int id);
}
