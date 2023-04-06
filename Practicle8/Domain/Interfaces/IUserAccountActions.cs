using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle8.Domain.Interfaces
{
    public interface IUserAccountActions
    {
        void CheckBalance();
        void PlaceDeposite();
        void MakeWithDrawal();
    }
}