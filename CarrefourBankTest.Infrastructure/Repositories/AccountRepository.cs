using CarrefourBankTest.Domain.Entities;
using CarrefourBankTest.Domain.Repositories;
using CarrefourBankTest.Infrastructure.Context;

namespace CarrefourBankTest.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

       public async Task<Account> CreateAsync() 
        {
            var account = new Account();
            account.Balance = 0;
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task UpdateAsync(Account account)
        {
             _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
