using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle8.Domain.Entities
{
    public class UserAccount
    {
        public long CardNumber { get; set; }
        public int Cardpin { get; set; }

        public long AccountNumber { get; set; }
        public string FullName { get; set; }
        public decimal AccountBalance { get; set; }
        public int totalLogin { get; set; }
        public bool IsLocked { get; set; }
    }
}
