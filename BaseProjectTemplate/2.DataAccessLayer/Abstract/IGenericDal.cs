namespace BaseProjectTemplate._2.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T?> GetByIdAsync(long id);
        Task InsertAsync(T entity, string userId);
        Task UpdateAsync(T entity, string userId);
        Task DeleteAsync(Guid id, string userId);
    }
}
