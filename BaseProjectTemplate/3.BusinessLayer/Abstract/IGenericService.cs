namespace BaseProjectTemplate._3.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(Guid Id);
        Task<T?> GetByIdAsync(long Id);
        Task InsertAsync(T Entity, string UserId);
        Task UpdateAsync(T Entity, string UserId);
        Task DeleteAsync(Guid id, string UserId);
    }
}
