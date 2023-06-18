using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrefourBankTest.Domain.Interfaces
{
    public interface IAccountService
    {
        Task<int> CreateAsync();
        Task CreditAsync(int accountId, decimal amount);
        Task DebitAsync(int accountId, decimal amount);
        Task<decimal> GetBalanceAsync(int accountId);
    }
}
