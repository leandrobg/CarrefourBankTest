using CarrefourBankTest.Application.DTOs;
using CarrefourBankTest.Application.Interfaces;
using CarrefourBankTest.Application.Mappers;
using CarrefourBankTest.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrefourBankTest.Application.Services
{
    public class AccountAppService : IAccountAppService
    {
        private readonly IAccountService _accountService;

        public AccountAppService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<int> CreateAsync() 
        {
            return await _accountService.CreateAsync();
        }

        public async Task CreditAsync(int accountId, decimal amount)
        {
            await _accountService.CreditAsync(accountId, amount);
        }

        public async Task DebitAsync(int accountId, decimal amount)
        {
            await _accountService.DebitAsync(accountId, amount);
        }

        public async Task<decimal> GetBalanceAsync(int accountId)
        {
            return await _accountService.GetBalanceAsync(accountId);
        }
    }
}
