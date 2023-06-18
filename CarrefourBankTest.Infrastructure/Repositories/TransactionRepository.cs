using CarrefourBankTest.Domain.Entities;
using CarrefourBankTest.Domain.Repositories;
using CarrefourBankTest.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CarrefourBankTest.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(int accountId)
        {
            return await _context.Transactions.Where(t => t.AccountId == accountId).ToListAsync();
        }
    }
}
