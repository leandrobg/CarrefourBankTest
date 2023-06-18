using CarrefourBankTest.Domain.Entities;

namespace CarrefourBankTest.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<Account> CreateAsync();
        Task<Account> GetByIdAsync(int id);
        Task UpdateAsync(Account account);
    }
}
