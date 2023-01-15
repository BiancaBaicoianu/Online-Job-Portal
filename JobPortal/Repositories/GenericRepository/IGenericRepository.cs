namespace JobPortal.Repository
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T?> GetById(int id);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(T entity);
        Task<Repositories.EmployeeApplyingForJobRepository?> GetEmployeeApplyingForJobByIds(Guid EmployeeId, Guid JobId);
    }
}
