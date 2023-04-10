using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Practicle8.Domain.Entities
{
    internal static class GenerateId
    {
        public static string GuId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

    }
}
