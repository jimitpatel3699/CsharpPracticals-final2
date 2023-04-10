using Practicle8.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle8.Domain.Entities
{
    internal class Transaction
    {
        public string TransactionId { get; set; }
        public long UserBankAccountId { get; set; }
        public DateTime TransactionDate { get; set; }   
        public TransactionType TransactionType { get; set; }
        public string Description { get; set; }
        public Decimal TransactionAmount { get; set; }
    }
}
