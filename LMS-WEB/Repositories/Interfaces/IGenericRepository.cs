namespace LMS_WEB.Repositories.Interfaces;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
}