namespace ecom.Services.Base;

public interface IEntityBaseService<T> where T:class, IEntityBaseModel, new()
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(int id, T entity);
    Task DeleteAsync(int id);
}