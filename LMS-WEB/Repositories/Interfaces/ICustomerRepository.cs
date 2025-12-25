using LMS_WEB.Models;

namespace LMS_WEB.Repositories.Interfaces;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<IEnumerable<Customer>> FilterAsync(string? name, int? cityId);
}
