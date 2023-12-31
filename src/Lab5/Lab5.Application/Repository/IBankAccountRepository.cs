using Lab5.Application.Models;

namespace Lab5.Application.Repository;

public interface IBankAccountRepository : IRepository<BankAccount>
{
    Task<RepositoryRequestResult> Update(BankAccount obj);
}