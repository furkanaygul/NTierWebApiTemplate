namespace BaseProjectTemplate._4.ServiceLayer.Interfaces
{
    public interface IApiGenericService<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> CreateAsync(T Dto, string UserId);
        Task<T> UpdateAsync(Guid Id, T Dto, string UserId);
        Task DeleteAsync(Guid Id, string UserId);
    }
}
