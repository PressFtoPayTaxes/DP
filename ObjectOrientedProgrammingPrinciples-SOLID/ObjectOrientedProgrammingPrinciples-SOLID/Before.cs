using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingPrinciples_SOLID
{
    interface IFactory
    {
        void CreateInstance();
        void SaveToDatabase();
    }

    class Factory : IFactory
    {
        public void CreateInstance()
        {
            Console.WriteLine("Instance created");
        }

        public void SaveToDatabase()
        {
            Console.WriteLine("No database");
        }
    }

    class Before
    {
        public void ClientCode()
        {
            Factory factory = new Factory();

            Console.WriteLine("Creating instance");
            factory.CreateInstance();
        }
    }
}
