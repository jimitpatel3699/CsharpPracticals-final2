using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practicle2
{
    public class CopyConstuctor
    {
        int x;
        int y;
       
        public CopyConstuctor(int x, int y)
        {
            Console.WriteLine($"normal constructor called\n");
            this.x = x;
            this.y = y;
        }
        public CopyConstuctor(CopyConstuctor obj)
        {
            Console.WriteLine($"copy constructor called\n");
            this.x = obj.x;
        }

       
    }
}
