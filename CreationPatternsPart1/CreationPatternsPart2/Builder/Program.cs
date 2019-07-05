using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface IBuilder
    {
        void BuildMainboard();
        void BuildProcessor();
        void BuildVideoCard();
        void BuildSoundCard();
        void BuildTuner();
        Computer GetProduct();
        void Reset();
    }

    public class DellBuilder : IBuilder
    {
        private Computer _computer;

        public DellBuilder()
        {
            _computer = new Computer();
        }

        public void BuildMainboard()
        {
            _computer.Add("Dell mainboard");
        }

        public void BuildProcessor()
        {
            _computer.Add("Dell processor");
        }

        public void BuildSoundCard()
        {
            _computer.Add("Dell sound card");
        }

        public void BuildTuner()
        {
            _computer.Add("Dell tuner");
        }

        public void BuildVideoCard()
        {
            _computer.Add("Dell video card");
        }

        public Computer GetProduct()
        {
            return _computer;
        }

        public void Reset()
        {
            _computer = new Computer();
        }
    }

    public class SonyBuilder : IBuilder
    {
        private Computer _computer;

        public SonyBuilder()
        {
            _computer = new Computer();
        }

        public void BuildMainboard()
        {
            _computer.Add("Sony mainboard");
        }

        public void BuildProcessor()
        {
            _computer.Add("Sony processor");
        }

        public void BuildSoundCard()
        {
            _computer.Add("Sony sound card");
        }

        public void BuildTuner()
        {
            _computer.Add("Sony tuner");
        }

        public void BuildVideoCard()
        {
            _computer.Add("Sony video card");
        }

        public Computer GetProduct()
        {
            return _computer;
        }

        public void Reset()
        {
            _computer = new Computer();
        }
    }

    public class Computer
    {
        private List<object> _parts;

        public Computer()
        {
            _parts = new List<object>();
        }

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public string GetParts()
        {
            string parts = "";

            foreach(var part in _parts)
            {
                parts += part.ToString();
                parts += ", ";
            }
            parts = parts.Remove(parts.Length - 2);
            return parts;
        }
    }

    public class Director
    {
        private IBuilder _builder;

        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        public void BuildBasicKit()
        {
            _builder.BuildMainboard();
            _builder.BuildProcessor();
        }

        public void BuildStandardKit()
        {
            BuildBasicKit();
            _builder.BuildVideoCard();
        }

        public void BuildStandardPlusKit()
        {
            BuildStandardKit();
            _builder.BuildSoundCard();
        }

        public void BuildLuxKit()
        {
            BuildStandardPlusKit();
            _builder.BuildTuner();
        }

        public Computer GetProduct()
        {
            Computer product = _builder.GetProduct();
            _builder.Reset();
            return product;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(new DellBuilder());

            director.BuildBasicKit();
            Console.WriteLine($"Dell basic kit:\n{director.GetProduct().GetParts()}");
            director.BuildStandardKit();
            Console.WriteLine($"Dell standard kit:\n{director.GetProduct().GetParts()}");
            director.BuildStandardPlusKit();
            Console.WriteLine($"Dell standard plus kit:\n{director.GetProduct().GetParts()}");
            director.BuildLuxKit();
            Console.WriteLine($"Dell lux kit:\n{director.GetProduct().GetParts()}");

            Console.WriteLine();

            director = new Director(new SonyBuilder());

            director.BuildBasicKit();
            Console.WriteLine($"Sony basic kit:\n{director.GetProduct().GetParts()}");
            director.BuildStandardKit();
            Console.WriteLine($"Sony standard kit:\n{director.GetProduct().GetParts()}");
            director.BuildStandardPlusKit();
            Console.WriteLine($"Sony standard plus kit:\n{director.GetProduct().GetParts()}");
            director.BuildLuxKit();
            Console.WriteLine($"Sony lux kit:\n{director.GetProduct().GetParts()}");

            Console.ReadLine();
        }
    }
}
