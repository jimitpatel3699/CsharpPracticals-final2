using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle8.Domain.Entities
{
    public class InternalTransfer
    {
        public decimal TransferAmount { get; set; }
        public long ReciepeintAccNum { get; set; }
        public string ReciepeintName { get; set; }
    }
}
