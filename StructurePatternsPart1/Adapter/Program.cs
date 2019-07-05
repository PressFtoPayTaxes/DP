using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public interface IWashingMachine
    {
        string Wash();
    }

    public class Autowashing : IWashingMachine
    {
        public string Wash()
        {
            return "Washing machine: Autowashing...";
        }
    }

    public class WashingAdapter : IWashingMachine
    {
        private Handwashing _handwashing;

        public WashingAdapter(Handwashing handwashing)
        {
            _handwashing = handwashing;
        }

        public string Wash()
        {
            return _handwashing.HandWash();
        }
    }

    public class Handwashing
    {
        public string HandWash()
        {
            return "Washing machine: Handwashing...";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IWashingMachine washingMachine = new Autowashing();

            Console.WriteLine(washingMachine.Wash());
            Console.WriteLine("There is no electricity");

            washingMachine = new WashingAdapter(new Handwashing());
            Console.WriteLine(washingMachine.Wash());

            Console.ReadLine();
        }
    }
}
