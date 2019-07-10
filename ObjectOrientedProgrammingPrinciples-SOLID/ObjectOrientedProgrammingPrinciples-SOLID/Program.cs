using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingPrinciples_SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            var before = new Before();
            before.ClientCode();
            var after = new After();
            after.ClientCode();
        }
    }
}
