using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIP
{
    class Program
    {
        static void Main(string[] args)
        {
            Before before = new Before();
            before.ClientCode();
            DIP_After.After after = new DIP_After.After();
            after.ClientCode();
        }
    }
}
