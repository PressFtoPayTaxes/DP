using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationPatternsPart1
{
    public interface IAbstractFactory
    {
        IAbstractMainboard CreateMainboard();
        IAbstractProcessor CreateProcessor();
    }

    public interface IAbstractMainboard
    {
        string GetName();
        string GetProcessor(IAbstractProcessor processor);
    }

    public interface IAbstractProcessor
    {
        string GetName();
    }

    public class Dell : IAbstractFactory
    {
        public IAbstractMainboard CreateMainboard()
        {
            return new DellMainboard();
        }

        public IAbstractProcessor CreateProcessor()
        {
            return new DellProcessor();
        }
    }

    public class DellProcessor : IAbstractProcessor
    {
        public string GetName()
        {
            return "Processor by Dell";
        }
    }

    public class DellMainboard : IAbstractMainboard
    {
        public string GetName()
        {
            return "Mainboard by Dell";
        }

        public string GetProcessor(IAbstractProcessor processor)
        {
            return $"Mainboard by Dell with {processor.GetName()}";
        }
    }

    public class Sony : IAbstractFactory
    {
        public IAbstractMainboard CreateMainboard()
        {
            return new SonyMainboard();
        }

        public IAbstractProcessor CreateProcessor()
        {
            return new SonyProcessor();
        }
    }

    public class SonyProcessor : IAbstractProcessor
    {
        public string GetName()
        {
            return "Processor by Sony";
        }
    }

    public class SonyMainboard : IAbstractMainboard
    {
        public string GetName()
        {
            return "Mainboard by Sony";
        }

        public string GetProcessor(IAbstractProcessor processor)
        {
            return $"Mainboard by Sony with {processor.GetName()}";
        }
    }

    public class Client
    {
        public static void ClientCode(IAbstractFactory factory)
        {
            IAbstractMainboard mainboard = factory.CreateMainboard();
            IAbstractProcessor processor = factory.CreateProcessor();

            Console.WriteLine(mainboard.GetProcessor(processor));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dell dellFactory = new Dell();
            Console.WriteLine("Dell factory:");
            Client.ClientCode(dellFactory);

            Sony sonyFactory = new Sony();
            Console.WriteLine("Sony factory:");
            Client.ClientCode(sonyFactory);

            Console.ReadLine();
        }
    }
}
