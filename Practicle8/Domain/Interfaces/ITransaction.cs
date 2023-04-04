using Practicle8.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle8.Domain.Interfaces
{
    internal interface ITransaction
    {
        void InsertTransaction(long _UserBankAccountId, TransactionType _tranType,decimal _tranAmount, string _desc);
        void ViewTransaction();
    }
}
