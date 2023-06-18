using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrefourBankTest.Application.DTOs
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
