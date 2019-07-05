using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface ISouvenir
    {
        string GetName();
        int GetWeight();
    }

    public class Statuette : ISouvenir
    {
        public string GetName()
        {
            return "Statuette";
        }

        public int GetWeight()
        {
            return 500;
        }
    }

    public class Photoframe : ISouvenir
    {
        public string GetName()
        {
            return "Photoframe";
        }

        public int GetWeight()
        {
            return 300;
        }
    }

    public abstract class Addition : ISouvenir
    {
        protected ISouvenir _souvenir;

        public Addition(ISouvenir souvenir)
        {
            _souvenir = souvenir;
        }

        public abstract string GetName();

        public abstract int GetWeight();
    }

    public class Stand : Addition
    {
        public Stand(ISouvenir souvenir) : base(souvenir)
        {

        }

        public override string GetName()
        {
            return $"{_souvenir.GetName()} + stand";
        }

        public override int GetWeight()
        {
            return _souvenir.GetWeight() + 150;
        }
    }

    public class Backlight : Addition
    {
        public Backlight(ISouvenir souvenir) : base(souvenir)
        {

        }

        public override string GetName()
        {
            return $"{_souvenir.GetName()} + backlight";
        }

        public override int GetWeight()
        {
            return _souvenir.GetWeight() + 100;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Statuette statuette = new Statuette();
            Stand stand = new Stand(statuette);
            Console.WriteLine($"{stand.GetName()}: {stand.GetWeight()} g");

            Photoframe frame = new Photoframe();
            Stand stand2 = new Stand(frame);
            Console.WriteLine($"{stand2.GetName()}: {stand2.GetWeight()} g");

            Photoframe frame2 = new Photoframe();
            Stand stand3 = new Stand(frame2);
            Backlight backlight = new Backlight(stand3);
            Console.WriteLine($"{backlight.GetName()}: {backlight.GetWeight()} g");

            Console.ReadLine();
        }
    }
}
