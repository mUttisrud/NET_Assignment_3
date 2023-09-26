namespace Assignment_3.Services
{
    public interface ICrudService<TEntity, TID>
    {
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(TID id);
        Task<TEntity> UpdateAsync(TEntity obj);
        Task DeleteByIdAsync(TID id);
    }
}
