using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        public abstract class Printer
        {
            protected abstract IPaper GetPaper(); // Factory method

            public void Print()
            {
                Console.WriteLine($"Printing on {GetPaper().GetName()} paper");
            }
        }

        public interface IPaper
        {
            string GetName();
        }

        public class CanonPrinter : Printer
        {
            protected override IPaper GetPaper()
            {
                return new PerlPaper();
            }
        }

        public class PerlPaper : IPaper
        {
            public string GetName()
            {
                return "Perl";
            }
        }

        public class HPPrinter : Printer
        {
            protected override IPaper GetPaper()
            {
                return new OffsetPaper();
            }
        }

        public class OffsetPaper : IPaper
        {
            public string GetName()
            {
                return "Offset";
            }
        }

        static void Main(string[] args)
        {
            CanonPrinter canon = new CanonPrinter();
            Console.Write("Canon printer: ");
            canon.Print();

            HPPrinter hp = new HPPrinter();
            Console.Write("HP printer: ");
            hp.Print();

            Console.ReadLine();
        }
    }
}
