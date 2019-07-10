using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedProgrammingPrinciples_SOLID
{
    interface IInstancesCreator
    {
        void CreateInstance();
    }

    interface IDatabaseSaver
    {
        void SaveToDatabase();
    }

    class OnlyFactory : IInstancesCreator
    {
        public void CreateInstance()
        {
            Console.WriteLine("Instance created");
        }
    }

    public class After
    {
        public void ClientCode()
        {
            OnlyFactory factory = new OnlyFactory();
            Console.WriteLine("Creating instance");
            factory.CreateInstance();
        }
    }
}
