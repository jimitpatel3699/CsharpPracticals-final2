using Practicle8.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicle8.App
{ 
    internal sealed class Entry
    {
        static void Main(string[] args)
        {            
            AtmApp atmApp = new AtmApp();
            atmApp.InitializeData();
            atmApp.Run();           
        }
    }
}
