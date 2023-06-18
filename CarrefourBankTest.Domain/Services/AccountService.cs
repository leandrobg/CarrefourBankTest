using CarrefourBankTest.Domain.Entities;
using CarrefourBankTest.Domain.Interfaces;
using CarrefourBankTest.Domain.Repositories;

namespace CarrefourBankTest.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<int> CreateAsync() 
        {
            var account = await _accountRepository.CreateAsync();
            return account.Id;
        }

        public async Task CreditAsync(int accountId, decimal amount)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            account.Balance += amount;

            var transaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Type = TransactionType.Credit,
                CreatedAt = DateTime.UtcNow
            };

            await _transactionRepository.AddAsync(transaction);
            await _accountRepository.UpdateAsync(account);
        }

        public async Task DebitAsync(int accountId, decimal amount)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);

            if (account.Balance < amount)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            account.Balance -= amount;

            var transaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Type = TransactionType.Debit,
                CreatedAt = DateTime.UtcNow
            };

            await _transactionRepository.AddAsync(transaction);
            await _accountRepository.UpdateAsync(account);
        }

        public async Task<decimal> GetBalanceAsync(int accountId)
        {
            var account = await _accountRepository.GetByIdAsync(accountId);
            return account.Balance;
        }
    }
}
