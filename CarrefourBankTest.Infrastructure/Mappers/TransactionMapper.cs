using CarrefourBankTest.Application.DTOs;
using CarrefourBankTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrefourBankTest.Infrastructure.Mappers
{
    public static class TransactionMapper
    {
        public static TransactionDto ToDto(Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                AccountId = transaction.AccountId,
                Amount = transaction.Amount,
                Type = transaction.Type.ToString(),
                CreatedAt = transaction.CreatedAt
            };
        }
    }
}
