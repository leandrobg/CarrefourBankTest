using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrefourBankTest.Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
