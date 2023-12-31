namespace Lab5.Application.Repository;

public interface IRepository<T>
{
    Task<T?> GetById(int id);
    Task<RepositoryRequestResult> Create(T obj);
    Task<RepositoryRequestResult> Delete(int id);
}